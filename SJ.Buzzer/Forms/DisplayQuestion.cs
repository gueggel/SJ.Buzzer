/*!
 * ========================================================================
 * @project    SJ.Buzzer
 *
 * Messagebox fuer die Eingabe eines Textes.
 *
 * @file       DisplayQuestion.cs
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

namespace SJ.App.Buzzer
{
    using System;
    using System.Windows.Forms;


    /// <summary>
    /// Messagebox fuer die Eingabe eines Textes.
    /// </summary>
    public partial class DisplayQuestion : Form
    {
        #region Properties

        /// <summary>
        /// Eingabetext
        /// </summary>
        public string Input
        {
            get;
            private set;
        }

        #endregion


        #region Statische Methoden

        /// <summary>
        /// Dialog anzeigen.
        /// </summary>
        /// <param name="title">Fenstertitel</param>
        /// <param name="question">Frage/Meldung</param>
        /// <param name="maxLength">Maximale Zeichenanzahl der Eingabe</param>
        /// <param name="input">Rueckgabewert der Eingabe</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Show( string title, string question, int maxLength, out string input ) => Show( title, question, maxLength, out input, string.Empty );


        /// <summary>
        /// Dialog anzeigen.
        /// </summary>
        /// <param name="title">Fenstertitel</param>
        /// <param name="question">Frage/Meldung</param>
        /// <param name="maxLength">Maximale Zeichenanzahl der Eingabe</param>
        /// <param name="input">Rueckgabewert der Eingabe</param>
        /// <param name="defaultInput">Vorgabe fuer die Eingabe</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Show( string title, string question, int maxLength, out string input, string defaultInput )
        {
            DisplayQuestion dialog = null;

            try
            {
                dialog = new DisplayQuestion( title, question, defaultInput, maxLength );

                DialogResult result = dialog.ShowDialog();
                input = dialog.Input;

                return result;
            }
            catch
            {
                input = string.Empty;
                return DialogResult.Cancel;
            }
            finally
            {
                dialog?.Dispose();
            }
        }


        #endregion


        #region Konstruktor

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="title">Fenstertitel</param>
        /// <param name="question">Frage/Meldung</param>
        /// <param name="defaultInput">Vorgabe fuer die Eingabe</param>
        /// <param name="maxLength">Maximale Zeichenanzahl der Eingabe</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DisplayQuestion( string title, string question, string defaultInput, int maxLength )
        {
            InitializeComponent();

            if( title == null )
            {
                throw new ArgumentNullException( nameof( title ) );
            }

            if( question == null )
            {
                throw new ArgumentNullException( nameof( question ) );
            }

            Text = title.Trim();
            lblMessage.Text = question.Trim();

            if( defaultInput == null )
            {
                defaultInput = string.Empty;
            }

            txtInput.MaxLength = maxLength;
            txtInput.Text = defaultInput.Trim();
        }


        #endregion


        #region Events

        /// <summary>
        /// Button: Ja
        /// </summary>
        private void BtnOkClick( object sender, EventArgs e )
        {
            Input = txtInput.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }


        /// <summary>
        /// Button: Abbruch
        /// </summary>
        private void BtnCancelClick( object sender, EventArgs e )
        {
            Input = string.Empty;
            DialogResult = DialogResult.Cancel;
            Close();
        }


        #endregion
    }
}
