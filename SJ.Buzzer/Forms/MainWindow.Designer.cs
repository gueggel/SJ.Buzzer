namespace SJ.App.Buzzer
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFullscreen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQueryBuzzer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuerySelector = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuerySep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuQueryReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuerySep2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuQueryTimer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSound = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSoundWrongAnswer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSoundCorrectAnswer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSoundDaramtic = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSoundFanfare = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSoundApplause = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSoundIntro = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSoundWrongAnswerRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSoundStop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBuzzer1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBuzzer1Sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuBuzzer1None = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBuzzer2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBuzzer2Sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuBuzzer2None = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetupSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuReReadControllers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetupSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSetupCountdown = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetupSoundButtonStopCountdown = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetupEndCountdownStartBuzzer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetupSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSetupLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageGerman = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tlMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbSounds = new System.Windows.Forms.GroupBox();
            this.flButtonsSound = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSoundWrongAnswer = new System.Windows.Forms.Button();
            this.btnSoundCorrectAnswer = new System.Windows.Forms.Button();
            this.buttonSoundDramatic = new System.Windows.Forms.Button();
            this.btnSoundFanfare = new System.Windows.Forms.Button();
            this.btnSoundApplause = new System.Windows.Forms.Button();
            this.btnSoundIntro = new System.Windows.Forms.Button();
            this.btnSoundWrongAnswerRestart = new System.Windows.Forms.Button();
            this.btnSoundStop = new System.Windows.Forms.Button();
            this.tlBottom = new System.Windows.Forms.TableLayoutPanel();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.flButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStartSelector = new System.Windows.Forms.Button();
            this.btnStartBuzzer = new System.Windows.Forms.Button();
            this.gbTimer = new System.Windows.Forms.GroupBox();
            this.tlTimer = new System.Windows.Forms.TableLayoutPanel();
            this.btnTimerStartStop = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.barTimer = new System.Windows.Forms.ProgressBar();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.lblPlayer3 = new System.Windows.Forms.Label();
            this.lblPlayer4 = new System.Windows.Forms.Label();
            this.lblPlayer5 = new System.Windows.Forms.Label();
            this.lblPlayer6 = new System.Windows.Forms.Label();
            this.lblPlayer7 = new System.Windows.Forms.Label();
            this.lblPlayer8 = new System.Windows.Forms.Label();
            this.ctrlBuzzer1 = new SJ.App.Buzzer.Controls.BuzzerUI();
            this.ctrlBuzzer2 = new SJ.App.Buzzer.Controls.BuzzerUI();
            this.ctrlBuzzer3 = new SJ.App.Buzzer.Controls.BuzzerUI();
            this.ctrlBuzzer4 = new SJ.App.Buzzer.Controls.BuzzerUI();
            this.ctrlBuzzer5 = new SJ.App.Buzzer.Controls.BuzzerUI();
            this.ctrlBuzzer6 = new SJ.App.Buzzer.Controls.BuzzerUI();
            this.ctrlBuzzer7 = new SJ.App.Buzzer.Controls.BuzzerUI();
            this.ctrlBuzzer8 = new SJ.App.Buzzer.Controls.BuzzerUI();
            this.msMain.SuspendLayout();
            this.tlMain.SuspendLayout();
            this.gbSounds.SuspendLayout();
            this.flButtonsSound.SuspendLayout();
            this.tlBottom.SuspendLayout();
            this.gbQuery.SuspendLayout();
            this.flButtons.SuspendLayout();
            this.gbTimer.SuspendLayout();
            this.tlTimer.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.SystemColors.Control;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuView,
            this.menuQuery,
            this.menuSound,
            this.menuSetup,
            this.menuHelp});
            resources.ApplyResources(this.msMain, "msMain");
            this.msMain.Name = "msMain";
            // 
            // menuFile
            // 
            this.menuFile.BackColor = System.Drawing.SystemColors.Control;
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuQuit});
            resources.ApplyResources(this.menuFile, "menuFile");
            this.menuFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuFile.Name = "menuFile";
            // 
            // menuQuit
            // 
            this.menuQuit.BackColor = System.Drawing.SystemColors.Control;
            this.menuQuit.Image = global::SJ.App.Buzzer.Properties.Resources.exit;
            this.menuQuit.Name = "menuQuit";
            resources.ApplyResources(this.menuQuit, "menuQuit");
            this.menuQuit.Click += new System.EventHandler(this.MenuQuit_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFullscreen});
            resources.ApplyResources(this.menuView, "menuView");
            this.menuView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuView.Name = "menuView";
            // 
            // menuFullscreen
            // 
            this.menuFullscreen.Image = global::SJ.App.Buzzer.Properties.Resources.view_fullscreen;
            this.menuFullscreen.Name = "menuFullscreen";
            resources.ApplyResources(this.menuFullscreen, "menuFullscreen");
            this.menuFullscreen.Click += new System.EventHandler(this.MenuFullscreen_Click);
            // 
            // menuQuery
            // 
            this.menuQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuQueryBuzzer,
            this.menuQuerySelector,
            this.menuQuerySep1,
            this.menuQueryReset,
            this.menuQuerySep2,
            this.menuQueryTimer});
            resources.ApplyResources(this.menuQuery, "menuQuery");
            this.menuQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuQuery.Name = "menuQuery";
            // 
            // menuQueryBuzzer
            // 
            this.menuQueryBuzzer.Image = global::SJ.App.Buzzer.Properties.Resources.ledred;
            this.menuQueryBuzzer.Name = "menuQueryBuzzer";
            resources.ApplyResources(this.menuQueryBuzzer, "menuQueryBuzzer");
            this.menuQueryBuzzer.Click += new System.EventHandler(this.BtnStartBuzzer_Click);
            // 
            // menuQuerySelector
            // 
            this.menuQuerySelector.Image = global::SJ.App.Buzzer.Properties.Resources.edit_remove;
            this.menuQuerySelector.Name = "menuQuerySelector";
            resources.ApplyResources(this.menuQuerySelector, "menuQuerySelector");
            this.menuQuerySelector.Click += new System.EventHandler(this.BtnStartSelector_Click);
            // 
            // menuQuerySep1
            // 
            this.menuQuerySep1.Name = "menuQuerySep1";
            resources.ApplyResources(this.menuQuerySep1, "menuQuerySep1");
            // 
            // menuQueryReset
            // 
            this.menuQueryReset.Image = global::SJ.App.Buzzer.Properties.Resources.reload;
            this.menuQueryReset.Name = "menuQueryReset";
            resources.ApplyResources(this.menuQueryReset, "menuQueryReset");
            this.menuQueryReset.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // menuQuerySep2
            // 
            this.menuQuerySep2.Name = "menuQuerySep2";
            resources.ApplyResources(this.menuQuerySep2, "menuQuerySep2");
            // 
            // menuQueryTimer
            // 
            this.menuQueryTimer.Image = global::SJ.App.Buzzer.Properties.Resources.kalarm;
            this.menuQueryTimer.Name = "menuQueryTimer";
            resources.ApplyResources(this.menuQueryTimer, "menuQueryTimer");
            this.menuQueryTimer.Click += new System.EventHandler(this.BtnTimerStartStop_Click);
            // 
            // menuSound
            // 
            this.menuSound.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSoundWrongAnswer,
            this.menuSoundCorrectAnswer,
            this.menuSoundDaramtic,
            this.menuSoundFanfare,
            this.menuSoundApplause,
            this.menuSoundIntro,
            this.toolStripSeparator1,
            this.menuSoundWrongAnswerRestart,
            this.toolStripSeparator2,
            this.menuSoundStop});
            this.menuSound.Name = "menuSound";
            resources.ApplyResources(this.menuSound, "menuSound");
            // 
            // menuSoundWrongAnswer
            // 
            this.menuSoundWrongAnswer.Image = global::SJ.App.Buzzer.Properties.Resources.cancel;
            this.menuSoundWrongAnswer.Name = "menuSoundWrongAnswer";
            resources.ApplyResources(this.menuSoundWrongAnswer, "menuSoundWrongAnswer");
            this.menuSoundWrongAnswer.Click += new System.EventHandler(this.BtnSoundWrongAnswer_Click);
            // 
            // menuSoundCorrectAnswer
            // 
            this.menuSoundCorrectAnswer.Image = global::SJ.App.Buzzer.Properties.Resources.button_ok;
            this.menuSoundCorrectAnswer.Name = "menuSoundCorrectAnswer";
            resources.ApplyResources(this.menuSoundCorrectAnswer, "menuSoundCorrectAnswer");
            this.menuSoundCorrectAnswer.Click += new System.EventHandler(this.BtnSoundCorrectAnswer_Click);
            // 
            // menuSoundDaramtic
            // 
            this.menuSoundDaramtic.Image = global::SJ.App.Buzzer.Properties.Resources.core;
            this.menuSoundDaramtic.Name = "menuSoundDaramtic";
            resources.ApplyResources(this.menuSoundDaramtic, "menuSoundDaramtic");
            this.menuSoundDaramtic.Click += new System.EventHandler(this.BtnSoundDramatic_Click);
            // 
            // menuSoundFanfare
            // 
            this.menuSoundFanfare.Image = global::SJ.App.Buzzer.Properties.Resources.services;
            this.menuSoundFanfare.Name = "menuSoundFanfare";
            resources.ApplyResources(this.menuSoundFanfare, "menuSoundFanfare");
            this.menuSoundFanfare.Click += new System.EventHandler(this.BtnSoundFanfare_Click);
            // 
            // menuSoundApplause
            // 
            this.menuSoundApplause.Image = global::SJ.App.Buzzer.Properties.Resources.kuser;
            this.menuSoundApplause.Name = "menuSoundApplause";
            resources.ApplyResources(this.menuSoundApplause, "menuSoundApplause");
            this.menuSoundApplause.Click += new System.EventHandler(this.BtnSoundApplause_Click);
            // 
            // menuSoundIntro
            // 
            this.menuSoundIntro.Image = global::SJ.App.Buzzer.Properties.Resources.knotify;
            this.menuSoundIntro.Name = "menuSoundIntro";
            resources.ApplyResources(this.menuSoundIntro, "menuSoundIntro");
            this.menuSoundIntro.Click += new System.EventHandler(this.BtnSoundIntro_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // menuSoundWrongAnswerRestart
            // 
            this.menuSoundWrongAnswerRestart.Image = global::SJ.App.Buzzer.Properties.Resources.cancel;
            this.menuSoundWrongAnswerRestart.Name = "menuSoundWrongAnswerRestart";
            resources.ApplyResources(this.menuSoundWrongAnswerRestart, "menuSoundWrongAnswerRestart");
            this.menuSoundWrongAnswerRestart.Click += new System.EventHandler(this.BtnSoundWrongAnswerRestart_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // menuSoundStop
            // 
            this.menuSoundStop.Image = global::SJ.App.Buzzer.Properties.Resources.player_stop;
            this.menuSoundStop.Name = "menuSoundStop";
            resources.ApplyResources(this.menuSoundStop, "menuSoundStop");
            this.menuSoundStop.Click += new System.EventHandler(this.BtnSoundStop_Click);
            // 
            // menuSetup
            // 
            this.menuSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBuzzer1,
            this.menuBuzzer2,
            this.menuSetupSep1,
            this.menuReReadControllers,
            this.menuSetupSep2,
            this.menuSetupCountdown,
            this.menuSetupSoundButtonStopCountdown,
            this.menuSetupEndCountdownStartBuzzer,
            this.menuSetupSep3,
            this.menuSetupLanguage});
            resources.ApplyResources(this.menuSetup, "menuSetup");
            this.menuSetup.Name = "menuSetup";
            // 
            // menuBuzzer1
            // 
            this.menuBuzzer1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBuzzer1Sep1,
            this.menuBuzzer1None});
            this.menuBuzzer1.Image = global::SJ.App.Buzzer.Properties.Resources.ledred;
            this.menuBuzzer1.Name = "menuBuzzer1";
            resources.ApplyResources(this.menuBuzzer1, "menuBuzzer1");
            this.menuBuzzer1.DropDownOpening += new System.EventHandler(this.MenuBuzzer1_DropDownOpening);
            // 
            // menuBuzzer1Sep1
            // 
            this.menuBuzzer1Sep1.Name = "menuBuzzer1Sep1";
            resources.ApplyResources(this.menuBuzzer1Sep1, "menuBuzzer1Sep1");
            // 
            // menuBuzzer1None
            // 
            this.menuBuzzer1None.Name = "menuBuzzer1None";
            resources.ApplyResources(this.menuBuzzer1None, "menuBuzzer1None");
            this.menuBuzzer1None.Click += new System.EventHandler(this.MenuBuzzer1None_Click);
            // 
            // menuBuzzer2
            // 
            this.menuBuzzer2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBuzzer2Sep1,
            this.menuBuzzer2None});
            this.menuBuzzer2.Image = global::SJ.App.Buzzer.Properties.Resources.ledred;
            this.menuBuzzer2.Name = "menuBuzzer2";
            resources.ApplyResources(this.menuBuzzer2, "menuBuzzer2");
            this.menuBuzzer2.DropDownOpening += new System.EventHandler(this.MenuBuzzer2_DropDownOpening);
            // 
            // menuBuzzer2Sep1
            // 
            this.menuBuzzer2Sep1.Name = "menuBuzzer2Sep1";
            resources.ApplyResources(this.menuBuzzer2Sep1, "menuBuzzer2Sep1");
            // 
            // menuBuzzer2None
            // 
            this.menuBuzzer2None.Name = "menuBuzzer2None";
            resources.ApplyResources(this.menuBuzzer2None, "menuBuzzer2None");
            this.menuBuzzer2None.Click += new System.EventHandler(this.MenuBuzzer2None_Click);
            // 
            // menuSetupSep1
            // 
            this.menuSetupSep1.Name = "menuSetupSep1";
            resources.ApplyResources(this.menuSetupSep1, "menuSetupSep1");
            // 
            // menuReReadControllers
            // 
            this.menuReReadControllers.Image = global::SJ.App.Buzzer.Properties.Resources.reload;
            this.menuReReadControllers.Name = "menuReReadControllers";
            resources.ApplyResources(this.menuReReadControllers, "menuReReadControllers");
            this.menuReReadControllers.Click += new System.EventHandler(this.MenuReReadControllers_Click);
            // 
            // menuSetupSep2
            // 
            this.menuSetupSep2.Name = "menuSetupSep2";
            resources.ApplyResources(this.menuSetupSep2, "menuSetupSep2");
            // 
            // menuSetupCountdown
            // 
            this.menuSetupCountdown.Image = global::SJ.App.Buzzer.Properties.Resources.kalarm;
            this.menuSetupCountdown.Name = "menuSetupCountdown";
            resources.ApplyResources(this.menuSetupCountdown, "menuSetupCountdown");
            this.menuSetupCountdown.Click += new System.EventHandler(this.MenuSetupCountdown_Click);
            // 
            // menuSetupSoundButtonStopCountdown
            // 
            this.menuSetupSoundButtonStopCountdown.Checked = true;
            this.menuSetupSoundButtonStopCountdown.CheckOnClick = true;
            this.menuSetupSoundButtonStopCountdown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuSetupSoundButtonStopCountdown.Name = "menuSetupSoundButtonStopCountdown";
            resources.ApplyResources(this.menuSetupSoundButtonStopCountdown, "menuSetupSoundButtonStopCountdown");
            // 
            // menuSetupEndCountdownStartBuzzer
            // 
            this.menuSetupEndCountdownStartBuzzer.Checked = true;
            this.menuSetupEndCountdownStartBuzzer.CheckOnClick = true;
            this.menuSetupEndCountdownStartBuzzer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuSetupEndCountdownStartBuzzer.Name = "menuSetupEndCountdownStartBuzzer";
            resources.ApplyResources(this.menuSetupEndCountdownStartBuzzer, "menuSetupEndCountdownStartBuzzer");
            // 
            // menuSetupSep3
            // 
            this.menuSetupSep3.Name = "menuSetupSep3";
            resources.ApplyResources(this.menuSetupSep3, "menuSetupSep3");
            // 
            // menuSetupLanguage
            // 
            this.menuSetupLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLanguageGerman,
            this.menuLanguageEnglish});
            this.menuSetupLanguage.Image = global::SJ.App.Buzzer.Properties.Resources.locale;
            this.menuSetupLanguage.Name = "menuSetupLanguage";
            resources.ApplyResources(this.menuSetupLanguage, "menuSetupLanguage");
            // 
            // menuLanguageGerman
            // 
            this.menuLanguageGerman.Name = "menuLanguageGerman";
            resources.ApplyResources(this.menuLanguageGerman, "menuLanguageGerman");
            this.menuLanguageGerman.Click += new System.EventHandler(this.MenuLanguageGerman_Click);
            // 
            // menuLanguageEnglish
            // 
            this.menuLanguageEnglish.Name = "menuLanguageEnglish";
            resources.ApplyResources(this.menuLanguageEnglish, "menuLanguageEnglish");
            this.menuLanguageEnglish.Click += new System.EventHandler(this.MenuLanguageEnglish_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInfo});
            resources.ApplyResources(this.menuHelp, "menuHelp");
            this.menuHelp.Name = "menuHelp";
            // 
            // menuInfo
            // 
            this.menuInfo.Image = global::SJ.App.Buzzer.Properties.Resources.messagebox_info;
            this.menuInfo.Name = "menuInfo";
            resources.ApplyResources(this.menuInfo, "menuInfo");
            this.menuInfo.Click += new System.EventHandler(this.MenuInfo_Click);
            // 
            // tlMain
            // 
            resources.ApplyResources(this.tlMain, "tlMain");
            this.tlMain.BackColor = System.Drawing.SystemColors.Control;
            this.tlMain.Controls.Add(this.gbSounds, 0, 2);
            this.tlMain.Controls.Add(this.tlBottom, 0, 3);
            this.tlMain.Controls.Add(this.lblPlayer1, 0, 0);
            this.tlMain.Controls.Add(this.lblPlayer2, 1, 0);
            this.tlMain.Controls.Add(this.lblPlayer3, 2, 0);
            this.tlMain.Controls.Add(this.lblPlayer4, 3, 0);
            this.tlMain.Controls.Add(this.lblPlayer5, 4, 0);
            this.tlMain.Controls.Add(this.lblPlayer6, 5, 0);
            this.tlMain.Controls.Add(this.lblPlayer7, 6, 0);
            this.tlMain.Controls.Add(this.lblPlayer8, 7, 0);
            this.tlMain.Controls.Add(this.ctrlBuzzer1, 0, 1);
            this.tlMain.Controls.Add(this.ctrlBuzzer2, 1, 1);
            this.tlMain.Controls.Add(this.ctrlBuzzer3, 2, 1);
            this.tlMain.Controls.Add(this.ctrlBuzzer4, 3, 1);
            this.tlMain.Controls.Add(this.ctrlBuzzer5, 4, 1);
            this.tlMain.Controls.Add(this.ctrlBuzzer6, 5, 1);
            this.tlMain.Controls.Add(this.ctrlBuzzer7, 6, 1);
            this.tlMain.Controls.Add(this.ctrlBuzzer8, 7, 1);
            this.tlMain.Name = "tlMain";
            // 
            // gbSounds
            // 
            resources.ApplyResources(this.gbSounds, "gbSounds");
            this.tlMain.SetColumnSpan(this.gbSounds, 8);
            this.gbSounds.Controls.Add(this.flButtonsSound);
            this.gbSounds.Name = "gbSounds";
            this.gbSounds.TabStop = false;
            // 
            // flButtonsSound
            // 
            resources.ApplyResources(this.flButtonsSound, "flButtonsSound");
            this.flButtonsSound.Controls.Add(this.btnSoundWrongAnswer);
            this.flButtonsSound.Controls.Add(this.btnSoundCorrectAnswer);
            this.flButtonsSound.Controls.Add(this.buttonSoundDramatic);
            this.flButtonsSound.Controls.Add(this.btnSoundFanfare);
            this.flButtonsSound.Controls.Add(this.btnSoundApplause);
            this.flButtonsSound.Controls.Add(this.btnSoundIntro);
            this.flButtonsSound.Controls.Add(this.btnSoundWrongAnswerRestart);
            this.flButtonsSound.Controls.Add(this.btnSoundStop);
            this.flButtonsSound.Name = "flButtonsSound";
            // 
            // btnSoundWrongAnswer
            // 
            resources.ApplyResources(this.btnSoundWrongAnswer, "btnSoundWrongAnswer");
            this.btnSoundWrongAnswer.Image = global::SJ.App.Buzzer.Properties.Resources.cancel;
            this.btnSoundWrongAnswer.Name = "btnSoundWrongAnswer";
            this.btnSoundWrongAnswer.Tag = "cancel";
            this.btnSoundWrongAnswer.UseVisualStyleBackColor = true;
            this.btnSoundWrongAnswer.Click += new System.EventHandler(this.BtnSoundWrongAnswer_Click);
            // 
            // btnSoundCorrectAnswer
            // 
            resources.ApplyResources(this.btnSoundCorrectAnswer, "btnSoundCorrectAnswer");
            this.btnSoundCorrectAnswer.Image = global::SJ.App.Buzzer.Properties.Resources.button_ok;
            this.btnSoundCorrectAnswer.Name = "btnSoundCorrectAnswer";
            this.btnSoundCorrectAnswer.Tag = "button_ok";
            this.btnSoundCorrectAnswer.UseVisualStyleBackColor = true;
            this.btnSoundCorrectAnswer.Click += new System.EventHandler(this.BtnSoundCorrectAnswer_Click);
            // 
            // buttonSoundDramatic
            // 
            resources.ApplyResources(this.buttonSoundDramatic, "buttonSoundDramatic");
            this.buttonSoundDramatic.Image = global::SJ.App.Buzzer.Properties.Resources.core;
            this.buttonSoundDramatic.Name = "buttonSoundDramatic";
            this.buttonSoundDramatic.Tag = "core";
            this.buttonSoundDramatic.UseVisualStyleBackColor = true;
            this.buttonSoundDramatic.Click += new System.EventHandler(this.BtnSoundDramatic_Click);
            // 
            // btnSoundFanfare
            // 
            resources.ApplyResources(this.btnSoundFanfare, "btnSoundFanfare");
            this.btnSoundFanfare.Image = global::SJ.App.Buzzer.Properties.Resources.services;
            this.btnSoundFanfare.Name = "btnSoundFanfare";
            this.btnSoundFanfare.Tag = "services";
            this.btnSoundFanfare.UseVisualStyleBackColor = true;
            this.btnSoundFanfare.Click += new System.EventHandler(this.BtnSoundFanfare_Click);
            // 
            // btnSoundApplause
            // 
            resources.ApplyResources(this.btnSoundApplause, "btnSoundApplause");
            this.btnSoundApplause.Image = global::SJ.App.Buzzer.Properties.Resources.kuser;
            this.btnSoundApplause.Name = "btnSoundApplause";
            this.btnSoundApplause.Tag = "kuser";
            this.btnSoundApplause.UseVisualStyleBackColor = true;
            this.btnSoundApplause.Click += new System.EventHandler(this.BtnSoundApplause_Click);
            // 
            // btnSoundIntro
            // 
            resources.ApplyResources(this.btnSoundIntro, "btnSoundIntro");
            this.btnSoundIntro.Image = global::SJ.App.Buzzer.Properties.Resources.knotify;
            this.btnSoundIntro.Name = "btnSoundIntro";
            this.btnSoundIntro.Tag = "knotify";
            this.btnSoundIntro.UseVisualStyleBackColor = true;
            this.btnSoundIntro.Click += new System.EventHandler(this.BtnSoundIntro_Click);
            // 
            // btnSoundWrongAnswerRestart
            // 
            resources.ApplyResources(this.btnSoundWrongAnswerRestart, "btnSoundWrongAnswerRestart");
            this.btnSoundWrongAnswerRestart.Image = global::SJ.App.Buzzer.Properties.Resources.cancel;
            this.btnSoundWrongAnswerRestart.Name = "btnSoundWrongAnswerRestart";
            this.btnSoundWrongAnswerRestart.Tag = "cancel";
            this.btnSoundWrongAnswerRestart.UseVisualStyleBackColor = true;
            this.btnSoundWrongAnswerRestart.Click += new System.EventHandler(this.BtnSoundWrongAnswerRestart_Click);
            // 
            // btnSoundStop
            // 
            resources.ApplyResources(this.btnSoundStop, "btnSoundStop");
            this.btnSoundStop.Image = global::SJ.App.Buzzer.Properties.Resources.player_stop;
            this.btnSoundStop.Name = "btnSoundStop";
            this.btnSoundStop.Tag = "player_stop";
            this.btnSoundStop.UseVisualStyleBackColor = true;
            this.btnSoundStop.Click += new System.EventHandler(this.BtnSoundStop_Click);
            // 
            // tlBottom
            // 
            resources.ApplyResources(this.tlBottom, "tlBottom");
            this.tlMain.SetColumnSpan(this.tlBottom, 8);
            this.tlBottom.Controls.Add(this.gbQuery, 1, 0);
            this.tlBottom.Controls.Add(this.gbTimer, 0, 0);
            this.tlBottom.Name = "tlBottom";
            // 
            // gbQuery
            // 
            resources.ApplyResources(this.gbQuery, "gbQuery");
            this.gbQuery.Controls.Add(this.flButtons);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.TabStop = false;
            // 
            // flButtons
            // 
            resources.ApplyResources(this.flButtons, "flButtons");
            this.flButtons.Controls.Add(this.btnClear);
            this.flButtons.Controls.Add(this.btnStartSelector);
            this.flButtons.Controls.Add(this.btnStartBuzzer);
            this.flButtons.Name = "flButtons";
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClear.Image = global::SJ.App.Buzzer.Properties.Resources.reload;
            this.btnClear.Name = "btnClear";
            this.btnClear.Tag = "reload";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnStartSelector
            // 
            resources.ApplyResources(this.btnStartSelector, "btnStartSelector");
            this.btnStartSelector.BackColor = System.Drawing.SystemColors.Control;
            this.btnStartSelector.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStartSelector.Image = global::SJ.App.Buzzer.Properties.Resources.edit_remove;
            this.btnStartSelector.Name = "btnStartSelector";
            this.btnStartSelector.Tag = "edit_remove";
            this.btnStartSelector.UseVisualStyleBackColor = false;
            this.btnStartSelector.Click += new System.EventHandler(this.BtnStartSelector_Click);
            // 
            // btnStartBuzzer
            // 
            resources.ApplyResources(this.btnStartBuzzer, "btnStartBuzzer");
            this.btnStartBuzzer.BackColor = System.Drawing.SystemColors.Control;
            this.btnStartBuzzer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStartBuzzer.Image = global::SJ.App.Buzzer.Properties.Resources.ledred;
            this.btnStartBuzzer.Name = "btnStartBuzzer";
            this.btnStartBuzzer.Tag = "ledred";
            this.btnStartBuzzer.UseVisualStyleBackColor = false;
            this.btnStartBuzzer.Click += new System.EventHandler(this.BtnStartBuzzer_Click);
            // 
            // gbTimer
            // 
            resources.ApplyResources(this.gbTimer, "gbTimer");
            this.gbTimer.Controls.Add(this.tlTimer);
            this.gbTimer.Name = "gbTimer";
            this.gbTimer.TabStop = false;
            // 
            // tlTimer
            // 
            resources.ApplyResources(this.tlTimer, "tlTimer");
            this.tlTimer.Controls.Add(this.btnTimerStartStop, 2, 0);
            this.tlTimer.Controls.Add(this.lblTimer, 0, 0);
            this.tlTimer.Controls.Add(this.barTimer, 1, 0);
            this.tlTimer.Name = "tlTimer";
            // 
            // btnTimerStartStop
            // 
            resources.ApplyResources(this.btnTimerStartStop, "btnTimerStartStop");
            this.btnTimerStartStop.Image = global::SJ.App.Buzzer.Properties.Resources.player_play;
            this.btnTimerStartStop.Name = "btnTimerStartStop";
            this.btnTimerStartStop.Tag = "player_play";
            this.btnTimerStartStop.UseVisualStyleBackColor = true;
            this.btnTimerStartStop.Click += new System.EventHandler(this.BtnTimerStartStop_Click);
            // 
            // lblTimer
            // 
            resources.ApplyResources(this.lblTimer, "lblTimer");
            this.lblTimer.Name = "lblTimer";
            // 
            // barTimer
            // 
            resources.ApplyResources(this.barTimer, "barTimer");
            this.barTimer.Name = "barTimer";
            this.barTimer.Step = 1;
            this.barTimer.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // lblPlayer1
            // 
            resources.ApplyResources(this.lblPlayer1, "lblPlayer1");
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Click += new System.EventHandler(this.LblPlayer_Click);
            // 
            // lblPlayer2
            // 
            resources.ApplyResources(this.lblPlayer2, "lblPlayer2");
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Click += new System.EventHandler(this.LblPlayer_Click);
            // 
            // lblPlayer3
            // 
            resources.ApplyResources(this.lblPlayer3, "lblPlayer3");
            this.lblPlayer3.Name = "lblPlayer3";
            this.lblPlayer3.Click += new System.EventHandler(this.LblPlayer_Click);
            // 
            // lblPlayer4
            // 
            resources.ApplyResources(this.lblPlayer4, "lblPlayer4");
            this.lblPlayer4.Name = "lblPlayer4";
            this.lblPlayer4.Click += new System.EventHandler(this.LblPlayer_Click);
            // 
            // lblPlayer5
            // 
            resources.ApplyResources(this.lblPlayer5, "lblPlayer5");
            this.lblPlayer5.Name = "lblPlayer5";
            this.lblPlayer5.Click += new System.EventHandler(this.LblPlayer_Click);
            // 
            // lblPlayer6
            // 
            resources.ApplyResources(this.lblPlayer6, "lblPlayer6");
            this.lblPlayer6.Name = "lblPlayer6";
            this.lblPlayer6.Click += new System.EventHandler(this.LblPlayer_Click);
            // 
            // lblPlayer7
            // 
            resources.ApplyResources(this.lblPlayer7, "lblPlayer7");
            this.lblPlayer7.Name = "lblPlayer7";
            this.lblPlayer7.Click += new System.EventHandler(this.LblPlayer_Click);
            // 
            // lblPlayer8
            // 
            resources.ApplyResources(this.lblPlayer8, "lblPlayer8");
            this.lblPlayer8.Name = "lblPlayer8";
            this.lblPlayer8.Click += new System.EventHandler(this.LblPlayer_Click);
            // 
            // ctrlBuzzer1
            // 
            resources.ApplyResources(this.ctrlBuzzer1, "ctrlBuzzer1");
            this.ctrlBuzzer1.Name = "ctrlBuzzer1";
            this.ctrlBuzzer1.Number = ((byte)(1));
            // 
            // ctrlBuzzer2
            // 
            resources.ApplyResources(this.ctrlBuzzer2, "ctrlBuzzer2");
            this.ctrlBuzzer2.Name = "ctrlBuzzer2";
            this.ctrlBuzzer2.Number = ((byte)(2));
            // 
            // ctrlBuzzer3
            // 
            resources.ApplyResources(this.ctrlBuzzer3, "ctrlBuzzer3");
            this.ctrlBuzzer3.Name = "ctrlBuzzer3";
            this.ctrlBuzzer3.Number = ((byte)(3));
            // 
            // ctrlBuzzer4
            // 
            resources.ApplyResources(this.ctrlBuzzer4, "ctrlBuzzer4");
            this.ctrlBuzzer4.Name = "ctrlBuzzer4";
            this.ctrlBuzzer4.Number = ((byte)(4));
            // 
            // ctrlBuzzer5
            // 
            resources.ApplyResources(this.ctrlBuzzer5, "ctrlBuzzer5");
            this.ctrlBuzzer5.Name = "ctrlBuzzer5";
            this.ctrlBuzzer5.Number = ((byte)(5));
            // 
            // ctrlBuzzer6
            // 
            resources.ApplyResources(this.ctrlBuzzer6, "ctrlBuzzer6");
            this.ctrlBuzzer6.Name = "ctrlBuzzer6";
            this.ctrlBuzzer6.Number = ((byte)(6));
            // 
            // ctrlBuzzer7
            // 
            resources.ApplyResources(this.ctrlBuzzer7, "ctrlBuzzer7");
            this.ctrlBuzzer7.Name = "ctrlBuzzer7";
            this.ctrlBuzzer7.Number = ((byte)(7));
            // 
            // ctrlBuzzer8
            // 
            resources.ApplyResources(this.ctrlBuzzer8, "ctrlBuzzer8");
            this.ctrlBuzzer8.Name = "ctrlBuzzer8";
            this.ctrlBuzzer8.Number = ((byte)(8));
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlMain);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.MainWindow_ResizeEnd);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tlMain.ResumeLayout(false);
            this.tlMain.PerformLayout();
            this.gbSounds.ResumeLayout(false);
            this.gbSounds.PerformLayout();
            this.flButtonsSound.ResumeLayout(false);
            this.flButtonsSound.PerformLayout();
            this.tlBottom.ResumeLayout(false);
            this.tlBottom.PerformLayout();
            this.gbQuery.ResumeLayout(false);
            this.gbQuery.PerformLayout();
            this.flButtons.ResumeLayout(false);
            this.flButtons.PerformLayout();
            this.gbTimer.ResumeLayout(false);
            this.gbTimer.PerformLayout();
            this.tlTimer.ResumeLayout(false);
            this.tlTimer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuQuit;
        private System.Windows.Forms.TableLayoutPanel tlMain;
        private System.Windows.Forms.ToolStripMenuItem menuQuery;
        private System.Windows.Forms.ToolStripMenuItem menuQueryBuzzer;
        private System.Windows.Forms.ToolStripMenuItem menuQuerySelector;
        private System.Windows.Forms.ToolStripSeparator menuQuerySep1;
        private System.Windows.Forms.ToolStripMenuItem menuQueryReset;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuFullscreen;
        private System.Windows.Forms.GroupBox gbSounds;
        private System.Windows.Forms.FlowLayoutPanel flButtonsSound;
        private System.Windows.Forms.Button btnSoundWrongAnswer;
        private System.Windows.Forms.Button btnSoundFanfare;
        private System.Windows.Forms.Button btnSoundCorrectAnswer;
        private System.Windows.Forms.Button buttonSoundDramatic;
        private System.Windows.Forms.ToolStripMenuItem menuSetup;
        private System.Windows.Forms.ToolStripMenuItem menuBuzzer1;
        private System.Windows.Forms.ToolStripSeparator menuBuzzer1Sep1;
        private System.Windows.Forms.ToolStripMenuItem menuBuzzer1None;
        private System.Windows.Forms.ToolStripMenuItem menuBuzzer2;
        private System.Windows.Forms.ToolStripSeparator menuBuzzer2Sep1;
        private System.Windows.Forms.ToolStripMenuItem menuBuzzer2None;
        private System.Windows.Forms.ToolStripSeparator menuSetupSep1;
        private System.Windows.Forms.ToolStripMenuItem menuReReadControllers;
        private System.Windows.Forms.TableLayoutPanel tlBottom;
        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.FlowLayoutPanel flButtons;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStartSelector;
        private System.Windows.Forms.Button btnStartBuzzer;
        private System.Windows.Forms.GroupBox gbTimer;
        private System.Windows.Forms.TableLayoutPanel tlTimer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.ProgressBar barTimer;
        private System.Windows.Forms.ToolStripSeparator menuQuerySep2;
        private System.Windows.Forms.ToolStripMenuItem menuQueryTimer;
        private System.Windows.Forms.ToolStripMenuItem menuSetupCountdown;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuInfo;
        private System.Windows.Forms.Button btnSoundApplause;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label lblPlayer3;
        private System.Windows.Forms.Label lblPlayer4;
        private System.Windows.Forms.Label lblPlayer5;
        private System.Windows.Forms.Label lblPlayer6;
        private System.Windows.Forms.Label lblPlayer7;
        private System.Windows.Forms.Label lblPlayer8;
        private System.Windows.Forms.Button btnSoundIntro;
        private System.Windows.Forms.Button btnSoundWrongAnswerRestart;
        private System.Windows.Forms.ToolStripSeparator menuSetupSep2;
        private System.Windows.Forms.ToolStripMenuItem menuSetupSoundButtonStopCountdown;
        private System.Windows.Forms.ToolStripMenuItem menuSetupEndCountdownStartBuzzer;
        private System.Windows.Forms.Button btnTimerStartStop;
        private System.Windows.Forms.ToolStripSeparator menuSetupSep3;
        private System.Windows.Forms.ToolStripMenuItem menuSetupLanguage;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageGerman;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageEnglish;
        private Controls.BuzzerUI ctrlBuzzer1;
        private Controls.BuzzerUI ctrlBuzzer2;
        private Controls.BuzzerUI ctrlBuzzer3;
        private Controls.BuzzerUI ctrlBuzzer4;
        private Controls.BuzzerUI ctrlBuzzer5;
        private Controls.BuzzerUI ctrlBuzzer6;
        private Controls.BuzzerUI ctrlBuzzer7;
        private Controls.BuzzerUI ctrlBuzzer8;
        private System.Windows.Forms.Button btnSoundStop;
        private System.Windows.Forms.ToolStripMenuItem menuSound;
        private System.Windows.Forms.ToolStripMenuItem menuSoundWrongAnswer;
        private System.Windows.Forms.ToolStripMenuItem menuSoundCorrectAnswer;
        private System.Windows.Forms.ToolStripMenuItem menuSoundDaramtic;
        private System.Windows.Forms.ToolStripMenuItem menuSoundFanfare;
        private System.Windows.Forms.ToolStripMenuItem menuSoundApplause;
        private System.Windows.Forms.ToolStripMenuItem menuSoundIntro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuSoundWrongAnswerRestart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuSoundStop;
    }
}

