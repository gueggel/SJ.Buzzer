/*!
 * ========================================================================
 * @project    SJ.Buzzer
 *
 * Control: Darstellung eines Buzzers.
 *
 * @file       BuzzerUI.cs
 * @author     Stefan Jahn <development@stefanjahn.de>
 * @copyright  Copyright (C) 2012-2021 Stefan Jahn
 * @link       https://stefanjahn.de
 *
 * @date       21.05.2021
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

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SJ.App.Buzzer.Helper;

namespace SJ.App.Buzzer.Controls
{
    /// <summary>
    /// Control: Darstellung eines Buzzers.
    /// </summary>
    public partial class BuzzerUI : UserControl
    {
        #region Attribute

        /// <summary>
        /// Farbe: Buzzerbutton
        /// </summary>        
        private Color _ColorBuzzer;

        /// <summary>
        /// Nummer des Buzzers
        /// </summary>
        private byte _Number = 1;

        #endregion


        #region Properties

        /// <summary>
        /// Nummer des Buzzers
        /// </summary>
        [Category( "Setup" )]
        [DefaultValue( 1 )]
        public byte Number
        {
            get => _Number;
            set
            {
                _Number = value;
                lblNumber.Text = string.Format( System.Globalization.CultureInfo.CurrentCulture, "{0}", value );
            }
        }

        /// <summary>
        /// True = Buzzerbutton ist gedrueckt
        /// </summary>
        [Category( "Value" )]
        [DefaultValue( false )]
        public bool BuzzerPressed
        {
            get;
            private set;
        }

        /// <summary>
        /// Farbe: Blauer Button
        /// </summary>
        [Category( "Color" )]
        [DefaultValue( typeof( Color ), "0x00BFFF" )]
        public Color ColorBlue
        {
            set;
            get;
        }

        /// <summary>
        /// Farbe: Oranger Button
        /// </summary>
        [Category( "Color" )]
        [DefaultValue( typeof( Color ), "0xFF8C00" )]
        public Color ColorOrange
        {
            set;
            get;
        }

        /// <summary>
        /// Farbe: Gruener Button
        /// </summary>
        [Category( "Color" )]
        [DefaultValue( typeof( Color ), "0x00FF00" )]
        public Color ColorGreen
        {
            set;
            get;
        }

        /// <summary>
        /// Farbe: Gelber Button
        /// </summary>
        [Category( "Color" )]
        [DefaultValue( typeof( Color ), "0xFFFF00" )]
        public Color ColorYellow
        {
            set;
            get;
        }

        /// <summary>
        /// Farbe: Button ist gedrueckt
        /// </summary>
        [Category( "Color" )]
        [DefaultValue( typeof( Color ), "0x000000" )]
        public Color ColorButtonPressed
        {
            get;
            set;
        }


        /// <summary>
        /// Farbe: Buzzerbutton ist gedrueckt
        /// </summary>
        [Category( "Color" )]
        [DefaultValue( typeof( Color ), "0xFFFF00" )]
        public Color ColorBuzzerPressed
        {
            get;
            set;
        }

        /// <summary>
        /// Farbe: Buzzerbutton
        /// </summary>
        [Category( "Color" )]
        [DefaultValue( typeof( Color ), "0xFF0000" )]
        public Color ColorBuzzer
        {
            get => _ColorBuzzer;
            set
            {
                _ColorBuzzer = value;
                BrushBuzzer = new SolidBrush( value );
            }
        }

        /// <summary>
        /// Brush fuer den Buzzerbutton. Wird aus ColorBuzzer berechnet.
        /// </summary>
        private Brush BrushBuzzer
        {
            get;
            set;
        }

        #endregion

        #region Konstruktor

        /// <summary>
        /// Konstruktor
        /// </summary>
        public BuzzerUI()
        {
            ColorBuzzer = Color.Red;
            ColorBlue = Color.DeepSkyBlue;
            ColorOrange = Color.DarkOrange;
            ColorGreen = Color.Lime;
            ColorYellow = Color.Yellow;
            ColorButtonPressed = Color.Black;
            ColorBuzzerPressed = Color.Yellow;
            BuzzerPressed = false;

            InitializeComponent();

            Number = 1;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="number">Nummer des Buzzers</param>
        public BuzzerUI( byte number )
        {
            ColorBuzzer = Color.Red;
            ColorBlue = Color.DeepSkyBlue;
            ColorOrange = Color.DarkOrange;
            ColorGreen = Color.Lime;
            ColorYellow = Color.Yellow;
            ColorButtonPressed = Color.Black;
            ColorBuzzerPressed = Color.Yellow;
            BuzzerPressed = false;

            InitializeComponent();

            Number = number;
        }

        #endregion


        #region Methoden

        /// <summary>
        /// Auswahlbutton ein-/ausschalten.
        /// </summary>
        /// <param name="buttonColor">Button</param>
        /// <param name="pressed">True = Gedrueckt</param>
        public void SetButton( BuzzerButton buttonColor, bool pressed )
        {
            if( pressed )
            {
                SetPressed( buttonColor );
            }
            else
            {
                SetNormal( buttonColor );
            }
        }

        /// <summary>
        /// Buzzerknopf ein-/ausscahlten.
        /// </summary>
        /// <param name="pressed">True = Gedrueckt</param>
        public void SetBuzzer( bool pressed )
        {
            BuzzerPressed = pressed;
            DrawBuzzer( pnlBuzzer.CreateGraphics() );
            pnlBuzzer.Refresh();
        }

        /// <summary>
        /// Button-Objekt abfragen.
        /// </summary>
        /// <param name="buttonColor">Button</param>
        /// <returns>Button</returns>
        private Button GetButton( BuzzerButton buttonColor )
        {
            switch( buttonColor )
            {
                case BuzzerButton.Blue:
                    return btnBlue;
                case BuzzerButton.Orange:
                    return btnOrange;
                case BuzzerButton.Green:
                    return btnGreen;
                case BuzzerButton.Yellow:
                    return btnYellow;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Farbe des betreffenden Buttons abfragen.
        /// </summary>
        /// <param name="buttonColor">Button</param>
        /// <returns>Farbe</returns>
        private Color GetColor( BuzzerButton buttonColor )
        {
            switch( buttonColor )
            {
                case BuzzerButton.Blue:
                    return ColorBlue;
                case BuzzerButton.Orange:
                    return ColorOrange;
                case BuzzerButton.Green:
                    return ColorGreen;
                case BuzzerButton.Yellow:
                    return ColorYellow;
                default:
                    return Color.Black;
            }
        }
        /// <summary>
        /// Button: Ausschalten (nicht gedrueckt)
        /// </summary>
        /// <param name="buttonColor">Button</param>
        private void SetNormal( BuzzerButton buttonColor )
        {
            Button button = GetButton(buttonColor);
            if( button == null )
            {
                return;
            }

            button.BackColor = GetColor( buttonColor );
            button.FlatAppearance.BorderSize = 0;
        }

        /// <summary>
        /// Button: Einschalten (gedrueckt)
        /// </summary>
        /// <param name="buttonColor">Button</param>
        private void SetPressed( BuzzerButton buttonColor )
        {
            Button button = GetButton(buttonColor);
            if( button == null )
            {
                return;
            }

            int size = button.Height/8;
            if( size < 1 )
            {
                size = 1;
            }
            button.FlatAppearance.BorderSize = size;
            button.BackColor = ColorButtonPressed;
        }

        /// <summary>
        /// Alle Buttons ausschalten.
        /// </summary>
        public void Reset()
        {
            BuzzerPressed = false;
            DrawBuzzer( pnlBuzzer.CreateGraphics() );
            SetNormal( BuzzerButton.Blue );
            SetNormal( BuzzerButton.Orange );
            SetNormal( BuzzerButton.Green );
            SetNormal( BuzzerButton.Yellow );
        }


        /// <summary>
        /// Buzzer-Knopf zeichnen.
        /// </summary>
        /// <param name="graph">Garphics-Objekt</param>
        private void DrawBuzzer( Graphics graph )
        {
            //Groesse der Box abfragen
            int width = pnlBuzzer.Width;
            int height = pnlBuzzer.Height;

            //Durchmesser des Kreises an Hand der kleinsten Groesse (Hoehe oder Breite) der Box bestimmen.
            if( width > height )
            {
                width = height;
            }
            else if( height > width )
            {
                height = width;
            }

            //Linke obere Ecke des Kreise berechnen
            int x = (pnlBuzzer.Width-width)/2;
            int y = (pnlBuzzer.Height-height)/2;

            int lineWidth = width/15;
            if( lineWidth < 2 )
            {
                lineWidth = 2;
            }

            int circlePadding = 0;

            //Kreis zeichen
            graph.Clear( Color.Black );
            graph.FillEllipse( BrushBuzzer, x, y, width, height );

            if( BuzzerPressed )
            {
                graph.DrawEllipse(
                    new Pen( ColorBuzzerPressed, lineWidth ),
                    x + lineWidth / 2 + circlePadding,
                    y + lineWidth / 2 + circlePadding,
                    width - lineWidth - circlePadding * 2,
                    height - lineWidth - circlePadding * 2
                    );
                lblNumber.ForeColor = ColorButtonPressed;
            }
            else
            {
                lblNumber.ForeColor = pnlBuzzer.BackColor;
            }

            //Nummer zeichnen
            //height-5 von der Groesse abziehen und spaeter als Padding unten anfuegen.
            //Grund: Der Text hat (warum auch immer) oben einen groesseren Abstand als zu den anderen Seiten, somit ist der Text nie wirklich zentriert.
            //Achtung: Nicht die Textfarbe des Labels aendern, andernfalls wird eine Endlosschleife von PnlBuzzer_Paint()/DrawBuzzer() erzeugt.
            lblNumber.Font = new Font( lblNumber.Font.FontFamily, height - height / 5, lblNumber.Font.Style, GraphicsUnit.Pixel );
            lblNumber.Location = new Point( x, y );
            lblNumber.Size = new Size( width, height );
            lblNumber.Padding = new Padding( 0, 0, 0, height / 5 );

        }

        #endregion

        #region Events

        /// <summary>
        /// Event: Panel (Buzzerbutton) wird gezeichnet.
        /// </summary>
        private void PnlBuzzer_Paint( object sender, PaintEventArgs e ) => DrawBuzzer( e.Graphics );

        /// <summary>
        /// Event: Groesse des Panels (Buzzerbutton) hat sich geaendert.
        /// </summary>
        private void PnlBuzzer_SizeChanged( object sender, System.EventArgs e ) => DrawBuzzer( pnlBuzzer.CreateGraphics() );

        #endregion
    }
}
