/*!
 * ========================================================================
 * @project    SJ.Buzzer
 *
 * Programmstart
 *
 * @file       Program.cs
 * @author     Stefan Jahn <development@stefanjahn.de>
 * @copyright  Copyright (C) 2012-2021 Stefan Jahn
 * @link       https://stefanjahn.de
 *
 * @date       20.04.2012 21:58
 * @version    20210523
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
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace SJ.App.Buzzer
{
    /// <summary>
    /// Programmstart
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            MainWindow window = null;

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault( false );

                bool doLoop = false;

                do
                {
                    doLoop = false;
                    window = new MainWindow();

                    Application.Run( window );

                    //Pruefen ob Sprache geaendert werden soll
                    if( !string.IsNullOrWhiteSpace( window.SetLanguage ) )
                    {
                        //Gewuenschte Sprache einstellen
                        Thread.CurrentThread.CurrentCulture = new CultureInfo( window.SetLanguage );
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo( window.SetLanguage );

                        //Programm von Vorne starten
                        doLoop = true;
                    }
                } while( doLoop );
            }
            catch( Exception ex )
            {
                string text = ex.Message + Environment.NewLine;

                try
                {
                    text += Environment.NewLine + "TYP: " + ex.GetType().ToString();
                }
                catch
                {
                }

                try
                {
                    text += Environment.NewLine + "SOURCE: " + ex.Source;
                }
                catch
                {
                }

                try
                {
                    text += Environment.NewLine + "TARGET-SITE: " + ex.TargetSite.ToString();
                }
                catch
                {
                }

                text += Environment.NewLine + Environment.NewLine + "STACKTRACE:" + Environment.NewLine + ex.ToString();

                MessageBox.Show( text, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally
            {
                window?.Dispose();
            }
        }
    }
}
