
namespace SJ.App.Buzzer.Controls
{
    partial class BuzzerUI
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnOrange = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnYellow = new System.Windows.Forms.Button();
            this.pnlBuzzer = new System.Windows.Forms.Panel();
            this.lblNumber = new System.Windows.Forms.Label();
            this.tlMain.SuspendLayout();
            this.pnlBuzzer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlMain
            // 
            this.tlMain.BackColor = System.Drawing.Color.Black;
            this.tlMain.ColumnCount = 1;
            this.tlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlMain.Controls.Add(this.btnBlue, 0, 1);
            this.tlMain.Controls.Add(this.btnOrange, 0, 2);
            this.tlMain.Controls.Add(this.btnGreen, 0, 3);
            this.tlMain.Controls.Add(this.btnYellow, 0, 4);
            this.tlMain.Controls.Add(this.pnlBuzzer, 0, 0);
            this.tlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMain.Location = new System.Drawing.Point(0, 0);
            this.tlMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlMain.Name = "tlMain";
            this.tlMain.RowCount = 5;
            this.tlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlMain.Size = new System.Drawing.Size(200, 600);
            this.tlMain.TabIndex = 0;
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnBlue.CausesValidation = false;
            this.btnBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBlue.Enabled = false;
            this.btnBlue.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnBlue.FlatAppearance.BorderSize = 0;
            this.btnBlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlue.Location = new System.Drawing.Point(4, 244);
            this.btnBlue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBlue.Size = new System.Drawing.Size(192, 84);
            this.btnBlue.TabIndex = 0;
            this.btnBlue.TabStop = false;
            this.btnBlue.UseVisualStyleBackColor = false;
            // 
            // btnOrange
            // 
            this.btnOrange.BackColor = System.Drawing.Color.DarkOrange;
            this.btnOrange.CausesValidation = false;
            this.btnOrange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOrange.Enabled = false;
            this.btnOrange.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnOrange.FlatAppearance.BorderSize = 0;
            this.btnOrange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrange.Location = new System.Drawing.Point(4, 332);
            this.btnOrange.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnOrange.Name = "btnOrange";
            this.btnOrange.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnOrange.Size = new System.Drawing.Size(192, 86);
            this.btnOrange.TabIndex = 0;
            this.btnOrange.TabStop = false;
            this.btnOrange.UseVisualStyleBackColor = false;
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Lime;
            this.btnGreen.CausesValidation = false;
            this.btnGreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGreen.Enabled = false;
            this.btnGreen.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnGreen.FlatAppearance.BorderSize = 0;
            this.btnGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGreen.Location = new System.Drawing.Point(4, 422);
            this.btnGreen.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnGreen.Size = new System.Drawing.Size(192, 86);
            this.btnGreen.TabIndex = 0;
            this.btnGreen.TabStop = false;
            this.btnGreen.UseVisualStyleBackColor = false;
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Yellow;
            this.btnYellow.CausesValidation = false;
            this.btnYellow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYellow.Enabled = false;
            this.btnYellow.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnYellow.FlatAppearance.BorderSize = 0;
            this.btnYellow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYellow.Location = new System.Drawing.Point(4, 512);
            this.btnYellow.Margin = new System.Windows.Forms.Padding(4, 2, 4, 4);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnYellow.Size = new System.Drawing.Size(192, 84);
            this.btnYellow.TabIndex = 0;
            this.btnYellow.TabStop = false;
            this.btnYellow.UseVisualStyleBackColor = false;
            // 
            // pnlBuzzer
            // 
            this.pnlBuzzer.AutoSize = true;
            this.pnlBuzzer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBuzzer.CausesValidation = false;
            this.pnlBuzzer.Controls.Add(this.lblNumber);
            this.pnlBuzzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBuzzer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.pnlBuzzer.Location = new System.Drawing.Point(4, 4);
            this.pnlBuzzer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.pnlBuzzer.Name = "pnlBuzzer";
            this.pnlBuzzer.Size = new System.Drawing.Size(192, 234);
            this.pnlBuzzer.TabIndex = 1;
            this.pnlBuzzer.SizeChanged += new System.EventHandler(this.PnlBuzzer_SizeChanged);
            this.pnlBuzzer.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlBuzzer_Paint);
            // 
            // lblNumber
            // 
            this.lblNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 192F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNumber.ForeColor = System.Drawing.Color.Black;
            this.lblNumber.Location = new System.Drawing.Point(0, 0);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(192, 192);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "1";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BuzzerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlMain);
            this.Name = "BuzzerUI";
            this.Size = new System.Drawing.Size(200, 600);
            this.tlMain.ResumeLayout(false);
            this.tlMain.PerformLayout();
            this.pnlBuzzer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlMain;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnOrange;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnYellow;
        private System.Windows.Forms.Panel pnlBuzzer;
        private System.Windows.Forms.Label lblNumber;
    }
}
