namespace PS
{
    partial class FormPSSM18D
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
            this.efDevTextEdit2 = new EF.EFDevTextEdit(this.components);
            this.efDevTextEdit1 = new EF.EFDevTextEdit(this.components);
            this.efDevLookUpEdit1 = new EF.EFDevLookUpEdit(this.components);
            this.efLabel6 = new EF.EFLabel();
            this.efLabel7 = new EF.EFLabel();
            this.efLabel5 = new EF.EFLabel();
            this.btn_cancel = new EF.EFButton();
            this.htno_txt = new EF.EFDevTextEdit(this.components);
            this.efLabel4 = new EF.EFLabel();
            this.btn_del = new EF.EFButton();
            this.pono_txt = new EF.EFDevTextEdit(this.components);
            this.efLabel3 = new EF.EFLabel();
            this.state_txt = new EF.EFDevTextEdit(this.components);
            this.efStatusBar1 = new EF.EFStatusBar(this.components);
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.efDevTextEdit3 = new EF.EFDevTextEdit(this.components);
            this.efLabel1 = new EF.EFLabel();
            this.efTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efDevTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.htno_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_del)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pono_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.state_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevTextEdit3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // efTabControl1
            // 
            this.efTabControl1.Controls.Add(this.tabPage1);
            this.efTabControl1.Location = new System.Drawing.Point(2, 2);
            this.efTabControl1.Name = "efTabControl1";
            this.efTabControl1.SelectedIndex = 0;
            this.efTabControl1.Size = new System.Drawing.Size(336, 261);
            this.efTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.efLabel1);
            this.tabPage1.Controls.Add(this.efDevTextEdit3);
            this.tabPage1.Controls.Add(this.efDevTextEdit2);
            this.tabPage1.Controls.Add(this.efDevTextEdit1);
            this.tabPage1.Controls.Add(this.efDevLookUpEdit1);
            this.tabPage1.Controls.Add(this.efLabel6);
            this.tabPage1.Controls.Add(this.efLabel7);
            this.tabPage1.Controls.Add(this.efLabel5);
            this.tabPage1.Controls.Add(this.btn_cancel);
            this.tabPage1.Controls.Add(this.htno_txt);
            this.tabPage1.Controls.Add(this.efLabel4);
            this.tabPage1.Controls.Add(this.btn_del);
            this.tabPage1.Controls.Add(this.pono_txt);
            this.tabPage1.Controls.Add(this.efLabel3);
            this.tabPage1.Controls.Add(this.state_txt);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(328, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "计划删除";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // efDevTextEdit2
            // 
            this.efDevTextEdit2.Enabled = false;
            this.efDevTextEdit2.Location = new System.Drawing.Point(71, 50);
            this.efDevTextEdit2.Name = "efDevTextEdit2";
            this.efDevTextEdit2.Size = new System.Drawing.Size(92, 20);
            this.efDevTextEdit2.TabIndex = 17;
            // 
            // efDevTextEdit1
            // 
            this.efDevTextEdit1.Enabled = false;
            this.efDevTextEdit1.Location = new System.Drawing.Point(125, 109);
            this.efDevTextEdit1.Name = "efDevTextEdit1";
            this.efDevTextEdit1.Size = new System.Drawing.Size(92, 20);
            this.efDevTextEdit1.TabIndex = 16;
            this.efDevTextEdit1.Visible = false;
            // 
            // efDevLookUpEdit1
            // 
            this.efDevLookUpEdit1.Location = new System.Drawing.Point(222, 50);
            this.efDevLookUpEdit1.Name = "efDevLookUpEdit1";
            this.efDevLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.efDevLookUpEdit1.Properties.NullText = "";
            this.efDevLookUpEdit1.Size = new System.Drawing.Size(100, 20);
            this.efDevLookUpEdit1.TabIndex = 13;
            this.efDevLookUpEdit1.EditValueChanged += new System.EventHandler(this.efDevLookUpEdit1_EditValueChanged);
            // 
            // efLabel6
            // 
            this.efLabel6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel6.Location = new System.Drawing.Point(169, 53);
            this.efLabel6.Name = "efLabel6";
            this.efLabel6.Size = new System.Drawing.Size(48, 14);
            this.efLabel6.TabIndex = 12;
            this.efLabel6.Text = "设备代码";
            // 
            // efLabel7
            // 
            this.efLabel7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel7.Location = new System.Drawing.Point(17, 53);
            this.efLabel7.Name = "efLabel7";
            this.efLabel7.Size = new System.Drawing.Size(60, 14);
            this.efLabel7.TabIndex = 11;
            this.efLabel7.Text = "计划号";
            // 
            // efLabel5
            // 
            this.efLabel5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel5.Location = new System.Drawing.Point(181, 20);
            this.efLabel5.Name = "efLabel5";
            this.efLabel5.Size = new System.Drawing.Size(24, 14);
            this.efLabel5.TabIndex = 11;
            this.efLabel5.Text = "炉号";
            // 
            // btn_cancel
            // 
            this.btn_cancel.FnNo = 0;
            this.btn_cancel.Hint = "";
            this.btn_cancel.Location = new System.Drawing.Point(222, 125);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "退出";
            this.btn_cancel.Click += new System.EventHandler(this.efButton3_Click);
            // 
            // htno_txt
            // 
            this.htno_txt.Enabled = false;
            this.htno_txt.Location = new System.Drawing.Point(222, 17);
            this.htno_txt.Name = "htno_txt";
            this.htno_txt.Size = new System.Drawing.Size(93, 20);
            this.htno_txt.TabIndex = 10;
            // 
            // efLabel4
            // 
            this.efLabel4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel4.Location = new System.Drawing.Point(5, 20);
            this.efLabel4.Name = "efLabel4";
            this.efLabel4.Size = new System.Drawing.Size(60, 14);
            this.efLabel4.TabIndex = 9;
            this.efLabel4.Text = "制造命令号";
            // 
            // btn_del
            // 
            this.btn_del.FnNo = 0;
            this.btn_del.Hint = "";
            this.btn_del.Location = new System.Drawing.Point(43, 125);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btn_del.TabIndex = 1;
            this.btn_del.Text = "删除";
            this.btn_del.Click += new System.EventHandler(this.efButton1_Click);
            // 
            // pono_txt
            // 
            this.pono_txt.Enabled = false;
            this.pono_txt.Location = new System.Drawing.Point(71, 17);
            this.pono_txt.Name = "pono_txt";
            this.pono_txt.Size = new System.Drawing.Size(93, 20);
            this.pono_txt.TabIndex = 8;
            // 
            // efLabel3
            // 
            this.efLabel3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel3.Location = new System.Drawing.Point(17, 86);
            this.efLabel3.Name = "efLabel3";
            this.efLabel3.Size = new System.Drawing.Size(48, 14);
            this.efLabel3.TabIndex = 7;
            this.efLabel3.Text = "计划状态";
            // 
            // state_txt
            // 
            this.state_txt.Enabled = false;
            this.state_txt.Location = new System.Drawing.Point(71, 83);
            this.state_txt.Name = "state_txt";
            this.state_txt.Size = new System.Drawing.Size(92, 20);
            this.state_txt.TabIndex = 6;
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
            // efDevTextEdit3
            // 
            this.efDevTextEdit3.Location = new System.Drawing.Point(222, 83);
            this.efDevTextEdit3.Name = "efDevTextEdit3";
            this.efDevTextEdit3.Size = new System.Drawing.Size(92, 20);
            this.efDevTextEdit3.TabIndex = 18;
            this.efDevTextEdit3.Visible = false;
            // 
            // efLabel1
            // 
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(181, 86);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(35, 14);
            this.efLabel1.TabIndex = 19;
            this.efLabel1.Text = "*密码";
            this.efLabel1.Visible = false;
            // 
            // FormPSSM18D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 215);
            this.Controls.Add(this.efStatusBar1);
            this.Controls.Add(this.efTabControl1);
            this.Name = "FormPSSM18D";
            this.Text = "其他";
            this.Load += new System.EventHandler(this.FormPSSM18D_Load);
            this.efTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efDevTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.htno_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_del)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pono_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.state_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevTextEdit3.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFTabControl efTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private EF.EFButton btn_del;
        private EF.EFButton btn_cancel;
        private EF.EFLabel efLabel3;
        private EF.EFDevTextEdit state_txt;
        private EF.EFLabel efLabel5;
        private EF.EFDevTextEdit htno_txt;
        private EF.EFLabel efLabel4;
        private EF.EFDevTextEdit pono_txt;
        private EF.EFLabel efLabel6;
        private EF.EFDevLookUpEdit efDevLookUpEdit1;
        private EF.EFStatusBar efStatusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private EF.EFLabel efLabel7;
        private EF.EFDevTextEdit efDevTextEdit1;
        private EF.EFDevTextEdit efDevTextEdit2;
        private EF.EFLabel efLabel1;
        private EF.EFDevTextEdit efDevTextEdit3;
    }
}