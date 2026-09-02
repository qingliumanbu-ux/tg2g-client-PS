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
    public partial class FormPSSM18O : EF.EFFormBase
    {
        public FormPSSM18O()
        {
            InitializeComponent();
        }
        public string factory_div = " ";
        public string heat_no = "";
        public string pono = "";
        public int charge_no = 0;
        public string dev_code = "";
        public string v_start_time = ""; //开始时间
        public string v_end_time = ""; //结束时间    
        public string area_id = ""; //
        public DataTable UnitTable = new DataTable(); //
        public string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。
        int v_time = 0;
        string charge_choose = "";
        string[] formats = { "yyyy/M/d HH:mm:ss", "yyyy/M/d H:mm:ss", "yyyy/M/dd H:mm:ss", "yyyy/M/dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss", "yyyy/MM/dd H:mm:ss", "yyyy/MM/d HH:mm:ss", "yyyy/MM/d H:mm:ss" };

        private void FormPSSM18O_Load(object sender, EventArgs e)
        {
            if (EF.EF_Args.common_parameter_1.Trim() != "")
            {
                v_curr_part_name = EF.EF_Args.common_parameter_1;//当前画面的分区代码
            }
            QueryState();  
           // SetDev();
            pono_txt.Text = pono;
            htno_txt.Text = heat_no;

            //if (dev_code.Trim() == "")
            //{
            //    dev_code = UnitTable.Rows[0]["DEV_CODE"].ToString() + "-" + UnitTable.Rows[0]["CHARGE_NO"].ToString();
            //}

            efDevLookUpEdit1.EditValue = dev_code;

            //start_time.DateTime = DateTime.Now;
            //end_time.DateTime = DateTime.Now;            
        }

        #region efButton1_Click
        /// <summary>
        /// 开始信号模拟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void efButton1_Click(object sender, EventArgs e)
        {
            string proc_time =  start_time.DateTime.ToString("yyyyMMddHHmmss");
            string proc_no = this.proc_no_txt.Text.Trim();
            RunSignal("2", proc_time, proc_no);
            if(btnClickEvent!=null)
            {
                EI.Logger.Info("王程宇的前台日志测试接管开始：------------【接管时刻4】------------接管刷新开始，当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                btnClickEvent("1");
                EI.Logger.Info("王程宇的前台日志测试接管开始：------------【接管时刻5】------------接管刷新结束，当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
          
            return;
        }
        #endregion

        #region efButton2_Click
        /// <summary>
        /// 结束信号模拟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void efButton2_Click(object sender, EventArgs e)
        {
            if(dev_code.Substring(0,1) == "B")
            {
                v_time = 40;
            }
            else if (dev_code.Substring(0, 1) == "C")
            {
                v_time = 60;
            }
            else
            {
                v_time = 80;
            }

            v_start_time = start_time.DateTime.ToString("yyyyMMddHHmmss");
            v_end_time = this.start_time.DateTime.AddMinutes(v_time).ToString("yyyyMMddHHmmss");

            string proc_time = end_time.DateTime.ToString("yyyyMMddHHmmss");
            //if(proc_time.CompareTo(v_end_time) > 0)
            //{
            //    DialogResult result = MessageBox.Show("设备代码[" + dev_code.Substring(0,2) + "]处理时间超过[" + v_time + "]分钟,是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if(result == DialogResult.No)
            //    {
            //        return;
            //    }
            //}
            string proc_no = this.proc_no_txt.Text.Trim();

            RunSignal("3", proc_time, proc_no);
            if (btnClickEvent != null)
            {
                EI.Logger.Info("王程宇的前台日志测试接管开始：------------【接管时刻4】------------接管刷新开始，当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                btnClickEvent("1");
                EI.Logger.Info("王程宇的前台日志测试接管开始：------------【接管时刻5】------------接管刷新结束，当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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

        #region efButton1_Click_1
        /// <summary>
        /// 开始时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void efButton1_Click_1(object sender, EventArgs e)
        {
            start_time.DateTime = DateTime.Now;
        }
        #endregion

        #region efButton2_Click_1
        /// <summary>
        /// 结束时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void efButton2_Click_1(object sender, EventArgs e)
        {
            end_time.DateTime = DateTime.Now;
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
            charge_choose = dev_code.Substring(dev_code.Length - 1);
            QueryState();
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

            DateTime time1;
            DateTime time2;
            try
            {
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("PONO", typeof(String));
                inBlock.Tables[0].Columns.Add("HEAT_NO", typeof(String));
                inBlock.Tables[0].Columns.Add("DEV_CODE", typeof(String));
                inBlock.Tables[0].Rows.Add(factory_div,pono,heat_no,dev_code);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18_ot_inq", inBlock);
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
                if (outBlock.Tables.Contains("DEV_CODE_E"))
                {
                    this.efDevLookUpEdit2.Properties.DataSource = outBlock.Tables["DEV_CODE_E"];
                    this.efDevLookUpEdit2.Properties.ValueMember = "DEV_CODE_E";
                    this.efDevLookUpEdit2.Properties.DisplayMember = "DEV_CODE_E";
                    this.efDevLookUpEdit2.Properties.Columns.Clear();
                    this.efDevLookUpEdit2.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEV_CODE_E", "电炉设备代码"));

                }
                if (outBlock.Tables.Contains("PROC_TIME"))
                {
                    v_start_time = outBlock.Tables["PROC_TIME"].Rows[0]["START_TIME"].ToString();
                    v_end_time = outBlock.Tables["PROC_TIME"].Rows[0]["END_TIME"].ToString();
                    area_id = outBlock.Tables["PROC_TIME"].Rows[0]["AREA_ID"].ToString();

                    start_time.DateTime = DateTime.ParseExact(v_start_time, "yyyyMMddHHmmss", null);
                    end_time.DateTime = DateTime.ParseExact(v_end_time, "yyyyMMddHHmmss", null);

                    for (int i = 0; i < UnitTable.Rows.Count; i++ )
                    {
                        if(charge_choose == UnitTable.Rows[i]["CHARGE_NO"].ToString())
                        {
                            if (DateTime.TryParseExact(UnitTable.Rows[i]["BEGIN_TIME"].ToString(), formats, null, System.Globalization.DateTimeStyles.None, out time1))
                            {
                                start_time.DateTime = time1;
                            }

                            if (DateTime.TryParseExact(UnitTable.Rows[i]["END_TIME"].ToString(), formats, null, System.Globalization.DateTimeStyles.None, out time2))
                            {
                                end_time.DateTime = time2;
                            }
                            //start_time.DateTime = DateTime.TryParseExact(UnitTable.Rows[i]["BEGIN_TIME"]);
                            //end_time.DateTime = DateTime.ParseExact(UnitTable.Rows[i]["END_TIME"]);
                        }
                    }

                    if (area_id.Trim() != "3" && area_id.Trim() != "2" )
                    {
                        this.proc_no_txt.Text = outBlock.Tables["PROC_TIME"].Rows[0]["PROC_NO"].ToString().Trim() != "" ? outBlock.Tables["PROC_TIME"].Rows[0]["PROC_NO"].ToString().Trim() : outBlock.Tables["PROC_TIME"].Rows[0]["PRE_PROC_NO"].ToString();
                    }
                    else this.proc_no_txt.Text = outBlock.Tables["PROC_TIME"].Rows[0]["PROC_NO"].ToString().Trim() != "" ? outBlock.Tables["PROC_TIME"].Rows[0]["PROC_NO"].ToString().Trim() : " ";

                    if (area_id.Trim() != "3" && area_id.Trim() != "2")
                    {
                        this.proc_no_txt.Visible = false;
                    }
                    else
                    {
                        this.proc_no_txt.Visible = true;
                    }
                }

                
                return ;
               

            }
            catch (Exception err)
            {
                this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000018/*系统出现异常[{0}]，请联系系统维护人员。*/, err.Message);
                return ;
            }
        }

        private void SetDev()
        {
            EI.EIInfo outInfo = EF.Utility.ExecQuery(" SELECT * from( select b.dev_code||'-'|| a.charge_no AS code,b.dev_code AS DEV_CODE,a.CHARGE_NO AS charge_no from tpssm12 a,tpssmd1 b where a.sm_plan_no =(select sm_plan_no from tpssm11 where pono= '" + pono + "') AND SUBSTR(a.DEV_CODE,1,1) = b.DEV_TECH_CODE AND a.AREA_ID <> 5  UNION SELECT dev_code||'-'|| charge_no AS code, dev_code AS DEV_CODE, CHARGE_NO AS charge_no from tpssm12 where sm_plan_no =(select sm_plan_no from tpssm11 where pono= '" + pono + "') AND AREA_ID = 5) ORDER BY charge_no,dev_code ");
            if (outInfo.sys_info.flag == 0)
            {
                this.efDevLookUpEdit1.Properties.DataSource = outInfo.Tables[0];
                this.efDevLookUpEdit1.Properties.ValueMember = "DEV_CODE";
                this.efDevLookUpEdit1.Properties.DisplayMember = "DEV_CODE";
                this.efDevLookUpEdit1.Properties.Columns.Clear();
                this.efDevLookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEV_CODE", "设备代码"));

            }
        }

        private void RunSignal(string flag,string proc_time,string proc_no)
        {
            
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;
            string check_flag = " ";
        
            try
            {
                EI.Logger.Info("王程宇的前台日志测试接管开始：------------【接管时刻2】------------接管处理开始，当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("PONO", typeof(String));
                inBlock.Tables[0].Columns.Add("HEAT_NO", typeof(String));
                inBlock.Tables[0].Columns.Add("DEV_CODE", typeof(String));
                inBlock.Tables[0].Columns.Add("CHARGE_NO", typeof(int));
                inBlock.Tables[0].Columns.Add("PROC_TIME", typeof(String));
                inBlock.Tables[0].Columns.Add("PROC_FLAG", typeof(String));//2-开始 3-结束
                inBlock.Tables[0].Columns.Add("PROC_NO", typeof(String));
                inBlock.Tables[0].Columns.Add("CHECK_FLAG", typeof(String));

                if(efDevLookUpEdit1.EditValue==null)
                {
                    MessageBox.Show("设备代码不能为空。");
                    return;
                }
                //if (proc_no.Trim() == "")
                //{
                //    MessageBox.Show("脱碳炉号不能为空。");
                //    return;
                //}
                if(efDevCheckEdit1.Checked)
                {
                    check_flag = "1";
                }
                else
                {
                    check_flag = "0";
                }
                dev_code = efDevLookUpEdit1.EditValue.ToString();
                int pos = dev_code.IndexOf("-");
                charge_no = Int32.Parse(dev_code.Substring(pos + 1));

                inBlock.Tables[0].Rows.Add(factory_div, pono, heat_no, dev_code.Substring(0, pos), charge_no, proc_time, flag, proc_no, check_flag);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18_ot_run", inBlock);
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    //this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000043/*查询失败：{0}*/, s.msg);
                    MessageBox.Show(s.msg);
                    //this.DialogResult = DialogResult.None;
                    return;
                }
                EI.Logger.Info("王程宇的前台日志测试接管开始：------------【接管时刻3】------------接管处理结束，当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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

        private void efButton3_Click_1(object sender, EventArgs e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;
            string dev_code_e = "";

            try
            {
                if (EF.EFMessageBox.Show("是否增加电炉预溶液处理?", "增加电炉预溶液处理", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.No)
                {
                    return;
                }
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("PONO", typeof(String));
                inBlock.Tables[0].Columns.Add("DEV_CODE_E", typeof(String));
                //inBlock.Tables[0].Columns.Add("SM_PLAN_NO");
                //inBlock.Tables[0].Rows.Add();

                if (efDevLookUpEdit2.EditValue == null)
                {
                    MessageBox.Show("电炉设备代码不能为空。");
                    return;
                }

                dev_code_e = efDevLookUpEdit2.EditValue.ToString();
                inBlock.Tables[0].Rows.Add(factory_div, pono, dev_code_e);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_eaf_add", inBlock);
                s = outBlock.GetSys();

                if (s.flag < 0)
                {
                    //this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000043/*查询失败：{0}*/, s.msg);
                    MessageBox.Show(s.msg);
                    //this.DialogResult = DialogResult.None;
                    return;
                }

                QueryState();

                if (btnClickEvent != null)
                {
                    btnClickEvent("1");
                }
            }
            catch (Exception err)
            {
                this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000018/*系统出现异常[{0}]，请联系系统维护人员。*/, err.Message);
                return;
            }
        }
        
    }
}
