namespace SJ.App.Buzzer
{
    partial class About
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.tlMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpInfo = new System.Windows.Forms.TabPage();
            this.wbInfo = new System.Windows.Forms.WebBrowser();
            this.tpLicense = new System.Windows.Forms.TabPage();
            this.wbLicense = new System.Windows.Forms.WebBrowser();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlMain.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpInfo.SuspendLayout();
            this.tpLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tlMain
            // 
            resources.ApplyResources(this.tlMain, "tlMain");
            this.tlMain.Controls.Add(this.btnOk, 1, 2);
            this.tlMain.Controls.Add(this.tcMain, 0, 1);
            this.tlMain.Controls.Add(this.pbIcon, 0, 0);
            this.tlMain.Controls.Add(this.lblTitle, 1, 0);
            this.tlMain.Name = "tlMain";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // tcMain
            // 
            resources.ApplyResources(this.tcMain, "tcMain");
            this.tlMain.SetColumnSpan(this.tcMain, 2);
            this.tcMain.Controls.Add(this.tpInfo);
            this.tcMain.Controls.Add(this.tpLicense);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            // 
            // tpInfo
            // 
            resources.ApplyResources(this.tpInfo, "tpInfo");
            this.tpInfo.Controls.Add(this.wbInfo);
            this.tpInfo.Name = "tpInfo";
            this.tpInfo.UseVisualStyleBackColor = true;
            // 
            // wbInfo
            // 
            resources.ApplyResources(this.wbInfo, "wbInfo");
            this.wbInfo.AllowNavigation = false;
            this.wbInfo.AllowWebBrowserDrop = false;
            this.wbInfo.IsWebBrowserContextMenuEnabled = false;
            this.wbInfo.Name = "wbInfo";
            this.wbInfo.ScriptErrorsSuppressed = true;
            this.wbInfo.WebBrowserShortcutsEnabled = false;
            // 
            // tpLicense
            // 
            resources.ApplyResources(this.tpLicense, "tpLicense");
            this.tpLicense.Controls.Add(this.wbLicense);
            this.tpLicense.Name = "tpLicense";
            this.tpLicense.UseVisualStyleBackColor = true;
            // 
            // wbLicense
            // 
            resources.ApplyResources(this.wbLicense, "wbLicense");
            this.wbLicense.AllowNavigation = false;
            this.wbLicense.AllowWebBrowserDrop = false;
            this.wbLicense.IsWebBrowserContextMenuEnabled = false;
            this.wbLicense.Name = "wbLicense";
            this.wbLicense.ScriptErrorsSuppressed = true;
            this.wbLicense.WebBrowserShortcutsEnabled = false;
            // 
            // pbIcon
            // 
            resources.ApplyResources(this.pbIcon, "pbIcon");
            this.pbIcon.Image = global::SJ.App.Buzzer.Properties.Resources.ledred_big;
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.TabStop = false;
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // About
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOk;
            this.Controls.Add(this.tlMain);
            this.Name = "About";
            this.tlMain.ResumeLayout(false);
            this.tlMain.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tpInfo.ResumeLayout(false);
            this.tpLicense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlMain;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpInfo;
        private System.Windows.Forms.TabPage tpLicense;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.WebBrowser wbInfo;
        private System.Windows.Forms.WebBrowser wbLicense;
    }
}