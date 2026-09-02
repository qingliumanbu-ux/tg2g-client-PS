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
    /// 出钢计划甘特图管理
    /// <para> 1.查询出钢计划；</para>
    /// <para> 2.修改并下达出钢计划；</para>
    /// <para> 3.画面配置；</para>
    /// </summary>
    /// Copyright: Baosight Software LTD.co Copyright (c) 2011
    /// Company: 上海宝信软件股份有限公司
    /// Author:  lijie
    /// Version: 1.0
    /// History:
    /// 2011-11-29 lijie [创建] 
    public partial class FormPSSM18Z : EF.EFFormMain
    {
        private string factory_div = "";
        private string s_factory_div = "";
        private string query_type = "1";
        private string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。
        private string show_flag = "";
        private string box_flag = "0";

        private GEZ.GEUserControl geUserControl1;

        public FormPSSM18Z()
        {
            InitializeComponent();
            initGE();
            this.geUserControl1.QueryPlanEvent += new GEZ.QueryPlanHandler(geUserControl1_QueryPlanEvent); //计划查询
            this.geUserControl1.UpdatePlanEvent += new GEZ.UpdatePlanHandler(geUserControl1_UpdatePlanEvent); //计划保存
            this.geUserControl1.ChangePlanEvent += new GEZ.ChangePlanHandler(geUserControl1_ChangePlanEvent); //炉次交换及钢种变更
            this.geUserControl1.ShowFactSignalEvent += new GEZ.ShowFactSignalHandler(geUserControl1_ShowFactSignalEvent); //实际显示
            this.geUserControl1.UpdateFactSignalEvent += new GEZ.UpdateFactSignalHandler(geUserControl1_UpdateFactSignalEvent);
            this.geUserControl1.ModelRunEvent += new GEZ.ModelRunHandler(geUserControl1_ModelRunEvent); //模型调用
            this.geUserControl1.StateBackEvent += new GEZ.StateBackHandler(geUserControl1_StateBackEvent); //状态回退
            this.geUserControl1.ReturnStoveEvent += new GEZ.ReturnStoveHandler(geUserControl1_ReturnStoveEvent); //回炉
            this.geUserControl1.OtherEvent += new GEZ.OtherHandler(geUserControl1_OtherEvent);//其他事件处理,点击按钮，选中工序弹出对话框
            this.geUserControl1.Other2Event += new GEZ.Other2Handler(geUserControl1_Other2Event);//其他事件2处理,点击按钮，直接弹出对话框
            this.geUserControl1.TimedRefreshEvent += new GEZ.TimedRefreshHandler(geUserControl1_TimedRefresh);//控制自动刷新
            // this.geUserControl1.ChangeCCDTimeEvent +=new GE.ChangeCCDTimeHandler( geUserControl1_ChangeCCDTimeEvent);
            //this.geUserControl1.SendPlanEvent += new GEZ.SendPlanHandler(geUserControl1_SendPlanEvent);

        }
        private void geUserControl1_TimedRefresh(bool timeFlag)
        {
            if (timeFlag)
            {
                this.efDevCheckEdit1.Checked = timeFlag;
            }
            else 
            {
                this.efDevCheckEdit1.Checked = timeFlag;
            }
        }
        /// <summary>
        /// 添加甘特图控件，并布局
        /// </summary>
        private void initGE()
        {
            this.geUserControl1 = new GEZ.GEUserControl();
            this.efPanel1.Controls.Add(this.geUserControl1);
            //this.geUserControl1.Anchor = AnchorStyles.Bottom & AnchorStyles.Left & AnchorStyles.Right & AnchorStyles.Top;
            this.geUserControl1.Dock = DockStyle.Fill;
            this.geUserControl1.BackColor = System.Drawing.Color.Black;
            this.geUserControl1.CanEdit = true;

            this.geUserControl1.Name = "geUserControl1";
            this.efDevCheckEdit1.BringToFront();
            this.efDevCheckEdit1.Checked = true;
            //this.efCheckBox1.BringToFront();
            //this.efCheckBox1.Checked = false;
        }

        #region 画面加载及初始化
        private void FormPSSM21_EF_START_FORM_BY_EP(object sender, EF.EF_Args i_args)
        {

            //增加以下信息
            //=================
            //画面对应的当前分区= v_curr_part
            v_curr_part_name = this.ef_args.formPartition; //画面在 EPESOBJ 中维护的分区代码。

            //产品化中炼钢单元号代码是A，如果有多个分厂，可通过配置子画面的方式传入这个参数。
            factory_div = i_args.GetCallParamsByName("factory_div");
            show_flag = i_args.GetCallParamsByName("showflag");

            //若ES没有配置参数, 默认取“1”
            if (factory_div.Trim() == "") factory_div = "LG1";

        }

        /// <summary>
        /// 画面初始化
        /// <para>初始化主工序代码</para>
        /// <para>查询出钢计划</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>无</returns>
        private void geUserControl1_Load(object sender, System.EventArgs e)
        {
            s_factory_div = this.ef_args.GetCallParamsByName("key");
            //this.geUserControl1.RegName = factory_div;
            efDevCalcEdit1.Value = 60;

            query(query_type);

        }
        #endregion



        #region 计时器

        /// <summary>
        /// 计时器
        /// <para>查询出钢计划</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>无</returns>
        private void querytimer_Tick(object sender, System.EventArgs e)
        {
            query(query_type);
        }
        #endregion


        #region 计划查询 事件
        /// <summary>
        /// 出钢计划查询事件
        /// <para>查询出钢计划</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="inblock"></param>
        /// <returns>无</returns>
        private void geUserControl1_QueryPlanEvent(object sender, out EI.EIInfo inblock, string query_mode)
        {
            inblock = query(query_mode);
        }
        #endregion


        #region 计划保存  函数与事件
        public bool planSave(EI.EIInfo _planBlock)
        {
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;

            try
            {
                //定义出钢计划的“炼钢单元号”
                string server_name = " ";
                DataTable dt = _planBlock.Tables.Add("PLAN");
                dt.Columns.Add("FACTORY_DIV", typeof(String));  //炼钢单元号
                dt.Rows.Add(factory_div);
                //dt.Rows[0]["FACTORY_DIV"] = factory_div;

                server_name = "pssm12z_save2";
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, server_name, _planBlock);
                s = outBlock.GetSys();

                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    GC.PM_utility2.Dev_messageBoxError("保存失败！" + s.msg);
                    return false;
                }

                if (box_flag == "0")
                {
                    GC.PM_utility2.Dev_messageBoxInfo("保存成功！");
                    //this.EFMsgInfo = "计划保存成功";
                }

                box_flag = "0";
                //query(query_type);
            }
            catch (Exception err)
            {
                this.EFMsgInfo = err.Message;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 计划保存事件
        /// <para>保存出钢计划</para>
        /// <para>下达出钢计划</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="outblock"></param>
        /// <returns>无</returns>
        private void geUserControl1_UpdatePlanEvent(object sender, EI.EIInfo outblock)
        {
            //计划保存
            if (planSave(outblock) == false) return;

            //重新查询计划
            query(query_type);
            this.EFMsgInfo = GC.GCRS.GCRSC0000009/*处理成功。*/;
        }
        #endregion


        #region 某些功能
        private void geUserControl1_ShowElementEvent(object sender, string pono)
        {

        }
        //private void geUserControl1_ChangeCCDTimeEvent(EI.EIInfo outblock)
        //{ 

        //}
        private void geUserControl1_ShowPlanMakeEvent()
        {
            //			FormPSSM11PlanDlg f11run = new FormPSSM11PlanDlg();
            //			factory_div = "A";
            //			//			f11run.Show();
            //			f11run.ShowDialog();
            //
            //			// 判断对话框的结果
            //			switch( f11run.DialogResult )
            //			{
            //				case DialogResult.OK :
            //					query();
            //					this.EFMsgInfo = "编制成功。";
            //					break;
            //				case DialogResult.Cancel:
            //					break;
            //			}
            //plan_send();
        }

        private void geUserControl1_ShowSmeltingEvent(string pono, string equipmentid)
        {

        }

        private void geUserControl1_MidPackageDivsionEvent(string pono, string td_chg_flg)
        {

        }

        private void geUserControl1_MidPackageCombinationEvent(string pono, string td_chg_flg)
        {

        }

        #endregion


        #region 设备状态更新
        /// <summary>
        /// 设备状态更新
        /// <para>保存修改的设备状态</para>
        /// </summary>
        /// <param name="devcode"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="details"></param>
        /// <param name="subdetail"></param>
        /// <returns>无</returns>
        private void geUserControl1_EquipmentStateDeleteEvent(string devcode, string starttime, string endtime, string details, string subdetail)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;

            try
            {
                //inBlock.Tables[0].Columns.Add("DEV_CODE",typeof(String));
                //inBlock.Tables[0].Columns.Add("START_TIME", typeof(String));
                //inBlock.Tables[0].Columns.Add("END_TIME", typeof(String));
                //inBlock.Tables[0].Rows.Add();
                //inBlock.Tables[0].Rows[0]["DEV_CODE"]=devcode;
                //inBlock.Tables[0].Rows[0]["START_TIME"]=starttime;
                //inBlock.Tables[0].Rows[0]["END_TIME"]=endtime;

                //outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18_del", inBlock);
                //s = outBlock.GetSys();

                //if (s.flag < 0)
                //{
                //    this.EFSysInfo = s;
                //    return;
                //}

            }
            catch (Exception err)
            {
                this.EFMsgInfo = string.Format(GC.GCRS.GCRSC0000018/*系统出现异常[{0}]，请联系系统维护人员。*/, err.Message);
                return;
            }
            this.EFMsgInfo = GC.GCRS.GCRSC0000009/*处理成功。*/;
        }
        #endregion


        #region 钢水对换与钢种变更
        private void geUserControl1_ChangePlanEvent(EI.EIInfo outblock, string pono1, string pono2, int heat_num)
        {
            //1是只有1炉在计划内，并且有实绩，2是有2炉都在计划内  

            //EI.EIInfo inBlock = new EI.EIInfo();
            //EI.EIInfo outBlock;
            //EI.EIInfo.eiinfo_sys s;

            //try
            //{
            //    //有2炉都在计划内 
            //    if (heat_num == 2)
            //    {

            //        if (EF.EFMessageBox.Show("是否进行钢水对换?", "钢水对换", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            //            == DialogResult.No)
            //        {
            //            return;
            //        }

            //        inBlock.Tables[0].TableName = "HEAT_CHG";  //钢水对换
            //        inBlock.Tables[0].Columns.Add("FACTORY_DIV");
            //        inBlock.Tables[0].Columns.Add("SM_PLAN_NO");
            //        inBlock.Tables[0].Rows.Add();
            //        inBlock.Tables[0].Rows[0]["SM_PLAN_NO"] = pono1;
            //        inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;
            //        inBlock.Tables[0].Rows.Add();
            //        inBlock.Tables[0].Rows[1]["SM_PLAN_NO"] = pono2;
            //        inBlock.Tables[0].Rows[1]["FACTORY_DIV"] = factory_div;

            //        outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18_chg_in", inBlock);  
            //        s = outBlock.GetSys();

            //        if (s.flag < 0)
            //        {
            //            this.EFSysInfo = s;
            //            return;
            //        }

            //    }                
            //    else if (heat_num == 1)//只有1炉在计划内，并且有实绩
            //    {

            //        //if (EF.EFMessageBox.Show(PS.PSSM.PSSMC0000084/*是否进行钢种变更?*/, PS.PSSM.PSSMC0000085/*钢种变更*/, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            //        //  == DialogResult.No)
            //        if (EF.EFMessageBox.Show("是否进行钢种变更", "钢种变更", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            //          == DialogResult.No)
            //        {
            //            return;
            //        }
            //        inBlock.Tables[0].TableName = "STNO_CHG";  //钢种变更
            //        inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
            //        inBlock.Tables[0].Columns.Add("WORK_PROC", typeof(String));
            //        inBlock.Tables[0].Columns.Add("PONO_OUT", typeof(String));
            //        inBlock.Tables[0].Columns.Add("PONO_IN", typeof(String));
            //        inBlock.Tables[0].Rows.Add();
            //        inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;
            //        inBlock.Tables[0].Rows[0]["WORK_PROC"] = "0";
            //        inBlock.Tables[0].Rows[0]["PONO_OUT"] = pono1;
            //        inBlock.Tables[0].Rows[0]["PONO_IN"] = pono2;

            //        outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18_chg_out", inBlock);//
            //        s = outBlock.GetSys();

            //        if (s.flag < 0)
            //        {
            //            this.EFSysInfo = s;
            //            return;
            //        }
            //    }
            //    this.EFMsgInfo = GC.GCRS.GCRSC0000009/*处理成功。*/;

            //    //重新查询计划
            //    query(query_type);

            //    //自动保存下发
            //    //if (EF.EFMessageBox.Show("处理成功,是否保存并下发计划", "保存并下发计划", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            //    //      == DialogResult.No)
            //    //{
            //    //    return;
            //    //}
            //    //object sender1 = new object();
            //    //this.geUserControl1_UpdatePlanEvent(sender1, outblock);

            //   // GC.PM_utility2.Dev_messageBoxError("处理成功,请保存并下发计划！");//提醒用户手动保存
            //}
            //catch (Exception err)
            //{
            //    this.EFMsgInfo = err.Message;
            //    return ;
            //}


        }
        #endregion


        #region 实际显示
        private void geUserControl1_ShowFactSignalEvent(EI.EIInfo outblock, string pono, int k, string ccbeginttime, string ccendtime)
        {

        }

        private void geUserControl1_UpdateFactSignalEvent(EI.EIInfo updateblock)
        {

        }
        #endregion


        #region 时间调整（Dlg）
        /// <summary>
        /// 时间优化调整
        /// </summary>
        /// <para>时间优化调整</para>
        /// <param name="sender"></param>
        /// <param name="outblock"></param>
        /// <returns>无</returns>
        private void geUserControl1_ModelRunEvent(object sender, EI.EIInfo outblock)
        {
            //计划保存
            //if (planSave(outblock) == false) return;

            //EI.EIInfo inBlock = new EI.EIInfo();
            //EI.EIInfo outBlock;
            //EI.EIInfo.eiinfo_sys s;

            //inBlock.Tables.Add("PLAN");
            //inBlock.Tables["PLAN"].Columns.Add("FACTORY_DIV");
            //inBlock.Tables["PLAN"].Columns.Add("MODE");
            //inBlock.Tables["PLAN"].Rows.Add(factory_div, 1);//时间优化

            //outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18_create", inBlock);
            //s = outBlock.GetSys();

            //if (s.flag < 0)
            //{
            //   this.EFMsgInfo = outBlock.sys_info.msg + "\n" + outBlock.sys_info.sysmsg;    //状态栏提示报错             
            //   return;
            //}

            //query(query_type);

        }
        #endregion


        #region 状态回退（Dlg）
        /// <summary>
        /// 状态回退
        /// </summary>
        /// <para>连铸回退到转炉吹炼前</para>
        /// <para>连铸回退到精炼结束后</para>
        /// <param name=""></param>
        /// <returns>无</returns>
        private void geUserControl1_StateBackEvent(string pono, string heat_no)
        {
            //弹出状态回退画面
            FormPSSM18S sBack = new FormPSSM18S();
            sBack.factory_div = factory_div;
            sBack.heat_no = heat_no;
            sBack.pono = pono;
            sBack.v_curr_part_name = v_curr_part_name;
            sBack.ShowDialog();

            // 判断对话框的结果
            switch (sBack.DialogResult)
            {
                case DialogResult.OK:
                    //重新查询出钢计划
                    query(query_type);
                    this.EFMsgInfo = GC.GCRS.GCRSC0000009/*处理成功。*/;
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }
        #endregion


        #region 钢水返送（Dlg）
        /// <summary>
        /// 钢水返送
        /// </summary>
        /// <para>有实绩后，钢水回炉</para>
        /// <param name=""></param>
        /// <returns>无</returns>
        private bool geUserControl1_ReturnStoveEvent(string pono, string heat_no)
        {
            bool isReturn = false;
            //弹出钢水返送画面
            FormPSSM18R rStove = new FormPSSM18R();
            //FormPSSM18B rStove = new FormPSSM18B();
            EF.EF_Args.common_parameter_1 = v_curr_part_name;//传递分区
            rStove.factory_div = factory_div;
            rStove.heat_no = heat_no;
            rStove.ShowDialog();

            // 判断对话框的结果
            switch (rStove.DialogResult)
            {
                case DialogResult.OK:
                    //重新查询出钢计划
                    query(query_type);
                    this.EFMsgInfo = GC.GCRS.GCRSC0000009/*处理成功。*/;
                    isReturn = true;
                    break;
                case DialogResult.Cancel:
                    isReturn = false;
                    break;
            }
            return isReturn;
        }
        #endregion

        #region 其他功能，点击工序弹出对换框（Dlg）
        /// <summary>
        /// 其他事件，比如信号模拟
        /// </summary>
        /// <para></para>
        /// <param name=""></param>
        /// <returns>无</returns>
        private void geUserControl1_OtherEvent(string pono, string heat_no, string dev_code, int charge_no)
        {

            FormPSSM18O otherDlg = new FormPSSM18O();
            otherDlg.btnClickEvent += new FormPSSM18O.btnClickEventHandler(otherDlg_btnClickEvent);//控制是否重新刷新计划
            otherDlg.factory_div = factory_div;
            otherDlg.heat_no = heat_no;
            otherDlg.pono = pono;
            otherDlg.dev_code = dev_code + "-" + charge_no;
            otherDlg.v_curr_part_name = v_curr_part_name;//传递分区
            //otherDlg.charge_no = charge_no;

            otherDlg.TopMost = true;
            otherDlg.ShowDialog();

            // otherDlg.ShowDialog();
            // 判断对话框的结果
            //switch (otherDlg.DialogResult)
            //{
            //    case DialogResult.OK:
            //        //重新查询出钢计划
            //        query(query_type);
            //        this.EFMsgInfo = GC.GCRS.GCRSC0000009/*处理成功。*/;                    
            //        break;
            //    case DialogResult.Cancel:
            //        break;
            //}


        }

        #region 其他事件2，点击按钮直接弹出对换框（Dlg）
        /// <summary>
        /// 钢水返送
        /// </summary>
        /// <para>有实绩后，钢水回炉</para>
        /// <param name=""></param>
        /// <returns>无</returns>
        private void geUserControl1_Other2Event()
        {

            FormPSSM18O2 other2Dlg = new FormPSSM18O2();
            EF.EF_Args.common_parameter_1 = v_curr_part_name;//传递分区
            other2Dlg.factory_div = factory_div;//传入厂别区分
            other2Dlg.ShowDialog();
            // 判断对话框的结果
            switch (other2Dlg.DialogResult)
            {
                case DialogResult.OK:
                    //重新查询出钢计划
                    query(query_type);
                    this.EFMsgInfo = GC.GCRS.GCRSC0000009/*处理成功。*/;
                    break;
                case DialogResult.Cancel:
                    break;
            }
            return;
        }
        #endregion
        private void otherDlg_btnClickEvent(string flag)
        {
            if (flag == "1") query(query_type);

        }
        #endregion


        #region 计划查询
        /// <summary>
        /// 计划查询
        /// </summary>
        /// <para>查询出钢计划</para>
        /// <param name=""></param>
        /// <returns>无</returns>
        public EI.EIInfo query(string query_mode)
        {

            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;

            try
            {
                string server_name = " ";
                //定义出钢计划的“炼钢单元号”
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("QUERY_TYPE", typeof(String));
                inBlock.Tables[0].Columns.Add("SHOW_FLAG", typeof(String));
                inBlock.Tables[0].Rows.Add();
                inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;
                inBlock.Tables[0].Rows[0]["QUERY_TYPE"] = "3";
                inBlock.Tables[0].Rows[0]["SHOW_FLAG"] = show_flag;

                server_name = "pssm18z_inq";

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, server_name, inBlock);
                s = outBlock.GetSys();

                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    return outBlock;
                }


                geUserControl1.GetPlanForEdit(outBlock);



            }
            catch (Exception err)
            {
                this.EFMsgInfo = err.Message;
                return null;
            }
            //this.EFMsgInfo = GC.GCRS.GCRSC0000001/*查询成功。*/;
            String now = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.EFMsgInfo = "当前【" + now + "】查询成功";
            return outBlock;
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("select data");// 测试用
        }

        private void efDevCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.efDevCheckEdit1.Checked == true)
            {
                if (efDevCalcEdit1.Value >= 10)
                {
                    this.timer1.Interval = Int32.Parse(efDevCalcEdit1.Value.ToString()) * 1000;
                }
                else this.timer1.Interval = 60000;
                this.timer1.Start();
            }
            else
            {
                this.timer1.Stop();

            }
        }

        private void geUserControl1_SendPlanEvent(Decimal time, EI.EIInfo _planBlock)
        {
            //计划保存
            box_flag = "1";

            if (planSave(_planBlock) == false) return;

            string server_name = " ";
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;

            if (_planBlock.Tables.Contains("PLAN"))
            {
                _planBlock.Tables["PLAN"].Columns.Add("SOURCE_FLAG", typeof(String));
                _planBlock.Tables["PLAN"].Rows[0]["SOURCE_FLAG"] = "TPSSM15";
            }
            else
            {
                DataTable dt = _planBlock.Tables.Add("PLAN");
                dt.Columns.Add("FACTORY_DIV", typeof(String));  //炼钢单元号
                dt.Columns.Add("SOURCE_FLAG", typeof(String));
                dt.Rows.Add(factory_div, "TPSSM15");
            }

            //inBlock.Tables.Add("PLAN");
            //inBlock.Tables["PLAN"].Columns.Add("FACTORY_DIV", typeof(String));
            //inBlock.Tables["PLAN"].Rows.Add(factory_div,"TPSSM15");
            //inBlock.Tables["PLAN"].Columns.Add("MODE");
            //inBlock.Tables["PLAN"].Rows.Add(factory_div, 1);//时间优化
            _planBlock.Tables.Add("TIME");
            _planBlock.Tables["TIME"].Columns.Add("TIME", typeof(Decimal));
            //inBlock.Tables["PLAN"].Columns.Add("MODE");
            _planBlock.Tables["TIME"].Rows.Add(time);//时间优化

            if (show_flag == "2") server_name = "pssm18_save";
            else server_name = "pssm18_send";
            //outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, server_name, _planBlock);
            //s = outBlock.GetSys();

            //if (s.flag < 0)
            //{
            //    this.EFSysInfo = s;
            //    GC.PM_utility2.Dev_messageBoxError("下发失败！" + s.msg);
            //    //return false;
            //}
            //GC.PM_utility2.Dev_messageBoxInfo("已下发计划！");

            query(query_type);
        }


    }
}
