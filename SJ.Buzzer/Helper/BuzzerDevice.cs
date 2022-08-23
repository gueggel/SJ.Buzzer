/*!
 * ========================================================================
 * @project    SJ.Buzzer
 *
 * Zugriff auf einen Buzzer-Controller (mit 4 Buzzer).
 *
 * @file       BuzzerDevice.cs
 * @author     Stefan Jahn <development@stefanjahn.de>
 * @copyright  Copyright (C) 2012-2021 Stefan Jahn
 * @link       https://stefanjahn.de
 *
 * @date       20.04.2012 21:58
 * @version    20220823
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
using System.Linq;

using SharpDX.DirectInput;

namespace SJ.App.Buzzer.Helper
{
    #region Delegates

    /// <summary>
    /// Event: Button wurde gedrueckt.
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="buzzerNumber">Nummer des Buzzers</param>
    /// <param name="buzzerButton">Nummer des Buttons</param>
    /// <param name="isPressed">True = Button wird gedrueckt</param>
    /// <param name="buzzerFound">True = Erster Buzzer wurde gedrueckt</param>
    /// <param name="buttonFound">True = Erster Button eines Buzzers wurde gedrueckt</param>
    public delegate void EventButtonPressed( object sender, BuzzerNumber buzzerNumber, BuzzerButton buzzerButton, bool isPressed, bool buzzerFound, bool buttonFound );

    #endregion


    /// <summary>
    /// Zugriff auf einen Buzzer-Controller (mit 4 Buzzer).
    /// <remarks>
    /// Der Controller verwaltet 4 einzelne Buzzers. In der Systemsteuerung von Windows taucht der Controller
    /// als einzelner Joystick mit 20 Buttons auf. Jeder Buzzer hat 5 Buttons: Einen Buzzer-Button und
    /// vier farbige Auswahlbuttons. Die einzelnen Buttons des Controllers sind einfach in 5er-Bloecken
    /// durchnummeriert: 0-4 = 1 Buzzer, 5-9 = 2 Buzzer, ...
    /// </remarks>
    /// </summary>
    public class BuzzerDevice : IDisposable
    {
        #region Enums

        /// <summary>
        /// Art der Abfrage des Buzzerbuttons.
        /// </summary>
        private enum QueryBuzzerType
        {
            /// <summary>
            /// Kein Spielmodus, jeder Buzzerbutton kann beliebig gedrueckt werden.
            /// </summary>
            None,

            /// <summary>
            /// Spielmodus: Warte auf den ersten Buzzerbutton der gedrueckt wird.
            /// </summary>
            WaitForFirstBuzzer,

            /// <summary>
            /// Buzzerbutton wurde gedrueckt.
            /// </summary>
            IsPressed,
        }

        /// <summary>
        /// Art der Abfrage der Auswahlbuttons.
        /// </summary>
        private enum QueryButtonsType
        {
            /// <summary>
            /// Kein Spielmodus, jeder Auswahlbutton kann beliebig gedrueckt werden.
            /// </summary>
            None,

            /// <summary>
            /// Spielmodus: Warte auf den ersten Auswahlbutton der gedrueckt wird.
            /// </summary>
            WaitForFirstButton,

            /// <summary>
            /// Auswahlbutton wurde gedrueckt.
            /// </summary>
            IsPressed
        }

        #endregion


        #region Attribute

        /// <summary>
        /// Device fuer den Zugriff auf den Buzzer-Controller (der alle 4 Buzzer beinhaltet).
        /// </summary>
        private Joystick _Controller;

        /// <summary>
        /// GUID des gewaehlten Controllers.
        /// </summary>
        private Guid _SelectedController;

        private int _CountButtons;

        #endregion


        #region Events

        /// <summary>
        /// Event: Button wurde gedrueckt.
        /// </summary>
        public EventButtonPressed ButtonPressed;

        #endregion


        #region Properties

        /// <summary>
        /// DirectInput-Objekt
        /// </summary>
        private DirectInput DInput
        {
            get;
            set;
        }

        /// <summary>
        /// GUID des gewaehlten Controllers.
        /// </summary>
        public Guid SelectedController
        {
            get => _SelectedController;
            set
            {
                _SelectedController = value;

                Controller?.Dispose();

                if( value != Guid.Empty )
                {
                    Controller = new Joystick( DInput, value );
                }
                else
                {
                    Controller = null;
                }
            }
        }

        /// <summary>
        /// True = Buzzer aktiv.
        /// </summary>
        public bool Enabled => ( Controller != null );


        /// <summary>
        /// True = Erster Buzzer wurde gedrueckt.
        /// </summary>
        public bool IsBuzzerFound => ( QueryBuzzer == QueryBuzzerType.IsPressed );


        /// <summary>
        /// Art der Abfrage des Buzzer eines Controllers.
        /// </summary>
        private QueryBuzzerType QueryBuzzer
        {
            get;
            set;
        }

        /// <summary>
        /// Art der Abfrage der einzelnen Auswahlbuttons eines Controllers.
        /// </summary>
        private Dictionary<BuzzerNumber, QueryButtonsType> QueryButtons
        {
            get;
            set;
        }


        /// <summary>
        /// Status der einzelnen Buzzers.
        /// </summary>
        public Dictionary<BuzzerNumber, BuzzerState> State
        {
            get;
            private set;
        }


        /// <summary>
        /// Vorheriger Status der einzelnen Buzzers.
        /// </summary>
        private Dictionary<BuzzerNumber, BuzzerState> PreviousState
        {
            get;
            set;
        }


        /// <summary>
        /// Device fuer den Zugriff auf den Buzzer-Controller (der alle 4 Buzzer beinhaltet).
        /// </summary>
        private Joystick Controller
        {
            get => _Controller;
            set
            {
                //Falls schon ein Controller ausgewahlt war, so diesen wieder freigeben.
                if( Controller != null )
                {
                    try
                    {
                        if( !Controller.IsDisposed )
                        {
                            Controller.Unacquire();
                        }
                    }
                    catch
                    {

                    }

                    Controller.Dispose();
                }

                _Controller = value;
                Clear();

                //Gewaehlten Controller aktivieren.
                if( Controller != null )
                {
                    //Todo: Alter DirectX-Code
                    //Controller.SetCooperativeLevel( Parent, CooperativeLevel.Background | CooperativeLevel.NonExclusive );
                    //Controller.SetDataFormat( DeviceDataFormat.Joystick );
                    Controller.Acquire();

                    CountButtons = Controller.Capabilities.ButtonCount;
                }
            }
        }

        /// <summary>
        /// Auflistung aller verfuegbaren Buttonnummern.
        /// </summary>
        private List<int> ListOrderButtons
        {
            get;
            set;
        }

        /// <summary>
        /// Anzahl der Buttons auf dem Buzzer.
        /// </summary>
        public int CountButtons
        {
            get => _CountButtons;
            private set
            {
                _CountButtons = value;
                ListOrderButtons = new List<int>( value );

                for( int i = 0; i < value; i++ )
                {
                    ListOrderButtons.Add( i );
                }
            }
        }


        /// <summary>
        /// Liste mit den Devices (Jyostick) abfragen.
        /// <para>
        /// Key = Controller/Instance GUID, Value = Name
        /// </para>
        /// </summary>
        public Dictionary<Guid, string> ListDevices
        {
            get
            {
                try
                {
                    Dictionary<Guid, string> controllers = new Dictionary<Guid, string>();
                    IList<DeviceInstance> list = DInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);

                    foreach( DeviceInstance instance in list )
                    {
                        controllers.Add( instance.InstanceGuid, instance.ProductName );
                    }

                    return controllers;
                }
                catch
                {
                    //Fehler bei der Abfrage, leere Liste zurueckgeben.
                    return new Dictionary<Guid, string>();
                }
            }
        }

        #endregion


        #region Konstruktor

        /// <summary>
        /// Konstruktor
        /// </summary>
        public BuzzerDevice()
        {
            DInput = new DirectInput();
            QueryBuzzer = QueryBuzzerType.None;
            CountButtons = 0;

            QueryButtons = new Dictionary<BuzzerNumber, QueryButtonsType>();
            State = new Dictionary<BuzzerNumber, BuzzerState>();
            PreviousState = new Dictionary<BuzzerNumber, BuzzerState>();

            QueryButtons.Add( BuzzerNumber.One, QueryButtonsType.None );
            QueryButtons.Add( BuzzerNumber.Two, QueryButtonsType.None );
            QueryButtons.Add( BuzzerNumber.Three, QueryButtonsType.None );
            QueryButtons.Add( BuzzerNumber.Four, QueryButtonsType.None );

            PreviousState.Add( BuzzerNumber.One, new BuzzerState() );
            PreviousState.Add( BuzzerNumber.Two, new BuzzerState() );
            PreviousState.Add( BuzzerNumber.Three, new BuzzerState() );
            PreviousState.Add( BuzzerNumber.Four, new BuzzerState() );

            State.Add( BuzzerNumber.One, new BuzzerState() );
            State.Add( BuzzerNumber.Two, new BuzzerState() );
            State.Add( BuzzerNumber.Three, new BuzzerState() );
            State.Add( BuzzerNumber.Four, new BuzzerState() );

            Controller = null;
            SelectedController = Guid.Empty;

            ResetWait();
        }


        #endregion


        #region Destruktor

        /// <summary>
        /// Destruktor
        /// </summary>
        ~BuzzerDevice()
        {
            Dispose( false );
        }


        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }


        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">True = Managed Resourcen freigeben</param>
        protected virtual void Dispose( bool disposing )
        {
            //Managed Resourcen freigeben
            if( disposing )
            {
                if( Controller != null )
                {
                    if( !Controller.IsDisposed )
                    {
                        Controller.Unacquire();
                    }

                    Controller.Dispose();
                }

                DInput?.Dispose();
            }

            //Unmanaged Resourcen freigeben
        }


        #endregion


        #region Methoden

        /// <summary>
        /// Status/Einstellungen loeschen.
        /// </summary>
        private void Clear()
        {
            CountButtons = 0;

            //Art der Abfrage/Spielemodus
            QueryBuzzer = QueryBuzzerType.None;
            QueryButtons[BuzzerNumber.One] = QueryButtonsType.None;
            QueryButtons[BuzzerNumber.Two] = QueryButtonsType.None;
            QueryButtons[BuzzerNumber.Three] = QueryButtonsType.None;
            QueryButtons[BuzzerNumber.Four] = QueryButtonsType.None;

            //Status der Buttons
            State[BuzzerNumber.One].Reset();
            State[BuzzerNumber.Two].Reset();
            State[BuzzerNumber.Three].Reset();
            State[BuzzerNumber.Four].Reset();

            PreviousState[BuzzerNumber.One].Reset();
            PreviousState[BuzzerNumber.Two].Reset();
            PreviousState[BuzzerNumber.Three].Reset();
            PreviousState[BuzzerNumber.Four].Reset();
        }

        /// <summary>
        /// Buzzer abfragen.
        /// </summary>
        public void Poll()
        {
            if( !Enabled )
            {
                return;
            }

            //Beenden falls der Buzzerbutton eines Buzzers schon gedrueckt worden ist
            if( QueryBuzzer == QueryBuzzerType.IsPressed )
            {
                return;
            }

            //Beenden falls die Auswahlbuttons der Buzzers schon gedrueckt worden ist
            if( QueryButtons[BuzzerNumber.One] == QueryButtonsType.IsPressed
                 && QueryButtons[BuzzerNumber.Two] == QueryButtonsType.IsPressed
                 && QueryButtons[BuzzerNumber.Three] == QueryButtonsType.IsPressed
                 && QueryButtons[BuzzerNumber.Four] == QueryButtonsType.IsPressed )
            {
                return;
            }

            //Abfrage durchfuehren
            Controller.Poll();

            //Status abfragen
            JoystickState state = Controller.GetCurrentState();
            bool[] buttons = state.Buttons;
            bool buttonFound = false;

            //Reihenfolge der Button-Nummern mischen
            Random rnd = new Random(Environment.TickCount);
            List<int> randomList = ListOrderButtons.OrderBy(item=>rnd.Next()).ToList();

            //Alle Buttons aller Buzzer durchgehen            
            foreach( int buttonNumber in randomList )
            {
                //Nummer des aktuellen Buzzer bestimmen (1...4)
                BuzzerNumber currentNumber = GetBuzzerNumber(buttonNumber);

                //Typ des aktuellen Buttons bestimmen (Buzzer, Blau, Orange, Gruen, Gelb)
                BuzzerButton currentButton = GetBuzzerButton(buttonNumber);

                //Falls kein Buzzer/Button gefunden wurde, oder der Button schon gedruueckt ist, so weiter mit dem naechsten Button
                if( currentButton == BuzzerButton.None || currentNumber == BuzzerNumber.None || QueryButtons[currentNumber] == QueryButtonsType.IsPressed )
                {
                    continue;
                }

                //Pruefen ob Button gedrueckt worden ist
                if( buttons[buttonNumber] == true )
                {
                    //Wurde nur Auswahlbutton gedrueckt
                    if( currentButton != BuzzerButton.Buzzer )
                    {
                        switch( QueryButtons[currentNumber] )
                        {
                            //Kein Spielmodus, alle Button aller Buzzer koennen beliebig gedrueckt werden
                            case QueryButtonsType.None:
                                State[currentNumber].Button[currentButton] = true;
                                break;

                            //Spielmodus: Warte auf den ersten Buzzer der gedrueckt wird
                            case QueryButtonsType.WaitForFirstButton:
                                State[currentNumber].Button[currentButton] = true;

                                //Vermerken das der Button gedrueckt wurde
                                QueryButtons[currentNumber] = QueryButtonsType.IsPressed;
                                buttonFound = true;
                                break;
                        }
                    }
                    else
                    {
                        State[currentNumber].Button[currentButton] = true;
                    }

                    //Pruefen ob der Button in der vorherigen Abfrage nicht gedrueckt worden ist (wurder der Button erstmalig gedrueckt)
                    if( PreviousState[currentNumber].Button[currentButton] != true )
                    {
                        //Vermerken das Button gedrueckt wurde
                        PreviousState[currentNumber].Button[currentButton] = true;

                        //Wurde Buzzerbutton gedrueckt
                        if( currentButton == BuzzerButton.Buzzer && QueryBuzzer == QueryBuzzerType.WaitForFirstBuzzer )
                        {
                            //Vermerken das der Buzzerbutton gedrueckt wurde
                            QueryBuzzer = QueryBuzzerType.IsPressed;

                            //Signal: Button gedrueckt
                            RaiseEvent( buttonNumber, true, true, false );
                            return;
                        }
                        else
                        {
                            //Signal: Button gedrueckt
                            RaiseEvent( buttonNumber, true, false, buttonFound );
                        }
                    }
                }
                else
                {
                    //Button wurde nicht gedrueckt
                    State[currentNumber].Button[currentButton] = false;

                    //Pruefen ob der Button in der vorherigen Abfrage gedrueckt worden ist, somit wurde der Button losgelassen
                    if( PreviousState[currentNumber].Button[currentButton] != false )
                    {
                        //Vermerken das Button losgelassen wurde
                        PreviousState[currentNumber].Button[currentButton] = false;

                        //Signal: Button losgelassen
                        RaiseEvent( buttonNumber, false, false, false );
                    }
                }
            }
        }


        /// <summary>
        /// BuzzerNumber bestimmen.
        /// </summary>
        /// <param name="buttonNumber">Nummer des Buttons</param>
        /// <returns>BuzzerNumber</returns>
        private BuzzerNumber GetBuzzerNumber( int buttonNumber )
        {
            switch( buttonNumber )
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    return BuzzerNumber.One;

                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return BuzzerNumber.Two;

                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    return BuzzerNumber.Three;

                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                    return BuzzerNumber.Four;

                default:
                    return BuzzerNumber.None;
            }
        }


        /// <summary>
        /// BuzzerButton bestimmen.
        /// </summary>
        /// <param name="buttonNumber">Nummer des Buttons</param>
        /// <returns>BuzzerButton</returns>
        private BuzzerButton GetBuzzerButton( int buttonNumber )
        {
            switch( buttonNumber )
            {
                case 0:
                case 5:
                case 10:
                case 15:
                    return BuzzerButton.Buzzer;

                case 1:
                case 6:
                case 11:
                case 16:
                    return BuzzerButton.Yellow;

                case 2:
                case 7:
                case 12:
                case 17:
                    return BuzzerButton.Green;

                case 3:
                case 8:
                case 13:
                case 18:
                    return BuzzerButton.Orange;


                case 4:
                case 9:
                case 14:
                case 19:
                    return BuzzerButton.Blue;

                default:
                    return BuzzerButton.None;
            }
        }


        /// <summary>
        /// Event ausloesen wenn Button gedrueckt/losgelassen wird.
        /// </summary>
        /// <param name="buttonNumber">Nummer des Buttons</param>
        /// <param name="isPressed">True = Button wird gedrueckt</param>
        /// <param name="buzzerFound">True = Erster Buzzer wurde gedrueckt</param>
        /// <param name="buttonFound">True = Erster Button eines Buzzers wurde gedrueckt</param>
        private void RaiseEvent( int buttonNumber, bool isPressed, bool buzzerFound, bool buttonFound )
        {
            if( ButtonPressed == null )
            {
                return;
            }

            ButtonPressed( this, GetBuzzerNumber( buttonNumber ), GetBuzzerButton( buttonNumber ), isPressed, buzzerFound, buttonFound );
        }


        /// <summary>
        /// Abfrage/Spielemodus zuruecksetzen.
        /// </summary>
        public void ResetWait()
        {
            if( !Enabled )
            {
                return;
            }

            QueryBuzzer = QueryBuzzerType.None;
            QueryButtons[BuzzerNumber.One] = QueryButtonsType.None;
            QueryButtons[BuzzerNumber.Two] = QueryButtonsType.None;
            QueryButtons[BuzzerNumber.Three] = QueryButtonsType.None;
            QueryButtons[BuzzerNumber.Four] = QueryButtonsType.None;

            State[BuzzerNumber.One].Reset();
            State[BuzzerNumber.Two].Reset();
            State[BuzzerNumber.Three].Reset();
            State[BuzzerNumber.Four].Reset();
        }


        /// <summary>
        /// Spielemodus: Abfrage des Buzzerbuttons starten.
        /// </summary>
        public void WaitForBuzzer()
        {
            if( !Enabled )
            {
                return;
            }

            ResetWait();
            QueryBuzzer = QueryBuzzerType.WaitForFirstBuzzer;
        }


        /// <summary>
        /// Spielemodus: Abfrage der Auswahlbuttons starten.
        /// </summary>
        public void WaitForButton()
        {
            if( !Enabled )
            {
                return;
            }

            ResetWait();
            QueryButtons[BuzzerNumber.One] = QueryButtonsType.WaitForFirstButton;
            QueryButtons[BuzzerNumber.Two] = QueryButtonsType.WaitForFirstButton;
            QueryButtons[BuzzerNumber.Three] = QueryButtonsType.WaitForFirstButton;
            QueryButtons[BuzzerNumber.Four] = QueryButtonsType.WaitForFirstButton;
        }


        #endregion
    }
}
