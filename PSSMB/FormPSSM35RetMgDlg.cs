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
    public partial class FormPSSM35RetMgDlg : EF.EFFormBase
    {
        private EI.EIInfo.eiinfo_sys s;
        private string sm_plan_no =" ";  //炼钢计划号
        private string c_pono = " ";  //炼钢PONO
        private string c_stno = " ";  //炼钢ST_NO
        private string c_ladle_no = " ";  //炼钢钢包
        public string factory_div = " ";
        public string heat_no = " ";
        public string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。

        private string g_form = "PSSM35RetDlg"; //SI配置画面名
        private DataSet DS;
        private BE2.FormConfig.FormConfigHelper formConfigHelper;
        private BE2.Common.LayoutDataChecker layoutDataCheckerMain = new BE2.Common.LayoutDataChecker();
        public FormPSSM35RetMgDlg()
        {
            InitializeComponent();
        }

        #region 属性
        public string SM_PLAN_NO  //炼钢计划号
        {
            set
            {
                sm_plan_no = value;
            }
        }
        #endregion

        private void FormPSSM35RetMgDlg_Load(object sender, EventArgs e)
        {
            
            
            //EF.Utility.SetGridColumn(new EF.EFDevGrid[] {  this.efDevGrid1 }, new string[] { "PSSM35RET_Q"}, v_curr_part_name);
            ////初始化GRID 的基本设置。
            //GC.PM_utility2.DEV_Init_grid2(efDevGrid1, "0");
            formConfigHelper = new BE2.FormConfig.FormConfigHelper(v_curr_part_name, g_form, string.Empty, "#", " ", "pssm_form_get");
            DS = formConfigHelper.FormDataSet;

            // 初始化数据源
            BindingSource ps_pono = formConfigHelper.CreateBindingSourceForLayoutOrView("GridView1");

            // 单记录条件
            formConfigHelper.LoadLayoutControlsForEdit(this, layoutControl1, layoutControlGroup1, "LayoutGroupFilter");

            formConfigHelper.LoadGridView(this, "GridView1", this.efDevGrid1, this.gridView1, null);


            layoutControl1.BestFit();

            query(); //画面初始化查询

            //设备代码下拉
            EI.EIInfo inBlock1 = new EI.EIInfo();
            EI.EIInfo outBlock1;
            try
            {
                inBlock1.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock1.Tables[0].Rows.Add(factory_div);
                outBlock1 = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18b_rt_inq", inBlock1);
                s = outBlock1.GetSys();
                if (s.flag < 0)
                {
                    this.efStatusBar1.Text = string.Format(GC.GCRS.GCRSC0000043/*查询失败：{0}*/, s.msg);
                    return;
                }
                this.efDevLookUpEdit_dest.Properties.DataSource = outBlock1.Tables["POSITION"];
                this.efDevLookUpEdit_dest.Properties.ValueMember = "DEV_CODE";
                this.efDevLookUpEdit_dest.Properties.DisplayMember = "STATION_NAME";
                this.efDevLookUpEdit_dest.Properties.Columns.Clear();
                DataRow dt_cc = outBlock1.Tables["POSITION"].Rows.Add();
                dt_cc["DEV_CODE"] = "CC";
                dt_cc["STATION_NAME"] = "连铸机";
                this.efDevLookUpEdit_dest.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEV_CODE", "设备代码"));

                
            }
            catch (Exception err)
            {
                this.efStatusBar1.Text = string.Format(GC.GCRS.GCRSC0000018/*系统出现异常[{0}]，请联系系统维护人员。*/, err.Message);
            }
        }

        #region 查询函数
        /// <summary>
        /// 对话框初始化查询函数
        /// <para>连铸设备查询</para>
        /// </summary>
        private void query()
        {
            //查询条件
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;

            try
            {

                //查询条件项
                inBlock.Tables[0].Columns.Add("SM_PLAN_NO");
                inBlock.Tables[0].Columns.Add("RETURN_MODE");
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("PROJ");
                
                //获取调整数据
                DataRow row = inBlock.Tables[0].Rows.Add();
                row["SM_PLAN_NO"] = sm_plan_no;
                //row["RETURN_MODE"] = efDevRadio_return_mode.Properties.Items[efDevRadio_return_mode.SelectedIndex].Value;
                row["RETURN_MODE"] = efDevRadio_return_mode.EditValue;
                row["FACTORY_DIV"] = factory_div;
                row["PROJ"] = "MG";


                //调用后台
                this.efStatusBar1.Text = "查询中...";
                //outBlock = EI.EITuxedo.CallService("pssm35dlg_inq", inBlock);
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm35dlg_inq", inBlock);

                s = outBlock.GetSys();


                //判断调用是否成功
                if (s.flag < 0)
                {
                    this.efStatusBar1.Text = s.msg;
                    return;
                }
                else
                {
                    DataRow row_ret = outBlock.Tables["TPSSM_PLAN"].Rows[0];
                    //this.dS_PSSM35.TPSSM_PLAN.Rows.Clear();
                    //this.dS_PSSM35.TPSSM11.Rows.Clear();
                    //outBlock.ConvertToStrongType(this.dS_PSSM35);
                    formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SM_PLAN_NO", row_ret["SM_PLAN_NO"].ToString());
                    formConfigHelper.SetControlEditValue("LayoutGroupFilter", "PONO", row_ret["PONO"].ToString());
                    formConfigHelper.SetControlEditValue("LayoutGroupFilter", "ST_NO", row_ret["ST_NO"].ToString());
                    formConfigHelper.SetControlEditValue("LayoutGroupFilter", "HEAT_NO", row_ret["HEAT_NO"].ToString());
                    formConfigHelper.SetControlEditValue("LayoutGroupFilter", "LADLE_NO", row_ret["LADLE_NO"].ToString());
                    efDevSpin_ret_wt.EditValue = row_ret["OUT_STEEL_WT"].ToString();
                    //this.pONOEFTextBox.Text = row_ret["PONO"].ToString();
                    //this.sT_NOEFTextBox.Text = row_ret["ST_NO"].ToString();
                   // this.ef_heat_no.Text = row_ret["HEAT_NO"].ToString();
                   // this.efTextBox1.Text = row_ret["ST_NO"].ToString();

                    outBlock.blk_now = 1;
                    //EF.Utility.SetCustomGridValue(this.efDevGrid_plan, outBlock, "TPSSM11",true);
                    //EF.Utility.SetCustomGridValue(this.efDevGrid1, outBlock, "TPSSM11", true);
                    //EF.Utility.SetCustomGridValue(efDevGrid1, outBlock, false, true);
                    this.formConfigHelper.MergeDataToGrid(outBlock.Tables[1], efDevGrid1);
                }

                this.efStatusBar1.Text = "初始化成功。";

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

        #region 确定按钮
        private void efButton_OK_Click(object sender, EventArgs e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;

            try
            {
                //获取选择的记录
                //DataTable tempTable_pono = efDevGrid_plan.GetSelectedDataRow();

                //if (tempTable_pono.Rows.Count <= 0)
                //{
                //    string str = "请选择返送钢水的目的炼钢计划。";
                //    EF.EFMessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.efStatusBar1.Text = str;
                //    this.DialogResult = DialogResult.None;
                //    return;
                //}
                EI.EIInfo inBlock_dest = new EI.EIInfo();
                inBlock_dest.Tables[0].Merge(this.efDevGrid1.GetSelectedDataRow());




                //定义钢水返送输入块
                DataTable table = inBlock.Tables[0];
                table.TableName = "HTNO_RET";
                table.Columns.Add("FACTORY_DIV", System.Type.GetType("System.String"));  //厂别
                table.Columns.Add("SM_PLAN_NO", System.Type.GetType("System.String"));  //计划号
                table.Columns.Add("HEAT_NO", System.Type.GetType("System.String"));  //熔炼号
                table.Columns.Add("STEEL_RETURN_CODE", System.Type.GetType("System.String"));  //返送类型  1-回炉；2-兑包  3-分割
                table.Columns.Add("RET_HEAT_NO", System.Type.GetType("System.String"));  //目的熔炼号
                table.Columns.Add("RET_PONO", System.Type.GetType("System.String"));  //目的制造命令号
                table.Columns.Add("RETURN_MLSL", System.Type.GetType("System.String"));  //返送熔钢(t)
                table.Columns.Add("RET_DEST", System.Type.GetType("System.String"));  //返送目的地
                table.Columns.Add("RET_TIME", System.Type.GetType("System.String"));  //返送时刻
                table.Columns.Add("REMARK", System.Type.GetType("System.String"));  //备注
                table.Columns.Add("RETURN_PLAN_NO", System.Type.GetType("System.String")); //返送目的计划号


                if (inBlock_dest.Tables[0].Rows.Count < 1)
                {
                    //// 警告类，惊叹号
                    //DialogResult result = EF.EFMessageBox.Show("是否确认返送目标为空？", EF.EF_Args.epEname, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    //if (result == DialogResult.No)
                    //{                        
                    //    this.DialogResult = DialogResult.None;
                    //    return;
                    //}
                    //DataRow row = table.Rows.Add();
                    //row["FACTORY_DIV"] = factory_div;
                    //row["SM_PLAN_NO"] = formConfigHelper.GetControlEditValue("LayoutGroupFilter", "SM_PLAN_NO").ToString();
                    //row["HEAT_NO"] = formConfigHelper.GetControlEditValue("LayoutGroupFilter", "HEAT_NO").ToString();
                    //row["STEEL_RETURN_CODE"] = efDevRadio_return_mode.EditValue;
                    //row["RET_DEST"] = this.efDevLookUpEdit_dest.EditValue;
                    //row["RETURN_MLSL"] = efDevSpin_ret_wt.Value;

                    EF.EFMessageBox.Show("返送目标PONO为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.efStatusBar1.Text = "返送目标PONO为空";
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else
                {
                    if (this.efDevLookUpEdit_dest.EditValue.ToString().Trim().CompareTo("")==0)
                    {
                        EF.EFMessageBox.Show("【返送目的地】为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.efStatusBar1.Text = "【返送目的地】为空";
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    if (this.efDevSpin_ret_wt.Value <= 0)
                    {
                        EF.EFMessageBox.Show("【返送钢水量】为0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.efStatusBar1.Text = "【返送钢水量】为0";
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    foreach (DataRow row_in in this.efDevGrid1.GetSelectedDataRow().Rows)
                    {
                        DataRow row = table.Rows.Add();
                        row["FACTORY_DIV"] = factory_div;
                        row["SM_PLAN_NO"] = formConfigHelper.GetControlEditValue("LayoutGroupFilter", "SM_PLAN_NO").ToString();
                        row["HEAT_NO"] = formConfigHelper.GetControlEditValue("LayoutGroupFilter", "HEAT_NO").ToString();
                        row["STEEL_RETURN_CODE"] = efDevRadio_return_mode.EditValue;
                        //row["RET_HEAT_NO"] = row_in["HEAT_NO"];
                        Char[] old_heat_no_char = formConfigHelper.GetControlEditValue("LayoutGroupFilter", "HEAT_NO").ToString().ToCharArray();
                        old_heat_no_char[1] = '1';
                        row["RET_HEAT_NO"] = new String(old_heat_no_char);
                        row["RET_PONO"] = row_in["PONO"];
                        row["RETURN_MLSL"] = Convert.ToDecimal(row_in["RETURN_MLSL"]) == 0 ? efDevSpin_ret_wt.Value : row_in["RETURN_MLSL"];
                        row["RET_DEST"] = this.efDevLookUpEdit_dest.EditValue;
                        //row["RET_TIME"] = tempTable_pono.Rows[0]["SM_PLAN_NO"];
                        row["REMARK"] = efDevText_remark.Text.Trim();
                        row["RETURN_PLAN_NO"] = row_in["SM_PLAN_NO"]; 
                    }
                    //if(efDevRadio_return_mode.Properties.Items[efDevRadio_return_mode.SelectedIndex].Value.ToString()=="3"
                    //    && inBlock_dest.Tables[0].Rows.Count>1)
                    if (efDevRadio_return_mode.EditValue == "3"
                        && inBlock_dest.Tables[0].Rows.Count > 1)
                    {
                        // 警告类，惊叹号
                        DialogResult result = EF.EFMessageBox.Show("分割操作只能选择一个目的计划！");
                        return;
                    }
                }

                

               


                this.efStatusBar1.Text = "返送操作中...";
               
                //outBlock = EI.EITuxedo.CallService("pssm35_ins", inBlock);
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18b_rt_upd", inBlock);
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

            this.efStatusBar1.Text = "返送操作成功。";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion


    }
}
