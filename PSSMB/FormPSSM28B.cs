using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PS
{
    public partial class FormPSSM28B : EF.EFForm
    {
        #region 构造方法
        public FormPSSM28B()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定变量
        /// <summary>
        /// 由PSSM11调用时获取
        /// </summary>
        private string v_curr_part_name = "BSMES"; //当前画面的分区代码。
        private string colname;
        private string factory_div;
        private string cc_mach_no;
        private string pono;
        private string bof_no;
        private string refine_route_code;
        private string device_code;
        private string device_name;
        private string service_name_inq;
        public EI.EIInfo inBlock_cast = new EI.EIInfo();
        public EI.EIInfo inBlock_All = new EI.EIInfo();
        #endregion

        #region Load事件
        /// <summary>
        /// 一   提取参数(Dictionary<String, String>)EF.EF_Args.common_object_1
        /// 二   委托加载(Load)
        /// 三   委托查询(F2 查询)
        /// 四   委托确认(F3 确认)
        /// </summary>
        private void FormPSSM28B_EF_START_FORM_BY_EF(object sender, EF.EF_Args i_args)
        {
            #region 提取参数
            Dictionary<String, String> paras = (Dictionary<String, String>)EF.EF_Args.common_object_1;
            v_curr_part_name = paras.ContainsKey("V_CURR_PART_NAME") ? paras["V_CURR_PART_NAME"] : "BSMES";
            colname = paras.ContainsKey("COLNAME") ? paras["COLNAME"] : "";//switch条件
            factory_div = paras.ContainsKey("FACTORY_DIV") ? paras["FACTORY_DIV"] : "";
            cc_mach_no = paras.ContainsKey("CC_MACH_NO") ? paras["CC_MACH_NO"] : "";
            pono = paras.ContainsKey("PONO") ? paras["PONO"] : "";
            bof_no = paras.ContainsKey("BOF_NO") ? paras["BOF_NO"] : "";
            refine_route_code = paras.ContainsKey("REFINE_ROUTE_CODE") ? paras["REFINE_ROUTE_CODE"] : "";
            #endregion

            ///
            //确认设备号
            //分配加载委托
            //分配确认委托
            ///
            switch (colname)
            {
                case "CAST_NO_SHOW":  //浇次调整
                    device_code = cc_mach_no;//设备号
                    B_Load = castLoad;
                    B_Load += castNoLoad;
                    B_Confirm = castChange;//确认
                    break;
                case "CC_START_TIME":  //浇铸时刻调整
                case "CC_END_TIME":  //浇铸时刻调整
                    device_code = cc_mach_no;//设备号
                    B_Load = castLoad;
                    B_Load += castTimeLoad;
                    B_Confirm = timeChange;//确认
                    break;
                case "SR1_START_TIME":
                    device_code = refine_route_code.Substring(0, 2);//设备号
                    B_Load = seqLoad;
                    B_Confirm = seqConfirm;//确认
                    break;
                case "SR2_START_TIME":
                    device_code = refine_route_code.Substring(2, 2);//设备号
                    B_Load = seqLoad;
                    B_Confirm = seqConfirm;//确认
                    break;
                case "SR3_START_TIME":
                    device_code = refine_route_code.Substring(4, 2);//设备号
                    B_Load = seqLoad;
                    B_Confirm = seqConfirm;//确认
                    break;
                case "SR4_START_TIME":
                    device_code = refine_route_code.Substring(6, 2);//设备号
                    B_Load = seqLoad;
                    B_Confirm = seqConfirm;//确认
                    break;
                case "DC_BLOW_START_TIME":
                    device_code = bof_no;//设备号
                    B_Load = smeltTimeLoad;
                    B_Confirm = smeltConfirm;//确认
                    break;
            }
            B_Load = devLoad + B_Load;//加载设备号
        }
        public void FormPSSM28B_Load(object sender, EventArgs e)
        {
            #region 提取参数
            Dictionary<String, String> paras = (Dictionary<String, String>)EF.EF_Args.common_object_1;
            v_curr_part_name = paras.ContainsKey("V_CURR_PART_NAME") ? paras["V_CURR_PART_NAME"] : "BSMES";
            colname = paras.ContainsKey("COLNAME") ? paras["COLNAME"] : "";//switch条件
            factory_div = paras.ContainsKey("FACTORY_DIV") ? paras["FACTORY_DIV"] : "";
            cc_mach_no = paras.ContainsKey("CC_MACH_NO") ? paras["CC_MACH_NO"] : "";
            pono = paras.ContainsKey("PONO") ? paras["PONO"] : "";
            bof_no = paras.ContainsKey("BOF_NO") ? paras["BOF_NO"] : "";
            refine_route_code = paras.ContainsKey("REFINE_ROUTE_CODE") ? paras["REFINE_ROUTE_CODE"] : "";


            inBlock_All = (EI.EIInfo)EF.EF_Args.common_object_2;
            #endregion

            ///
            //确认设备号
            //分配加载委托
            //分配确认委托
            ///
            switch (colname)
            {
                case "CAST_NO_SHOW":  //浇次调整
                    device_code = cc_mach_no;//设备号
                    B_Load = castLoad;
                    B_Load += castNoLoad;
                    B_Confirm = castChange;//确认
                    break;
                case "CC_START_TIME":  //浇铸时刻调整
                case "CC_END_TIME":  //浇铸时刻调整
                    device_code = cc_mach_no;//设备号
                    B_Load = castLoad;
                    B_Load += castTimeLoad;
                    B_Confirm = timeChange;//确认
                    break;
                case "SR1_START_TIME":
                    device_code = refine_route_code.Substring(0, 2);//设备号
                    B_Load = seqLoad;
                    B_Confirm = seqConfirm;//确认
                    break;
                case "SR2_START_TIME":
                    device_code = refine_route_code.Substring(2, 2);//设备号
                    B_Load = seqLoad;
                    B_Confirm = seqConfirm;//确认
                    break;
                case "SR3_START_TIME":
                    device_code = refine_route_code.Substring(4, 2);//设备号
                    B_Load = seqLoad;
                    B_Confirm = seqConfirm;//确认
                    break;
                case "SR4_START_TIME":
                    device_code = refine_route_code.Substring(6, 2);//设备号
                    B_Load = seqLoad;
                    B_Confirm = seqConfirm;//确认
                    break;
                case "DC_BLOW_START_TIME":
                    device_code = bof_no;//设备号
                    B_Load = smeltTimeLoad;
                    B_Confirm = smeltConfirm;//确认
                    break;
            }
            B_Load = devLoad + B_Load;//加载设备号
            if (B_Load != null)
            {
                B_Load();//根据EF调用条件加载对应的内容

                //查询的必要条件封装为私有属性，在Load中加载
                B_Query = b_query;//查询委托
                b_query_result = B_Query.BeginInvoke(null, null);//异步查询数据 存入B_Query_Result
                queryTimer.Start();//开启计时器检查异步查询状态 再调用showData()显示回调数据
            }
        }
        #endregion

        #region 加载组件
        private delegate void PSSM28B_Load();//定义加载委托
        private PSSM28B_Load B_Load;
        private void devLoad()//加载设备号
        {
            layoutControlGroup1.TextVisible = false;
            EF.Utility.SetSingleGridColumn(efDevGrid1, "PSSM28B_INQ", v_curr_part_name);
            EFX.EFCGrid.GetEFCGridBase(efDevGrid1).SetGridCellValue(0, "DEV_CODE", device_code);//设置0行DEV_CODE列的值
            layoutControlGroup1.Size = new System.Drawing.Size(layoutControlGroup1.Size.Width, 55/*一行*/);
        }
        private void castLoad()
        {
            device_name = "CC_MACH_NO";
            //service_name_inq = "pssm11_inq_cast";
            EF.Utility.SetGridColumn(new EF.EFDevGrid[] { efDevGrid2 }, new string[] { "PSSM28_CAST_DLG" }, v_curr_part_name);




        }
        private void castNoLoad()//加载浇次调整内容 gird 1 2
        {
            //grid2 用于显示查询数据
            layoutControlGroup2.Text = "浇次内计划信息";
            efDevGrid2.ShowSelectionColumn = false;

            if (gridView2.Columns.ColumnByFieldName("CC_REQ_TIME") != null)
            {
                gridView2.Columns["CC_REQ_TIME"].OptionsColumn.AllowEdit = false;
            }
            efDevGrid2.AllowDragRow = true; //允许行拖动
        }
        private void castTimeLoad()//加载浇铸时刻调整内容 grid 1 2 3
        {
            //grid2 用于显示查询数据
            layoutControlGroup2.Text = "浇次内计划信息";
            efDevGrid2.ShowSelectionColumn = true;//显示多选框列
            if (gridView2.Columns.ColumnByFieldName("CC_REQ_TIME") != null)
            {
                gridView2.Columns["CC_REQ_TIME"].OptionsColumn.AllowEdit = true;
                gridView2.FocusedColumn = gridView2.Columns.ColumnByFieldName("CC_REQ_TIME");
            }
            efDevGrid2.AllowDragRow = false; //不允许行拖动

            //grid3 用于选择调整范围
            layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGroup3.Text = "时间调整范围";
            layoutControlGroup3.Enabled = true;
            EF.Utility.SetSingleGridColumn(efDevGrid3, "PSSM11_CAST_TIME", v_curr_part_name);
            set_Heat_Scope_LookUp_Value();
        }
        private void set_Heat_Scope_LookUp_Value()//设置下拉框 调整开浇时间的 炉次选择 grid3
        {
            DataTable dt = new DataTable();
            String heat_scope = "HEAT_SCOPE";//1选择的炉 2CAST内炉次 3后续所有炉
            String CN = "CN";
            String[] CNs = { "选择的炉", "CAST内炉次", "后续所有炉" };//1选择的炉 2CAST内炉次 3后续所有炉
            dt.Columns.Add(heat_scope, typeof(System.String));
            dt.Columns.Add(CN, typeof(System.String));
            for (int i = 0; i < CNs.Length; i++)
            {
                dt.Rows.Add();
                dt.Rows[i][heat_scope] = i + 1;
                dt.Rows[i][CN] = CNs[i];
            }
            EFX.EFCGrid.GetEFCGridBase(efDevGrid3).Columns[heat_scope].SetPopupGridDataSource(dt, heat_scope, new string[] { CN });
            EFX.EFCGrid.GetEFCGridBase(efDevGrid3).SetGridCellValue(0, "HEAT_SCOPE", 1);//设置0行HEAT_SCOPE列的值 [选择的炉]
            EFX.EFCGrid.GetEFCGridBase(efDevGrid3).SetGridCellValue(0, "TIME_UPD", true);//设置0行TIME_UPD列的值 [自动前推各工序作业]
            EFX.EFCGrid.GetEFCGridBase(efDevGrid3).SetGridCellValue(0, "PROC_NO_UPD", false);//设置0行PROC_NO_UPD列的值 [自动更新各工序顺序]
        }
        private void seqLoad()// grid 1 2
        {
            device_name = "DEV_CODE";
            service_name_inq = "pssm11_seq_inq";
            //layoutControlGroup2.Text = "已生产炉次";
            //EF.Utility.SetGridColumn(new EF.EFDevGrid[] { efDevGrid2, efDevGrid3 }, new string[] { "PSSM11_SEQ_DLG", "PSSM11_SEQ_DLG2" }, v_curr_part_name);
            //调整界面不再显示已生产炉次 ↑
            layoutControlGroup2.Text = "未生产炉次";
            efDevGrid2.AllowDragRow = true;
            EF.Utility.SetGridColumn(new EF.EFDevGrid[] { efDevGrid2 }, new string[] { "PSSM28_SEQ_DLG2" }, v_curr_part_name);
        }
        private void smeltTimeLoad()//浇铸窗口加载 grid 1 2
        {
            device_name = "DEV_CODE";
            service_name_inq = "pssm11_time_inq";
            EF.Utility.SetGridColumn(new EF.EFDevGrid[] { efDevGrid2 }, new string[] { "PSSM28_TIME_DLG" }, v_curr_part_name);
            layoutControlGroup2.Text = bof_no + "号炉转炉作业信息";
        }
        #endregion

        #region 查询组件
        private delegate EI.EIInfo PSSM11B_Query();//定义查询委托
        private PSSM11B_Query B_Query;//定义查询委托
        private IAsyncResult b_query_result;//异步查询结果

        //主查询(查询service见加载组件)
        private EI.EIInfo b_query()//提取查询条件并发送到后台 返回查询数据
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
            inBlock.Tables[0].Columns.Add("PONO", typeof(String));
            inBlock.Tables[0].Columns.Add(device_name, typeof(String));
            DataRow row = inBlock.Tables[0].Rows.Add();
            row["FACTORY_DIV"] = factory_div;
            row["PONO"] = pono;
            row[device_name] = device_code;//设备号
            return EI.EIManager.Instance.CallService(v_curr_part_name, service_name_inq, inBlock);
        }
        private void showData(EI.EIInfo outBlock)//显示查询数据
        {
            if (outBlock.sys_info.flag < 0)
            {
                EFMsgInfo = outBlock.sys_info.msg + "\n" + outBlock.sys_info.sysmsg;
            }
            else
            {
                EF.Utility.SetCustomGridValue(efDevGrid2, outBlock, false);
                gridView2.BestFitColumns();
                EFMsgInfo = "查询成功。";
                Console.WriteLine("查询成功");
            }
        }
        private void queryTimer_Tick(object sender, EventArgs e)//计时器检测异步查询状态
        {
            if (b_query_result.IsCompleted)
            {
                showData(B_Query.EndInvoke(b_query_result));
                queryTimer.Stop();//关闭计时器 停止检测异步查询状态
            }
        }
        #endregion

        #region 确认组件
        private delegate void PSSM11B_Confirm();
        private PSSM11B_Confirm B_Confirm;

        private void castChange()
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            inBlock.Tables[0].TableName = "CAST";
            inBlock.Tables[0].Merge((DataTable)efDevGrid2.DataSource);

            inBlock.Tables.Add();
            inBlock.Tables[1].TableName = "DEV";

            inBlock.Tables[1].Columns.Add("FACTORY_DIV", typeof(System.String));
            inBlock.Tables[1].Columns.Add("CC_MACH_NO", typeof(System.String));

            inBlock.Tables[1].Rows.Add();
            inBlock.Tables[1].Rows[0]["FACTORY_DIV"] = factory_div;
            inBlock.Tables[1].Rows[0]["CC_MACH_NO"] = cc_mach_no;

            EFMsgInfo = "顺序更新中...";
            outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm11_cast_upd", inBlock);

            if (outBlock.sys_info.flag < 0)
            {
                EFMsgInfo = outBlock.sys_info.msg + "\n" + outBlock.sys_info.sysmsg;
            }
            else
            {
                MessageBox.Show(cc_mach_no + "号连铸机计划浇次顺序进行了调整。");
                EFMsgInfo = "顺序更新成功。";
            }
        }

        private void timeChange()
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            if (this.efDevGrid1.GetSelectedDataRow().Rows.Count <= 0)
            {
                EFMsgInfo = "请选择要调整时间的炉次。";
            }
            inBlock.Tables[0].TableName = "CAST";
            inBlock.Tables[0].Merge(efDevGrid2.GetSelectedDataRow());

            DataTable dt = new DataTable();
            dt = EF.Utility.GetSingleGridValue(efDevGrid3).Tables[0];
            ///HEAT_SCOPE（时间调整范围（1-单炉次时间修改 2-CAST内 3-后续所有炉次））
            ///TIME_UPD（前工序时间调整）
            ///PROC_NO_UPD（工序顺序号调整）
            inBlock.Tables.Add();
            inBlock.Tables[1].TableName = "COND";
            inBlock.Tables[1].Merge(EF.Utility.GetSingleGridValue(efDevGrid3).Tables[0]);
            inBlock.Tables[1].Columns.Add("FACTORY_DIV", typeof(System.String));
            inBlock.Tables[1].Columns.Add("CC_MACH_NO", typeof(System.String));
            inBlock.Tables[1].Rows[0]["FACTORY_DIV"] = factory_div;
            inBlock.Tables[1].Rows[0]["CC_MACH_NO"] = cc_mach_no;

            EFMsgInfo = "时间更新中...";
            outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm11_cast_tm", inBlock);

            if (outBlock.sys_info.flag < 0)
            {
                EFMsgInfo = outBlock.sys_info.msg + "\n" + outBlock.sys_info.sysmsg;
            }
            else
            {
                MessageBox.Show(cc_mach_no + "号连铸机计划连铸时间进行了调整。");
                EFMsgInfo = "顺序更新成功。";
            }
        }

        private void seqConfirm()
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            try
            {
                inBlock.Tables[0].TableName = "PLAN";
                inBlock.Tables[0].Merge((DataTable)efDevGrid2.DataSource);

                Common.DateTimeConvert.ConvertTo14ByteString(inBlock, "PLAN", new string[] { "START_TIME" });

                //inBlock.Tables.Add();
                //inBlock.Tables[1].TableName = "DEV";
                #region 后台需要传入已生产炉次的信息？↓
                //inBlock.Tables[1].Merge((DataTable)efDevGrid_Prod.DataSource);
                #endregion ===========================↑

                #region =========厂别和设备号=======？↓
                //inBlock.Tables[1].Columns.Add("FACTORY_DIV", typeof(String));
                //inBlock.Tables[1].Columns.Add("DEV_CODE", typeof(String));//
                //inBlock.Tables[1].Rows[0]["FACTORY_DIV"] = factory_div;
                //inBlock.Tables[1].Rows[0]["DEV_CODE"] = dev_code;
                #endregion ===========================↑

                EFMsgInfo = "顺序更新中...";
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm11_seq_upd", inBlock);

                if (outBlock.sys_info.flag < 0)
                {
                    EFMsgInfo = outBlock.sys_info.msg + "\n" + outBlock.sys_info.sysmsg;
                }
                else
                {
                    EFMsgInfo = "顺序更新成功。";
                }
            }
            catch (Exception)
            {
            }
        }

        private void smeltConfirm()
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            try
            {
                inBlock.Tables[0].TableName = "MAIN";
                inBlock.Tables[0].Columns.Add("FACTORY_DIV");
                DataRow row = inBlock.Tables[0].Rows.Add();
                row["FACTORY_DIV"] = factory_div;

                inBlock.Tables.Add();
                inBlock.Tables[1].TableName = "BOF";
                inBlock.Tables[1].Merge((DataTable)EF.Utility.GetCustomGridValue(efDevGrid2).Tables[0]);

                EFMsgInfo = "时间修改中...";
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm11_time_upd", inBlock);

                if (outBlock.sys_info.flag < 0)
                {
                    EFMsgInfo = outBlock.sys_info.msg + "\n" + outBlock.sys_info.sysmsg;
                }
                else
                {
                    EFMsgInfo = "熔炼时间修改成功。";
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region 按钮事件
        private void FormPSSM28B_EF_DO_F2(object sender, EF.EF_Args e)
        {
            b_query_result = B_Query.BeginInvoke(null, null);//异步查询数据 存入B_Query_Result
            queryTimer.Enabled = true;//使用计时器检查异步查询状态 再调用showQuery显示回调数据
        }
        private void FormPSSM28B_EF_DO_F3(object sender, EF.EF_Args e)
        {
            try
            {
                if (B_Confirm != null) B_Confirm();
            }
            catch (Exception)
            {
                Close();
            }
        }
        #endregion

    }
}
