/*!
 * ========================================================================
 * @project    SJ.Buzzer
 *
 * Info anzeigen.
 *
 * @file       About.cs
 * @author     Stefan Jahn <development@stefanjahn.de>
 * @copyright  Copyright (C) 2012-2021 Stefan Jahn
 * @link       https://stefanjahn.de
 *
 * @date       11.07.2012 14:00
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
using System.Drawing;
using System.Windows.Forms;

namespace SJ.App.Buzzer
{
    /// <summary>
    /// Info anzeigen.
    /// </summary>
    public partial class About : Form
    {
        #region Konstruktor

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="title">Programmname</param>
        /// <param name="version">Version</param>
        /// <param name="htmlInfo">Text: Info (HTML-Code)</param>
        /// <param name="htmlLicense">Text: Lizenz (HTML-Code, bei NULL wird keine Lizenz angezeigt)</param>
        /// <param name="icon">Icon</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public About( string title, string version, string htmlInfo, string htmlLicense, Image icon )
        {
            InitializeComponent();
            InitializeWindowSize();

            //Fehlerkontrolle
            if( title == null )
            {
                throw new ArgumentNullException( nameof( title ) );
            }

            if( htmlInfo == null )
            {
                throw new ArgumentNullException( nameof( htmlInfo ) );
            }

            title = title.Trim();
            htmlInfo = htmlInfo.Trim();
            htmlLicense = htmlLicense?.Trim();

            if( string.IsNullOrWhiteSpace( title ) )
            {
                throw new ArgumentException( "Parameter is empty.", nameof( title ) );
            }

            if( string.IsNullOrWhiteSpace( htmlInfo ) )
            {
                throw new ArgumentException( "Parameter is empty.", nameof( htmlInfo ) );
            }

            //Inhalte anzeigen
            Text = string.Format( System.Globalization.CultureInfo.CurrentCulture, "{0}: {1}", title, Resources.Language.AboutTitle );
            lblTitle.Text = title;

            if( !string.IsNullOrWhiteSpace( version ) )
            {
                lblTitle.Text += " " + version.Trim();
            }

            //Info anzeigen
            wbInfo.DocumentText = htmlInfo;

            //Lizenz anzeigen oder Tab entfernen
            if( !string.IsNullOrWhiteSpace( htmlLicense ) )
            {
                wbLicense.DocumentText = htmlLicense;
            }
            else
            {
                tcMain.TabPages.Remove( tpLicense );
            }

            if( icon != null )
            {
                pbIcon.Image = icon;
            }
            else
            {
                pbIcon.Visible = false;
            }
        }


        #endregion


        #region Methoden

        /// <summary>
        /// Fenstergroesse an Hand der aktuellen Aufloesung festlegen.
        /// </summary>
        private void InitializeWindowSize()
        {
            //Aktuelle Screengroesse / 3
            int width = Screen.PrimaryScreen.Bounds.Width/2;
            int height = Screen.PrimaryScreen.Bounds.Height/2;

            //Fehlerkontrolle
            if( width < 600 )
            {
                width = 600;
            }

            if( width > 800 )
            {
                width = 800;
            }

            if( height < 400 )
            {
                height = 400;
            }

            if( height > 600 )
            {
                height = 600;
            }

            if( height > Screen.PrimaryScreen.Bounds.Height )
            {
                height = Screen.PrimaryScreen.Bounds.Height - 10;
            }

            if( width > Screen.PrimaryScreen.Bounds.Width )
            {
                width = Screen.PrimaryScreen.Bounds.Width - 10;
            }

            Size = new Size( width, height );
        }

        #endregion


        #region Events

        /// <summary>
        /// Button: Ok
        /// </summary>
        private void BtnOk_Click( object sender, EventArgs e ) => Close();


        #endregion
    }
}
