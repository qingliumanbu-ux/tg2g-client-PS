using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PS
{
    /// <summary>
    /// 钢水返送
    /// <para> 选择熔炼号,设置返送钢水量,返送位置,返送日期；</para>
    /// </summary>
    /// Copyright: Baosight Software LTD.co Copyright (c) 2011
    /// Company: 上海宝信软件股份有限公司
    /// Author:  lijie
    /// Version: 1.0
    /// History:
    /// 2011-11-29 lijie [创建] 
    
    public partial class FormPSSM18B : EF.EFPopupForm
    {
        public FormPSSM18B()
        {
            InitializeComponent();
        }
        public string main_backlog_code = " ";
        public string heat_no = " ";
        public string factory_div = " ";
        public string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。
        
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_RET_HEAT_NO = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_RET_PONO = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

        #region 窗体事件

        /// <summary>
        /// 画面初始化
        /// <para>查询熔炼号和返送位置</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>无</returns>
        private void FormPSSM18R_Load(object sender, EventArgs e)
        {
            if (EF.EF_Args.common_parameter_1.Trim() != "")
            {
                v_curr_part_name = EF.EF_Args.common_parameter_1;//当前画面的分区代码
            }
            EF.Utility.SetGridColumn(new EF.EFDevGrid[] { this.efDevGrid1 }, new string[] { "PSSM18R_INQ" }, v_curr_part_name);
            this.gridView1.OptionsCustomization.AllowSort = false;
            QueryHtnoPos();
            this.efDevComboBox_htno.Text = heat_no;
            
        }

        /// <summary>
        /// 返送确定按钮事件
        /// <para>校验输入项,钢水返送</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>无</returns>
        private void efBtnOk_Click(object sender, EventArgs e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;
            try
            {
                if ( (efDevComboBox_htno.EditValue ==null) || (efDevComboBox_htno.EditValue.ToString().Trim() == ""))
                {
                    efDevComboBox_htno.Focus();
                    efDevComboBox_htno.ErrorIcon = (new ErrorProvider()).Icon.ToBitmap(); //设置惊叹号
                    efDevComboBox_htno.ErrorText = "熔炼号不能为空";
                    return;
                }
                if (this.gridView1.RowCount < 1)
                {
                   // 警告类，惊叹号
                     DialogResult result = EF.EFMessageBox.Show("是否确认返送目标为空？", EF.EF_Args.epEname, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);            

                    if( result == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    if (!EFX.EFCGrid.GetEFCGridBase(efDevGrid1).ValidateGridDataEx())
                    { //若校验失败，则直接离开。

                        //this.EFMsgInfo = "请输入必输信息。";
                        EF.EFMessageBox.Show("请输入必输信息。");
                        return;
                    }
                    for (int i = 0; i < this.gridView1.RowCount; i++)
                    {//列信息
                        this.efDevGrid1.SetSelectedColumnChecked(i, true);
                    }
                   
                    inBlock.Tables[0].Merge(this.efDevGrid1.GetSelectedDataRow());
                }
                
                //if (!inBlock.Tables[0].Columns.Contains("MAIN_BACKLOG_CODE"))
                //{
                //    inBlock.Tables[0].Columns.Add("MAIN_BACKLOG_CODE", typeof(System.String));                    
                //}
                //厂别区分
                if (!inBlock.Tables[0].Columns.Contains("FACTORY_DIV"))
                {
                    inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(System.String));
                }
               
                if (!inBlock.Tables[0].Columns.Contains("HEAT_NO"))
                {
                    inBlock.Tables[0].Columns.Add("HEAT_NO", typeof(System.String));                    
                }
                if (inBlock.Tables[0].Rows.Count < 1)
                {
                    inBlock.Tables[0].Rows.Add();
                }
                //inBlock.Tables[0].Rows[0]["MAIN_BACKLOG_CODE"]  = "A";
                inBlock.Tables[0].Rows[0]["HEAT_NO"]            = this.efDevComboBox_htno.EditValue.ToString();
                inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18b_rt_upd", inBlock);
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000017/*处理失败[{0}]。*/, s.msg);
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            catch (Exception err)
            {
                this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000018/*系统出现异常[{0}]，请联系系统维护人员。*/, err.Message);
                this.DialogResult = DialogResult.None;
            }
            this.statusBarPanel1.Text = GC.GCRS.GCRSC0000009/*处理成功。*/;
            this.DialogResult = DialogResult.OK;
            this.Close();
            return;
        }
        

        /// <summary>
        /// 返送取消按钮事件
        /// <para></para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>无</returns>
        private void efBtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region 内部函数

        /// <summary>
        /// 查询熔炼号和返送位置
        /// <para>查询熔炼号和返送位置,初始化下拉框</para>
        /// </summary>
        /// <param name=""></param>
        /// <returns>无</returns>
        private void QueryHtnoPos()
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;
            int k = 0;
            try
            {
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Rows.Add(factory_div);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18b_rt_inq", inBlock);
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000043/*查询失败：{0}*/, s.msg);
                    return;
                }

                //初始化熔炼号下拉框
                if (outBlock.Tables.Contains("HTNO"))
                {
                    //DataRow row = outBlock.Tables["HTNO"].NewRow();
                    k = 0;
                    efDevComboBox_htno.Properties.Items.Clear();
                    while (k < outBlock.Tables["HTNO"].Rows.Count)
                    {
                        efDevComboBox_htno.Properties.Items.Add(outBlock.Tables[0].Rows[k]["HEAT_NO"].ToString());
                        k++;
                    }
                }
                //初始化返送位置下拉框
                if (gridView1.Columns.Contains(gridView1.Columns["RET_DEST"]))
                {
                    Common.Utility.SetGridItemLookUpEditProperty(gridView1, "RET_DEST", outBlock.Tables["POSITION"], "STATION_NAME", "DEV_CODE");
                }
                if (gridView1.Columns.Contains(gridView1.Columns["RET_HEAT_NO"]))
                {
                    gridView1.Columns["RET_HEAT_NO"].ColumnEdit = repositoryItemLookUpEdit_RET_HEAT_NO;
                    DataTable dt = outBlock.Tables["HTNO"];
                    repositoryItemLookUpEdit_RET_HEAT_NO.DataSource = dt;
                    repositoryItemLookUpEdit_RET_HEAT_NO.DisplayMember = "HEAT_NO";
                    repositoryItemLookUpEdit_RET_HEAT_NO.ValueMember = "HEAT_NO";
                    repositoryItemLookUpEdit_RET_HEAT_NO.Columns.Clear();
                    repositoryItemLookUpEdit_RET_HEAT_NO.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HEAT_NO", "返送熔炼号"));

                    this.repositoryItemLookUpEdit_RET_HEAT_NO.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    //设置控件画面输入时不会自动弹出下拉列表
                    this.repositoryItemLookUpEdit_RET_HEAT_NO.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                    this.repositoryItemLookUpEdit_RET_HEAT_NO.ProcessNewValue  += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(heat_no_ProcessNewValue);

                }
                if (gridView1.Columns.Contains(gridView1.Columns["RET_PONO"]))
                {
                    //EFX.EFCGrid.GetEFCGridBase(this.efDevGrid1).Columns["PONO"].SetPopupGridDataSource(outBlock.Tables["PONO"], "PONO", new[] { "PONO" });
                    gridView1.Columns["RET_PONO"].ColumnEdit = repositoryItemLookUpEdit_RET_PONO;
                    DataTable dt = outBlock.Tables["PONO"];
                    repositoryItemLookUpEdit_RET_PONO.DataSource = dt;
                    repositoryItemLookUpEdit_RET_PONO.DisplayMember = "PONO";
                    repositoryItemLookUpEdit_RET_PONO.ValueMember = "PONO";
                    repositoryItemLookUpEdit_RET_PONO.Columns.Clear();
                    repositoryItemLookUpEdit_RET_PONO.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PONO", "返送PONO"));

                    this.repositoryItemLookUpEdit_RET_PONO.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    //设置控件画面输入时不会自动弹出下拉列表
                    this.repositoryItemLookUpEdit_RET_PONO.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                    this.repositoryItemLookUpEdit_RET_PONO.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(pono_ProcessNewValue);


                }

            }
            catch (Exception err)
            {
                this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000018/*系统出现异常[{0}]，请联系系统维护人员。*/, err.Message);
            }
        }
        private void heat_no_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            DataTable dt = this.repositoryItemLookUpEdit_RET_HEAT_NO.DataSource as DataTable;
            DataRow dr = dt.NewRow();
            dr["HEAT_NO"] = e.DisplayValue.ToString();
            dt.Rows.Add(dr);
            e.Handled = true;
        }
        private void pono_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            DataTable dt = this.repositoryItemLookUpEdit_RET_PONO.DataSource as DataTable;
            DataRow dr = dt.NewRow();
            dr["PONO"] = e.DisplayValue.ToString();
            dt.Rows.Add(dr);
            e.Handled = true;
        }

        private void Query(string heat_no)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;
            int k = 0;
            try
            {
                inBlock.Tables[0].Columns.Add("HEAT_NO", typeof(String));
                inBlock.Tables[0].Rows.Add(heat_no);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18b_rt_inq2", inBlock);
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000043/*查询失败：{0}*/, s.msg);
                    return;
                }

                //将信息压入指定的GRID, 
                EF.Utility.SetCustomGridValue(this.efDevGrid1, outBlock, false);
                //列宽自动调整。
                this.gridView1.BestFitColumns();
            }
            catch (Exception err)
            {
                this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000018/*系统出现异常[{0}]，请联系系统维护人员。*/, err.Message);
            }
        }

        #endregion

        private void efDevComboBox_htno_SelectedValueChanged(object sender, EventArgs e)
        {
            string heat_no = "";
            if (this.efDevComboBox_htno.EditValue != null)
            {
                heat_no = efDevComboBox_htno.EditValue.ToString();
                Query(heat_no);
            }
        }
    }
}
