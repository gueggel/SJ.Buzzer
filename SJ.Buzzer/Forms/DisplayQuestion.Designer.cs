/*!
 * ========================================================================  
 * @project    Buzzer
 *
 * Messagebox fuer die Eingabe eines Textes.
 *   
 * @file       DisplayQuestion.designer.cs
 * @author     Stefan Jahn <development@stefanjahn.de>
 * @copyright  Copyright (C) 2011 Stefan Jahn
 * @link       http://stefanjahn.de
 *
 * @date       20.04.2011 21:58
 * @version    20110420
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
    partial class DisplayQuestion
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayQuestion));
            this.tlMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.flButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tlMain.SuspendLayout();
            this.flButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlMain
            // 
            resources.ApplyResources(this.tlMain, "tlMain");
            this.tlMain.Controls.Add(this.lblMessage, 0, 0);
            this.tlMain.Controls.Add(this.txtInput, 0, 1);
            this.tlMain.Controls.Add(this.flButtons, 0, 2);
            this.tlMain.Name = "tlMain";
            // 
            // lblMessage
            // 
            resources.ApplyResources(this.lblMessage, "lblMessage");
            this.lblMessage.Name = "lblMessage";
            // 
            // txtInput
            // 
            resources.ApplyResources(this.txtInput, "txtInput");
            this.txtInput.Name = "txtInput";
            // 
            // flButtons
            // 
            resources.ApplyResources(this.flButtons, "flButtons");
            this.flButtons.Controls.Add(this.btnCancel);
            this.flButtons.Controls.Add(this.btnOk);
            this.flButtons.Name = "flButtons";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // DisplayQuestion
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplayQuestion";
            this.ShowIcon = false;
            this.tlMain.ResumeLayout(false);
            this.tlMain.PerformLayout();
            this.flButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flButtons;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TableLayoutPanel tlMain;
    }
}
