/*!
 * ========================================================================
 * @project    SJ.Buzzer
 *
 * Status eines einzelnen Buzzers.
 *
 * @file       BuzzerState.cs
 * @author     Stefan Jahn <development@stefanjahn.de>
 * @copyright  Copyright (C) 2012-2021 Stefan Jahn
 * @link       https://stefanjahn.de
 *
 * @date       20.04.2012 21:58
 * @version    20120711
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

using System.Collections.Generic;


namespace SJ.App.Buzzer.Helper
{
    /// <summary>
    /// Status eines einzelnen Buzzers.
    /// </summary>
    public class BuzzerState
    {
        #region Properties

        /// <summary>
        /// True = Buzzer wurde gedrueckt.
        /// </summary>
        public Dictionary<BuzzerButton, bool> Button
        {
            get;
            private set;
        }


        /// <summary>
        /// Welcher Auswahlbutton wurde gedrueckt.
        /// </summary>
        public BuzzerButton PressedButton
        {
            get
            {
                if( Button[BuzzerButton.Blue] )
                {
                    return BuzzerButton.Blue;
                }

                if( Button[BuzzerButton.Orange] )
                {
                    return BuzzerButton.Orange;
                }

                if( Button[BuzzerButton.Green] )
                {
                    return BuzzerButton.Green;
                }

                if( Button[BuzzerButton.Yellow] )
                {
                    return BuzzerButton.Yellow;
                }

                return BuzzerButton.None;
            }
        }

        #endregion


        #region Konstruktor

        /// <summary>
        /// Konstruktor
        /// </summary>
        public BuzzerState() => Button = new Dictionary<BuzzerButton, bool>
            {
                { BuzzerButton.Buzzer, false },
                { BuzzerButton.Blue, false },
                { BuzzerButton.Orange, false },
                { BuzzerButton.Green, false },
                { BuzzerButton.Yellow, false }
            };


        #endregion


        #region Methoden

        /// <summary>
        /// Buttons zuruecksetzen.
        /// </summary>
        public void Reset()
        {
            Button[BuzzerButton.Buzzer] = false;
            Button[BuzzerButton.Blue] = false;
            Button[BuzzerButton.Orange] = false;
            Button[BuzzerButton.Green] = false;
            Button[BuzzerButton.Yellow] = false;
        }


        #endregion
    }
}
