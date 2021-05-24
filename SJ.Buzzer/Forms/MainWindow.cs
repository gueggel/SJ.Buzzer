/*!
 * ========================================================================
 * @project    SJ.Buzzer
 *
 * Hauptfenster
 *
 * @file       MainWindow.cs
 * @author     Stefan Jahn <development@stefanjahn.de>
 * @copyright  Copyright (C) 2012-2021 Stefan Jahn
 * @link       https://stefanjahn.de
 *
 * @date       20.04.2012 21:58
 * @version    20210524
 * @license    http://www.gnu.org/copyleft/gpl.html
 * ------------------------------------------------------------------------
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * ========================================================================
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using SharpDX.XAudio2;

using SJ.App.Buzzer.Controls;
using SJ.App.Buzzer.Helper;

namespace SJ.App.Buzzer
{
    /// <summary>
    /// Hauptfenster
    /// </summary>
    public partial class MainWindow : Form
    {
        #region Attribute

        /// <summary>
        /// Audio-Device
        /// </summary>
        private XAudio2 _AudioDevice;

        #endregion


        #region Properties

        /// <summary>
        /// Audio: Device
        /// </summary>
        private XAudio2 AudioDevice
        {
            get
            {
                return _AudioDevice;
            }
            set
            {
                _AudioDevice = value;
                MasterVoice = new MasteringVoice(value);
            }
        }

        /// <summary>
        /// Audio: Hauptkanal fuer die Ausgabe.
        /// </summary>
        private MasteringVoice MasterVoice
        {
            get;
            set;
        }

        /// <summary>
        /// Ausgabe: Gewuenschte Sprache.
        /// </summary>
        public string SetLanguage
        {
            get;
            private set;
        }

        /// <summary>
        /// Letzter State des Windows (Fullscreen oder Normal)
        /// </summary>
        private FormWindowState LastWindowState
        {
            get;
            set;
        }

        /// <summary>
        /// True = Buzzer-Devuce #1 oder #2 im Menue ausgewaehlt.
        /// </summary>
        private bool BuzzerDeviceAvailabe => !menuBuzzer1None.Checked || !menuBuzzer2None.Checked;

        /// <summary>
        /// Liste mit den Controls (UI) des Buzzer-Device #1
        /// </summary>
        private Dictionary<BuzzerNumber, BuzzerUI> ListBuzzer1UI
        {
            get;
            set;
        }

        /// <summary>
        /// Liste mit den Controls (UI) des Buzzer-Device #2
        /// </summary>
        private Dictionary<BuzzerNumber, BuzzerUI> ListBuzzer2UI
        {
            get;
            set;
        }

        /// <summary>
        /// True = Buzzer in verkehrter Reihenfolge abfragen.
        /// </summary>
        private bool PollReverse
        {
            get;
            set;
        }


        /// <summary>
        /// Timer fuer die Abfrage des Buzzers.
        /// </summary>
        private System.Windows.Forms.Timer PollBuzzerTimer
        {
            get;
            set;
        }


        /// <summary>
        /// Countdown: Timer
        /// </summary>
        private System.Windows.Forms.Timer CountdownTimer
        {
            get;
            set;
        }


        /// <summary>
        /// Countdown: Hoehe des Countdowns, Sekunden
        /// </summary>
        private int CountdownMax
        {
            get;
            set;
        }


        /// <summary>
        /// Countdown: AKtuelle Zeit des Countdown, Sekunden
        /// </summary>
        private int CountdownCurrent
        {
            get;
            set;
        }


        /// <summary>
        /// Buzzer-Device #1
        /// </summary>
        private BuzzerDevice BuzzerDevice1
        {
            get;
            set;
        }


        /// <summary>
        /// Buzzer-Device #2
        /// </summary>
        private BuzzerDevice BuzzerDevice2
        {
            get;
            set;
        }


        /// <summary>
        /// Liste mit den Namen der Devices.
        /// </summary>
        private Dictionary<Guid, string> ListDevices
        {
            get;
            set;
        }

        /// <summary>
        /// Liste mit den Buttons eines Buzzers.
        /// </summary>
        private List<BuzzerNumber> ListBuzzerNumbers
        {
            get;
            set;
        }

        private Dictionary<Soundfile, Sound> ListSounds
        {
            get;
            set;
        }

        #endregion


        #region Konstruktor

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            ListBuzzerNumbers = new List<BuzzerNumber>
            {
                BuzzerNumber.One,
                BuzzerNumber.Two,
                BuzzerNumber.Three,
                BuzzerNumber.Four
            };


            PollReverse = false;
            LastWindowState = WindowState;
            SetLanguage = string.Empty;

            InitializeSounds();
            InitializeBuzzerDevice1();
            InitializeBuzzerDevice2();
            InitializeBuzzerTimer();
            InitializeMenu();
            InitializePlayerNames();
            InitializeCountdown();
            HideShowBuzzer();
            ResetMenuAndButtons();
            StartStopCountdown( true );
            InitializeWindowSize();
        }


        #endregion


        #region Destruktor

        /// <summary>
        /// Destruktor
        /// </summary>
        ~MainWindow()
        {
        }


        #endregion


        #region Methoden, Initialize

        /// <summary>
        /// Sounddateien einrichten.
        /// </summary>
        private void InitializeSounds()
        {
            AudioDevice = new XAudio2();

            ListSounds = new Dictionary<Soundfile, Sound>
            {
                { Soundfile.Applause, new Sound( AudioDevice, Resources.Sounds.Applause ) },
                { Soundfile.BuzzerPressed, new Sound( AudioDevice, Resources.Sounds.BuzzerPressed ) },
                { Soundfile.CorrectAnswer, new Sound( AudioDevice, Resources.Sounds.CorrectAnswer ) },
                { Soundfile.Dramatic, new Sound( AudioDevice, Resources.Sounds.Dramatic ) },
                { Soundfile.Fanfare, new Sound( AudioDevice, Resources.Sounds.Fanfare ) },
                { Soundfile.Intro, new Sound( AudioDevice, Resources.Sounds.Intro ) },
                { Soundfile.ButtonClick, new Sound( AudioDevice, Resources.Sounds.ButtonClick ) },
                { Soundfile.TickTack, new Sound( AudioDevice, Resources.Sounds.TickTack ) },
                { Soundfile.WrongAnswer, new Sound( AudioDevice, Resources.Sounds.WrongAnswer ) }
            };
        }


        /// <summary>
        /// Urspruengliche Fenstergroesse wieder einstellen.
        /// </summary>
        private void InitializeWindowSize()
        {
            int width = Properties.Settings.Default.WindowSize.Width;
            int height = Properties.Settings.Default.WindowSize.Height;

            //Pruefen ob Fenstergroesse kleiner als Bildschirmgroesse ist
            if( width > Screen.PrimaryScreen.Bounds.Width )
            {
                width = Screen.PrimaryScreen.Bounds.Width - 10;
            }

            if( height > Screen.PrimaryScreen.Bounds.Height )
            {
                height = Screen.PrimaryScreen.Bounds.Height - 10;
            }

            try
            {
                Size = new Size( width, height );
                SetFontSize();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Menue einstellen.
        /// </summary>
        private void InitializeMenu()
        {
            menuBuzzer1None.Checked = true;
            menuBuzzer2None.Checked = true;
            menuSetupSoundButtonStopCountdown.Checked = Properties.Settings.Default.SoundButtonStopCountdown;

            string language = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            menuLanguageGerman.Checked = string.Equals( language, "de", StringComparison.InvariantCultureIgnoreCase );
            menuLanguageEnglish.Checked = !menuLanguageGerman.Checked;
        }

        /// <summary>
        /// Buzzers des Device #1 einrichten.
        /// </summary>
        private void InitializeBuzzerDevice1()
        {
            ListBuzzer1UI = new Dictionary<BuzzerNumber, BuzzerUI>
            {
                { BuzzerNumber.One, ctrlBuzzer1 },
                { BuzzerNumber.Two, ctrlBuzzer2 },
                { BuzzerNumber.Three, ctrlBuzzer3 },
                { BuzzerNumber.Four, ctrlBuzzer4 }
            };

            //Farben einstellen
            foreach( BuzzerUI item in ListBuzzer1UI.Values )
            {
                item.ColorBuzzer = Properties.Settings.Default.ColorBuzzer;
                item.ColorBlue = Properties.Settings.Default.ColorButtonBlue;
                item.ColorOrange = Properties.Settings.Default.ColorButtonOrange;
                item.ColorGreen = Properties.Settings.Default.ColorButtonGreen;
                item.ColorYellow = Properties.Settings.Default.ColorButtonYellow;
                item.ColorButtonPressed = Properties.Settings.Default.ColorButtonPressed;
                item.ColorBuzzerPressed = Properties.Settings.Default.ColorBuzzerPressed;
            }

            //Event verbinden
            BuzzerDevice1 = new BuzzerDevice();
            BuzzerDevice1.ButtonPressed += new EventButtonPressed( Buzzer1_DrawButton );

            //Verfuegbare Devices speichern
            ListDevices = BuzzerDevice1.ListDevices;
        }


        /// <summary>
        /// Buzzers des Device #2 einrichten.
        /// </summary>
        private void InitializeBuzzerDevice2()
        {
            ListBuzzer2UI = new Dictionary<BuzzerNumber, BuzzerUI>
            {
                { BuzzerNumber.One, ctrlBuzzer5 },
                { BuzzerNumber.Two, ctrlBuzzer6 },
                { BuzzerNumber.Three, ctrlBuzzer7 },
                { BuzzerNumber.Four, ctrlBuzzer8 }
            };

            //Farben einstellen
            foreach( BuzzerUI item in ListBuzzer2UI.Values )
            {
                item.ColorBuzzer = Properties.Settings.Default.ColorBuzzer;
                item.ColorBlue = Properties.Settings.Default.ColorButtonBlue;
                item.ColorOrange = Properties.Settings.Default.ColorButtonOrange;
                item.ColorGreen = Properties.Settings.Default.ColorButtonGreen;
                item.ColorYellow = Properties.Settings.Default.ColorButtonYellow;
                item.ColorButtonPressed = Properties.Settings.Default.ColorButtonPressed;
                item.ColorBuzzerPressed = Properties.Settings.Default.ColorBuzzerPressed;
            }

            //Event verbinden
            BuzzerDevice2 = new BuzzerDevice();
            BuzzerDevice2.ButtonPressed += new EventButtonPressed( Buzzer2_DrawButton );
        }


        /// <summary>
        /// Spieler-Namen einrichten.
        /// </summary>
        private void InitializePlayerNames()
        {
            lblPlayer1.Text = string.Format( System.Globalization.CultureInfo.CurrentCulture, Resources.Language.DefaultPlayerName, 1 );
            lblPlayer2.Text = string.Format( System.Globalization.CultureInfo.CurrentCulture, Resources.Language.DefaultPlayerName, 2 );
            lblPlayer3.Text = string.Format( System.Globalization.CultureInfo.CurrentCulture, Resources.Language.DefaultPlayerName, 3 );
            lblPlayer4.Text = string.Format( System.Globalization.CultureInfo.CurrentCulture, Resources.Language.DefaultPlayerName, 4 );
            lblPlayer5.Text = string.Format( System.Globalization.CultureInfo.CurrentCulture, Resources.Language.DefaultPlayerName, 5 );
            lblPlayer6.Text = string.Format( System.Globalization.CultureInfo.CurrentCulture, Resources.Language.DefaultPlayerName, 6 );
            lblPlayer7.Text = string.Format( System.Globalization.CultureInfo.CurrentCulture, Resources.Language.DefaultPlayerName, 7 );
            lblPlayer8.Text = string.Format( System.Globalization.CultureInfo.CurrentCulture, Resources.Language.DefaultPlayerName, 8 );
        }

        /// <summary>
        /// Timer fuer die Abfrage der Buzzers-Devices einrichten.
        /// </summary>
        private void InitializeBuzzerTimer()
        {
            PollBuzzerTimer = new System.Windows.Forms.Timer
            {
                Interval = Properties.Settings.Default.TimerPollBuzzer
            };

            PollBuzzerTimer.Tick += new EventHandler( PollBuzzer_Tick );
            PollBuzzerTimer.Start();
        }

        /// <summary>
        /// Countdown einrichten.
        /// </summary>
        private void InitializeCountdown()
        {
            CountdownTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };
            CountdownTimer.Tick += new EventHandler( CountdownTimer_Tick );
            CountdownTimer.Stop();

            CountdownMax = Properties.Settings.Default.CountdownMax;
            CountdownCurrent = 0;
        }

        #endregion


        #region Methoden

        /// <summary>
        /// Alle Sounds beenden.
        /// </summary>
        private void SoundStop()
        {
            foreach( Soundfile key in ListSounds.Keys )
            {
                if( key != Soundfile.TickTack )
                {
                    ListSounds[key].Stop();
                }                
            }
        }


        /// <summary>
        /// Programm beenden
        /// </summary>
        private void Quit()
        {
            Enabled = false;

            PollBuzzerTimer?.Stop();
            CountdownTimer?.Stop();

            PollBuzzerTimer?.Dispose();
            CountdownTimer?.Dispose();
            BuzzerDevice1?.Dispose();
            BuzzerDevice2?.Dispose();

            foreach( Sound itemSound in ListSounds.Values )
            {
                itemSound?.Dispose();
            }

            MasterVoice?.Dispose();
            AudioDevice?.Dispose();

            Close();
        }

        /// <summary>
        /// Textgroesse aller Controls anpassen.
        /// </summary>
        private void SetFontSize()
        {
            try
            {
                Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                SuspendLayout();

                //Als Grundlage fuer die Textgroesse die minimale Hoehe oder Breite des Fensters nehmen.
                float value = Height;

                if( value > Width )
                {
                    value = Width;
                }

                //Textgroesse berechnen
                float size = value/42f;

                //Verhindern das Textgroesse zu klein wird
                if( size < 12 )
                {
                    size = 12;
                }

                //Alle Controls durchgehen
                foreach( Control ctrl in Controls )
                {
                    SetFontsizeOfControl( ctrl, size );
                    SetFontSize( ctrl, size );
                }

                //Zeilenhoehe mit den Spielernamen anpassen
                //AutoSize funktioniert nicht, beim Abwaehlen des Device #2 wird die Zeile viel zu gross dargestellt.
                tlMain.RowStyles[0].SizeType = SizeType.Absolute;
                tlMain.RowStyles[0].Height = size / 0.5f + lblPlayer1.Padding.Top + lblPlayer1.Padding.Bottom; //TODO: Korrekte Umrechnung von Point zu Pixel?
            }
            finally
            {
                ResumeLayout( true );
                Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Textgroesse aller Controls anpassen. (Rekursive Methode)
        /// </summary>
        /// <param name="ctrl">Control</param>
        /// <param name="size">Textgroesse</param>
        private void SetFontSize( Control control, float size )
        {
            //Textgroessen des Controls BuzzerUI nicht anpassen
            if( string.Equals( control.Name, "BuzzerUI", StringComparison.InvariantCultureIgnoreCase ) )
            {
                return;
            }

            //Alle Controls durchgehen
            foreach( Control ctrl in control.Controls )
            {
                SetFontsizeOfControl( ctrl, size );
                SetFontSize( ctrl, size );
            }
        }

        /// <summary>
        /// Textgroesse eines Controls setzen.
        /// </summary>
        /// <param name="ctrl">Control</param>
        /// <param name="size">Textgroesse</param>
        private void SetFontsizeOfControl( Control ctrl, float size )
        {
            Button button = ctrl as Button;

            //Textgroesse von GroupBox etwas kleiner darstellen
            if( ctrl is GroupBox )
            {
                ctrl.Font = new Font( ctrl.Font.FontFamily, size / 4f * 3f );
            }

            //Buttons mit Bildern speziell behandeln
            if( button != null && button.Image != null )
            {
                //Neue Bildgroesse festlegen
                int imgSize = (int)size;

                //Verhindern das Bild zu klein wird
                if( imgSize < 16 )
                {
                    imgSize = 16;
                }

                //Im Tag des Buttons steht der Ressourcenname des Bildes
                string imgName = button.Tag as string;

                //An Hand des Namen das Bild aus den Ressourcen laden und Groesse anpassen
                if( !string.IsNullOrWhiteSpace( imgName ) )
                {
                    Image imgSource = Properties.Resources.ResourceManager.GetObject( imgName ) as Image;

                    if( imgSource != null )
                    {
                        button.Image = new Bitmap( imgSource, imgSize, imgSize );
                    }
                }
            }

            if( ctrl is Label || ctrl is Button )
            {
                ctrl.Font = new Font( ctrl.Font.FontFamily, size );
            }
        }

        /// <summary>
        /// Einstellungen speichern.
        /// </summary>
        private void SaveSettings()
        {
            try
            {
                Properties.Settings.Default.CountdownMax = CountdownMax;
                Properties.Settings.Default.Player1 = lblPlayer1.Text;
                Properties.Settings.Default.Player2 = lblPlayer2.Text;
                Properties.Settings.Default.Player3 = lblPlayer3.Text;
                Properties.Settings.Default.Player4 = lblPlayer4.Text;
                Properties.Settings.Default.Player5 = lblPlayer5.Text;
                Properties.Settings.Default.Player6 = lblPlayer6.Text;
                Properties.Settings.Default.Player7 = lblPlayer7.Text;
                Properties.Settings.Default.Player8 = lblPlayer8.Text;
                Properties.Settings.Default.SoundButtonStopCountdown = menuSetupSoundButtonStopCountdown.Checked;
                Properties.Settings.Default.EndCountdownStartBuzzer = menuSetupEndCountdownStartBuzzer.Checked;
                Properties.Settings.Default.WindowSize = Size;

                Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }


        /// <summary>
        /// Vollbild an/aus
        /// </summary>
        private void ToggleFullscreen()
        {
            if( WindowState == FormWindowState.Maximized )
            {
                TopMost = false;
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                msMain.Visible = true;
                SetFontSize();

                return;
            }

            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            msMain.Visible = false;

            BringToFront(); //Notwendig da ansonsten die Taskleiste noch sichtbar ist.
            Focus();

            WindowState = FormWindowState.Maximized;
            SetFontSize();
        }


        /// <summary>
        /// Menu und Buttons zuruecksetzen.
        /// </summary>
        private void ResetMenuAndButtons()
        {
            btnStartBuzzer.Enabled = true && BuzzerDeviceAvailabe;
            btnStartSelector.Enabled = true && BuzzerDeviceAvailabe;
            btnClear.Enabled = false;

            menuQueryBuzzer.Enabled = true && BuzzerDeviceAvailabe;
            menuQuerySelector.Enabled = true && BuzzerDeviceAvailabe;
            menuQueryReset.Enabled = false;
        }


        /// <summary>
        /// Buzzers je nach Anzahl der aktiven Controller ein-/ausblenden.
        /// </summary>
        private void HideShowBuzzer()
        {
            SuspendLayout();

            //Ist 2. Buzzer-Controller angeschlossen, so zusaetzliche Spalten im WIndow anzeigen            
            ListBuzzer2UI[BuzzerNumber.One].Visible = ( !menuBuzzer2None.Checked );
            ListBuzzer2UI[BuzzerNumber.Two].Visible = ( !menuBuzzer2None.Checked );
            ListBuzzer2UI[BuzzerNumber.Three].Visible = ( !menuBuzzer2None.Checked );
            ListBuzzer2UI[BuzzerNumber.Four].Visible = ( !menuBuzzer2None.Checked );

            //Pruefen ob 2. Buzzer-Controller im Menue nicht ausgewaehlt/aktiv ist
            if( !menuBuzzer2None.Checked )
            {
                for( int i = 0; i < tlMain.ColumnStyles.Count; i++ )
                {
                    //Spaltenbreite (%) fuer 8 Buzzers
                    tlMain.ColumnStyles[i].Width = 12.5f;
                }
            }
            else
            {
                for( int i = 0; i < tlMain.ColumnStyles.Count; i++ )
                {
                    if( i > 3 )
                    {
                        //Spaltenbreite des 2. Buzzer-Controller auf 0 setzen (Spalten verstecken)
                        tlMain.ColumnStyles[i].Width = 0;
                    }
                    else
                    {
                        //Spaltenbreite (%) fuer 4 Buzzers
                        tlMain.ColumnStyles[i].Width = 25f;
                    }
                }
            }

            ResumeLayout( true );
        }


        /// <summary>
        /// Verfuegbare Controller im Menue auflisten.
        /// </summary>
        /// <param name="menuSeparator">Menuetrenner</param>
        /// <param name="menuNone">Menueeintrag "Keine Auswahl"</param>
        /// <param name="menuSetupBuzzer">Dropdownmenue fuer die Auswahl des Buzzers</param>
        /// <param name="device">Device</param>
        private void ListAllControllers( ToolStripSeparator menuSeparator, ToolStripMenuItem menuNone, ToolStripMenuItem menuSetupBuzzer, BuzzerDevice device )
        {
            menuSetupBuzzer.DropDownItems.Clear();

            //Liste der verfuegbaren Controller (alle Hoysticks, egal welcher Art) durchgehen
            foreach( Guid instanceGuid in ListDevices.Keys )
            {
                ToolStripMenuItem item = new ToolStripMenuItem(ListDevices[instanceGuid])
                {
                    Checked = (device.SelectedController == instanceGuid),
                    CheckOnClick = false,
                    Tag = instanceGuid // Instance GUID des Controllers im Menue-Eintrag speichern
                };

                //Eventhandler mit dem entsprechenden Buzzer-Controller (1 oder 2) verbinden
                if( device == BuzzerDevice2 )
                {
                    item.Click += new EventHandler( MenuBuzzer2Setup_Click );
                }
                else
                {
                    item.Click += new EventHandler( MenuBuzzer1Setup_Click );
                }

                menuSetupBuzzer.DropDownItems.Add( item );
            }

            menuSetupBuzzer.DropDownItems.Add( menuSeparator );
            menuSetupBuzzer.DropDownItems.Add( menuNone );
        }


        /// <summary>
        /// Device als Buzzer einstellen.
        /// </summary>
        /// <param name="selectedMenuItem">Menueeintrag des Device</param>
        /// <param name="menuNone">Menueeintrag "Keine Auswahl"</param>
        /// <param name="device">Device</param>
        private void SetupBuzzerDevice( object selectedMenuItem, ToolStripMenuItem menuNone, BuzzerDevice device )
        {
            ToolStripMenuItem menu = selectedMenuItem as ToolStripMenuItem;

            if( menu == null )
            {
                device.SelectedController = Guid.Empty;
                menuNone.Checked = true;
            }
            else
            {
                device.SelectedController = (Guid)menu.Tag; //Menu-Eintrag enthaelt die Instance GUID des Controllers.
                menu.Checked = true;
                menuNone.Checked = false;
            }

            ResetMenuAndButtons();
            HideShowBuzzer();
        }


        /// <summary>
        /// Auswahl Contoller des Buzzers aufheben.
        /// </summary>
        /// <param name="collection">Menueiste mit den Devices</param>
        /// <param name="menuNone">Menueeintrag "Keine Auswahl"</param>
        /// <param name="device">Device</param>
        private void SetupBuzzerDeviceNone( ToolStripItemCollection collection, ToolStripMenuItem menuNone, BuzzerDevice device )
        {
            //Alle Devices im Menue durchgehen und Markierung entfernen
            for( int i = 0; i < collection.Count - 2; i++ )
            {
                ( (ToolStripMenuItem)collection[i] ).Checked = false;
            }

            device.SelectedController = Guid.Empty;
            menuNone.Checked = true;

            ResetMenuAndButtons();
            HideShowBuzzer();
        }


        /// <summary>
        /// Alle Buzzer zurueckstellen.
        /// </summary>
        private void ResetBuzzers()
        {
            foreach( BuzzerNumber number in ListBuzzerNumbers )
            {
                ListBuzzer1UI[number].Reset();
                ListBuzzer2UI[number].Reset();
            }
        }


        /// <summary>
        /// Abfrage nach Buzzer starten.
        /// </summary>
        private void StartQueryBuzzer()
        {
            if( !BuzzerDeviceAvailabe )
            {
                return;
            }

            ResetMenuAndButtons();
            ResetBuzzers();

            //Buttons ein-/ausschalten
            btnStartBuzzer.Enabled = false;
            btnClear.Enabled = true;
            menuQueryBuzzer.Enabled = false;
            menuQueryReset.Enabled = true;

            //Abfrage/Spielemodus starten
            BuzzerDevice1.WaitForBuzzer();
            BuzzerDevice2.WaitForBuzzer();
        }


        /// <summary>
        /// Abfrage nach Auswahlbutton starten.
        /// </summary>
        private void StartQuerySelector()
        {
            if( !BuzzerDeviceAvailabe )
            {
                return;
            }

            ResetMenuAndButtons();
            ResetBuzzers();

            //Buttons ein-/ausschalten
            btnStartSelector.Enabled = false;
            btnClear.Enabled = true;
            menuQuerySelector.Enabled = false;
            menuQueryReset.Enabled = true;

            //Abfrage/Spielemodus starten
            BuzzerDevice1.WaitForButton();
            BuzzerDevice2.WaitForButton();
        }


        /// <summary>
        /// Abfrage zuruecksetzen.
        /// </summary>
        private void ResetQuery()
        {
            ResetMenuAndButtons();
            ResetBuzzers();

            //Abfrage/Spielemodus beenden
            BuzzerDevice1.ResetWait();
            BuzzerDevice2.ResetWait();
        }


        /// <summary>
        /// Countdown start/stopp.
        /// </summary>
        /// <param name="stop">True = Stoppen erzwingen</param>
        private void StartStopCountdown( bool stop )
        {
            //Zeit einstellen und Anzeige erneuern
            CountdownCurrent = CountdownMax;
            TimeSpan time = new TimeSpan(0, 0, CountdownCurrent);
            lblTimer.Text = time.Minutes.ToString( "00" ) + ":" + time.Seconds.ToString( "00" );
            barTimer.Maximum = CountdownMax;
            barTimer.Value = 0;

            //Pruefen ob Countdown gestoppt werden soll
            if( CountdownTimer.Enabled || stop )
            {
                //Countdown beenden
                ListSounds[Soundfile.TickTack].Stop();
                CountdownTimer.Stop();
                btnTimerStartStop.Text = Resources.Language.QueryStart;
                btnTimerStartStop.Image = Properties.Resources.player_play;
            }
            else
            {
                //Countdown starten
                ListSounds[Soundfile.TickTack].PlayLoop();
                CountdownTimer.Start();
                btnTimerStartStop.Text = Resources.Language.QueryStop;
                btnTimerStartStop.Image = Properties.Resources.player_stop;
            }
        }


        /// <summary>
        /// Countdown 1 Sekunde abgelaufen.
        /// </summary>
        private void CountdownTick()
        {
            //Countdown herunterzaehlen
            CountdownCurrent--;

            //Fortschrittsleiste des Countdown anpassen
            if( CountdownCurrent >= 0 )
            {
                barTimer.Value = CountdownMax - CountdownCurrent;
            }

            //Pruefen ob Countdown abgelaufen ist
            if( CountdownCurrent < 0 )
            {
                ListSounds[Soundfile.TickTack].Stop();
                ListSounds[Soundfile.WrongAnswer].Play();
                CountdownTimer.Stop();
                btnTimerStartStop.Text = Resources.Language.QueryStart;
                btnTimerStartStop.Image = Properties.Resources.player_play;
                CountdownCurrent = 0;

                //Nach Ablauf Buzzer abfragen
                if( menuSetupEndCountdownStartBuzzer.Checked )
                {
                    StartQueryBuzzer();
                }
            }

            //Timer und Anzeige zuruecksetzen
            TimeSpan time = new TimeSpan(0, 0, CountdownCurrent);
            lblTimer.Text = time.Minutes.ToString( "00" ) + ":" + time.Seconds.ToString( "00" );
        }


        /// <summary>
        /// Countdown einstellen.
        /// </summary>
        private void SetupCountdown()
        {

            if( DisplayQuestion.Show( Text, Resources.Language.SetupCountdown, 3, out string input, CountdownMax.ToString() ) != DialogResult.OK )
            {
                return;
            }

            try
            {
                CountdownMax = int.Parse( input );

                if( CountdownMax < 10 )
                {
                    CountdownMax = 10;
                }

                if( CountdownMax > 600 )
                {
                    CountdownMax = 600;
                }
            }
            catch
            {
                CountdownMax = 180;
            }

            StartStopCountdown( true );
        }


        /// <summary>
        /// Info anzeigen.
        /// </summary>
        private void ShowInfo()
        {
            About about = null;

            try
            {
                about = new About(
                    Text,
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                    Resources.Language.About,
                    Resources.Language.Licence,
                    Properties.Resources.ledred_big
                    );

                about.ShowDialog();
            }
            catch
            {
            }
            finally
            {
                about?.Dispose();
            }
        }


        /// <summary>
        /// Spielername einstellen.
        /// </summary>
        /// <param name="lblPlayer">Label</param>
        private void SetupPlayer( Label lblPlayer )
        {
            if( TopMost )
            {
                return;
            }

            string text = lblPlayer.Text;
            int id = 0;

            //ID je nach gewaehltem Spieler-Label ermitteln
            if( lblPlayer == lblPlayer1 )
            {
                id = 1;
            }

            else if( lblPlayer == lblPlayer2 )
            {
                id = 2;
            }

            else if( lblPlayer == lblPlayer3 )
            {
                id = 3;
            }

            else if( lblPlayer == lblPlayer4 )
            {
                id = 4;
            }

            else if( lblPlayer == lblPlayer5 )
            {
                id = 5;
            }

            else if( lblPlayer == lblPlayer6 )
            {
                id = 6;
            }

            else if( lblPlayer == lblPlayer7 )
            {
                id = 7;
            }

            else if( lblPlayer == lblPlayer8 )
            {
                id = 8;
            }

            string message = string.Format(System.Globalization.CultureInfo.CurrentCulture,Resources.Language.SetupPlayerQuestion,id);
            string defaultName = string.Format(System.Globalization.CultureInfo.CurrentCulture,Resources.Language.SetupPlayerName,id);

            if( DisplayQuestion.Show( Text, message, 40, out string input, text ) != DialogResult.OK )
            {
                return;
            }

            input = input.Trim();

            if( input == string.Empty )
            {
                input = defaultName;
            }

            lblPlayer.Text = input;
        }


        /// <summary>
        /// Sprache aendern.
        /// </summary>
        /// <param name="language">Gewuenschte Sprache (de, en)</param>
        private void ChangeLanguage( string language )
        {
            SetLanguage = language;
            Quit();
        }

        #endregion


        #region Events

        /// <summary>
        /// Button auf dem Buzzer-Controller #1 zeichnen.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="buzzerNumber">Nummer des Buzzers</param>
        /// <param name="buzzerButton">Nummer des Buttons</param>
        /// <param name="isPressed">True = Button wird gedrueckt</param>
        /// <param name="buzzerFound">True = Erster Buzzer wurde gedrueckt</param>
        /// <param name="buttonFound">True = Erster Button eines Buzzers wurde gedrueckt</param>
        private void Buzzer1_DrawButton( object sender, BuzzerNumber buzzerNumber, BuzzerButton buzzerButton, bool isPressed, bool buzzerFound, bool buttonFound )
        {
            if( buzzerButton == BuzzerButton.Buzzer )
            {
                ListBuzzer1UI[buzzerNumber].SetBuzzer( isPressed );
            }
            else
            {
                ListBuzzer1UI[buzzerNumber].SetButton( buzzerButton, isPressed );
            }
        }


        /// <summary>
        /// Button auf dem Buzzer #2 zeichnen.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="buzzerNumber">Nummer des Buzzers</param>
        /// <param name="buzzerButton">Nummer des Buttons</param>
        /// <param name="isPressed">True = Button wird gedrueckt</param>
        /// <param name="buzzerFound">True = Erster Buzzer wurde gedrueckt</param>
        /// <param name="buttonFound">True = Erster Button eines Buzzers wurde gedrueckt</param>
        private void Buzzer2_DrawButton( object sender, BuzzerNumber buzzerNumber, BuzzerButton buzzerButton, bool isPressed, bool buzzerFound, bool buttonFound )
        {
            if( buzzerButton == BuzzerButton.Buzzer )
            {
                ListBuzzer2UI[buzzerNumber].SetBuzzer( isPressed );
            }
            else
            {
                ListBuzzer2UI[buzzerNumber].SetButton( buzzerButton, isPressed );
            }
        }


        /// <summary>
        /// Fenstergroesse wurde geaendert.
        /// </summary>
        private void MainWindow_ResizeEnd( object sender, EventArgs e ) => SetFontSize();


        /// <summary>
        /// Menu: Programm beenden.
        /// </summary>
        private void MenuQuit_Click( object sender, EventArgs e ) => Quit();


        /// <summary>
        /// Buzzer abfragen.
        /// </summary>
        private void PollBuzzer_Tick( object sender, EventArgs e )
        {
            if( PollReverse )
            {
                BuzzerDevice2.Poll();
                BuzzerDevice1.Poll();
            }
            else
            {
                BuzzerDevice1.Poll();
                BuzzerDevice2.Poll();
            }

            PollReverse = !PollReverse;
        }


        /// <summary>
        /// Menu/Button: Abfrage des Buzzers starten.
        /// </summary>
        private void BtnStartBuzzer_Click( object sender, EventArgs e ) => StartQueryBuzzer();


        /// <summary>
        /// Menu/Button: Abfrage der Auswahlbuttons starten.
        /// </summary>
        private void BtnStartSelector_Click( object sender, EventArgs e ) => StartQuerySelector();


        /// <summary>
        /// Menu/Button: Abfrage zuruecksetzen.
        /// </summary>
        private void BtnClear_Click( object sender, EventArgs e ) => ResetQuery();


        /// <summary>
        /// Menu: Vollbild an/aus.
        /// </summary>
        private void MenuFullscreen_Click( object sender, EventArgs e ) => ToggleFullscreen();


        /// <summary>
        /// Button: Sound "Fanfare" abspielen.
        /// </summary>
        private void BtnSoundFanfare_Click( object sender, EventArgs e ) => ListSounds[Soundfile.Fanfare].Play();


        /// <summary>
        /// Button: Alle Sounds stoppen.
        /// </summary>
        private void BtnSoundStop_Click( object sender, EventArgs e ) => SoundStop();

        /// <summary>
        /// Button: Sound "Richtige Antwort" abspielen.
        /// </summary>
        private void BtnSoundCorrectAnswer_Click( object sender, EventArgs e )
        {
            ListSounds[Soundfile.CorrectAnswer].Play();

            if( menuSetupSoundButtonStopCountdown.Checked )
            {
                StartStopCountdown( true );
            }
        }


        /// <summary>
        /// Button: Sound "Falsche Antwort" abspielen.
        /// </summary>
        private void BtnSoundWrongAnswer_Click( object sender, EventArgs e )
        {
            ListSounds[Soundfile.WrongAnswer].Play();

            if( menuSetupSoundButtonStopCountdown.Checked )
            {
                StartStopCountdown( true );
            }
        }


        /// <summary>
        /// Button: Sound "Dramatik" abspielen.
        /// </summary>
        private void BtnSoundDramatic_Click( object sender, EventArgs e ) => ListSounds[Soundfile.Dramatic].Play();


        /// <summary>
        /// Button: Sound "Applaus" abspielen.
        /// </summary>
        private void BtnSoundApplause_Click( object sender, EventArgs e ) => ListSounds[Soundfile.Applause].Play();


        /// <summary>
        /// Button: Sound "Intro" abspielen.
        /// </summary>
        private void BtnSoundIntro_Click( object sender, EventArgs e ) => ListSounds[Soundfile.Intro].Play();


        /// <summary>
        /// Menu: Verfuegbare Buzzer #1 anzeigen.
        /// </summary>
        private void MenuBuzzer1_DropDownOpening( object sender, EventArgs e ) => ListAllControllers( menuBuzzer1Sep1, menuBuzzer1None, menuBuzzer1, BuzzerDevice1 );


        /// <summary>
        /// Menu: Verfuegbare Buzzer #2 anzeigen.
        /// </summary>
        private void MenuBuzzer2_DropDownOpening( object sender, EventArgs e ) => ListAllControllers( menuBuzzer2Sep1, menuBuzzer2None, menuBuzzer2, BuzzerDevice2 );


        /// <summary>
        /// Menu: Setup Buzzer #1
        /// </summary>
        private void MenuBuzzer1Setup_Click( object sender, EventArgs e ) => SetupBuzzerDevice( sender, menuBuzzer1None, BuzzerDevice1 );


        /// <summary>
        /// Menu: Setup Buzzer #2
        /// </summary>
        private void MenuBuzzer2Setup_Click( object sender, EventArgs e ) => SetupBuzzerDevice( sender, menuBuzzer2None, BuzzerDevice2 );


        /// <summary>
        /// Menu: Verfuegbare Buzzers neu einlesen.
        /// </summary>
        private void MenuReReadControllers_Click( object sender, EventArgs e ) => ListDevices = BuzzerDevice1.ListDevices;


        /// <summary>
        /// Menu: Auswahl Controller des Buzzer #1 aufheben.
        /// </summary>
        private void MenuBuzzer1None_Click( object sender, EventArgs e ) => SetupBuzzerDeviceNone( menuBuzzer1.DropDownItems, menuBuzzer1None, BuzzerDevice1 );


        /// <summary>
        /// Menu: Auswahl Controller des Buzzer #2 aufheben.
        /// </summary>
        private void MenuBuzzer2None_Click( object sender, EventArgs e ) => SetupBuzzerDeviceNone( menuBuzzer2.DropDownItems, menuBuzzer2None, BuzzerDevice2 );


        /// <summary>
        /// Countdown start/stopp.
        /// </summary>
        private void BtnTimerStartStop_Click( object sender, EventArgs e ) => StartStopCountdown( false );


        /// <summary>
        /// Countdown 1 Sekunde abgelaufen.
        /// </summary>
        private void CountdownTimer_Tick( object sender, EventArgs e ) => CountdownTick();


        /// <summary>
        /// Menu: Countdown einstellen.
        /// </summary>
        private void MenuSetupCountdown_Click( object sender, EventArgs e ) => SetupCountdown();


        /// <summary>
        /// Fenster wird geschlossen.
        /// </summary>
        private void MainWindow_FormClosing( object sender, FormClosingEventArgs e ) => SaveSettings();


        /// <summary>
        /// Menu: Info anzeigen.
        /// </summary>
        private void MenuInfo_Click( object sender, EventArgs e ) => ShowInfo();


        /// <summary>
        /// Label: Spielername einstellen.
        /// </summary>
        private void LblPlayer_Click( object sender, EventArgs e ) => SetupPlayer( (Label)sender );


        /// <summary>
        /// Button: Sound "Falsch" abspielen und Abfrage Buzzer neu starten.
        /// </summary>
        private void BtnSoundWrongAnswerRestart_Click( object sender, EventArgs e )
        {
            ListSounds[Soundfile.WrongAnswer].Play();

            if( menuSetupSoundButtonStopCountdown.Checked )
            {
                StartStopCountdown( true );
            }

            StartQueryBuzzer();
        }

        /// <summary>
        /// Event: Fenstergroesse wird angepasst.
        /// </summary>
        private void MainWindow_Resize( object sender, EventArgs e )
        {
            //Hat sich der WindowState geaendert?
            if( WindowState != LastWindowState )
            {
                LastWindowState = WindowState;

                if( WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Normal )
                {
                    SetFontSize();
                }
            }
        }


        /// <summary>
        /// Menu: Sprache aendern - Deutsch
        /// </summary>
        private void MenuLanguageGerman_Click( object sender, EventArgs e ) => ChangeLanguage( "de" );

        /// <summary>
        /// Menu: Sprache aendern - Englisch
        /// </summary>
        private void MenuLanguageEnglish_Click( object sender, EventArgs e ) => ChangeLanguage( "en" );

        #endregion
    }
}
