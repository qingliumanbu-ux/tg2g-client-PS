namespace PS
{
    partial class FormPSSM18CHECK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.efTabControl1 = new EF.EFTabControl(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.efDevRadioGroup1 = new EF.EFDevRadioGroup(this.components);
            this.btn_del = new EF.EFButton();
            this.efStatusBar1 = new EF.EFStatusBar(this.components);
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.efTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efDevRadioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_del)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // efTabControl1
            // 
            this.efTabControl1.Controls.Add(this.tabPage1);
            this.efTabControl1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.efTabControl1.Location = new System.Drawing.Point(2, 2);
            this.efTabControl1.Name = "efTabControl1";
            this.efTabControl1.SelectedIndex = 0;
            this.efTabControl1.Size = new System.Drawing.Size(336, 261);
            this.efTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.efDevRadioGroup1);
            this.tabPage1.Controls.Add(this.btn_del);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(328, 213);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "计划交换模式";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // efDevRadioGroup1
            // 
            this.efDevRadioGroup1.EditValue = 1;
            this.efDevRadioGroup1.Location = new System.Drawing.Point(61, 6);
            this.efDevRadioGroup1.Name = "efDevRadioGroup1";
            this.efDevRadioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.efDevRadioGroup1.Properties.Appearance.Options.UseFont = true;
            this.efDevRadioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "钢种交换"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "计划交换")});
            this.efDevRadioGroup1.Size = new System.Drawing.Size(204, 113);
            this.efDevRadioGroup1.TabIndex = 4;
            // 
            // btn_del
            // 
            this.btn_del.FnNo = 0;
            this.btn_del.Hint = "";
            this.btn_del.Location = new System.Drawing.Point(128, 125);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btn_del.TabIndex = 1;
            this.btn_del.Text = "确认";
            this.btn_del.Click += new System.EventHandler(this.efButton1_Click);
            // 
            // efStatusBar1
            // 
            this.efStatusBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.efStatusBar1.Location = new System.Drawing.Point(0, 196);
            this.efStatusBar1.Name = "efStatusBar1";
            this.efStatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.efStatusBar1.ShowPanels = true;
            this.efStatusBar1.Size = new System.Drawing.Size(341, 19);
            this.efStatusBar1.TabIndex = 10;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 324;
            // 
            // FormPSSM18CHECK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 215);
            this.Controls.Add(this.efStatusBar1);
            this.Controls.Add(this.efTabControl1);
            this.Name = "FormPSSM18CHECK";
            this.Text = "其他";
            this.Load += new System.EventHandler(this.FormPSSM18CHECK_Load);
            this.efTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efDevRadioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_del)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFTabControl efTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private EF.EFButton btn_del;
        private EF.EFStatusBar efStatusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private EF.EFDevRadioGroup efDevRadioGroup1;
    }
}