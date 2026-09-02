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
    public partial class FormPSSM18D : EF.EFFormBase
    {
        public FormPSSM18D()
        {
            InitializeComponent();
        }
        public string factory_div = " ";
        public string heat_no = "";
        public string pono = "";
        public int charge_no = 0;
        public string dev_code = "";  
        public string area_id = ""; //
        public string sm_plan_no = "";
        public string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。
        int v_time = 0;
        string password = "";

        private void FormPSSM18D_Load(object sender, EventArgs e)
        {
            if (EF.EF_Args.common_parameter_1.Trim() != "")
            {
                v_curr_part_name = EF.EF_Args.common_parameter_1;//当前画面的分区代码
            }
            QueryState();  
           // SetDev();
            pono_txt.Text = pono;
            htno_txt.Text = heat_no;

            efDevLookUpEdit1.EditValue = dev_code;
            efDevTextEdit1.Text = sm_plan_no;

            //start_time.DateTime = DateTime.Now;
            //end_time.DateTime = DateTime.Now;            
        }

        #region efButton1_Click
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void efButton1_Click(object sender, EventArgs e)
        {
            RunDel();
            QueryState();
            if(btnClickEvent!=null)
            {
                btnClickEvent("1");
            }
          
            return;
        }
        #endregion
        

        #region efButton3_Click
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void efButton3_Click(object sender, EventArgs e)
        {
            if (btnClickEvent != null)
            {
                btnClickEvent("2");
            }
            //this.DialogResult = DialogResult.Cancel;
            this.Close();
            
          
        }
        #endregion


        #region efDevLookUpEdit1_EditValueChanged
        /// <summary>
        /// 设备代码值改变，刷新计划时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void efDevLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            dev_code = efDevLookUpEdit1.EditValue.ToString();
            //QueryState();
        }
        #endregion
       
        #region 内部函数

        /// <summary>
        /// 查询炉次状态
        /// <para>根据制造命令号,查询当前炉次的状态</para>
        /// </summary>
        /// <param name=""></param>
        /// <returns>无</returns>
        private void QueryState()
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;
            
            try
            {
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("PONO", typeof(String));
                inBlock.Tables[0].Columns.Add("HEAT_NO", typeof(String));
                inBlock.Tables[0].Columns.Add("DEV_CODE", typeof(String));
                inBlock.Tables[0].Columns.Add("SM_PLAN_NO", typeof(String));
                inBlock.Tables[0].Rows.Add(factory_div,pono,heat_no,dev_code,sm_plan_no);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_del_inq", inBlock);
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000043/*查询失败：{0}*/, s.msg);
                    return ;
                }
                if (outBlock.Tables.Contains("STATE"))
                {
                    this.state_txt.Text = outBlock.Tables["STATE"].Rows[0]["RUN_STATUS"].ToString();
                }
                if (outBlock.Tables.Contains("DEV_CODE"))
                {
                    this.efDevLookUpEdit1.Properties.DataSource = outBlock.Tables["DEV_CODE"];
                    this.efDevLookUpEdit1.Properties.ValueMember = "DEV_CODE";
                    this.efDevLookUpEdit1.Properties.DisplayMember = "DEV_CODE";
                    this.efDevLookUpEdit1.Properties.Columns.Clear();
                    this.efDevLookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEV_CODE", "设备代码"));

                }
                if (outBlock.Tables.Contains("SM_PLAN_NOL2"))
                {
                    this.efDevTextEdit2.Text = outBlock.Tables["SM_PLAN_NOL2"].Rows[0]["SM_PLAN_NOL2"].ToString(); ;
                }
                return ;
               

            }
            catch (Exception err)
            {
                this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000018/*系统出现异常[{0}]，请联系系统维护人员。*/, err.Message);
                return ;
            }
        }


        private void RunDel()
        {
            
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;
        
            try
            {
                inBlock.Tables[0].Columns.Add("SM_PLAN_NO", typeof(String));
                inBlock.Tables[0].Columns.Add("CHARGE_NO", typeof(int));
                inBlock.Tables[0].Columns.Add("PASSWORD", typeof(String));
                

                if(efDevLookUpEdit1.EditValue==null)
                {
                    MessageBox.Show("设备代码不能为空。");
                    return;
                }

                if (EF.EFMessageBox.Show("是否删除制造命令" + pono + "上设备" + dev_code + "的计划", "删除工序", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                      == DialogResult.No)
                {
                    return ;
                }

                dev_code = efDevLookUpEdit1.EditValue.ToString();
                int pos = dev_code.IndexOf("-");
                charge_no = Int32.Parse(dev_code.Substring(pos + 1));
                sm_plan_no = efDevTextEdit1.Text.ToString();
                password = efDevTextEdit3.Text.ToString();

                inBlock.Tables[0].Rows.Add(sm_plan_no, charge_no, password);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_pssm12", inBlock);
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000043/*查询失败：{0}*/, s.msg);
                    //this.DialogResult = DialogResult.None;
                    return;
                }
                
                //if (dev_code.Substring(0, 1) == "B")
                //{
                //    this.htno_txt.Text = proc_no;
                //}

            }
            catch (Exception err)
            {
                this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000018/*系统出现异常[{0}]，请联系系统维护人员。*/, err.Message);
                //this.DialogResult = DialogResult.None;
            }
            this.statusBarPanel1.Text = GC.GCRS.GCRSC0000009/*处理成功。*/;
            //this.DialogResult = DialogResult.Yes;
            //this.Close();
            return;
        }
       
      
        #endregion

        public delegate void btnClickEventHandler(string flag);
        public btnClickEventHandler btnClickEvent = null;
        
    }
}
