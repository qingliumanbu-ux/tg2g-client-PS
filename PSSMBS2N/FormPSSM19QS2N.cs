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
    public partial class FormPSSM19QS2N : EF.EFFormMain
    {
        private string factory_div = "";
        private string s_factory_div = "";
        private string query_type = "1";
        private string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。
        private string flag = "";
        private string show_flag = "";

        private GES2N.GEUserControl geUserControl1;
        private GanttCustomizationLibrary.GanttControlWpf GanttControlLibrary1;

        public FormPSSM19QS2N()
        {
            InitializeComponent();
            GanttControlLibrary1 = new GanttCustomizationLibrary.GanttControlWpf();
            GanttControlLibrary1.GanttInstanceID = "PSSM182";
            GanttControlLibrary1.ReadOnly = true;
            elementHost1.Child = GanttControlLibrary1;
            GanttControlLibrary1.DataInputDelegate += GanttInteract_DataInputEvent;
            GanttControlLibrary1.AddGanttDelegate("Gantt_Load", new PlguinFramework.Interface.CommonDelegate(GanttInteract_LoadEvent));//状态回退
            //GanttControlLibrary1.DataInputDelegate += GanttInteract_DataInputEventLoad;
            GanttControlLibrary1.Loaded += GanttControlLibrary1_Loaded;

        }

        private void GanttControlLibrary1_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            query_type = "3";
            query(query_type);
            query_type = "1";
        }


        #region 加载静态数据
        private object[] GanttInteract_LoadEvent(params object[] args)
        {
            if (args.Length == 0) return null;
            return new object[] { query(args[0].ToString()) };
        }
        #endregion

        private object[] GanttControlLibrary1_ReturnStoveEvent(params object[] args)
        {
            if (args.Length != 2) return null;
            string pono = args[0].ToString();
            string heat_no = args[1].ToString();


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
            return new object[] { isReturn };
        }

        private object[] GanttControlLibrary1_SendPlanEvent(params object[] args)
        {
            if (args.Length == 0) return null;

            decimal time = (decimal)args[0];

            //计划保存
            //if (planSave(outblock) == false) return;

            if (EF.EFMessageBox.Show("是否进行计划下发", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                      == DialogResult.No)
            {
                return null;
            }
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;

            inBlock.Tables.Add("TIME");
            inBlock.Tables["TIME"].Columns.Add("TIME", typeof(Decimal));
            //inBlock.Tables["PLAN"].Columns.Add("MODE");
            inBlock.Tables["TIME"].Rows.Add(time);//时间优化

            outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_send", inBlock);
            s = outBlock.GetSys();

            if (s.flag < 0)
            {
                this.EFSysInfo = s;
                GC.PM_utility2.Dev_messageBoxError("下发失败！" + s.msg);
                return null;
            }
            GC.PM_utility2.Dev_messageBoxInfo("已下发计划！");

            query(query_type);

            return null;
        }

        private object[] GanttInteract_DataInputEvent(params object[] args)
        {
            //EI.Logger.Info(DateTime.Now.ToString());
            //EI.Logger.Info("wcy的前台日志测试333：接收到查询信号" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (args.Length == 0) return null;
            object[] obj = new object[1];
            obj[0] = query(args[0].ToString());
            //EI.Logger.Info(DateTime.Now.ToString());
            //EI.Logger.Info("wcy的前台日志测试333：结束查询返回数据" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return obj;
        }
        private object[] Gantt_UpdPat(params object[] args)
        {
            if (args.Length == 0) return null;

            EI.EIInfo inblock = new EI.EIInfo();
            inblock.Tables.Clear();
            inblock.Merge((DataSet)args[0]);

            EI.EIInfo.eiinfo_sys s;


            inblock.Tables.Add("PLAN");
            inblock.Tables["PLAN"].Columns.Add("FACTORY_DIV", typeof(string));
            inblock.Tables["PLAN"].Rows.Add();
            inblock.Tables["PLAN"].Rows[0]["FACTORY_DIV"] = "LG1";

            EI.EIInfo outblock = EI.EIManager.Instance.CallService("TGT8Z", "pssm18_save_addupdate", inblock);

            s = outblock.GetSys();

            if (s.flag < 0)
            {
                EF.EFMessageBox.Show(outblock.sys_info.msg + "\n" + outblock.sys_info.sysmsg, "提示");
                return null;
            }
            return null;
        }
        private object[] Gantt_LogEvent(params object[] args)
        {
            EI.Logger.Info("苏武耒的前台日志测试查询：" + args[0].ToString());
            return null;
        }

        #region 状态回退（Dlg）
        /// <summary>
        /// 状态回退
        /// </summary>
        /// <para>连铸回退到转炉吹炼前</para>
        /// <para>连铸回退到精炼结束后</para>
        /// <param name=""></param>
        /// <returns>无</returns>
        private object[] GanttInteract_StateBackEvent(params object[] args)//string pono, string heat_nom
        {
            //弹出状态回退画面
            FormPSSM18S sBack = new FormPSSM18S();
            sBack.factory_div = factory_div;
            sBack.heat_no = args[1].ToString();
            sBack.pono = args[0].ToString();
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
            return null;
        }
        #endregion

        void GanttControlLibrary1_QueryPlanEvent(object sender, out DataSet inblock, string mode)
        {
            inblock = query(mode);
        }
        /// <summary>
        /// 添加甘特图控件，并布局
        /// </summary>
        private void initGE()
        {
            this.geUserControl1 = new GES2N.GEUserControl();
            this.efPanel1.Controls.Add(this.geUserControl1);
            //this.geUserControl1.Anchor = AnchorStyles.Bottom & AnchorStyles.Left & AnchorStyles.Right & AnchorStyles.Top;
            this.geUserControl1.Dock = DockStyle.Fill;
            this.geUserControl1.BackColor = System.Drawing.Color.Black;
            this.geUserControl1.CanEdit = true;

            this.geUserControl1.Name = "geUserControl1";
            this.efDevCheckEdit1.BringToFront();
            this.efDevCheckEdit1.Checked = false;
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
            DateTime dt_e = DateTime.Now;

            try
            {

                //定义出钢计划的“炼钢单元号”
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("QUERY_TYPE", typeof(String));
                inBlock.Tables[0].Columns.Add("SHOW_FLAG", typeof(String));
                inBlock.Tables[0].Columns.Add("HISTROY_TIME", typeof(String));
                inBlock.Tables[0].Rows.Add();
                inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;
                inBlock.Tables[0].Rows[0]["QUERY_TYPE"] = query_mode;
                inBlock.Tables[0].Rows[0]["SHOW_FLAG"] = show_flag;
                inBlock.Tables[0].Rows[0]["HISTROY_TIME"] = this.efDevDateEdit1.DateTime.ToString("yyyyMMddHHmmss");

                EI.Logger.Info("王程宇的前台日志测试查询：------------【时刻2】------------查询开始，当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                DateTime lastnow = System.DateTime.Now;
                dt_e = DateTime.Now;
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm19_inq", inBlock);
                s = outBlock.GetSys();
                EI.Logger.Info("王程宇的前台日志测试查询：------------【时刻5】------------查询结束，当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    return outBlock;
                }
                if (query_mode != "2")
                {
                    //20240118 M5 M6 设备代码显示定制
                    string captionFieldName = "SHOW_CAPTION";
                    var devdt = outBlock.Tables["DEV"];
                    devdt.Columns.Add(captionFieldName, typeof(string));

                    foreach (DataRow row in devdt.Rows)
                    {
                        string devCode = row["DEV_CODE"].ToString();

                        if (devCode == "M5" || devCode == "M6")
                        {
                            devCode = row["STATION_NAME"].ToString(); ;
                        }

                        row[captionFieldName] = devCode;
                    }
                }

                EI.Logger.Info("尤振的前台日志测试查询：------------【时刻5.5】------------开始处理XML数据开始，当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                outBlock.WriteXmlSchema("indataSchema.xml");
                outBlock.WriteXml("indata.xml");
                //geUserControl1.GetPlanForEdit(outBlock);

                EI.Logger.Info("尤振的前台日志测试查询：------------【时刻5.6】------------开始处理数据，当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                DateTime start_time = DateTime.Now;

                if (query_mode == "1")
                {
                    GanttControlLibrary1.RefresheGanttViewByDataSet(outBlock, "");
                }
                else if (query_mode == "3")
                {
                    GanttControlLibrary1.UpdateGanttViewByDataSet(outBlock, "");
                }
                EI.Logger.Info("尤振的前台日志测试查询：------------【时刻6】------------结束处理数据，当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            }
            catch (Exception err)
            {
                this.EFMsgInfo = err.Message;
                return null;
            }
            //this.EFMsgInfo = GC.GCRS.GCRSC0000001/*查询成功。*/;

            TimeSpan ts = DateTime.Now - dt_e;

            this.EFMsgInfo = "当前【" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "】查询成功";

            EI.Logger.Info("wcy的前台日志测试查询2：前台处理数据结束，当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "前台处理用时：" + (DateTime.Now - dt_e).TotalSeconds);
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
    }
}
