/*!
 * ========================================================================
 * @project    SJ.Buzzer
 *
 * Definition der Enums.
 *
 * @file       Enum.cs
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

namespace SJ.App.Buzzer.Helper
{
    /// <summary>
    /// Art des Buttons auf dem Buzzer.
    /// </summary>
    public enum BuzzerButton
    {
        /// <summary>
        /// Keiner
        /// </summary>
        None,

        /// <summary>
        /// Buzzer
        /// </summary>
        Buzzer,

        /// <summary>
        /// Button: Blau
        /// </summary>
        Blue,

        /// <summary>
        /// Button: Orange
        /// </summary>
        Orange,

        /// <summary>
        /// Button: Gruen
        /// </summary>
        Green,

        /// <summary>
        /// Button: Gelb
        /// </summary>
        Yellow
    }


    /// <summary>
    /// Nummer des einzelnen Buzzers.
    /// </summary>
    public enum BuzzerNumber
    {
        /// <summary>
        /// Keiner
        /// </summary>
        None,

        /// <summary>
        /// Buzzer #1
        /// </summary>
        One,

        /// <summary>
        /// Buzzer #2
        /// </summary>
        Two,

        /// <summary>
        /// Buzzer #3
        /// </summary>
        Three,

        /// <summary>
        /// Buzzer #4
        /// </summary>
        Four
    }


    /// <summary>
    /// Wahl der Sounddatei.
    /// </summary>
    public enum Soundfile
    {
        WrongAnswer,
        BuzzerPressed,
        Fanfare,
        CorrectAnswer,
        ButtonClick,
        Dramatic,
        TickTack,
        Applause,
        Intro
    }
}
