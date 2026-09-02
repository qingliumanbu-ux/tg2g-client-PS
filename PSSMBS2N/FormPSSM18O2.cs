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
    public partial class FormPSSM18O2 : EF.EFFormBase
    {
        public string factory_div = "";
        private string cc_mach_no = "";
        public string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。
        public FormPSSM18O2()
        {
            InitializeComponent();
            if (EF.EF_Args.common_parameter_1.Trim() != "")
            {
                v_curr_part_name = EF.EF_Args.common_parameter_1;//当前画面的分区代码
            }
        }

        #region btn_del_Click 一键删除
        /// <summary>
        /// 一键删除所有未生产炉次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_del_Click(object sender, EventArgs e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;
            cc_mach_no = "";
            try
            {
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("CC_MACH_NO", typeof(String));
                inBlock.Tables[0].Rows.Add();
                if (factory_div.Trim() == "1")
                {
                    if (this.efDevCheckEdit1cc.Checked == true)
                    {
                        cc_mach_no = cc_mach_no + "1"; //1#CC
                    }
                    if (this.efDevCheckEdit2cc.Checked == true)
                    {
                        cc_mach_no = cc_mach_no + "2"; //2#CC
                    }
                    if (this.efDevCheckEdit3cc.Checked == true)
                    {
                        cc_mach_no = cc_mach_no + "3"; //3#CC
                    }

                    if (this.efDevCheckEditac.Checked == true)
                    {
                        cc_mach_no = cc_mach_no + "A"; //A#CC
                    }
                    if (this.efDevCheckEditbc.Checked == true)
                    {
                        cc_mach_no = cc_mach_no + "B"; //4#CC
                    }
                    if (this.efDevCheckEdit1cc.Checked == false && this.efDevCheckEdit2cc.Checked == false &&
                        this.efDevCheckEdit3cc.Checked == false && this.efDevCheckEditac.Checked == false && this.efDevCheckEditbc.Checked == false)
                    {
                        cc_mach_no = "123AB";
                    }
                }
                else if (factory_div.Trim() == "2")
                {
                    if (this.efDevCheckEdit4c.Checked == true)
                    {
                        cc_mach_no = cc_mach_no + "4"; //1#CC
                    }
                    if (this.efDevCheckEdit5c.Checked == true)
                    {
                        cc_mach_no = cc_mach_no + "5"; //2#CC
                    }
                    if (this.efDevCheckEditdc.Checked == true)
                    {
                        cc_mach_no = cc_mach_no + "D"; //3#CC
                    }

                    if (this.efDevCheckEditec.Checked == true)
                    {
                        cc_mach_no = cc_mach_no + "E"; //A#CC
                    }
                    if (this.efDevCheckEditfc.Checked == true)
                    {
                        cc_mach_no = cc_mach_no + "F"; //4#CC
                    }
                    if (this.efDevCheckEdit4c.Checked == false && this.efDevCheckEdit5c.Checked == false &&
                        this.efDevCheckEditdc.Checked == false && this.efDevCheckEditec.Checked == false && this.efDevCheckEditfc.Checked == false)
                    {
                        cc_mach_no = "45DEF";//全选
                    }
                }
                else if (factory_div.Trim() == "3")
                {
                    if (this.efDevCheckEdit7c.Checked == true)
                    {
                        cc_mach_no = cc_mach_no + "7"; //A#CC
                    }
                    if (this.efDevCheckEditgc.Checked == true)
                    {
                        cc_mach_no = cc_mach_no + "G"; //4#CC
                    }
                    if (this.efDevCheckEdit7c.Checked == false && this.efDevCheckEditgc.Checked == false )
                    {
                        cc_mach_no = "7G";
                    }
                }
                inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div.Trim();
                inBlock.Tables[0].Rows[0]["CC_MACH_NO"] = cc_mach_no;

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18_all_del", inBlock);
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000043/*查询失败：{0}*/, s.msg);
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
           
        }
        #endregion

        private void Get_proc_no()
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;

            try
            {
                inBlock.Tables[0].Columns.Add("dev_code", typeof(String));
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Rows.Add(efDevLookUpEdit1_bof.EditValue.ToString(), factory_div.Trim());

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18_ul_inq", inBlock);
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.statusBarPanel1.Text = string.Format("查询失败：{0}", s.msg);
                    return;
                }
                if (outBlock.Tables.Contains("PROC_NO"))
                {
                    this.efDevTextEdit1_heat_no.Text = outBlock.Tables["PROC_NO"].Rows[0]["PROC_NO"].ToString();
                }
            }
            catch (Exception err)
            {
                this.statusBarPanel1.Text = string.Format("系统出现异常[{0}]，请联系系统维护人员。", err.Message);
                return;
            }
        }

        private void Get_dev_code()
        {
            EI.EIInfo DsCodeName = new EI.EIInfo();
            string sqlStr = "select dev_code as code,station_name as code_desc_1_content from tpssmd1 where station_id = 'B' ";

            if (factory_div.Trim() != "")
            {
                sqlStr = sqlStr + "AND FACTORY_DIV = '" + factory_div + "' ";
            }
            sqlStr = sqlStr + "ORDER BY STATION_NO";
           
            DsCodeName = Common.Utility.ExecQuery(sqlStr);

            Common.Utility.SetLookUpEditProperty(this.efDevLookUpEdit1_bof, DsCodeName.Tables[0]);  
        }

        private void efButton_OK_Click(object sender, EventArgs e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;

            try
            {
                if(efDevTextEdit1_heat_no.Text.Length != 9)
                {
                    this.statusBarPanel1.Text = "处理号输入长度有误，请重新输入。";
                    GC.PM_utility2.Dev_messageBoxError(this.statusBarPanel1.Text);                    
                    return;
                }
                inBlock.Tables[0].Columns.Add("dev_code", typeof(String));
                inBlock.Tables[0].Columns.Add("proc_no", typeof(String));
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Rows.Add();
                inBlock.Tables[0].Rows[0]["dev_code"] = efDevLookUpEdit1_bof.EditValue.ToString();
                inBlock.Tables[0].Rows[0]["proc_no"] = efDevTextEdit1_heat_no.Text.ToString();
                inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18_ul_upd", inBlock);
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.statusBarPanel1.Text = string.Format("处理失败：{0}", s.msg);
                    GC.PM_utility2.Dev_messageBoxError(this.statusBarPanel1.Text); 
                    return;
                }
                this.statusBarPanel1.Text = string.Format("处理成功", s.msg);
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            catch (Exception err)
            {
                this.statusBarPanel1.Text = string.Format("系统出现异常[{0}]，请联系系统维护人员。", err.Message);
                GC.PM_utility2.Dev_messageBoxError(this.statusBarPanel1.Text); 
                return;
            }
        }

        private void efButton_CANCEL_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void efDevLookUpEdit1_bof_QueryPopUp(object sender, CancelEventArgs e)
        {
            this.Get_dev_code();
        }

        private void efDevLookUpEdit1_bof_EditValueChanged(object sender, EventArgs e)
        {
            this.Get_proc_no();
        }

        private void FormPSSM21O2_Load(object sender, EventArgs e)
        {
            if (factory_div.Trim() == "1")
            {//只显示一区
                layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            }
            else if (factory_div.Trim() == "2")
            {//二区
                layoutControlGroup5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            }
            else if (factory_div.Trim() == "3")
            {//三区
                layoutControlGroup6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            }
          

           //Width = 400;
        }
    }
}
