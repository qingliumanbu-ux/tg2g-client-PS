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
    public partial class FormPSSM28STChgDlg : EF.EFFormBase
    {
        private EI.EIInfo.eiinfo_sys s;
        public string factory_div = "";
        public string cc_mach_no = "";
        public string pono = "";
        public string st_no = "";
        public string sm_plan_no = "";
        public string v_curr_part_name = " "; //this.ef_args.formPartition; //当前画面的分区代码。

        public FormPSSM28STChgDlg()
        {
            InitializeComponent();
        }

        public void SetPONOInfo()
        {

            this.sM_PLAN_NOEFTextBox.Text = sm_plan_no;
            this.pONOEFTextBox.Text = pono;
            this.sT_NOEFTextBox.Text = st_no;
            this.cC_MACH_NOEFTextBox.Text = cc_mach_no;
        }

        private void FormPSSM28STChgDlg_Load(object sender, EventArgs e)
        {
            //if (EF.EF_Args.common_parameter_1.Trim() != "")
            //{
            //    v_curr_part_name = EF.EF_Args.common_parameter_1;//当前画面的分区代码
            //}
            EF.Utility.SetGridColumn(new EF.EFDevGrid[] { this.efDevGrid1 }, new string[] { "PSSM28_CHG" }, v_curr_part_name);
            this.efDevGrid1.ShowSelectionColumn = true;
            this.efDevGrid1.EFMultiSelect = false;

            SetPONOInfo();

            initQuery();
            query();
        }

        #region 对话框初始化查询函数
        /// <summary>
        /// 对话框初始化查询函数
        /// <para>连铸设备查询</para>
        /// </summary>
        private void initQuery()
        {
            //查询条件
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;

            try
            {

                //查询条件项
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Rows.Add();
                inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;

                //查询未编入计划的炉次，否则编制方法要修改
                //调用后台
                this.efStatusBar1.Text = "初始化查询中...";
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm11stdlg_inq", inBlock);
                s = outBlock.GetSys();
                //判断调用是否成功
                if (s.flag < 0)
                {
                    this.efStatusBar1.Text = s.msg;
                    return;
                }
                else
                {
                    if (outBlock.Tables[0] != null)
                    {
                        //if(outBlock.Tables[0].Rows.Count>0)
                        //{
                        //    Common.Utility.SetLookUpEditProperty(efDevLookUpEdit_CC_MACH_NO, outBlock.Tables[0], "STATION_NAME", "CC_MACH_NO", true);
                        //    Common.Utility.SetLookUpEditProperty(efDevLookUpEdit_CC_MACH_NO_1, outBlock.Tables[0], "STATION_NAME", "CC_MACH_NO", true);
                        //}

                        //20150909 lj Common.Utility.SetLookUpEditProperty 方法在roucount=0时下拉出来仍是上次的值
                        DataRow row = outBlock.Tables[0].NewRow();
                        row["DEV_NO"] = " ";
                        row["DEV_DESC"] = " ";
                        outBlock.Tables[0].Rows.InsertAt(row, 0);
                        this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.DataSource = outBlock.Tables[0];
                        this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.DisplayMember = "DEV_DESC";
                        this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.ValueMember = "DEV_NO";
                        this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.Columns.Clear();
                        this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEV_NO", "选项代码"));
                        this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEV_DESC", "选项描述"));
                    }                    
                }

                this.efStatusBar1.Text = "初始化成功。";

            }
            catch (Exception err)
            {
                this.efStatusBar1.Text = err.Message;
            }

        }
        #endregion

        #region 连铸命令查询函数，无翻页功能
        /// <summary>
        /// 炼钢连铸命令查询
        /// <para>制造命令</para>
        /// </summary>
        private void query()
        {
            //查询条件
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;

            try
            {

                //查询条件项
                inBlock.Tables[0].Columns.Add("FACTORY_DIV"); 
                inBlock.Tables[0].Columns.Add("CC_MACH_NO"); //连铸机号
                DataRow row = inBlock.Tables[0].Rows.Add();
                row["FACTORY_DIV"] = factory_div;
                row["CC_MACH_NO"] = cHG_CC_MACH_NOEFTDevLookUpEdit.EditValue;

                //查询未编入计划的炉次，否则编制方法要修改
                //调用后台
                this.efStatusBar1.Text = "查询中...";
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm11stchg_inq", inBlock);
                s = outBlock.GetSys();
                //判断调用是否成功
                if (s.flag < 0)
                {
                    this.efStatusBar1.Text = s.msg;
                    return;
                }
                else
                {
                    //将信息压入指定的GRID, 
                    EF.Utility.SetCustomGridValue(this.efDevGrid1, outBlock, false);
                    //列宽自动调整。
                    this.gridView1.BestFitColumns();
                }

                //bandedGridView_plan.BestFitColumns();
                this.efStatusBar1.Text = "查询成功。";

            }
            catch (Exception err)
            {
                this.efStatusBar1.Text = err.Message;
            }

        }
        #endregion

        #region 查询按钮
        private void efButton_inq_Click(object sender, EventArgs e)
        {
            query();
        }
        #endregion

        private void efButton_chg_Click(object sender, EventArgs e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            int i = 0;
            string v_pono_in = "";

            try
            {
                //获取选择的记录
                if (this.gridView1.SelectedRowsCount != 1)
                {
                    string str = "请选择需要变更入的一个制造命令。";
                    EF.EFMessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.efStatusBar1.Text = str;
                    this.DialogResult = DialogResult.None;
                    return;
                }

                for (i = 0; i < this.gridView1.RowCount; i++)
                {
                    if (efDevGrid1.GetSelectedColumnChecked(i) == true)
                    {
                        v_pono_in = gridView1.GetRowCellValue(i, "PONO").ToString().Trim();
                    }
                }

                //定义钢种变更输入块
                inBlock.Tables[0].TableName = "STNO_CHG";  //钢种变更
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("WORK_PROC", typeof(String));
                inBlock.Tables[0].Columns.Add("PONO_OUT", typeof(String));
                inBlock.Tables[0].Columns.Add("PONO_IN", typeof(String));
                inBlock.Tables[0].Rows.Add();
                inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;
                inBlock.Tables[0].Rows[0]["WORK_PROC"] = "0";
                inBlock.Tables[0].Rows[0]["PONO_OUT"] = this.pONOEFTextBox.Text;
                inBlock.Tables[0].Rows[0]["PONO_IN"] = v_pono_in;


                this.efStatusBar1.Text = "变更操作中...";
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18_chg_out", inBlock);
                s = outBlock.GetSys();

                if (s.flag < 0)
                {
                    this.efStatusBar1.Text = s.msg;
                    this.DialogResult = DialogResult.None;
                    return;
                }

            }
            catch (Exception err)
            {
                this.efStatusBar1.Text = err.Message;
                this.DialogResult = DialogResult.None;
                return;
            }

            this.efStatusBar1.Text = "钢种变更成功";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void efButton_quit_Click(object sender, EventArgs e)
        {

        }
    }
}
