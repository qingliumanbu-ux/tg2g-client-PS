using DevExpress.XtraEditors;
using EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace PS
{
    public partial class FormPSSM28SI : EF.EFForm
    {
        EI.EIInfo.eiinfo_sys s;
        private string factory_div = "A10";
        private string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。
        private EI.EIInfo inBlock_All = new EI.EIInfo();
        private EI.EIInfo inBlock_Show = new EI.EIInfo();
        private EI.EIInfo inBlock_Save = new EI.EIInfo();
        private EI.EIInfo inBlock_para = new EI.EIInfo();
        private EI.EIInfo dlg_block= new EI.EIInfo();
        private string err_msg = " ";
        private int plan_flag = 0;
        private string v_plan_edit_flag = " ";
        private string v_edit_flag = " ";     //A-不考虑锁定   空表示考虑锁定
        private string if_cc_time_chg = " ";
        private string time_div = " ";   //1-CC; 2-BOF
        private string form_opt = "";    //画面执行的动作

        private string g_form = "PSSM28"; //SI配置画面名
        private DataSet DS;
        private BE2.FormConfig.FormConfigHelper formConfigHelper;
        private BE2.Common.LayoutDataChecker layoutDataCheckerMain = new BE2.Common.LayoutDataChecker();

        public FormPSSM28SI()
        {
            InitializeComponent();
        }

        private void FormPSSM28SI_EF_START_FORM_BY_EP(object sender, EF.EF_Args i_args)
        {
            //产品化中炼钢单元号代码是A，如果有多个分厂，可通过配置子画面的方式传入这个参数。
            factory_div = i_args.GetCallParamsByName("factory_div");
            
            //PSSM28B = i_args.GetCallParamsByName("PSSM28B");
            //若ES没有配置参数, 默认取“1”
            if (factory_div.Trim() == "") factory_div = "A10";

            time_div = i_args.GetCallParamsByName("time_div");
            if (time_div.Trim() == "") time_div = "1";//1-CC时间; 2-BOF时间
        }

        private void FormPSSM28SI_Load(object sender, EventArgs e)
        {

            //增加以下信息
            //=================
            //画面对应的当前分区= v_curr_part
            v_curr_part_name = this.ef_args.formPartition; //画面在 EPESOBJ 中维护的分区代码。
            if (this.ef_args.formEName.Equals("PSSM281SI"))
                g_form = this.ef_args.formEName;
            else if (this.ef_args.formEName.Equals("PSSM282SI"))
                g_form = "PSSM281SI";
            formConfigHelper = new BE2.FormConfig.FormConfigHelper(this.ef_args.formPartition, g_form, string.Empty,
               "DataSet_PS028", "PSSM28_CATCH,PSSM28_INQD", "pssm_form_get");

            DS = formConfigHelper.FormDataSet;

            // 初始化数据源
            BindingSource ps_create = BE2.FormConfig.Utility.CreatBindingSource(DS, "PSSM28_CATCH"); // pono汇总
            BindingSource ps_plan = BE2.FormConfig.Utility.CreatBindingSource(DS, "PSSM28_INQD"); // 材料信息 

            // 单记录条件
            formConfigHelper.LoadLayoutControlsForEdit(this, layoutControl1, layoutControlGroup2, "LayoutGroupFilter");
            //formConfigHelper.ClearLayoutData("LayoutGroupFilter");
            //formConfigHelper.AddRowToLayout("LayoutGroupFilter");
            //formConfigHelper.AcceptChanges("LayoutGroupFilter");
            formConfigHelper.LoadGridView(this, "GridView1", this.efDevGrid1, this.gridView1, ps_plan);            

            //双击事件
            Control efLB_count_yy = formConfigHelper.GetControl(layoutControlGroup2, "YY_COUNT");
            if (efLB_count_yy != null)
            {
                efLB_count_yy.DoubleClick += new System.EventHandler(this.efLB_count_yy_DoubleClick);
            }

            //EF.Utility.SetGridColumn(new EF.EFDevGrid[] { this.efDevGridProcNo }, new string[] { "PSSM11_INQ_PROC_" + factory_div }, v_curr_part_name);
            //layoutControlGroup4.Size = new System.Drawing.Size(layoutControlGroup4.Size.Width, 90/*两行*/);

            //EI.EIInfo outBlk = EF.Utility.GetPartitionCodeClassValue(v_curr_part_name, "PSA1");
            ////PONO状态的代码说明转换
            //if (outBlk.Tables.Contains("PSA1"))
            //{
            //    Common.Utility.SetGridItemLookUpEditProperty(this.bandedGridViewPlan, "PONO_STATUS", outBlk.Tables["PSA1"], "CODE_DESC_1_CONTENT", "CODE");
            //}

            //DevExpress.XtraGrid.Columns.GridColumn column = this.bandedGridViewPlan.Columns.ColumnByFieldName("CHARGE_COL");
            //if (column != null)
            //{
            //    column.Width = 30;
            //    column.OptionsColumn.ShowCaption = false;
            //    column.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            //}
            //bandedGridViewPlan.Columns[0].OwnerBand.Caption = "选<br>择";
            //layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;//隐藏浇注信息空白框18/5/7

            Reset_block();
            //foreach (var col in EFX.EFCGrid.GetEFCGridBase(efDevGridPlan).Columns.Keys)
            //{
            //    string col_name = EFX.EFCGrid.GetEFCGridBase(efDevGridPlan).Columns[col].ColumnInfo.ItemEname;
            //    inBlock_Show.Tables[0].Columns.Add(col_name, typeof(String));
            //    //if (col.ColumnInfo.ItemKeyFlag)
            //    //{
            //    //    var colName = col.G.ItemEname;
            //    //    EFX.EFCGrid.GetEFCGridBase(efDevGridPlan).Columns[colName].EnableEdit = false;
            //    //    inBlock_Show.Tables[0].Columns.Add(colName, typeof(String));
            //    //}
            //}




            //此画面不建议用EPED54
            //EFX.EFCGrid.InitMultiBandedGridColumn(new[] { efDevGridPlan }, new string[] { "PSSM11_INQ_PONO" });//多行记录信息。
            //this.bandedGridViewPlan.OptionsView.ShowColumnHeaders = false;

            //画面加载初始化
            //query_init();   暂时看没什么用

            query("2");  //出钢计划查询
            //queryCurrProcShow();//处理号查询
            //queryCC_pour();  //浇注信息查询
            //queryRespond();  //应答、计划状态信息查询

            //计数器开始
            //this.timer_pour.Enabled = true;  //浇注周期
            //System.Threading.Thread.Sleep();
            //this.timer_proc_no.Enabled = true;  //处理号查询
            this.timer_plan.Enabled = true;  //出钢计划查询(删除、计划交换、钢种变更时停止)
            ////控制除选择列外，其他列不可编辑
            //efDevGridPlan.SetAllColumnEditableWithoutSelection(false);

           
        }

        private void efLB_count_yy_DoubleClick(object sender, EventArgs e)
        {
            if ("YY_COUNT".Equals(form_opt))
            {
                this.EFMsgInfo = "保留炉数统计中...";
                return;
            }
            
            form_opt = "YY_COUNT";

            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            try
            {
                
                inBlock.Tables[0].TableName = "TPSSM11";
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Rows.Add();
                inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;

                //调用后台
                //this.EFMsgInfo = "保留炉数统计中...";
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm28_yy_inq", inBlock);
                s = outBlock.GetSys();
                //判断调用是否成功
                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    return;
                }

                ((TextEdit)sender).Text = outBlock.Tables[0].Rows[0]["YY_COUNT"].ToString();

                //执行成功
                this.EFMsgInfo = "保留炉数统计成功。";

            }
            catch (Exception ex)
            {
                this.EFMsgInfo = ex.Message;
            }
            finally
            {
                form_opt = "";
            }
            
        }

        #region 画面按钮事件
        #region F2查询
        private void FormPSSM28SI_EF_DO_F2(object sender, EF.EF_Args e)
        {
            //queryCurrProcShow();
            plan_status_ca("0");
            query("2");

        }
        #endregion

        #region F3计划编辑新增
        private void FormPSSM28SI_EF_DO_F3(object sender, EF.EF_Args e)
        {
            //弹出对话框，录入计划编制条件
            //query("2");
            this.timer_plan.Enabled = false;  //出钢计划查询
            plan_status_ca("1");
            //暂时注释独占编辑
            if (v_edit_flag == "0") return;
            EF.EF_Args.common_parameter_1 = v_curr_part_name;//传递分区
            EF.EF_Args.common_object_1 = inBlock_All;//传递分区
            //FormPSSM28AddDlgSI addDlg = new FormPSSM28AddDlgSI();
            FormPSSM28AddNumSI addDlg = new FormPSSM28AddNumSI();
            //addDlg.Owner = this;
            addDlg.factory_div = factory_div;
            addDlg.Text = "出钢计划新增";
            addDlg.v_curr_part_name = v_curr_part_name;
            addDlg.time_div = time_div;   // 1-连铸  2-转炉时间
            addDlg.ShowDialog();

            inBlock_All = addDlg.inBlock_All;

            //inBlock_All = (EI.EIInfo)EF.EF_Args.common_object_2; 
            // 判断对话框的结果
            switch (addDlg.DialogResult)
            {
                case DialogResult.OK:
                    del_pono_from_dlg();
                    //query("1");
                    query_view(plan_flag);
                    this.EFMsgInfo = "计划新增成功。";
                    break;
                case DialogResult.Cancel:
                    this.EFMsgInfo = "计划新增取消。";
                    break;
            }
        }

        private void del_pono_from_dlg()
        {
            if (inBlock_All.Tables.Contains("PLAN_PONO_CC"))
            {
                EI.EIInfo inBlock = new EI.EIInfo();
                inBlock.Tables[0].TableName = "PLAN_DEL";
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("SM_PLAN_NO", typeof(String));
                inBlock.Tables[0].Columns.Add("PONO", typeof(String));
                int delCountAll = 0;

                DataTable dt = inBlock_All.Tables["PLAN_PONO_CC"];
                for (int ci = 0; ci < dt.Rows.Count; ci++)
                {
                    String cc_mach_no = dt.Rows[ci]["CC_MACH_NO"].ToString().Trim();
                    int pono_num = Convert.ToInt32(dt.Rows[ci]["PONO_NUM"].ToString());
                    int pono_num_plan = Convert.ToInt32(dt.Rows[ci]["PONO_NUM_PLAN"].ToString());
                    if(pono_num < pono_num_plan)
                    {
                        int delNoCount = pono_num_plan - pono_num;
                        for (int di = this.gridView1.RowCount - 1; di >= 0 && delNoCount > 0; di--)
                        {
                            if (cc_mach_no.CompareTo(this.gridView1.GetDataRow(di)["CC_MACH_NO"].ToString()) == 0)
                            {
                                inBlock.Tables[0].Rows.Add();
                                inBlock.Tables[0].Rows[delCountAll]["FACTORY_DIV"] = factory_div.Trim();
                                inBlock.Tables[0].Rows[delCountAll]["SM_PLAN_NO"] = this.gridView1.GetDataRow(di)["SM_PLAN_NO"].ToString().Trim();
                                inBlock.Tables[0].Rows[delCountAll]["PONO"] = this.gridView1.GetDataRow(di)["PONO"].ToString().Trim();
                                delNoCount--;
                                delCountAll++;
                            }  
                        }                                           
                    }
                }
                if (delCountAll>0)
                {
                    this.EFMsgInfo = "计划删除中...";
                    planDelete(inBlock);
                }

            }
        }

        #endregion

        #region F4 计划调整（对话框）
        ///制程编辑窗口 EFLayoutPopForm 数据块
        [Description("制程编辑窗口 EFLayoutPopForm 数据块")]
        
        private void FormPSSM28SI_EF_DO_F4(object sender, EF.EF_Args e)
        {
            //efDevGridPlan.SetSelectedColumnChecked(2, true);//测试 选中行
            plan_status_ca("1");
            this.timer_plan.Enabled = false;  //出钢计划查询
            if (this.efDevGrid1.GetSelectedDataRow().Rows.Count != 1)//只选一条计划进行调整
            {
                this.EFMsgInfo = "请选择要调整的一条计划进行操作！";
                GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                return;
            }



            DataRow row = efDevGrid1.GetSelectedDataRow().Rows[0];

            EFLayoutPopForm pssm_plan_Dlg = new EFLayoutPopForm(); //制程编辑面板
            try
            {
                string i_func_id_p = "PSSM28_P_UPD";
                pssm_plan_Dlg.Name = "FormPSSM28_UpdPlan";
                pssm_plan_Dlg.FormTitle = "制程编辑面板";
                pssm_plan_Dlg.Add_Modify_Flag = EFLayoutPopForm.OPER_FLAG.Add;
                pssm_plan_Dlg.FuncID = i_func_id_p;
                pssm_plan_Dlg.Partition = v_curr_part_name;
                pssm_plan_Dlg.Excute_Service_Name = "pssm11_init";//待写
                pssm_plan_Dlg.AutoWidth = false;
                pssm_plan_Dlg.CurLayoutControl.AllowCustomizationMenu = true;
                pssm_plan_Dlg.FormWidth = 1055;
                pssm_plan_Dlg.FormHeight = 255;
                pssm_plan_Dlg.EFRowFirst = false;
                pssm_plan_Dlg.EFRowCount = 3;
                pssm_plan_Dlg.LoadConfig();
                //获取对话框里显示的数据
                EI.EIInfo inBlock = EFX.EFXLayoutHelper.GetLayoutControlValue(pssm_plan_Dlg.CurLayoutControl);
                inBlock.Tables[0].Rows.Clear();
                inBlock.Tables[0].Rows.Add();
                if (!inBlock.Tables[0].Columns.Contains("FACTORY_DIV")) inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                if (!inBlock.Tables[0].Columns.Contains("SM_PLAN_NO")) inBlock.Tables[0].Columns.Add("SM_PLAN_NO", typeof(String));
                if (!inBlock.Tables[0].Columns.Contains("ST_NO")) inBlock.Tables[0].Columns.Add("ST_NO", typeof(String));
                inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;         //
                inBlock.Tables[0].Rows[0]["SM_PLAN_NO"] = row["SM_PLAN_NO"];    //
                inBlock.Tables[0].Rows[0]["ST_NO"] = row["ST_NO"];    //

                //string service_name = "pssm11a_plan_inq";//制程编辑面板数据查询
                //dlg_block.Tables.Clear();
                //dlg_block = EI.EIManager.Instance.CallService(v_curr_part_name, service_name, inBlock);
                dlg_block.Tables[0].Rows.Clear();
                dlg_block.Tables[0].Merge(this.efDevGrid1.GetSelectedDataRow());

                EI.EIInfo outBlock_ed54 = new EI.EIInfo();
                err_msg = "制程编辑面板数据查询";
                string pop_colmn = "select item_ename,item_type,item_default_value,REGULAR_EXPRESS from ted54 t " +
                            " where func_id = \'" + i_func_id_p.Trim() + "\' order  by seq_no ";
                outBlock_ed54 = EF.Utility.ExecQueryPart(v_curr_part_name, pop_colmn);
                outBlock_ed54.Tables[0].Columns[0].Caption = "列名";
                outBlock_ed54.Tables[0].Columns[1].Caption = "字段类型";
                outBlock_ed54.Tables[0].Columns[2].Caption = "字段默认值";
                outBlock_ed54.Tables[0].Columns[3].Caption = "规则";
                string col_name ="";
                for( int col_n=0;col_n<outBlock_ed54.Tables[0].Rows.Count;col_n++)
                {
                    col_name = outBlock_ed54.Tables[0].Rows[col_n][0].ToString();
                    if (!dlg_block.Tables[0].Columns.Contains(col_name)) dlg_block.Tables[0].Columns.Add(col_name, typeof(String));
                }

                
                string[] necessary = "PONO,ST_NO,CAST_NO,CAST_DIV_NO,FACTORY_DIV,SM_PLAN_NO,HEAT_NO,CURR_WP_NO".Split(',');
                for (int i = 0; i < necessary.Length; i++)
                {
                    if (!dlg_block.Tables[0].Columns.Contains(necessary[i])) dlg_block.Tables[0].Columns.Add(necessary[i], typeof(String));
                    dlg_block.Tables[0].Rows[0][necessary[i]] = row[necessary[i]];

                }
                err_msg = "可编辑列汇总";
                if (!dlg_block.Tables[0].Columns.Contains("EDITABLE_COL"))//从后台传入可编辑列，如果不存在尽量去改后台
                {
                    dlg_block.Tables[0].Columns.Add("EDITABLE_COL", typeof(String));
                }
                string editable_col = "";//可编辑列汇总
                if (row["CC_FLAG2"].ToString() == "0")  //未开浇 
                {
                    editable_col += "CC";
                    for (int i = 1; i <= 4; i++)
                    {
                        string colname_f = "SR" + i.ToString() + "_FLAG";
                        if (row[colname_f].ToString() == "0" || row[colname_f].ToString().Trim() == "") editable_col = editable_col + "SR" + i.ToString();
                    }
                    if(editable_col.Contains("SR"))
                    {
                        if (row["MAIN_SMELT_FLAG2"].ToString() == "0")
                        {
                            editable_col += "DC";
                            if (row["PRE_SMELT_FLAG2"].ToString() == "0")
                            {
                                editable_col += "DP";
                            }
                        }
                    }
                }
                
                dlg_block.Tables[0].Rows[0]["EDITABLE_COL"] = editable_col;
                    //for (int i = 0, j = 1; i < dlg_block.Tables["PLAN"].Rows.Count; i++)//改后台service_name↑
                    //{
                    //    //如果 charge_no > curr_wp_no 则可编辑：实际工序还没达到该工序
                    //    if (dlg_block.Tables[0].Rows[i]["CHARGE_NO"].ToString().CompareTo(dlg_block.Tables["PLAN"].Rows[i]["CURR_WP_NO"].ToString()) > 0)
                    //        switch (dlg_block.Tables["PLAN"].Rows[i]["AREA_ID"].ToString())
                    //        {
                    //            case "1": editable_col += "DS"; break;
                    //            case "2": editable_col += "DP"; break;
                    //            case "3": editable_col += "DC"; break;
                    //            case "4": editable_col += "SR" + j++; break;//每次遇到area_id=4 j后自加1
                    //            case "5": editable_col += "CC"; break;
                    //        }
                    //    dlg_block.Tables[ts_table].Rows[0]["EDITABLE_COL"] = editable_col;
                    //}


                err_msg = "设备与时间准备";
                DataRow dlg_row = dlg_block.Tables[0].Rows[0];
                int bof_charge = 0;
                for (int r_sub = 0; r_sub < inBlock_All.Tables["SUB"].Rows.Count;r_sub++ )
                {
                    DataRow dr = inBlock_All.Tables["SUB"].Rows[r_sub];
                    err_msg = "设备与时间准备-DP";
                    if (dr["PONO"].ToString().Trim() != dlg_row["PONO"].ToString().Trim()) continue;
                    if (dr["AREA_ID"].ToString() == "2")
                    {
                        dlg_row["DEV_CODE_DP"] = dr["DEV_CODE"];
                        dlg_row["PROC_TIME_DP"] = dr["PROC_TIME"];
                        dlg_row["START_TIME_DP"] = dr["START_TIME_REAL"].ToString().Trim() != "" ? dr["START_TIME_REAL"] : dr["START_TIME"];
                        dlg_row["END_TIME_DP"] = dr["END_TIME_REAL"];
                    }
                    err_msg = "设备与时间准备-BOF";
                    if (dr["AREA_ID"].ToString() == "3")
                    {
                        err_msg = "设备与时间准备-BOF 设备 " + dr["DEV_CODE"].ToString();
                        dlg_row["DEV_CODE_DC"] = dr["DEV_CODE"];
                        err_msg += dr["DEV_CODE"].ToString();
                        err_msg = "设备与时间准备-BOF 处理时间 ";
                        dlg_row["PROC_TIME_DC"] = dr["PROC_TIME"];
                        err_msg += dr["PROC_TIME"].ToString();
                        err_msg = "设备与时间准备-BOF 开始时间 ";
                        dlg_row["START_TIME_DC"] = dr["START_TIME_REAL"].ToString().Trim() != "" ? dr["START_TIME_REAL"] : dr["START_TIME"];
                        err_msg += dr["START_TIME_REAL"].ToString();
                        err_msg = "设备与时间准备-BOF 结束时间 ";
                        dlg_row["END_TIME_DC"] = dr["END_TIME_REAL"];
                        err_msg += dr["END_TIME_REAL"].ToString();
                        err_msg = "设备与时间准备-BOF CHARGE_NO ";
                        bof_charge =Convert.ToInt32( dr["CHARGE_NO"]);
                        err_msg += dr["CHARGE_NO"].ToString();
                    }
                    err_msg = "设备与时间准备-SR";
                    if (dr["AREA_ID"].ToString() == "4")
                    {
                        string sr_div = Convert.ToString(Convert.ToInt32(dr["CHARGE_NO"]) - bof_charge);
                        string sr_col_dev = "DEV_CODE_SR" + sr_div;
                        string sr_col_proctime = "PROC_TIME_SR" + sr_div;
                        string sr_col_starttime = "START_TIME_SR" + sr_div;
                        string sr_col_endtime = "END_TIME_SR" + sr_div;
                        dlg_row[sr_col_dev] = dr["DEV_CODE"];
                        dlg_row[sr_col_proctime] = dr["PROC_TIME"];
                        dlg_row[sr_col_starttime] = dr["START_TIME_REAL"].ToString().Trim() != "" ? dr["START_TIME_REAL"] : dr["START_TIME"];
                        dlg_row[sr_col_endtime] = dr["END_TIME_REAL"];
                    }
                    err_msg = "设备与时间准备-CC";
                    if (dr["AREA_ID"].ToString() == "5")
                    {
                        dlg_row["DEV_CODE_CC"] = dr["DEV_CODE"];
                        dlg_row["PROC_TIME_CC"] = dr["PROC_TIME"];
                        dlg_row["START_TIME_CC"] = dr["START_TIME_REAL"].ToString().Trim() != "" ? dr["START_TIME_REAL"] : dr["START_TIME"];
                        dlg_row["END_TIME_CC"] = dr["END_TIME_REAL"];
                    }
                }
                
                
                pssm_plan_Dlg.DataSourceRow = dlg_block.Tables[0].Rows[0];
                pssm_plan_Dlg.Shown += pssm_plan_Dlg_Shown;
                pssm_plan_Dlg.Click += pssm_plan_Dlg_Click;//测试用事件
                pssm_plan_Dlg.FormClosed += pssm_plan_Dlg_FormClosed;
                pssm_plan_Dlg.ShowDialog();
                pssm_plan_Dlg.Controls.Clear();
                pssm_plan_Dlg.Dispose();
                
            }
            catch (Exception)
            {
                pssm_plan_Dlg.Dispose();
                this.EFMsgInfo = "计划调整功能正在开发中" + err_msg;
            }
            //Query();

            //原方案
            //FormPSSM11C formC = new FormPSSM11C();
            //formC.Text = "出钢计划炉次条件修改";
            //formC.set(row["PONO"].ToString(),
            //    row["HEAT_NO"].ToString(),
            //    row["ST_NO"].ToString(),
            //    row["CAST_NO"].ToString(),
            //    row["CAST_DIV_NO"].ToString(),
            //    factory_div,
            //    row["SM_PLAN_NO"].ToString()
            //    );
            //formC.ShowDialog();
        }

        #endregion

        #region F5 计划删除
        private void FormPSSM28SI_EF_PRE_DO_F5(object sender, EF.EF_Args e)
        {
            this.timer_plan.Enabled = false;  //出钢计划查询停止
        }

        private void FormPSSM28SI_EF_CANCEL_DO_F5(object sender, EF.EF_Args e)
        {
            this.timer_plan.Enabled = true;  //出钢计划查询启动
        }

        private void FormPSSM28SI_EF_DO_F5(object sender, EF.EF_Args e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;

            try
            {
                plan_status_ca("1");
                //暂时注释独占编辑
                if (v_edit_flag == "0") return;
                this.timer_plan.Enabled = false;  //出钢计划查询
                string sm_plan_no = "";
                string v_pono = "";
                int i = 0;
                if (this.efDevGrid1.GetSelectedDataRow().Rows.Count < 1)
                {
                    this.EFMsgInfo = "请选择要调整的一条计划进行操作！";
                    GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                    return;
                }

                inBlock.Tables[0].TableName = "PLAN_DEL";
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("SM_PLAN_NO", typeof(String));
                inBlock.Tables[0].Columns.Add("PONO", typeof(String));

                foreach (DataRow row in this.efDevGrid1.GetSelectedDataRow().Rows)
                {
                    sm_plan_no = row["SM_PLAN_NO"].ToString();
                    v_pono = row["PONO"].ToString();
                    inBlock.Tables[0].Rows.Add();
                    inBlock.Tables[0].Rows[i]["FACTORY_DIV"] = factory_div.Trim();
                    inBlock.Tables[0].Rows[i]["SM_PLAN_NO"] = sm_plan_no.Trim();
                    inBlock.Tables[0].Rows[i]["PONO"] = v_pono.Trim();
                    i++;
                }

                this.EFMsgInfo = "计划删除中...";

                planDelete(inBlock);

                //outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm11_del", inBlock);
                //s = outBlock.GetSys();

                //if (s.flag < 0)
                //{
                //    this.EFSysInfo = s;
                //    this.EFArgs.buttonStatusHold = true;
                //    return;
                //}

                //query("1");
                //this.timer_plan.Enabled = true;  //出钢计划查询启动
                //this.EFMsgInfo = "计划删除成功。";
                //bandedGridViewPlan.BestFitColumns();

            }
            catch (Exception err)
            {
                this.EFMsgInfo = "系统出现异常，请联系系统维护人员。 " + err.Message;
                this.EFArgs.buttonStatusHold = true;
                return;
            }
        }
        #endregion

        #region F6 计划保存
        private void FormPSSM28SI_EF_PRE_DO_F6(object sender, EF.EF_Args e)
        {

        }

        private void FormPSSM28SI_EF_CANCEL_DO_F6(object sender, EF.EF_Args e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;

            try
            {

                //inBlock.Tables[0].Columns.Add("OP_FLAG", typeof(string)); //下达：0  删除：1
                //inBlock.Tables[0].Rows.Add("0");

                //this.EFMsgInfo = "计划下达中...";
                ////outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm11_snd", inBlock);
                //s = outBlock.GetSys();

                //if (s.flag < 0)
                //{
                //    this.EFSysInfo = s;
                //    return;
                //}

                //timer_resp.Enabled = true;  //计数器启动

                ////queryRespond();  //应答、计划状态信息查询
                //this.EFMsgInfo = "计划下达成功!";

            }
            catch (Exception err)
            {
                this.EFMsgInfo = "系统出现异常，请联系系统维护人员。 " + err.Message;
                return;
            }
        }

        private void FormPSSM28SI_EF_DO_F6(object sender, EF.EF_Args e)
        {
            plan_status_ca("2");
            //暂时注释独占编辑
            if (v_edit_flag == "0") return;

            Set_save_block();
            if (planSave(inBlock_Save) == false) return;

            //重新查询计划
            query("2");
            this.EFMsgInfo = GC.GCRS.GCRSC0000009/*处理成功。*/;
        }
        #endregion

        #region F7 炉次交换
        private void FormPSSM28SI_EF_PRE_DO_F7(object sender, EF.EF_Args e)
        {
            this.timer_plan.Enabled = false;  //出钢计划查询停止
        }

        private void FormPSSM28SI_EF_CANCEL_DO_F7(object sender, EF.EF_Args e)
        {
            this.timer_plan.Enabled = true;  //出钢计划查询启动
        }

        private void FormPSSM28SI_EF_DO_F7(object sender, EF.EF_Args e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            String Oper_type="";

            try
            {

                //获取钢水交换 基准标记
                EI.EIInfo dtmd_no_a = EF.Utility.GetPartitionCodeClassValue(v_curr_part_name, "PSAM");
                //for (int i = 0; i < dtmd_no_a.Tables["PSAM"].Rows.Count; i++)
                //{
                    Oper_type = dtmd_no_a.Tables["PSAM"].Rows[0]["CODE"].ToString();
                //}

                plan_status_ca("2");
                //暂时注释独占编辑
                if (v_edit_flag == "0") return;
                this.timer_plan.Enabled = false;  //出钢计划查询
                string sm_plan_no = "";

                if (this.efDevGrid1.GetSelectedDataRow().Rows.Count != 2)
                {
                    this.EFMsgInfo = "请选择要交换的两个计划进行操作！";
                    GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                    return;
                }

                inBlock.Tables[0].TableName = "PLAN_DEL";
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("SM_PLAN_NO", typeof(String));

                int i = 0;
                foreach (DataRow row in this.efDevGrid1.GetSelectedDataRow().Rows)
                {
                    if (row["PONO_STATUS"].ToString() == "83")
                    {
                        this.EFMsgInfo = "选中PONO已经浇注完成！";
                        GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                        return;
                    }
                    sm_plan_no = row["SM_PLAN_NO"].ToString();

                    inBlock.Tables[0].Rows.Add();
                    inBlock.Tables[0].Rows[i]["FACTORY_DIV"] = factory_div.Trim();
                    inBlock.Tables[0].Rows[i]["SM_PLAN_NO"] = sm_plan_no.Trim();
                    i++;
                }

                inBlock.Tables[0].TableName = "HEAT_CHG";

                this.EFMsgInfo = "炉次对换中...";
                if (Oper_type == "P")
                {
                    outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_chg_in_pono", inBlock);
                }
                else
                {
                    outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_chg_in", inBlock);
                }
                //outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_chg_in", inBlock);
                s = outBlock.GetSys();

                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    this.EFArgs.buttonStatusHold = true;
                    return;
                }
                else
                {
                    query("2");
                    this.timer_plan.Enabled = true;  //出钢计划查询启动
                    this.EFMsgInfo = "炉次对换成功。";
                    //bandedGridViewPlan.BestFitColumns();
                }

            }
            catch (Exception err)
            {
                this.EFMsgInfo = "系统出现异常，请联系系统维护人员。 " + err.Message;
                this.EFArgs.buttonStatusHold = true;
                return;
            }
        }
        #endregion

        #region F8 钢种变更（对话框）
        private void FormPSSM28SI_EF_PRE_DO_F8(object sender, EF.EF_Args e)
        {
            this.timer_plan.Enabled = false;  //出钢计划查询停止
        }

        private void FormPSSM28SI_EF_CANCEL_DO_F8(object sender, EF.EF_Args e)
        {
            this.timer_plan.Enabled = true;  //出钢计划查询启动
        }

        private void FormPSSM28SI_EF_DO_F8(object sender, EF.EF_Args e)
        {
            try
            {
                EI.EIInfo inBlock = new EI.EIInfo();
                EI.EIInfo outBlock;

                plan_status_ca("2");
                //暂时注释独占编辑
                if (v_edit_flag == "0") return;
                this.timer_plan.Enabled = false;  //出钢计划查询
                //判断选择列是否有勾选（CHARGE_COL列）
                if (this.efDevGrid1.GetSelectedDataRow().Rows.Count != 1)
                {
                    this.EFMsgInfo = "请选择要交换的计划进行操作！";
                    GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                    return;
                }

                //弹出对话框，录入计划编制条件
                FormPSSM28STChgDlgSI stChgDlg = new FormPSSM28STChgDlgSI();
                stChgDlg.Text = "钢种变更";
                stChgDlg.v_curr_part_name = v_curr_part_name;
                EF.EF_Args.common_parameter_1 = v_curr_part_name;//传递分区

                foreach (DataRow row in this.efDevGrid1.GetSelectedDataRow().Rows)
                {
                    stChgDlg.factory_div = factory_div;
                    stChgDlg.sm_plan_no = row["SM_PLAN_NO"].ToString();
                    stChgDlg.pono = row["PONO"].ToString();
                    stChgDlg.st_no = row["ST_NO"].ToString();
                    stChgDlg.cc_mach_no = row["CC_MACH_NO"].ToString();
                    stChgDlg.heat_no = row["HEAT_NO"].ToString();
                }

                //stChgDlg.ShowDialog();
                stChgDlg.ShowDialog(this);
                // 判断对话框的结果
                switch (stChgDlg.DialogResult)
                {
                    case DialogResult.OK:
                        query("2");
                        this.timer_plan.Enabled = true;  //出钢计划查询启动
                        this.EFMsgInfo = "钢种变更成功。";
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            catch (Exception err)
            {
                this.EFMsgInfo = "系统出现异常，请联系系统维护人员。 " + err.Message;
                this.EFArgs.buttonStatusHold = true;
                return;
            }
        }
        #endregion

        #region F10 计划回退
        private void FormPSSM28SI_EF_DO_FA(object sender, EF.EF_Args e)
        {
            plan_status_ca("2");
            this.timer_plan.Enabled = false;  //出钢计划查询
            if (this.efDevGrid1.GetSelectedDataRow().Rows.Count != 1)
            {
                this.EFMsgInfo = "请选择一条记录进行回退操作！";
                GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                return;
            }

            string heat_no = "";
            string pono_status = "";

            foreach (DataRow row in this.efDevGrid1.GetSelectedDataRow().Rows)
            {
                heat_no = row["HEAT_NO"].ToString();
                pono_status = row["PONO_STATUS"].ToString();
            }

            if (pono_status.CompareTo("20") < 0)
            {
                this.EFMsgInfo = "计划未开始生产，请确认！";
                GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                return;
            }

            if (heat_no.Trim() == "")
            {
                this.EFMsgInfo = "熔炼号不能为空！";
                GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                return;
            }

            //弹出状态回退画面
            EF.EF_Args.common_parameter_1 = " ";
            FormPSSM18S sBack = new FormPSSM18S();
            sBack.factory_div = factory_div;
            sBack.heat_no = heat_no;
            sBack.v_curr_part_name = v_curr_part_name;
            sBack.ShowDialog();

            // 判断对话框的结果
            switch (sBack.DialogResult)
            {
                case DialogResult.OK:
                    //重新查询出钢计划
                    query("2");
                    this.EFMsgInfo = GC.GCRS.GCRSC0000009/*处理成功。*/;
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }
        #endregion

        #region F11 回炉 - 炉次返送
        private void FormPSSM28SI_EF_DO_FB(object sender, EF.EF_Args e)
        {
            
            plan_status_ca("2");
            //暂时注释独占编辑
            if (v_edit_flag == "0") return;
            this.timer_plan.Enabled = false;  //出钢计划查询
            if (this.efDevGrid1.GetSelectedDataRow().Rows.Count < 1)
            {
                this.EFMsgInfo = "请选择一条记录进行炉次返送操作！";
                GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                return;
            }
            else if (this.efDevGrid1.GetSelectedDataRow().Rows.Count > 1)
            {
                this.EFMsgInfo = "只能选择一条记录进行炉次返送操作！";
                GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                return;
            }
           
            string heat_no = "";
            string pono_status = "";
            string i_sm_plan_no = "";
            if(false)
            {
                foreach (DataRow row in this.efDevGrid1.GetSelectedDataRow().Rows)
                {
                    heat_no = row["HEAT_NO"].ToString();
                    pono_status = row["PONO_STATUS"].ToString();
                }

                if (pono_status.CompareTo("20") < 0)
                {
                    this.EFMsgInfo = "计划未开始生产，请确认！";
                    GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                    return;
                }

                if (heat_no.Trim() == "")
                {
                    this.EFMsgInfo = "熔炼号不能为空！";
                    GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                    return;
                }

                FormPSSM18B rStove = new FormPSSM18B();
                rStove.factory_div = factory_div;
                rStove.heat_no = heat_no;
                rStove.v_curr_part_name = v_curr_part_name;
                rStove.ShowDialog();

                // 判断对话框的结果
                switch (rStove.DialogResult)
                {
                    case DialogResult.OK:
                        //重新查询出钢计划
                        query("2");
                        this.EFMsgInfo = GC.GCRS.GCRSC0000009/*处理成功。*/;
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            else
            {
                foreach (DataRow row in this.efDevGrid1.GetSelectedDataRow().Rows)
                {
                    heat_no = row["HEAT_NO"].ToString();
                    pono_status = row["PONO_STATUS"].ToString();
                    i_sm_plan_no = row["SM_PLAN_NO"].ToString();
                }

                if (heat_no.Trim() == "")
                {
                    this.EFMsgInfo = "熔炼号不能为空！";
                    GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                    return;
                }else if(heat_no.Substring(1,1).CompareTo("1")==0) //熔炼号第2位为"1"的
                {
                    this.EFMsgInfo = "返送的炉次不能再次返送！";
                    GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                    return;
                }

                //FormPSSM35RetDlgSI dlg = new FormPSSM35RetDlgSI();
                FormPSSM35RetMgDlg dlg = new FormPSSM35RetMgDlg();
                dlg.SM_PLAN_NO = i_sm_plan_no;
                dlg.factory_div = factory_div;
                dlg.heat_no = heat_no;
                dlg.v_curr_part_name = v_curr_part_name;


                dlg.Text = "炉次返送";
                dlg.ShowDialog();

                // 判断对话框的结果
                switch (dlg.DialogResult)
                {
                    case DialogResult.OK:
                        query("2");
                        this.EFMsgInfo = "炉次返送设定成功。";
                        //this.EFMsgInfo = GC.GCRS.GCRSC0000009/*处理成功。*/;
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
           
           

            

           
        }
        #endregion

        #region 信号模拟
        private void FormPSSM28SI_EF_DO_FC(object sender, EF.EF_Args e)
        {
            string pono_status = "";
            string heat_no = "";
            string pono = "";
            string dev_code = "";
            int charge_no = 0;
            int curr_wp_no =0;
            plan_status_ca("2");
            this.timer_plan.Enabled = false;  //出钢计划查询
            //判断选择列是否有勾选（CHARGE_COL列）
            if (this.efDevGrid1.GetSelectedDataRow().Rows.Count != 1)
            {
                this.EFMsgInfo = "请选择一条记录进行操作！";
                GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                return;
            }

            foreach (DataRow row in this.efDevGrid1.GetSelectedDataRow().Rows)
            {
                pono_status = row["PONO_STATUS"].ToString();
                heat_no = row["HEAT_NO"].ToString();
                pono = row["PONO"].ToString();
                curr_wp_no =Convert.ToInt32( row["CURR_WP_NO"]);
                if (pono_status.CompareTo("83") >= 0)
                {
                    this.EFMsgInfo = "计划已经浇注完毕，请确认！";
                    GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                    return;
                }
            }

            foreach (DataRow row in this.efDevGrid1.GetSelectedDataRow().Rows)
            {
                pono_status = row["PONO_STATUS"].ToString();
                heat_no = row["HEAT_NO"].ToString();
                pono = row["PONO"].ToString();
                // dev_code = row["PONO"].ToString();
                if (pono_status.CompareTo("83") >= 0)
                {
                    this.EFMsgInfo = "计划已经浇注完毕，请确认！";
                    GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                    return;
                }
            }

            #region 甘特图方式

            for (int row = 0; row < inBlock_All.Tables["SUB"].Rows.Count;row++ )
            {
                DataRow sub_row= inBlock_All.Tables["SUB"].Rows[row];
                charge_no = Convert.ToInt32(sub_row["CHARGE_NO"]);
                if (pono == sub_row["PONO"].ToString()
                    && charge_no >= curr_wp_no
                    && sub_row["END_TIME_REAL"].ToString().Length<14)
                {
                    dev_code = sub_row["DEV_CODE"].ToString();
                    break;
                }
            }


            FormPSSM18O otherDlg = new FormPSSM18O();
            //EF.EF_Args.common_parameter_1 = v_curr_part_name;//传递分区
            otherDlg.v_curr_part_name = v_curr_part_name;//传递分区
            otherDlg.factory_div = factory_div;
            otherDlg.heat_no = heat_no;
            otherDlg.pono = pono;
            //otherDlg.dev_code = dev_code + "-" + charge_no;
            otherDlg.dev_code = dev_code + "-" + charge_no;
            //otherDlg.charge_no = charge_no;

            otherDlg.TopMost = true;
            otherDlg.ShowDialog();
            #endregion

            #region 原方式
            ////弹出对话框，录入计划编制条件
            //FormPSSM28Signal otherDlg = new FormPSSM28Signal();
            //otherDlg.Text = "信号模拟";
            //otherDlg.v_curr_part_name = v_curr_part_name;//传递分区

            //foreach (DataRow row in this.efDevGridPlan.GetSelectedDataRow().Rows)
            //{
            //    otherDlg.factory_div = factory_div;
            //    otherDlg.pono = row["PONO"].ToString();
            //}

            //otherDlg.TopMost = true;
            //otherDlg.Show();
            #endregion
            query("2");
        }
        #endregion
        #endregion


        #region 制程面板事件
        /// <summary>
        /// 获取鼠标点击的格子里的值 with bandedGridViewPlan_MouseDown
        /// </summary>
        /// <param name="colname"></param>
        /// <returns></returns>
        private string getValue(string colname)
        {
            return gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colname).ToString();
        }
        private void bandedGridViewPlan_MouseDown(object sender, MouseEventArgs e)
        {
           
            this.timer_plan.Enabled = false;  //出钢计划查询
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo HitInfo = this.gridView1.CalcHitInfo(e.Location);//获取鼠标点击的位置
            if (gridView1.RowCount == 0 || /*记录数大于0*/
                    !HitInfo.InRowCell /*有效的单元格*/||
                //e.Button != MouseButtons.Left /*鼠标左键*/||
                e.Button != MouseButtons.Right /*鼠标右键*/||
                    e.Clicks != 1  /*单击*/
                ) return;
            //强转当前行（避免鼠标点击的行与焦点行FocusedRowHandle不一致，鼠标点击时，焦点行FocusedRowHandle还未转换）
            gridView1.FocusedRowHandle = HitInfo.RowHandle;

            try
            {
                plan_status_ca("1");
                //暂时注释独占编辑
                if (v_edit_flag == "0") return;
                string colname = HitInfo.Column.FieldName;
                Dictionary<String, String> paras = new Dictionary<String, String>();
                string  pono, refine_route_code,sm_plan_no;
                string bof_no = "";
                bool flag = false;
                string cc_mach_no = " ";
                switch (colname)
                {
                    case "CAST_NO_SHOW":  //打开浇次调整对话框
                    case "CC_START_TIME":  //打开浇铸时刻调整对话框
                    case "CC_END_TIME":  //打开浇铸时刻调整对话框
                        cc_mach_no = getValue("CC_MACH_NO");
                       
                        sm_plan_no = getValue("SM_PLAN_NO");
                        if (sm_plan_no.Trim() != "")
                        {
                            for (int i = 0; i < inBlock_All.Tables["SUB"].Rows.Count; i++)
                            {
                                DataRow dr_p = inBlock_All.Tables["SUB"].Rows[i];
                                if (dr_p["SM_PLAN_NO"].ToString() == sm_plan_no
                                    && dr_p["AREA_ID"].ToString() == "5")
                                {
                                    cc_mach_no = dr_p["DEV_CODE"].ToString();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < inBlock_All.Tables["SUB"].Rows.Count; i++)
                            {
                                DataRow dr_p = inBlock_All.Tables["SUB"].Rows[i];
                                if (dr_p["AREA_ID"].ToString() == "5"
                                    && dr_p["DEV_CODE"].ToString().Substring(1, 1) == cc_mach_no)
                                {
                                    cc_mach_no = dr_p["DEV_CODE"].ToString();
                                    break;
                                }
                            }
                        }

                        if (flag = (cc_mach_no != null && cc_mach_no != ""))
                        {
                            paras.Add("CC_MACH_NO", cc_mach_no);
                        }
                        if (flag = (sm_plan_no != null && sm_plan_no != ""))
                        {
                            paras.Add("SM_PLAN_NO", sm_plan_no);
                        }
                        break;
                    case "SR1_START_TIME":
                    case "SR2_START_TIME":
                    case "SR3_START_TIME":
                    case "SR4_START_TIME":
                        string start_time = getValue(colname);
                        if (flag = (start_time != null && start_time != ""))
                        {
                            refine_route_code = getValue("REFINE_ROUTE_CODE");
                            if (flag = (int.Parse(colname.Substring(2, 1)) * 2 <= refine_route_code.Length))//判断数据是否匹配
                            {
                                paras.Add("REFINE_ROUTE_CODE", refine_route_code);
                            }
                        }
                        break;
                    case "DC_BLOW_START_TIME":
                        pono = getValue("PONO");
                        bof_no = getValue("DC_DEV_NO");
                        if (flag = (pono != null && pono != "" && bof_no != null && bof_no != ""))
                        {
                            paras.Add("PONO", pono);
                            paras.Add("BOF_NO", bof_no);
                        }
                        break;
                    case "SR1_NO":
                    case "SR2_NO":
                    case "SR3_NO":
                    case "SR4_NO":
                    case "CC_MACH_NO":
                    case "MAIN_SMELT":
                    case "PONO":
                    default:
                        break;
                }
                if (flag)
                {
                    paras.Add("COLNAME", colname);
                    paras.Add("V_CURR_PART_NAME", v_curr_part_name);
                    paras.Add("FACTORY_DIV", factory_div);

                    object original = EF.EF_Args.common_object_1;//存下原来的common_object_1
                    EF.EF_Args.common_object_1 = paras;
                    EF.EF_Args.common_object_2 = inBlock_All;
                    //EFShowDialogForm(PSSM28B);
                    //EFShowDialogForm(PSSM28B, new object[] { });

                    FormPSSM28CSI pssm28c = new FormPSSM28CSI();
                    pssm28c.ShowDialog();


                    EF.EF_Args.common_object_1 = original;//恢复原来的common_object-1


                   



                    switch (pssm28c.DialogResult)
                    {
                        case DialogResult.OK:
                            inBlock_All = pssm28c.inBlock_All;

                             Dictionary<String, String> paras_cal = new Dictionary<String, String>();
                             if (cc_mach_no.Trim() != "") paras_cal.Add("CC_MACH_NO", cc_mach_no);
                             paras_cal.Add("CAL_TYPE", "0");
                             if (time_div.Trim() == "1")
                             {
                                 PSUtils.plan_time_cal(inBlock_All, paras_cal);
                             }
                             else
                             {
                                 paras_cal.Add("CC_MACH_NO", bof_no);
                                 PSUtils.plan_time_cal_bof(inBlock_All, paras_cal);
                             }
                            query_view(plan_flag);
                            //this.timer_plan.Enabled = true;  //出钢计划查询启动
                            this.EFMsgInfo = "浇次调整确认。";
                            break;
                        case DialogResult.Cancel:
                            this.EFMsgInfo = "浇次调整取消。";
                            break;
                    }

                }
            }
            catch (Exception)
            {
                this.EFMsgInfo = "数据不匹配！";
            }
        }

        //制程编辑窗口点击事件之一
        [Description("制程编辑窗口点击事件之一")]
        private void pssm_plan_Dlg_Click(object sender, EventArgs e)
        {
            try
            {
                var form = sender as EFLayoutPopForm;
                EI.EIInfo inBlock = EFX.EFXLayoutHelper.GetLayoutControlValue(form.CurLayoutControl);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //制程编辑窗口加载事件之一
        [Description("制程编辑窗口加载事件之一")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        private void pssm_plan_Dlg_Shown(object sender, EventArgs e)
        {
            try
            {
                var form = sender as EFLayoutPopForm;
                if (form.DataSourceRow == null) return;//dlg_Block 表TRANSFORMATION 第一行
                if (form.DataSourceRow["FACTORY_DIV"] == null) return;
                //if (form.DataSourceRow["CURR_WP_NO"] == null) return;
                //if (form.DataSourceRow["EDITABLE_COL"] == null) return;
                string dlg_factory_div = form.DataSourceRow["FACTORY_DIV"].ToString();  //制程编辑面板dlg厂区
                //string curr_wp_no = form.DataSourceRow["CURR_WP_NO"].ToString();        //当前计划已经执行的工序
                string editable_col = form.DataSourceRow["EDITABLE_COL"].ToString();    //可编辑的列


                if (!dlg_block.Tables.Contains("DP"))
                {
                    dlg_block.Tables.Add("DP");
                    dlg_block.Tables["DP"].Merge(inBlock_All.Tables["DEV"].Clone());
                }
               
                if (!dlg_block.Tables.Contains("DP"))
                {
                    dlg_block.Tables.Add("DP");
                    dlg_block.Tables["DP"].Merge(inBlock_All.Tables["DEV"].Clone());
                }
                if (!dlg_block.Tables.Contains("DC"))
                {
                    dlg_block.Tables.Add("DC");
                    dlg_block.Tables["DC"].Merge(inBlock_All.Tables["DEV"].Clone());
                }
                if (!dlg_block.Tables.Contains("SR"))
                {
                    dlg_block.Tables.Add("SR");
                    dlg_block.Tables["SR"].Merge(inBlock_All.Tables["DEV"].Clone());
                }
                if (!dlg_block.Tables.Contains("CC"))
                {
                    dlg_block.Tables.Add("CC");
                    dlg_block.Tables["CC"].Merge(inBlock_All.Tables["DEV"].Clone());
                }
                if (dlg_block.Tables["DP"].Rows.Count > 0) dlg_block.Tables["DP"].Rows.Clear();
                if (dlg_block.Tables["DC"].Rows.Count > 0) dlg_block.Tables["DC"].Rows.Clear();
                if (dlg_block.Tables["SR"].Rows.Count > 0) dlg_block.Tables["SR"].Rows.Clear();
                if (dlg_block.Tables["CC"].Rows.Count > 0) dlg_block.Tables["CC"].Rows.Clear();

                for (int d_r = 0; d_r < inBlock_All.Tables["DEV"].Rows.Count; d_r++)
                {
                    DataRow dev_r = inBlock_All.Tables["DEV"].Rows[d_r];
                    if (dev_r["CLASS_ID"].ToString() == "2") dlg_block.Tables["DP"].ImportRow(dev_r);
                    if (dev_r["CLASS_ID"].ToString() == "3") dlg_block.Tables["DC"].ImportRow(dev_r);
                    if (dev_r["CLASS_ID"].ToString() == "4") dlg_block.Tables["SR"].ImportRow(dev_r);
                    if (dev_r["CLASS_ID"].ToString() == "5") dlg_block.Tables["CC"].ImportRow(dev_r);
                }
                var ef_DEV_CODE = form.CurLayoutControl.Controls["DEV_CODE_DC"] as LookUpEdit;
                string v_DEV_DC = ef_DEV_CODE.EditValue.ToString();
                for (int i = 3/*跳过前四个控件*/; i < form.CurLayoutControl.Controls.Count; i++)
                {
                    var control = form.CurLayoutControl.Controls[i];
                    if (!control.Name.Contains('_')) continue;//获取最后一个下划线'_'后面的字符串
                    string dev_type = control.Name.Split('_')[control.Name.Split('_').Length - 1]; //DS DP DC SR1234... CC


                    v_DEV_DC = ef_DEV_CODE.EditValue.ToString();
                    //加载各类设备下拉框
                    if (control.Name.Contains("DEV_CODE_") && control.Name.Length >= 9)
                    {
                        //Console.WriteLine(control.GetType() + "\t" + control.Name + "\t" + dev_type);
                        
                        if (control is EFDevLookUpEdit)
                        {
                            EFDevLookUpEdit lookup = control as EFDevLookUpEdit;
                            string dev_type2 = dev_type.Substring(0, 2);
                            if (dlg_block.Tables.Contains(dev_type2))
                            {
                                Common.Utility.SetLookUpEditProperty(lookup, dlg_block.Tables[dev_type2], "STATION_NAME", "DEV_CODE", true);
                            }
                            else
                            {
                                //    string sqlstr = "select DEV_CODE,STATION_NAME from tpssmd1 where factory_div = '{0}' and area_id = {1} order by area_id";
                                //    sqlstr = String.Format(sqlstr, dlg_factory_div, "DSDPDCSRCC".IndexOf(dev_type2) / 2 + 1);  //{0}{1}
                                //    EI.EIInfo blk = EF.Utility.ExecQuery(sqlstr);//大家都在用，很慢
                                //    Common.Utility.SetLookUpEditProperty(lookup, blk.Tables[0], "STATION_NAME", "DEV_CODE", true);
                            }
                        }
                    }

                    //调整各控件【可响应】属性
                    //if (editable_col.Contains(dev_type)) //如果可编辑列包括当前列则将当前列设为可响应
                    //{ control.Enabled = true; }
                    //else 
                    if (control.Name.Contains("DEV_CODE_"))//if 调整各控件【可响应】属性 else
                    {
                        string dev_pos = control.Name.ToString().Replace("DEV_CODE_", "");
                        if (!editable_col.Contains(dev_pos)) control.Enabled = false;//设备不在列表内，则不可响应
                        //if (!editable_col.Contains("DS"))//如果DS不可编辑
                        //    if (control.Name.Contains("DS")) control.Enabled = false;//则DS不可响应
                        //    else if (!editable_col.Contains("DP")) //如果DP也不可编辑
                        //        if (control.Name.Contains("DP")) control.Enabled = false;//则DP也不可响应
                        //        else if (!editable_col.Contains("DC")) //如果DC也不可编辑
                        //            if (control.Name.Contains("DC")) control.Enabled = false;//则DC也不可响应
                        //            else if (!editable_col.Contains("SR")) //如果SR也不可编辑
                        //                if (control.Name.Contains("SR")) control.Enabled = false;//则SR也不可响应
                        //                else if (!editable_col.Contains("CC")) //如果CC也不可编辑
                        //                    if (control.Name.Contains("CC")) control.Enabled = false;//则CC也不可响应
                                 
                    }
                    else if (control.Name.Contains("START_TIME_"))
                    {
                        string dev_pos = control.Name.ToString().Replace("START_TIME_", "");
                        if (!editable_col.Contains(dev_pos)) control.Enabled = false;//设备不在列表内，则不可响应

                        //if (!editable_col.Contains("DS"))//如果DS不可编辑
                        //{
                        //    if (control.Name.Contains("DS")) control.Enabled = false;//则DS不可响应
                        //}
                        //else if (!editable_col.Contains("DP")) //如果DP也不可编辑
                        //{
                        //    if (control.Name.Contains("DP")) control.Enabled = false;//则DP也不可响应
                        //}
                        //else if (!editable_col.Contains("DC")) //如果DC也不可编辑
                        //{
                        //    if (control.Name.Contains("DC")) control.Enabled = false;//则DC也不可响应
                        //}
                        //else if (!editable_col.Contains("SR")) //如果SR也不可编辑
                        //{
                        //    if (control.Name.Contains("SR")) control.Enabled = false;//则SR也不可响应
                        //}
                        //else if (!editable_col.Contains("CC")) //如果CC也不可编辑
                        //{
                        //    if (control.Name.Contains("CC")) control.Enabled = false;//则CC也不可响应
                        //}
                    }
                    else
                    {
                        control.Enabled = false;
                        if (control.Name.Contains("PROC_TIME_") && control.GetType() == typeof(EFDevCalcEdit)) //如果还没结束则可响应编辑
                        {
                            try //可能处理时长、开始时间等不存在
                            {
                                string end_col = "END_TIME_" + dev_type;
                                string end_time = form.DataSourceRow[end_col].ToString();
                                if (end_time.Trim().Length < 5) control.Enabled = true;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        
                    }//不可响应 //else 调整各控件【可响应】及【可编辑】属性 end

                    //加载各控件事件
                    if ((control.Name.Contains("DEV_CODE_") && control.GetType() == typeof(EFDevLookUpEdit))
                        //|| control.Name.Contains("START_TIME_CC")
                        )
                    {
                        ((EFDevLookUpEdit)control).EditValueChanged += DEV_CODE_Changed;
                    }
                    if ((control.Name.Contains("START_TIME_CC") && control.GetType() == typeof(EFDevDateEdit))
                       )
                    {
                        ((EFDevDateEdit)control).EditValueChanged += START_TIME_CHANGED;
                    }
                    if ((control.Name.Contains("PROC_TIME_CC") && control.GetType() == typeof(EFDevCalcEdit))
                      )
                    {
                        ((EFDevCalcEdit)control).EditValueChanged += PROD_TIME_CHANGED;
                    }
                   
                }//for 遍历控件 end
            }
            catch (Exception err)
            {
                string prompt = err_msg + err.Message;
                this.EFMsgInfo = prompt;
                GC.PM_utility2.Dev_messageBoxWarning(prompt);
            }
        }

        //切换工序设备触发事件（制程面板下拉框）
        private void DEV_CODE_Changed(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(EFDevDateEdit))
            {
                EFDevDateEdit control = sender as EFDevDateEdit;
                string control_Name = control.Name; //DS DP DC SR1234... CC
                if(control_Name.Trim()=="START_TIME_CC")
                {
                     if_cc_time_chg = "1";
                }
            }
            if (sender.GetType() == typeof(EFDevLookUpEdit))
            {
                EFDevLookUpEdit control = sender as EFDevLookUpEdit;
                string dev_type = control.Name.Split('_')[control.Name.Split('_').Length - 1]; //DS DP DC SR1234... CC
                string dev_div= dev_type.Substring(0,2);
                string editable_col = dlg_block.Tables[0].Rows[0]["EDITABLE_COL"].ToString();
                try
                {
                    //将设备代码的Text 赋给设备名的EditValue
                    ((EFDevLookUpEdit)control.Parent.Controls["STATION_NAME_" + dev_type]).EditValue = control.Text;
                }
                catch (Exception)
                {
                    this.EFMsgInfo = "未找到设备名控件。请设置：PSSM11A_CONST";
                    //EFCallForm("EPED54");
                }

                //if (!editable_col.Contains(dev_type))//未包含于可编辑的列:新的工序设置
                {
                    try
                    {
                        bool flag = false;
                        if (flag = (control.GetColumnValue("DEV_CODE") != null))//选择空白行时为null，作为取消该工序
                        {
                            string s_dev_code = control.GetColumnValue("DEV_CODE").ToString();
                            string s_pono = dlg_block.Tables[0].Rows[0]["PONO"].ToString();

                            //string s_st_no = dlg_block.Tables[0].Rows[0]["ST_NO"].ToString();
                            string std_proc_time = "";
                            string std_prep_time = "";
                            //string std_prep_time = control.GetColumnValue("STD_PREP_TIME").ToString();  //准备时间
                            //string std_proc_time = control.GetColumnValue("STD_PROC_TIME").ToString();  //处理时间
                            //if (s_dev_code.Substring(0,1)!="C")
                            //{
                            //    std_proc_time = GetDealTime(s_st_no, s_dev_code, "DEV");
                            //}
                            //else std_proc_time = GetDealTime(s_pono, s_dev_code, "SUB");

                            

                            if (std_prep_time == "") std_prep_time = "5";       //默认准备时间
                            //if (std_proc_time == "") std_proc_time = "40";      //默认处理时间
                            inBlock_para.Tables[0].Rows.Clear();
                            inBlock_para.Tables[0].Columns.Clear();
                           
                            if (std_proc_time == ""&&dev_div!="CC") 
                            {
                                string st_no =  dlg_block.Tables[0].Rows[0]["ST_NO"].ToString();
                                //std_proc_time = GetDealTime(st_no, s_dev_code, "PROC_TIME");
                                
                                inBlock_para.Tables[0].Columns.Add("ST_NO", typeof(String));
                                inBlock_para.Tables[0].Columns.Add("DEV_CODE", typeof(String));
                                inBlock_para.Tables[0].Rows.Add(st_no, s_dev_code);
                                std_proc_time = PSUtils.GetDealTime(inBlock_All, "PROC_TIME","PROC_TIME", inBlock_para);
                            }
                            else
                            {
                                inBlock_para.Tables[0].Columns.Add("PONO", typeof(String));
                                inBlock_para.Tables[0].Rows.Add(s_pono);
                                //string st_no = dlg_block.Tables[0].Rows[0]["ST_NO"].ToString();
                                //std_proc_time = GetDealTime(s_pono, " ", "SUB");
                                std_proc_time = PSUtils.GetDealTime(inBlock_All, "SUB","PROC_TIME", inBlock_para);
                            }
                            ((EFDevCalcEdit)control.Parent.Controls["PROC_TIME_" + dev_type]).EditValue = std_proc_time;
                            int add_time = Convert.ToInt32(std_proc_time) + Convert.ToInt32(std_prep_time);
                            string pre_dev = "";
                            if (dev_div.Trim() == "CC" || dev_div.Trim() == "SR")
                            {
                                for(int s=4;s>0;s--)
                                {

                                    if (((EFDevLookUpEdit)control.Parent.Controls["DEV_CODE_SR" + s.ToString()]).EditValue.ToString().CompareTo(" ") > 0
                                        && dev_div + s.ToString() != dev_type)
                                    {
                                        pre_dev = "DEV_CODE_SR" + s.ToString();
                                        
                                        err_msg = "获取上一工序的结束时间" + ((EFDevDateEdit)control.Parent.Controls["START_TIME_SR" + s.ToString()]).EditValue.ToString();
                                        err_msg += ";增加时间 = " + add_time;
                                        ((EFDevDateEdit)control.Parent.Controls["START_TIME_" + dev_type]).EditValue
                                            = (Convert.ToDateTime(((EFDevDateEdit)control.Parent.Controls["START_TIME_SR" + s.ToString()]).EditValue).AddMinutes(add_time));
                                        string st_time =  ((EFDevDateEdit)control.Parent.Controls["START_TIME_" + dev_type]).EditValue.ToString();
                                        add_time = add_time + Convert.ToInt32(((EFDevCalcEdit)control.Parent.Controls["PROC_TIME_SR" + s.ToString()]).EditValue);
                                    }
                                    else continue;
                                   
                                }
                                if(pre_dev.Trim()=="") //无精炼，找BOF
                                {
                                     if (((EFDevLookUpEdit)control.Parent.Controls["DEV_CODE_DC"]).EditValue.ToString().CompareTo(" ") > 0)
                                     {
                                         //add_time = add_time + Convert.ToInt32(((EFDevCalcEdit)control.Parent.Controls["PROC_TIME_DC" ]).EditValue);
                                         err_msg = "获取上一工序的结束时间" + ((EFDevDateEdit)control.Parent.Controls["START_TIME_DC" ]).EditValue.ToString();
                                         err_msg += ";增加时间 = " + add_time;
                                         ((EFDevDateEdit)control.Parent.Controls["START_TIME_" + dev_type]).EditValue
                                             = (Convert.ToDateTime(((EFDevDateEdit)control.Parent.Controls["START_TIME_DC"]).EditValue).AddMinutes(add_time));
                                         string st_time = ((EFDevDateEdit)control.Parent.Controls["START_TIME_" + dev_type]).EditValue.ToString();
                                     }
                                     else
                                     {
                                         string prompt = "转炉工序不可为空";
                                         this.EFMsgInfo = prompt;
                                         GC.PM_utility2.Dev_messageBoxWarning(prompt);
                                     }
                                }
                            }
                            else if (dev_div.Trim() == "DC")
                            {
                                 if (((EFDevDateEdit)control.Parent.Controls["START_TIME_DP"]).EditValue.ToString().CompareTo(" ") > 0)
                                 {
                                     add_time = add_time + Convert.ToInt32(((EFDevCalcEdit)control.Parent.Controls["PROC_TIME_DP" + s.ToString()]).EditValue);
                                     err_msg = "BOF 获取上一工序的结束时间" + ((EFDevDateEdit)control.Parent.Controls["START_TIME_DP"]).EditValue.ToString();
                                     err_msg += ";增加时间 = " + add_time;
                                     ((EFDevDateEdit)control.Parent.Controls["START_TIME_" + dev_type]).EditValue
                                         = (Convert.ToDateTime((EFDevDateEdit)control.Parent.Controls["PROC_TIME_DP"]).AddMinutes(add_time)).ToString("yyyyMMddHHmmss");
                                    
                                 }
                                 else
                                 {
                                     ((EFDevDateEdit)control.Parent.Controls["START_TIME_" + dev_type]).EditValue = DateTime.Now; 
                                 }
                            }
                            else if (dev_div.Trim() == "DP")
                            {
                                if (((EFDevDateEdit)control.Parent.Controls["START_TIME_DC"]).EditValue.ToString().CompareTo(" ") > 0)
                                {
                                    err_msg = "BP 获取上一工序的结束时间" + ((EFDevDateEdit)control.Parent.Controls["START_TIME_DP"]).EditValue.ToString();
                                    err_msg += ";增加时间 = " + add_time;
                                    ((EFDevDateEdit)control.Parent.Controls["START_TIME_" + dev_type]).EditValue
                                        = (Convert.ToDateTime((EFDevDateEdit)control.Parent.Controls["PROC_TIME_DP"]).AddMinutes(-1*add_time)).ToString("yyyyMMddHHmmss");

                                }
                                else
                                {
                                    ((EFDevDateEdit)control.Parent.Controls["START_TIME_" + dev_type]).EditValue = DateTime.Now;
                                }
                            }
                            
                        }
                        control.Parent.Controls["PROC_TIME_" + dev_type].Enabled = flag;
                        control.Parent.Controls["START_TIME_" + dev_type].Enabled = flag;


                    }
                    catch (Exception err)
                    {
                        //this.EFMsgInfo = "未找到相应控件。请设置：PSSM11A_CONST 或： " + err_msg ;
                        string prompt = err_msg + err.Message;
                        this.EFMsgInfo = prompt;
                        GC.PM_utility2.Dev_messageBoxWarning(prompt);
                        //this.EFMsgInfo = err_msg + err.Message;
                       
                    }
                }
            }
        }

        private void START_TIME_CHANGED(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(EFDevDateEdit))
            {
                EFDevDateEdit control = sender as EFDevDateEdit;
                string control_Name = control.Name; //DS DP DC SR1234... CC
                if (control_Name.Trim() == "START_TIME_CC")
                {
                    if_cc_time_chg = "1";
                }
            }
            
        }
        private void PROD_TIME_CHANGED(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(EFDevDateEdit))
            {
                EFDevDateEdit control = sender as EFDevDateEdit;
                string control_Name = control.Name; //DS DP DC SR1234... CC
                if (control_Name.Trim() == "START_TIME_CC")
                {
                    if_cc_time_chg = "1";
                }
            }

        }
        #endregion

        #region 自定义方法

        #region 未整理的功能函数
        private void gridInit(DevExpress.XtraGrid.Views.Grid.GridView gridview)
        {
            //标题行为2备行高
            //gridview.RowHeight = 30;

            //读取配置代码
            EI.EIInfo outBlk = EF.Utility.GetPartitionCodeClassValue(v_curr_part_name, "PSA2", "PSA1");
            //出钢计划状态的代码说明转换
            if (outBlk.Tables.Contains("PSA2"))
            {
                Common.Utility.SetGridItemLookUpEditProperty(gridview, "RUN_STATUS", outBlk.Tables["PSA2"], "CODE_DESC_1_CONTENT", "CODE");
                //SetGridItemLookUpEditProperty(DevExpress.XtraGrid.Views.Grid.GridView gridView, string colName, DataTable dt, string display, string value);
            }
            //PONO状态的代码说明转换
            if (outBlk.Tables.Contains("PSA1"))
            {
                Common.Utility.SetGridItemLookUpEditProperty(gridview, "PONO_STATUS", outBlk.Tables["PSA1"], "CODE_DESC_1_CONTENT", "CODE");
            }

            //固定前3列
            //gridview.Columns[2].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            //可见性控制
            //gridview.Columns["MAIN_BACKLOG_CODE"].Visible = false;

        }
        #endregion

        //本次整理函数
        #region 甘特图方式功能函数
        //画面加载初始化
        //获取接口参数
        public EI.EIInfo query(string query_mode)
        {

            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;

            try
            {

                //定义出钢计划的“炼钢单元号”
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("QUERY_TYPE", typeof(String));
                inBlock.Tables[0].Columns.Add("ORDER_MODE", typeof(String));  //排序方式: 1-出钢顺; 2-浇注顺
                inBlock.Tables[0].Rows.Add();
                inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;
                inBlock.Tables[0].Rows[0]["QUERY_TYPE"] = query_mode;

                if (efRadio_tps.Checked == true) //按出钢顺排序
                {
                    inBlock.Tables[0].Rows[0]["ORDER_MODE"] = "1";
                }
                else
                {
                    inBlock.Tables[0].Rows[0]["ORDER_MODE"] = "2";
                }
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_inq", inBlock);

                //inBlock_All.Tables.Clear();
                inBlock_All = outBlock;
                inBlock_All.Tables.Add("MODE_TYPE").Columns.Add("MODE_TYPE"); //新增模型优化模式
                inBlock_All.Tables["MODE_TYPE"].Rows.Add("0");
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    return outBlock;
                }
                else
                {
                    // 清空画面信息并绑定最新信息
                    query_view(plan_flag);
                    this.EFMsgInfo = "查询成功";
                }
               
            }
            catch (Exception err)
            {
                this.EFMsgInfo = err.Message;
                return null;
            }

            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;

            this.EFMsgInfo = GC.GCRS.GCRSC0000001/*查询成功。*/;
            this.timer_plan.Enabled = true;  //出钢计划查询
            return outBlock;
        }
        //将获取的值处理到显示框
        private void query_view(int query_div)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            //DataTable plan = new DataTable();
            //DataRow plan_row = plan.NewRow();

            inBlock.Tables[0].Merge(inBlock_All.Tables["SUB"]);
            inBlock_Show.Tables[0].Rows.Clear();
            inBlock_Show.Tables[0].Merge(inBlock_All.Tables["PLAN"]);
            int pono_status = 0;
            if (query_div == 0)
            {
                for (int p_row = inBlock_Show.Tables[0].Rows.Count - 1; p_row >= 0; p_row--)
                {
                    pono_status = Convert.ToInt32(inBlock_Show.Tables[0].Rows[p_row]["PONO_STATUS"]);
                    if (pono_status >= 83)
                    {
                        inBlock_Show.Tables[0].Rows.RemoveAt(p_row);

                    }
                }

                for (int row = inBlock_All.Tables["PLAN"].Rows.Count - 1; row >= 0; row--)
                {
                    pono_status = Convert.ToInt32(inBlock_All.Tables["PLAN"].Rows[row]["PONO_STATUS"]);

                    if (pono_status >= 83)
                    {
                        string d_pono = inBlock_All.Tables["PLAN"].Rows[row]["PONO"].ToString();
                        for (int sub_row = inBlock_All.Tables["SUB"].Rows.Count - 1; sub_row >= 0; sub_row--)
                        {
                            DataRow dr_sub = inBlock_All.Tables["SUB"].Rows[sub_row];
                            if (d_pono == dr_sub["PONO"].ToString())
                            {
                                inBlock_All.Tables["SUB"].Rows.RemoveAt(sub_row);
                            }
                        }





                        inBlock_All.Tables["PLAN"].Rows.RemoveAt(row);
                    }
                }


                

            }

            for (int view_row = 0; view_row < inBlock_Show.Tables[0].Rows.Count; view_row++)
            {
                inBlock_Show.Tables[0].Rows[view_row]["CAST_NO_SHOW"] = inBlock_Show.Tables[0].Rows[view_row]["CAST_NO"].ToString()
                                                                      + "-" + inBlock_Show.Tables[0].Rows[view_row]["CAST_DIV_NO"].ToString();

                //inBlock_Show.Tables[0].Rows[view_row]["CAST_NO_SHOW"] = inBlock_All.Tables["PLAN"].Rows[view_row]["CAST_NO"].ToString()
                //                                                      + "-" + inBlock_All.Tables["PLAN"].Rows[view_row]["CAST_DIV_NO"].ToString();

                string area_id = "";
                int first_srf = 0;
                String str_show_flag = ""; //为运转开始信号颜色显示用
                String str_start_time = "";
                String str_start_time_real = "";
                String str_end_time = "";
                String str_end_time_real = "";
                String str_rest_time = "";
                String str_dev_code = "";
                String str_arrive_real_time = "";
                String str_leave_real_time = "";
                String str_ld_arrive_time = "";
                for (int sub_row = 0; sub_row < inBlock.Tables[0].Rows.Count; sub_row++)
                {

                    if (inBlock_Show.Tables[0].Rows[view_row]["SM_PLAN_NO"].ToString()
                        != inBlock.Tables[0].Rows[sub_row]["SM_PLAN_NO"].ToString()
                        && inBlock_Show.Tables[0].Rows[view_row]["SM_PLAN_NO"].ToString().Trim()!="") continue;

                    if (inBlock_Show.Tables[0].Rows[view_row]["PONO"].ToString()
                      != inBlock.Tables[0].Rows[sub_row]["PONO"].ToString()) continue;

                    area_id = inBlock.Tables[0].Rows[sub_row]["AREA_ID"].ToString();
                    if (inBlock.Tables[0].Rows[sub_row]["SUB_CHARGE_NO"].ToString() != "0") continue; //复杂模式，暂不考虑

                    if (inBlock.Tables[0].Rows[sub_row]["END_TIME_REAL"].ToString().Trim() == "")
                    {

                        if (inBlock.Tables[0].Rows[sub_row]["START_TIME_REAL"].ToString().Trim() == "")
                        {
                            str_show_flag = "0";
                            //2015-10-14 增加精炼包到状态
                            if (area_id == "4"
                                    && inBlock.Tables[0].Rows[sub_row]["ARRIVE_REAL_TIME"].ToString().Trim() != "")
                            {
                                str_show_flag = "3";  //3-精炼包到
                            }
                        }
                        else
                        {
                            str_show_flag = "1";
                        }

                    }
                    else
                    {
                        str_show_flag = "2";
                    }
                    str_start_time = inBlock.Tables[0].Rows[sub_row]["START_TIME"].ToString();
                    str_start_time_real = inBlock.Tables[0].Rows[sub_row]["START_TIME_REAL"].ToString();
                    str_end_time = inBlock.Tables[0].Rows[sub_row]["END_TIME"].ToString();
                    str_end_time_real = inBlock.Tables[0].Rows[sub_row]["END_TIME_REAL"].ToString();
                    str_rest_time = inBlock.Tables[0].Rows[sub_row]["REST_TIME"].ToString();
                    str_dev_code = inBlock.Tables[0].Rows[sub_row]["DEV_CODE"].ToString();
                    str_arrive_real_time = inBlock.Tables[0].Rows[sub_row]["ARRIVE_REAL_TIME"].ToString();
                    DateTime time = DateTime.Now;
                    int time_sp = 20;
                    switch (area_id)
                    {
                        case "2": //脱磷
                            if (inBlock.Tables[0].Rows[sub_row]["START_TIME_REAL"].ToString().Trim() == "")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["DP_BLOW_START_TIME"]
                                    = str_start_time.Length > 12 ? str_start_time.Substring(8, 4) : " ";
                            }
                            else
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["DP_BLOW_START_TIME"]
                                    = str_start_time_real.Length > 12 ? str_start_time_real.Substring(8, 4) : " ";
                            }
                            if (inBlock.Tables[0].Rows[sub_row]["END_TIME_REAL"].ToString().Trim() == "")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["DP_TAP_START_TIME"]
                                    = str_end_time.Length > 12 ? str_end_time.Substring(8, 4) : " ";
                            }
                            else
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["DP_TAP_START_TIME"]
                                    = str_end_time_real.Length > 12 ? str_end_time_real.Substring(8, 4) : " ";
                            }

                            inBlock_Show.Tables[0].Rows[view_row]["DP_DEV_NO"] = inBlock.Tables[0].Rows[sub_row]["DEV_CODE"].ToString().Substring(1, 1);

                            if (inBlock.Tables[0].Rows[sub_row]["REST_TIME"].ToString().Trim() != "")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["BOF_REST_TIME"] = str_rest_time;
                            }

                            if (inBlock.Tables[0].Rows[sub_row]["SUB_CHARGE_NO"].ToString().Trim() == "1")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["PRE_SMELT_FLAG1"] = str_show_flag;
                            }
                            if (inBlock.Tables[0].Rows[sub_row]["SUB_CHARGE_NO"].ToString().Trim() == "2")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["PRE_SMELT_FLAG2"] = str_show_flag;
                            }
                            if (inBlock.Tables[0].Rows[sub_row]["SUB_CHARGE_NO"].ToString().Trim() == "3")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["PRE_SMELT_FLAG3"] = str_show_flag;
                            }
                            if (inBlock.Tables[0].Rows[sub_row]["SUB_CHARGE_NO"].ToString().Trim() == "0")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["PRE_SMELT_FLAG2"] = str_show_flag;
                                inBlock_Show.Tables[0].Rows[view_row]["PRE_SMELT_FLAG3"] = str_show_flag;
                            }
                            //准备保存数据

                            inBlock_Show.Tables[0].Rows[view_row]["LD_1_ID"] = inBlock.Tables[0].Rows[sub_row]["DEV_CODE"].ToString();
                            inBlock_Show.Tables[0].Rows[view_row]["LD_1_WAIT_START_TIME"] = str_start_time.Length < 14 ? time.ToString("yyyyMMddHHmmss") : str_start_time;
                            inBlock_Show.Tables[0].Rows[view_row]["LD_1_END_TIME"] = str_end_time.Length < 14 ? time.AddMinutes(time_sp).ToString("yyyyMMddHHmmss") : str_end_time;


                            break;
                        case "3": //转炉区
                            inBlock_Show.Tables[0].Rows[view_row]["DC_DEV_NO"] = str_dev_code.Length > 1 ? str_dev_code.Substring(1, 1) : " ";
                            //inBlock.Tables[0].Rows[sub_row]["DEV_CODE"].ToString().Substring(1, 1);

                            if (inBlock.Tables[0].Rows[sub_row]["REST_TIME"].ToString().Trim() != "")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["BOF_REST_TIME"] = str_rest_time;
                            }

                            if (inBlock.Tables[0].Rows[sub_row]["START_TIME_REAL"].ToString().Trim() == "")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["DC_BLOW_START_TIME"]
                                   = str_start_time.Length > 12 ? str_start_time.Substring(8, 4) : " ";
                            }
                            else
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["DC_BLOW_START_TIME"]
                                    = str_start_time_real.Length > 12 ? str_start_time_real.Substring(8, 4) : " ";
                            }
                            if (inBlock.Tables[0].Rows[sub_row]["END_TIME_REAL"].ToString().Trim() == "")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["DC_TAP_START_TIME"]
                                    = str_end_time.Length > 12 ? str_end_time.Substring(8, 4) : " ";
                            }
                            else
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["DC_TAP_START_TIME"]
                                    = str_end_time_real.Length > 12 ? str_end_time_real.Substring(8, 4) : " ";
                            }
                            first_srf = Convert.ToInt32(inBlock.Tables[0].Rows[sub_row]["CHARGE_NO"]);

                            if (inBlock.Tables[0].Rows[sub_row]["SUB_CHARGE_NO"].ToString().Trim() == "1")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["MAIN_SMELT_FLAG1"] = str_show_flag;
                            }
                            if (inBlock.Tables[0].Rows[sub_row]["SUB_CHARGE_NO"].ToString().Trim() == "2")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["MAIN_SMELT_FLAG2"] = str_show_flag;
                            }
                            if (inBlock.Tables[0].Rows[sub_row]["SUB_CHARGE_NO"].ToString().Trim() == "3")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["MAIN_SMELT_FLAG3"] = str_show_flag;
                            }
                            if (inBlock.Tables[0].Rows[sub_row]["SUB_CHARGE_NO"].ToString().Trim() == "0")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["MAIN_SMELT_FLAG2"] = str_show_flag;
                                inBlock_Show.Tables[0].Rows[view_row]["MAIN_SMELT_FLAG3"] = str_show_flag;
                            }

                            inBlock_Show.Tables[0].Rows[view_row]["LD_2_ID"] = inBlock.Tables[0].Rows[sub_row]["DEV_CODE"].ToString();
                            inBlock_Show.Tables[0].Rows[view_row]["LD_2_WAIT_START_TIME"] = str_start_time.Length < 14 ? time.ToString("yyyyMMddHHmmss") : str_start_time;
                            inBlock_Show.Tables[0].Rows[view_row]["LD_2_END_TIME"] = str_end_time.Length < 14 ? time.AddMinutes(time_sp).ToString("yyyyMMddHHmmss") : str_end_time; ;



                            break;

                        case "4": //精炼区域      
                            int tpssm12_charge_no = Convert.ToInt32(inBlock.Tables[0].Rows[sub_row]["CHARGE_NO"]);
                            string colname = "SR" + (tpssm12_charge_no - first_srf).ToString() + "_START_TIME";
                            string colname_f = "SR" + (tpssm12_charge_no - first_srf).ToString() + "_FLAG";
                            if (!inBlock_Show.Tables[0].Columns.Contains(colname)) inBlock_Show.Tables[0].Columns.Add(colname);
                            if (!inBlock_Show.Tables[0].Columns.Contains(colname_f)) inBlock_Show.Tables[0].Columns.Add(colname_f);
                            if (inBlock.Tables[0].Rows[sub_row]["REST_TIME"].ToString().Trim() != "")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["SR_REST_TIME"] = str_rest_time;
                            }
                            inBlock_Show.Tables[0].Rows[view_row][colname_f] = str_show_flag;

                            if (inBlock.Tables[0].Rows[sub_row]["END_TIME_REAL"].ToString().Trim() == "")
                            {
                                if (inBlock.Tables[0].Rows[sub_row]["START_TIME_REAL"].ToString().Trim() != "")
                                {
                                    inBlock_Show.Tables[0].Rows[view_row][colname] //str_arrive_real_time
                                         = str_start_time.Length > 12 ? str_start_time.Substring(8, 4) : " ";
                                }
                                else if (inBlock.Tables[0].Rows[sub_row]["ARRIVE_REAL_TIME"].ToString().Trim() != "")
                                {
                                    inBlock_Show.Tables[0].Rows[view_row][colname] //str_arrive_real_time
                                         = str_arrive_real_time.Length > 12 ? str_arrive_real_time.Substring(8, 4) : " ";
                                }
                                else
                                {
                                    inBlock_Show.Tables[0].Rows[view_row][colname]
                                        = str_start_time.Length > 12 ? str_start_time.Substring(8, 4) : " ";
                                }
                            }
                            else
                            {
                                inBlock_Show.Tables[0].Rows[view_row][colname]
                                    = str_end_time_real.Length > 12 ? str_end_time_real.Substring(8, 4) : " ";
                            }


                            string colname_1 = "FINERY_" + (tpssm12_charge_no - first_srf).ToString() + "_ID";
                            string colname_2 = "FINERY_" + (tpssm12_charge_no - first_srf).ToString() + "_START_TIME";
                            string colname_3 = "FINERY_" + (tpssm12_charge_no - first_srf).ToString() + "_END_TIME";
                            if (!inBlock_Show.Tables[0].Columns.Contains(colname_1)) inBlock_Show.Tables[0].Columns.Add(colname_1);
                            if (!inBlock_Show.Tables[0].Columns.Contains(colname_2)) inBlock_Show.Tables[0].Columns.Add(colname_2);
                            if (!inBlock_Show.Tables[0].Columns.Contains(colname_3)) inBlock_Show.Tables[0].Columns.Add(colname_3);
                            inBlock_Show.Tables[0].Rows[view_row][colname_1] = inBlock.Tables[0].Rows[sub_row]["DEV_CODE"].ToString();
                            inBlock_Show.Tables[0].Rows[view_row][colname_2] = str_start_time.Length < 14 ? time.ToString("yyyyMMddHHmmss") : str_start_time;
                            inBlock_Show.Tables[0].Rows[view_row][colname_3] = str_end_time.Length < 14 ? time.AddMinutes(time_sp).ToString("yyyyMMddHHmmss") : str_end_time;



                            break;
                        case "5": //浇铸
                            str_leave_real_time = inBlock.Tables[0].Rows[sub_row]["LEAVE_REAL_TIME"].ToString();
                            //if (inBlock_Show.Tables[0].Rows[view_row]["CC_REST_TIME"].ToString().Trim() == "")
                            //{
                            //    inBlock_Show.Tables[0].Rows[view_row]["CC_REST_TIME"] = 0;
                            //}
                            //if (inBlock_Show.Tables[0].Rows[view_row]["TD_CHG_FLG"].ToString().Trim() == "")
                            //{
                            //    inBlock_Show.Tables[0].Rows[view_row]["TD_CHG_FLG"] = 0;
                            //}
                            //if (inBlock_Show.Tables[0].Rows[view_row]["CAST_DIV_NO"].ToString().Trim() == "")
                            //{
                            //    inBlock_Show.Tables[0].Rows[view_row]["CAST_DIV_NO"] = 0;
                            //}
                            if (inBlock.Tables[0].Rows[sub_row]["ARRIVE_REAL_TIME"].ToString().Trim() == "")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["LD_ARRIVE_TIME"]
                                    = str_leave_real_time.Length > 12 ? str_leave_real_time.Substring(8, 4) : " ";
                            }
                            else
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["LD_ARRIVE_TIME"]
                                    = str_arrive_real_time.Length > 12 ? str_arrive_real_time.Substring(8, 4) : " ";
                            }

                            if (inBlock.Tables[0].Rows[sub_row]["START_TIME_REAL"].ToString().Trim() == "")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["CC_START_TIME"]
                                    = str_start_time.Length > 12 ? str_start_time.Substring(8, 4) : " ";
                            }
                            else
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["CC_START_TIME"]
                                    = str_start_time_real.Length > 12 ? str_start_time_real.Substring(8, 4) : " ";
                            }

                            if (inBlock.Tables[0].Rows[sub_row]["END_TIME_REAL"].ToString().Trim() == "")
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["CC_END_TIME"]
                                    = str_end_time.Length > 12 ? str_end_time.Substring(8, 4) : " ";
                            }
                            else
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["CC_END_TIME"]
                                    = str_end_time_real.Length > 12 ? str_end_time_real.Substring(8, 4) : " ";
                            }

                            if (inBlock.Tables[0].Rows[sub_row]["ARRIVE_REAL_TIME"].ToString().Trim().Length > 12)
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["CC_FLAG1"] = "1";//1-包到
                            }

                            if (inBlock.Tables[0].Rows[sub_row]["LEAVE_REAL_TIME"].ToString().Trim().Length > 12)
                            {
                                inBlock_Show.Tables[0].Rows[view_row]["CC_FLAG1"] = "2";//2-包离
                            }
                            inBlock_Show.Tables[0].Rows[view_row]["CC_FLAG2"] = str_show_flag;  //1-开浇; 2-浇完

                            //连铸等待位？
                            //inBlock_Show.Tables[0].Rows[view_row]["CAST_1_WAIT_ID"] = inBlock.Tables[0].Rows[sub_row]["DEV_CODE"].ToString();
                            //inBlock_Show.Tables[0].Rows[view_row]["CAST_1_WAIT_START_TIME"] = str_start_time;
                            //inBlock_Show.Tables[0].Rows[view_row]["CAST_1_WAIT_END_TIME"] = str_end_time;

                            inBlock_Show.Tables[0].Rows[view_row]["CAST_1_ID"] = inBlock.Tables[0].Rows[sub_row]["DEV_CODE"].ToString();
                            inBlock_Show.Tables[0].Rows[view_row]["CAST_1_START_TIME"] = str_start_time.Length < 14 ? time.ToString("yyyyMMddHHmmss") : str_start_time;
                            inBlock_Show.Tables[0].Rows[view_row]["CAST_1_END_TIME"] = str_end_time.Length < 14 ? time.AddMinutes(time_sp).ToString("yyyyMMddHHmmss") : str_end_time;

                            break;
                    }
                }
            }
            this.efDevGrid1.DataSource = inBlock_Show.Tables[0];

            formConfigHelper.MergeDataToGrid(inBlock_Show.Tables[0], gridView1);
        }
        //调用计划保存
        public bool planSave(EI.EIInfo _planBlock)
        {
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;

            try
            {
                //定义出钢计划的“炼钢单元号”
                if (!_planBlock.Tables.Contains("PLAN"))
                {
                    DataTable dt = _planBlock.Tables.Add("PLAN");
                    dt.Columns.Add("FACTORY_DIV", typeof(String));  //炼钢单元号
                    dt.Rows.Add(factory_div);
                }
                else
                {
                    _planBlock.Tables["PLAN"].Rows[0]["FACTORY_DIV"] = factory_div;
                }
                if (inBlock_All.Tables.Contains("PLAN_DEL"))
                {
                    if (!_planBlock.Tables.Contains("PLAN_DEL"))
                    {
                        _planBlock.Tables.Add("PLAN_DEL");
                    }
                    else
                    {
                        if (_planBlock.Tables["PLAN_DEL"].Rows.Count > 0) _planBlock.Tables["PLAN_DEL"].Rows.Clear();
                    }
                   
                    _planBlock.Tables["PLAN_DEL"].Merge(inBlock_All.Tables["PLAN_DEL"]);
                }
                

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_save", _planBlock);
                s = outBlock.GetSys();

                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    GC.PM_utility2.Dev_messageBoxError("保存11表失败！" + s.msg);
                    return false;
                }
                else if(false)
                {
                    //启动模型优化 //0-全局编制；1-时间优化；2-滚动编制；3-早到时间模式
                    int mode = Convert.ToInt32(inBlock_All.Tables["MODE_TYPE"].Rows[0]["MODE_TYPE"].ToString());
                    EI.EIInfo inBlock_mode = new EI.EIInfo();
                    EI.EIInfo outBlock_mode;

                    try
                    {
                        if (mode == 2) //mode=2 局部编制，传入选择炉次
                        {
                            //inBlock_mode = (EI.EIInfo)EF.EF_Args.common_object_1;
                        }

                        inBlock_mode.Tables.Add("PLAN");
                        inBlock_mode.Tables["PLAN"].Columns.Add("FACTORY_DIV");
                        inBlock_mode.Tables["PLAN"].Columns.Add("MODE");
                        inBlock_mode.Tables["PLAN"].Rows.Add(factory_div, mode);

                        outBlock_mode = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_create", inBlock_mode);
                        s = outBlock_mode.GetSys();

                        if (s.flag < 0)
                        {
                            this.EFMsgInfo = string.Format(GC.GCRS.GCRSC0000015/*模型优化失败，请联系系统维护人员。*/, s.msg);
                            this.DialogResult = DialogResult.None;
                            return false;
                        }

                    }
                    catch (Exception err)
                    {
                        this.EFMsgInfo = string.Format(GC.GCRS.GCRSC0000015/*应用异常，请联系系统维护人员。*/, err.Message);
                        this.DialogResult = DialogResult.None;
                        return false;
                    }
                }
                GC.PM_utility2.Dev_messageBoxInfo("保存成功，已下发计划！");
                //this.EFMsgInfo = "计划保存成功";

            }
            catch (Exception err)
            {
                this.EFMsgInfo = err.Message;
                return false;
            }

            return true;
        }
        //计划删除
        public void planDelete(EI.EIInfo inBlock)
        {
            try
            {

                EI.EIInfo inBlock_Pono = new EI.EIInfo();
                inBlock_Pono.Tables[0].Merge(inBlock_All.Tables["PONO"].Clone());
                err_msg = "ADD 删除数据块";
                if (!inBlock_All.Tables.Contains("PLAN_DEL"))
                {
                    inBlock_All.Tables.Add("PLAN_DEL");
                    inBlock_All.Tables["PLAN_DEL"].Merge(inBlock_Show.Tables[0].Clone());
                }

                for (int i = 0; i < inBlock.Tables[0].Rows.Count; i++)
                {
                    string i_sm_plan_no = inBlock.Tables[0].Rows[i]["SM_PLAN_NO"].ToString();
                    string i_pono = inBlock.Tables[0].Rows[i]["PONO"].ToString();
                    //EI.EIInfo outBlock_slab_l = EF.Utility.ExecQueryPart(,);
                    //若已有数据
                    int find_flag = 0;
                    err_msg = "从PONO_ADD 获取数据";
                    if (inBlock_All.Tables.Contains("PONO_ADD"))
                    {
                        for (int add = 0; add < inBlock_All.Tables["PONO_ADD"].Rows.Count; add++)
                        {
                            DataRow add_row = inBlock_All.Tables["PONO_ADD"].Rows[add];
                            if (add_row["PONO"].ToString() == i_pono)
                            {
                                inBlock_Pono.Tables[0].ImportRow(add_row);
                                find_flag = 1;
                                //add_row["PONO"] = " ";
                                inBlock_All.Tables["PONO_ADD"].Rows.RemoveAt(add);
                            }
                        }
                    }
                    err_msg = "准备删除数据";
                    for (int p_r = 0; p_r < inBlock_Show.Tables[0].Rows.Count; p_r++)
                    {
                        DataRow plan_row = inBlock_Show.Tables[0].Rows[p_r];
                        //if (i_pono.Trim() != plan_row["PONO"].ToString().Trim())
                        //{
                        //    DataRow pono = inBlock_Pono.Tables[0].Rows[p_r];
                        //  //  pono[""]
                        //   // inBlock_Pono.Tables[0].Rows.RemoveAt(p_r);
                        //    continue;
                        //} 
                        if (plan_row["PONO"].ToString() == i_pono)
                        {
                            if (Convert.ToInt32(plan_row["PONO_STATUS"]) >= 20
                             && plan_row["PONO"].ToString() == i_pono)
                            {
                                this.EFMsgInfo = "计划:[" + i_sm_plan_no + "]-制造命令:[" + i_pono + "]已开始生产，不能删除！";
                                GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                                this.EFArgs.buttonStatusHold = true;
                                return;
                            }

                            for (int r_plan = inBlock_All.Tables["PLAN"].Rows.Count - 1; r_plan >= 0; r_plan--)
                            {
                                DataRow rr = inBlock_All.Tables["PLAN"].Rows[r_plan];
                                if (rr["PONO"].ToString() == inBlock_Show.Tables[0].Rows[p_r]["PONO"].ToString())
                                {
                                    rr["PLAN_EDIT_FLAG"] = "D";
                                    //inBlock_All.Tables["PLAN"].Rows.RemoveAt(r_plan);//理论上这2个块应该是一致的
                                }
                            }
                            plan_row["PLAN_EDIT_FLAG"] = "D";

                            if (find_flag == 0)
                            {
                                //重新生成PONO
                                DataRow add_row = inBlock_Pono.Tables[0].Rows.Add();
                                add_row["PONO"] = i_pono;

                                add_row["CC_MACH_NO"] = plan_row["CC_MACH_NO"];
                                add_row["ST_NO"] = plan_row["ST_NO"];
                                add_row["REFINE_ROUTE_CODE"] = plan_row["REFINE_ROUTE_CODE"];
                                add_row["SMELT_MODE"] = plan_row["SMELT_MODE"];
                                add_row["SMELT_DIV"] = plan_row["SMELT_DIV"];
                                add_row["RESTRAND_FLG"] = plan_row["RESTRAND_FLG"];
                                if (plan_row.Table.Columns.Contains("CC_SEQ"))
                                {
                                    add_row["CC_SEQ"] = plan_row["CC_SEQ"];
                                }
                                if (plan_row.Table.Columns.Contains("PONO_PLAN_DATE"))
                                {
                                    add_row["PONO_PLAN_DATE"] = plan_row["PONO_PLAN_DATE"];
                                }

                                add_row["SG_SIGN"] = plan_row["SG_SIGN"];
                                add_row["GUIGE"] = plan_row["GUIGE2"];
                                if (plan_row.Table.Columns.Contains("CAST_LOT_NO")
                                    && plan_row.Table.Columns.Contains("CAST_LOT_DIV_NO"))
                                {
                                    add_row["CAST_LOT_NO"] = plan_row["CAST_LOT_NO"].ToString() + "-"
                                                        + plan_row["CAST_LOT_DIV_NO"].ToString();
                                }
                                inBlock_para.Tables[0].Rows.Clear();
                                inBlock_para.Tables[0].Columns.Clear();
                                inBlock_para.Tables[0].Columns.Add("PONO", typeof(String));
                                //inBlock_para.Tables[0].Columns.Add("CC_MACH_NO", typeof(String));
                                inBlock_para.Tables[0].Rows.Add(plan_row["PONO"].ToString());


                                //add_row["POUR_TIME"] = GetDealTime(plan_row["ST_NO"].ToString(), plan_row["CC_MACH_NO"].ToString(), "SUB");
                                add_row["POUR_TIME"] = PSUtils.GetDealTime(inBlock_All, "SUB", "PROC_TIME", inBlock_para);
                                add_row["SLAB_DEST"] = plan_row["SLAB_DEST"];
                                add_row["CI_DIV"] = plan_row["BACKLOG_EA"].ToString().Trim() != "" ? plan_row["BACKLOG_EA"].ToString().Substring(plan_row["BACKLOG_EA"].ToString().Length - 1, 1) : "C";
                            }

                        }//若界面PONO= 要删除的PONO
                    }//循环获取界面显示计划
                }//循环处理所有的PONO

                err_msg = "处理删除数据";
                for (int i = inBlock_Show.Tables[0].Rows.Count - 1; i >= 0; i--)
                {
                    DataRow rs = inBlock_Show.Tables[0].Rows[i];
                    if (rs["PLAN_EDIT_FLAG"].ToString() == "D")
                    {
                        int del_ins = 1;
                        for (int rd = inBlock_All.Tables["PLAN_DEL"].Rows.Count - 1; rd >= 0; rd--)
                        {
                            if (inBlock_All.Tables["PLAN_DEL"].Rows[rd]["PONO"].ToString() == rs["PONO"].ToString())
                            {
                                del_ins = 0;
                                break;
                            }
                            else
                            {
                                del_ins = 1;
                            }
                        }
                        if (del_ins == 1) inBlock_All.Tables["PLAN_DEL"].ImportRow(rs);
                        inBlock_Show.Tables[0].Rows.RemoveAt(i);
                    }
                }
                for (int i = inBlock_All.Tables["PLAN"].Rows.Count - 1; i >= 0; i--)
                {
                    DataRow rs = inBlock_All.Tables["PLAN"].Rows[i];
                    if (rs["PLAN_EDIT_FLAG"].ToString() == "D") inBlock_All.Tables["PLAN"].Rows.RemoveAt(i);
                }

                err_msg = "PONO数据回收";
                inBlock_All.Tables["PONO"].Merge(inBlock_Pono.Tables[0], false);


            }
            catch (Exception err)
            {
                this.EFMsgInfo = err_msg + err.Message;
                this.EFArgs.buttonStatusHold = true;
                return;
            }

        }
        void pssm_plan_Dlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = sender as EFLayoutPopForm;
            //EI.EIInfo inBlock_upd = new EI.EIInfo();
            EI.EIInfo inBlock_upd = EFX.EFXLayoutHelper.GetLayoutControlValue(form.CurLayoutControl);
            switch (form.DialogResult)
            {
                case DialogResult.OK:
                    planUpdate(inBlock_upd);
                    this.EFMsgInfo = "计划调整成功。";
                    break;
                case DialogResult.Cancel:
                    this.EFMsgInfo = "计划调整取消。";
                    break;
            }
            
        }
      
        //计划调整
        public void planUpdate(EI.EIInfo inBlock)
        {
            try
            {
                EI.EIInfo inBlock_temp = new EI.EIInfo();
                EI.EIInfo inBlock_sub = new EI.EIInfo();
                inBlock_temp.Tables[0].Merge(inBlock_All.Tables["SUB"].Clone());
                inBlock_sub.Tables[0].Merge(inBlock_All.Tables["SUB"].Clone());
                DataRow proc_row = inBlock.Tables[0].Rows[0]; 
                string p_st_no = "";
                string p_cc_mach_no = "";
                string p_pono = "";
                string p_cc_req_time = "";
                string p_bof_no = "";
                p_cc_req_time = proc_row["START_TIME_CC"].ToString().Trim();
                p_pono = proc_row["PONO"].ToString().Trim();
                p_cc_mach_no = proc_row["DEV_CODE_CC"].ToString().Trim();
                //处理PLAN表
                 for (int row = 0; row < inBlock_All.Tables["PLAN"].Rows.Count; row++)
                 {
                     DataRow plan_row = inBlock_All.Tables["PLAN"].Rows[row];
                     if (plan_row["PONO"].ToString().Trim() == proc_row["PONO"].ToString().Trim())
                     {
                         plan_row["REFINE_ROUTE_CODE"] = proc_row["DEV_CODE_SR1"].ToString().Trim()
                                                       + proc_row["DEV_CODE_SR2"].ToString().Trim()
                                                       + proc_row["DEV_CODE_SR3"].ToString().Trim()
                                                       + proc_row["DEV_CODE_SR4"].ToString().Trim()
                                                       ;
                         plan_row["PLAN_EDIT_FLAG"] = "U";
                         
                         p_st_no = plan_row["ST_NO"].ToString().Trim();
                         break;
                     }
                 }
                 for (int row = 0; row < inBlock_All.Tables["SUB"].Rows.Count; row++)
                 {
                     DataRow plan_row_sub = inBlock_All.Tables["SUB"].Rows[row];
                     if (plan_row_sub["PONO"].ToString().Trim() == proc_row["PONO"].ToString().Trim()
                         &&plan_row_sub["AREA_ID"].ToString().Trim()=="5"
                         )
                     {
                         p_cc_mach_no = plan_row_sub["DEV_CODE"].ToString().Trim();
                         //if (plan_row_sub["START_TIME_REAL"].ToString().Length < 14)
                         //{
                         //    p_cc_req_time = plan_row_sub["START_TIME"].ToString().Trim();
                         //}
                         //else
                         //{
                         //    p_cc_req_time = plan_row_sub["START_TIME_REAL"].ToString().Trim();
                         //}
                         
                         break;
                     }
                 }
                 inBlock_para.Tables[0].Rows.Clear();
                 inBlock_para.Tables[0].Columns.Clear();
                 inBlock_para.Tables[0].Columns.Add("ST_NO", typeof(String));
                 inBlock_para.Tables[0].Columns.Add("DEV_CODE", typeof(String));
                 //inBlock_para.Tables[0].Rows.Add(st_no, s_dev_code); inBlock_para.Tables[0].Rows.Clear();
                int i_charge_no = 1;
                if (proc_row["DEV_CODE_DP"].ToString().Trim() != "")
                {
                    DataRow plan_tmp = inBlock_temp.Tables[0].Rows.Add();
                    plan_tmp["FACTORY_DIV"] = proc_row["FACTORY_DIV"];
                    plan_tmp["PONO"] = proc_row["PONO"];
                    plan_tmp["SM_PLAN_NO"] = proc_row["SM_PLAN_NO"];
                    plan_tmp["DEV_CODE"] = proc_row["DEV_CODE_DP"];
                    plan_tmp["AREA_ID"] = "2";
                    plan_tmp["SM_PLAN_NO"] = proc_row["SM_PLAN_NO"]; ;
                    plan_tmp["CHARGE_NO"] = i_charge_no++;
                    plan_tmp["SUB_CHARGE_NO"] = "0";
                    inBlock_sub.Merge(GetSubRow(inBlock_temp));
                    inBlock_temp.Tables[0].Rows.Clear();
                    DataRow rs = inBlock_sub.Tables[0].Rows[inBlock_sub.Tables[0].Rows.Count - 1];
                    if (rs["END_TIME_REAL"].ToString().Length < 14)
                    {
                        rs["PROC_TIME"] = proc_row["PROC_TIME_DP"];
                        rs["START_TIME"] = proc_row["START_TIME_DP"];
                        rs["END_TIME"] = (Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(proc_row["START_TIME_DP"].ToString())).AddMinutes(Convert.ToDouble(proc_row["PROC_TIME_DC"]))).ToString("yyyyMMddHHmmss"); ;
                    }
                   
                }
                if (proc_row["DEV_CODE_DC"].ToString().Trim() != "")
                {
                    DataRow plan_tmp = inBlock_temp.Tables[0].Rows.Add();
                    plan_tmp["FACTORY_DIV"] = factory_div;
                    plan_tmp["PONO"] = proc_row["PONO"];
                    plan_tmp["SM_PLAN_NO"] = proc_row["SM_PLAN_NO"];
                    plan_tmp["CHARGE_NO"] = i_charge_no++;
                    plan_tmp["SUB_CHARGE_NO"] = "0";
                    plan_tmp["DEV_CODE"] = proc_row["DEV_CODE_DC"];
                    plan_tmp["AREA_ID"] = "3";
                    inBlock_sub.Merge(GetSubRow(inBlock_temp));
                    inBlock_temp.Tables[0].Rows.Clear();
                    DataRow rs = inBlock_sub.Tables[0].Rows[inBlock_sub.Tables[0].Rows.Count - 1];
                    if (rs["END_TIME_REAL"].ToString().Length < 14)
                    {
                        rs["PROC_TIME"] = proc_row["PROC_TIME_DC"];
                        rs["START_TIME"] = proc_row["START_TIME_DC"];
                        rs["END_TIME"] = (Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(proc_row["START_TIME_DC"].ToString())).AddMinutes(Convert.ToDouble(proc_row["PROC_TIME_DC"]))).ToString("yyyyMMddHHmmss");

                    }
                    p_bof_no = proc_row["DEV_CODE_DC"].ToString();
                    //plan_tmp["PROC_TIME"] = Convert.ToDateTime(proc_row["PROC_TIME_DC"]).ToString("yyyyMMddHHmmss");
                    //plan_tmp["START_TIME"] = Convert.ToDateTime(proc_row["START_TIME_DC"]).ToString("yyyyMMddHHmmss");
                    //plan_tmp["END_TIME"] = (Convert.ToDateTime(proc_row["START_TIME_DC"]).AddMinutes(Convert.ToInt32(proc_row["PROC_TIME_DC"]))).ToString("yyyyMMddHHmmss");
                }
                if (proc_row["DEV_CODE_SR1"].ToString().Trim() != "")
                {
                    DataRow plan_tmp = inBlock_temp.Tables[0].Rows.Add();
                    plan_tmp["FACTORY_DIV"] = factory_div;
                    plan_tmp["PONO"] = proc_row["PONO"];
                    plan_tmp["SM_PLAN_NO"] = proc_row["SM_PLAN_NO"];
                    plan_tmp["HEAT_NO"] = proc_row["HEAT_NO"];
                    plan_tmp["CHARGE_NO"] = i_charge_no++;
                    plan_tmp["SUB_CHARGE_NO"] = "0";
                    plan_tmp["DEV_CODE"] = proc_row["DEV_CODE_SR1"];
                    plan_tmp["AREA_ID"] = "4";
                    inBlock_sub.Merge(GetSubRow(inBlock_temp));
                    inBlock_temp.Tables[0].Rows.Clear();
                    DataRow rs = inBlock_sub.Tables[0].Rows[inBlock_sub.Tables[0].Rows.Count - 1];
                    if (rs["END_TIME_REAL"].ToString().Length < 14)
                    {
                        rs["PROC_TIME"] = proc_row["PROC_TIME_SR1"];
                        rs["START_TIME"] = proc_row["START_TIME_SR1"];
                        rs["END_TIME"] = (Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(proc_row["START_TIME_SR1"].ToString())).AddMinutes(Convert.ToDouble(proc_row["PROC_TIME_SR1"]))).ToString("yyyyMMddHHmmss"); ;
                    }
                }
                if (proc_row["DEV_CODE_SR2"].ToString().Trim() != "")
                {
                    DataRow plan_tmp = inBlock_temp.Tables[0].Rows.Add();
                    plan_tmp["FACTORY_DIV"] = factory_div;
                    plan_tmp["PONO"] = proc_row["PONO"];
                    plan_tmp["SM_PLAN_NO"] = proc_row["SM_PLAN_NO"];
                    plan_tmp["HEAT_NO"] = proc_row["HEAT_NO"];
                    plan_tmp["CHARGE_NO"] = i_charge_no++;
                    plan_tmp["SUB_CHARGE_NO"] = "0";
                    plan_tmp["DEV_CODE"] = proc_row["DEV_CODE_SR2"];
                    plan_tmp["AREA_ID"] = "4";
                    inBlock_sub.Merge(GetSubRow(inBlock_temp));
                    inBlock_temp.Tables[0].Rows.Clear();
                    DataRow rs = inBlock_sub.Tables[0].Rows[inBlock_sub.Tables[0].Rows.Count - 1];
                    if (rs["END_TIME_REAL"].ToString().Length < 14)
                    {
                        rs["PROC_TIME"] = proc_row["PROC_TIME_SR2"];
                        rs["START_TIME"] = proc_row["START_TIME_SR2"];
                        rs["END_TIME"] = (Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(proc_row["START_TIME_SR2"].ToString())).AddMinutes(Convert.ToDouble(proc_row["PROC_TIME_SR2"]))).ToString("yyyyMMddHHmmss"); ;
                    }
                }
                if (proc_row["DEV_CODE_SR3"].ToString().Trim() != "")
                {
                    DataRow plan_tmp = inBlock_temp.Tables[0].Rows.Add();
                    plan_tmp["FACTORY_DIV"] = factory_div;
                    plan_tmp["PONO"] = proc_row["PONO"];
                    plan_tmp["SM_PLAN_NO"] = proc_row["SM_PLAN_NO"];
                    plan_tmp["HEAT_NO"] = proc_row["HEAT_NO"];
                    plan_tmp["CHARGE_NO"] = i_charge_no++;
                    plan_tmp["SUB_CHARGE_NO"] = "0";
                    plan_tmp["DEV_CODE"] = proc_row["DEV_CODE_SR3"];
                    plan_tmp["AREA_ID"] = "4";
                    inBlock_sub.Merge(GetSubRow(inBlock_temp));
                    inBlock_temp.Tables[0].Rows.Clear();
                    DataRow rs = inBlock_sub.Tables[0].Rows[inBlock_sub.Tables[0].Rows.Count - 1];
                    if (rs["END_TIME_REAL"].ToString().Length < 14)
                    {
                        rs["PROC_TIME"] = proc_row["PROC_TIME_SR3"];
                        rs["START_TIME"] = proc_row["START_TIME_SR3"];
                        rs["END_TIME"] = (Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(proc_row["START_TIME_SR3"].ToString())).AddMinutes(Convert.ToDouble(proc_row["PROC_TIME_SR3"]))).ToString("yyyyMMddHHmmss"); ;
                    }
                }
                if (proc_row["DEV_CODE_SR4"].ToString().Trim() != "")
                {
                    DataRow plan_tmp = inBlock_temp.Tables[0].Rows.Add();
                    plan_tmp["FACTORY_DIV"] = factory_div;
                    plan_tmp["PONO"] = proc_row["PONO"];
                    plan_tmp["SM_PLAN_NO"] = proc_row["SM_PLAN_NO"];
                    plan_tmp["HEAT_NO"] = proc_row["HEAT_NO"];
                    plan_tmp["CHARGE_NO"] = i_charge_no++;
                    plan_tmp["SUB_CHARGE_NO"] = "0";
                    plan_tmp["DEV_CODE"] = proc_row["DEV_CODE_SR4"];
                    plan_tmp["AREA_ID"] = "4";
                    plan_tmp.BeginEdit();
                    inBlock_sub.Merge(GetSubRow(inBlock_temp));
                    inBlock_temp.Tables[0].Rows.Clear();
                    DataRow rs = inBlock_sub.Tables[0].Rows[inBlock_sub.Tables[0].Rows.Count - 1];
                    if (rs["END_TIME_REAL"].ToString().Length < 14)
                    {
                        //inBlock_para.Tables[0].Rows.Clear();
                        //inBlock_para.Tables[0].Rows.Add(p_st_no, plan_tmp["DEV_CODE"].ToString()); 
                        //rs["PROC_TIME"] = proc_row["PROC_TIME_SR4"].ToString().Length > 0 ? proc_row["PROC_TIME_SR4"] : PSUtils.GetDealTime(inBlock_All, "DEV", "DEV_CODE", inBlock_para);
                        //rs["START_TIME"] = proc_row["START_TIME_SR4"].ToString().Length > 0 ? proc_row["START_TIME_SR4"] : proc_row["START_TIME_SR3"];
                        rs["PROC_TIME"] = proc_row["PROC_TIME_SR4"];
                        rs["START_TIME"] = proc_row["START_TIME_SR4"];
                        rs["END_TIME"] = (Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(proc_row["START_TIME_SR4"].ToString())).AddMinutes(Convert.ToDouble(proc_row["PROC_TIME_SR4"]))).ToString("yyyyMMddHHmmss"); ;
                    }
                }
                if (proc_row["DEV_CODE_CC"].ToString().Trim() != "")
                {
                    DataRow plan_tmp = inBlock_temp.Tables[0].Rows.Add();
                    //plan_tmp["FACTORY_DIV"] = factory_div;
                    plan_tmp["PONO"] = proc_row["PONO"];
                    plan_tmp["SM_PLAN_NO"] = proc_row["SM_PLAN_NO"];
                    plan_tmp["HEAT_NO"] = proc_row["HEAT_NO"];
                    plan_tmp["CHARGE_NO"] = i_charge_no++;
                    plan_tmp["SUB_CHARGE_NO"] = "0";
                    plan_tmp["DEV_CODE"] = proc_row["DEV_CODE_CC"];
                    plan_tmp["AREA_ID"] = "5";
                    //plan_tmp = GetSubRow(plan_tmp);
                    inBlock_sub.Merge(GetSubRow(inBlock_temp));
                    inBlock_temp.Tables[0].Rows.Clear();
                    DataRow rs = inBlock_sub.Tables[0].Rows[inBlock_sub.Tables[0].Rows.Count - 1];
                    if (rs["END_TIME_REAL"].ToString().Length<14
                        && proc_row["PROC_TIME_CC"].ToString().Length >0
                        && proc_row["START_TIME_CC"].ToString().Length >= 10)
                    {
                        rs["PROC_TIME"] = proc_row["PROC_TIME_CC"];
                        rs["START_TIME"] = proc_row["START_TIME_CC"];
                        rs["END_TIME"] = (Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(proc_row["START_TIME_CC"].ToString())).AddMinutes(Convert.ToDouble(proc_row["PROC_TIME_CC"]))).ToString("yyyyMMddHHmmss"); ;
                    }
                    
                }
                for (int i = inBlock_All.Tables["SUB"].Rows.Count - 1; i >= 0; i--)
                {
                    if (inBlock_All.Tables["SUB"].Rows[i]["PONO"].ToString()
                        == proc_row["PONO"].ToString())
                    {
                        inBlock_All.Tables["SUB"].Rows.RemoveAt(i);
                    }
                }


                inBlock_Show.SetBlkName(1, "PLAN_SHOW");
                inBlock_sub.SetBlkName(1, "SUB");
                inBlock_All.Tables["SUB"].Merge(inBlock_sub.Tables[0]);
                string[] colmn = { "PONO" };
                //PSUtils.OrderByRow(inBlock_All, "PLAN", inBlock_Show, "PLAN_SHOW", colmn, false);
                PSUtils.OrderByRow(inBlock_All, "SUB", inBlock_Show, "PLAN_SHOW", colmn, true);
               

                Dictionary<String, String> paras_cal = new Dictionary<String, String>();
                if (p_cc_mach_no.Trim() != "") paras_cal.Add("CC_MACH_NO", p_cc_mach_no);
                if (p_pono.Trim() != "") paras_cal.Add("PONO", p_pono);
                if (p_cc_req_time.Trim() != "") paras_cal.Add("CC_REQ_TIME", p_cc_req_time);
                paras_cal.Add("CAL_TYPE", "1");
                //paras.Add("CC_MACH_NO", cc_mach_no);
                //inBlock_All.Tables["SUB"].Merge(inBlock_sub.Tables[0]);
                if (if_cc_time_chg.Trim()=="1")
                {
                    if (time_div.Trim() == "1")
                    {
                        PSUtils.plan_time_cal(inBlock_All, paras_cal);
                    }
                    else
                    {
                        paras_cal.Add("BOF_NO", p_bof_no);
                        PSUtils.plan_time_cal_bof(inBlock_All, paras_cal);
                    }
                }

                query_view(plan_flag);

            }
            catch (Exception err)
            {
                this.EFMsgInfo = "系统出现异常，请联系系统维护人员。 " + err.Message;
                this.EFArgs.buttonStatusHold = true;
                return;
            }

        }
        //初始化数据块
        private void Reset_block()
        {
            #region 准备inBlock_Save数据块 用作计划保存
            inBlock_Save.Tables.Clear();
            inBlock_Save.Tables.Add();
            inBlock_Save.Tables[0].Columns.Add("PONO", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("HEAT_NO", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("ST_NO", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("RESTRAND_FLG", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("PLAN_STYLE", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("TD_CHG_FLG", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("REFINE_ROUTE_CODE", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("PONO_STATUS", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("CC_REQ_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("SMELT_MODE", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("LD_1_ID", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("LD_1_WAIT_START_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("LD_1_END_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("LD_2_ID", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("LD_2_WAIT_START_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("LD_2_END_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("FINERY_1_ID", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("FINERY_1_START_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("FINERY_1_END_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("FINERY_2_ID", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("FINERY_2_START_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("FINERY_2_END_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("FINERY_3_ID", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("FINERY_3_START_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("FINERY_3_END_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("FINERY_4_ID", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("FINERY_4_START_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("FINERY_4_END_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("CAST_1_WAIT_ID", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("CAST_1_WAIT_START_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("CAST_1_WAIT_END_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("CAST_1_ID", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("CAST_1_START_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("CAST_1_END_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("STEEL_RETURN_CODE", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("SG_SIGN", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("CC_MARK", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("TPD_ID", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("TPD_START_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("TPD_END_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("KR_ID", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("KR_START_TIME", typeof(String));
            inBlock_Save.Tables[0].Columns.Add("KR_END_TIME", typeof(String));

            inBlock_Save.Tables.Add();
            inBlock_Save.Tables[1].Columns.Add("PONO", typeof(String));

            inBlock_Save.Tables.Add();
            inBlock_Save.Tables[2].Columns.Add("dev_code", typeof(String));
            inBlock_Save.Tables[2].Columns.Add("start_time", typeof(String));
            inBlock_Save.Tables[2].Columns.Add("end_time", typeof(String));
            inBlock_Save.Tables[2].Columns.Add("dev_status_remark", typeof(String));
            inBlock_Save.Tables[2].Columns.Add("stop_flag", typeof(String));
            inBlock_Save.Tables[2].Columns.Add("status_area", typeof(String));

            #endregion

            inBlock_Show.Tables[0].Merge(inBlock_Save.Tables[0].Clone());
            #region 准备inBlock_Show数据块 用作计划显示
            if (!inBlock_Show.Tables[0].Columns.Contains("SM_PLAN_NO")) inBlock_Show.Tables[0].Columns.Add("SM_PLAN_NO", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("HEAT_NO")) inBlock_Show.Tables[0].Columns.Add("HEAT_NO", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("PONO")) inBlock_Show.Tables[0].Columns.Add("PONO", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("PONO_ORG")) inBlock_Show.Tables[0].Columns.Add("PONO_ORG", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("ST_NO")) inBlock_Show.Tables[0].Columns.Add("ST_NO", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("SMELT_MODE")) inBlock_Show.Tables[0].Columns.Add("SMELT_MODE", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("RESTRAND_FLG")) inBlock_Show.Tables[0].Columns.Add("RESTRAND_FLG", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("INS_FE_FLAG")) inBlock_Show.Tables[0].Columns.Add("INS_FE_FLAG", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("TD_CHG_FLG")) inBlock_Show.Tables[0].Columns.Add("TD_CHG_FLG", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("DP_DEV_NO")) inBlock_Show.Tables[0].Columns.Add("DP_DEV_NO", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("DC_DEV_NO")) inBlock_Show.Tables[0].Columns.Add("DC_DEV_NO", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("DP_LADLE_NO")) inBlock_Show.Tables[0].Columns.Add("DP_LADLE_NO", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("REFINE_ROUTE_CODE")) inBlock_Show.Tables[0].Columns.Add("REFINE_ROUTE_CODE", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("CC_MACH_NO1")) inBlock_Show.Tables[0].Columns.Add("CC_MACH_NO1", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("CAST_NO")) inBlock_Show.Tables[0].Columns.Add("CAST_NO", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("CAST_DIV_NO")) inBlock_Show.Tables[0].Columns.Add("CAST_DIV_NO", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("PI_END_TIME")) inBlock_Show.Tables[0].Columns.Add("PI_END_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("DS_END_TIME")) inBlock_Show.Tables[0].Columns.Add("DS_END_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("DP_LOAD_START_TIME")) inBlock_Show.Tables[0].Columns.Add("DP_LOAD_START_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("DP_BLOW_START_TIME")) inBlock_Show.Tables[0].Columns.Add("DP_BLOW_START_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("DP_TAP_START_TIME")) inBlock_Show.Tables[0].Columns.Add("DP_TAP_START_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("DC_LOAD_START_TIME")) inBlock_Show.Tables[0].Columns.Add("DC_LOAD_START_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("DC_BLOW_START_TIME")) inBlock_Show.Tables[0].Columns.Add("DC_BLOW_START_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("DC_TAP_START_TIME")) inBlock_Show.Tables[0].Columns.Add("DC_TAP_START_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("SR1_START_TIME")) inBlock_Show.Tables[0].Columns.Add("SR1_START_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("SR2_START_TIME")) inBlock_Show.Tables[0].Columns.Add("SR2_START_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("SR3_START_TIME")) inBlock_Show.Tables[0].Columns.Add("SR3_START_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("SR4_START_TIME")) inBlock_Show.Tables[0].Columns.Add("SR4_START_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("LD_ARRIVE_TIME")) inBlock_Show.Tables[0].Columns.Add("LD_ARRIVE_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("CC_START_TIME")) inBlock_Show.Tables[0].Columns.Add("CC_START_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("CC_END_TIME")) inBlock_Show.Tables[0].Columns.Add("CC_END_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("EARLY_TIME")) inBlock_Show.Tables[0].Columns.Add("EARLY_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("PONO_STATUS")) inBlock_Show.Tables[0].Columns.Add("PONO_STATUS", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("LADLE_NO")) inBlock_Show.Tables[0].Columns.Add("LADLE_NO", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("LD_STATUS")) inBlock_Show.Tables[0].Columns.Add("LD_STATUS", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("REMARK")) inBlock_Show.Tables[0].Columns.Add("REMARK", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("CAST_NO_SHOW")) inBlock_Show.Tables[0].Columns.Add("CAST_NO_SHOW", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("PI_FLAG")) inBlock_Show.Tables[0].Columns.Add("PI_FLAG", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("DS_FLAG")) inBlock_Show.Tables[0].Columns.Add("DS_FLAG", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("PRE_SMELT_FLAG1")) inBlock_Show.Tables[0].Columns.Add("PRE_SMELT_FLAG1", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("PRE_SMELT_FLAG2")) inBlock_Show.Tables[0].Columns.Add("PRE_SMELT_FLAG2", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("PRE_SMELT_FLAG3")) inBlock_Show.Tables[0].Columns.Add("PRE_SMELT_FLAG3", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("MAIN_SMELT_FLAG1")) inBlock_Show.Tables[0].Columns.Add("MAIN_SMELT_FLAG1", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("MAIN_SMELT_FLAG2")) inBlock_Show.Tables[0].Columns.Add("MAIN_SMELT_FLAG2", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("MAIN_SMELT_FLAG3")) inBlock_Show.Tables[0].Columns.Add("MAIN_SMELT_FLAG3", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("SR1_FLAG")) inBlock_Show.Tables[0].Columns.Add("SR1_FLAG", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("SR2_FLAG")) inBlock_Show.Tables[0].Columns.Add("SR2_FLAG", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("SR3_FLAG")) inBlock_Show.Tables[0].Columns.Add("SR3_FLAG", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("SR4_FLAG")) inBlock_Show.Tables[0].Columns.Add("SR4_FLAG", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("CC_FLAG1")) inBlock_Show.Tables[0].Columns.Add("CC_FLAG1", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("CC_FLAG2")) inBlock_Show.Tables[0].Columns.Add("CC_FLAG2", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("BOF_REST_TIME")) inBlock_Show.Tables[0].Columns.Add("BOF_REST_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("SR_REST_TIME")) inBlock_Show.Tables[0].Columns.Add("SR_REST_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("CC_REST_TIME")) inBlock_Show.Tables[0].Columns.Add("CC_REST_TIME", typeof(String));
            if (!inBlock_Show.Tables[0].Columns.Contains("ST_NO_FLAG")) inBlock_Show.Tables[0].Columns.Add("ST_NO_FLAG", typeof(String));

            #endregion
        }
        //调用计划保存前准备数据块
        private void Set_save_block()
        {
            try
            {
                inBlock_Save.Tables[0].Clear();
                inBlock_Save.Tables[0].Merge(inBlock_Show.Tables[0],false);

                //for(int row_plan=0;row_plan<inBlock_Show.Tables[0].Rows.Count;row_plan++)
                //{
                //    DataRow plan_row= inBlock_Save.Tables[0].Rows.Add();
                //    DataRow planShow_row= inBlock_Show.Tables[0].Rows[row_plan];
                //    //plan_row["PONO"] = planShow_row["PONO"];
                //    //plan_row["HEAT_NO"] = planShow_row["HEAT_NO"];
                //    //plan_row["ST_NO"] = planShow_row["ST_NO"];
                //    //plan_row["RESTRAND_FLG"] = planShow_row["RESTRAND_FLG"];
                //    //plan_row["PLAN_STYLE"] = " ";//计划编制类型？？？何意planShow_row["PONO"];   
                //    //plan_row["TD_CHG_FLG"] = planShow_row["TD_CHG_FLG"];
                //    //plan_row["REFINE_ROUTE_CODE"] = planShow_row["REFINE_ROUTE_CODE"];
                //    //plan_row["PONO_STATUS"] = planShow_row["PONO_STATUS"];
                //    plan_row["CC_REQ_TIME"] = " "; //planShow_row["PONO"];
                //    plan_row["SMELT_MODE"] = planShow_row["DP_DEV_NO"].ToString().Trim() != "" ? "2" : "1";
                //    plan_row["LD_1_ID"] = planShow_row["DP_DEV_NO"];
                //    plan_row["LD_1_WAIT_START_TIME"] = planShow_row["DP_LOAD_START_TIME"];
                //    plan_row["LD_1_END_TIME"] = planShow_row["DP_TAP_START_TIME"];
                //    plan_row["LD_2_ID"] = planShow_row["PONO"];
                //    plan_row["LD_2_WAIT_START_TIME"] = planShow_row["DC_LOAD_START_TIME"];
                //    plan_row["LD_2_END_TIME"] = planShow_row["DC_BLOW_START_TIME"];
                //    plan_row["FINERY_1_ID"] = planShow_row["PONO"];
                //    plan_row["FINERY_1_START_TIME"] = planShow_row["PONO"];
                //    plan_row["FINERY_1_END_TIME"] = planShow_row["PONO"];
                //    plan_row["FINERY_2_ID"] = planShow_row["PONO"];
                //    plan_row["FINERY_2_START_TIME"] = planShow_row["PONO"];
                //    plan_row["FINERY_2_END_TIME"] = planShow_row["PONO"];
                //    plan_row["FINERY_3_ID"] = planShow_row["PONO"];
                //    plan_row["FINERY_3_START_TIME"] = planShow_row["PONO"];
                //    plan_row["FINERY_3_END_TIME"] = planShow_row["PONO"];
                //    plan_row["FINERY_4_ID"] = planShow_row["PONO"];
                //    plan_row["FINERY_4_START_TIME"] = planShow_row["PONO"];
                //    plan_row["FINERY_4_END_TIME"] = planShow_row["PONO"];
                //    plan_row["CAST_1_WAIT_ID"] = planShow_row["PONO"];
                //    plan_row["CAST_1_WAIT_START_TIME"] = planShow_row["PONO"];
                //    plan_row["CAST_1_WAIT_END_TIME"] = planShow_row["PONO"];
                //    plan_row["CAST_1_ID"] = planShow_row["PONO"];
                //    plan_row["CAST_1_START_TIME"] = planShow_row["PONO"];
                //    plan_row["CAST_1_END_TIME"] = planShow_row["PONO"];
                //    plan_row["STEEL_RETURN_CODE"] = planShow_row["PONO"];
                //    plan_row["SG_SIGN"] = planShow_row["PONO"];
                //    //以下项目非必要，项目定制
                //    plan_row["CC_MARK"] = planShow_row["PONO"];
                //    plan_row["TPD_ID"] = planShow_row["PONO"];
                //    plan_row["TPD_START_TIME"] = planShow_row["PONO"];
                //    plan_row["TPD_END_TIME"] = planShow_row["PONO"];
                //    plan_row["KR_ID"] = planShow_row["PONO"];
                //    plan_row["KR_START_TIME"] = planShow_row["PONO"];
                //    plan_row["KR_END_TIME"] = planShow_row["PONO"];

                //}

               
            }
            catch (Exception err)
            {
                this.EFMsgInfo = "系统出现异常，请联系系统维护人员。 " + err.Message;
                return;
            }
            
        }

        private EI.EIInfo GetSubRow(EI.EIInfo inblock)
        {
            //从接口inBlock_All中获取与传入参数inblock中相同PONO的出钢计划子表信息
           try
           {
               EI.EIInfo outBlock_sub = new EI.EIInfo();
               outBlock_sub.Merge(inblock.Tables[0]);
               DataRow sub_row = inblock.Tables[0].Rows[0];
               int i = 0;
               for(i=0;i< inBlock_All.Tables["SUB"].Rows.Count;i++)
               {
                   DataRow dr = inBlock_All.Tables["SUB"].Rows[i];
                   if (sub_row["PONO"].ToString() == dr["PONO"].ToString())
                   {
                       int a = 1;
                   }
                   if(sub_row["PONO"].ToString()==dr["PONO"].ToString()
                       //&& sub_row["SM_PLAN_NO"].ToString() == dr["SM_PLAN_NO"].ToString()
                       && sub_row["FACTORY_DIV"].ToString()==dr["FACTORY_DIV"].ToString()
                       && sub_row["AREA_ID"].ToString() == dr["AREA_ID"].ToString()
                       && sub_row["DEV_CODE"].ToString() == dr["DEV_CODE"].ToString()
                       && sub_row["CHARGE_NO"].ToString() == dr["CHARGE_NO"].ToString()   //连CHARGE_NO都一样，说明无增加/减少工序  继承原记录
                       )
                   {
                       outBlock_sub.Tables[0].Rows.Clear();
                       outBlock_sub.Tables[0].ImportRow(dr);
                       break;
                   }
               }

               return outBlock_sub;
           }
           catch
           {
               return inblock;
           }
        }
   
        private void plan_status_ca(string catch_div)
        {
            try
            {
                

                EI.EIInfo inBlock = new EI.EIInfo();
                EI.EIInfo outBlock;
                EI.EIInfo.eiinfo_sys s;

                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("CATCH_DIV", typeof(String)); //0-查询  1-编制  2-下达  9-判定
                inBlock.Tables[0].Rows.Add();
                inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;
                inBlock.Tables[0].Rows[0]["CATCH_DIV"] = catch_div;

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm28_catch", inBlock);
                v_plan_edit_flag = "0";
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    this.EFMsgInfo = "出钢计划状态获取失败！";
                    GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                    return;
                    
                }
                DataRow dr = outBlock.Tables[0].Rows[0];
                v_plan_edit_flag = dr["ARCHIVE_FLAG"].ToString();
                v_edit_flag = v_edit_flag.Trim()=="A" ? "A" : dr["CATCH_RESULT"].ToString(); //0-不可编制  1-可编
                if (v_plan_edit_flag == "1") formConfigHelper.SetControlEditValue("LayoutGroupFilter", "CATCH_RESULT", "出钢计划编制"); //1-编制  2-下达
                else if (v_plan_edit_flag.ToString() == "2") formConfigHelper.SetControlEditValue("LayoutGroupFilter", "CATCH_RESULT", "出钢计划下达");
                else formConfigHelper.SetControlEditValue("LayoutGroupFilter", "CATCH_RESULT", "出钢计划已下达");

                formConfigHelper.SetControlEditValue("LayoutGroupFilter", "REC_REVISE_TIME", Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(dr["REC_REVISE_TIME"].ToString())));

                formConfigHelper.SetControlEditValue("LayoutGroupFilter", "REC_REVISOR", dr["REC_REVISOR"].ToString());

                if(catch_div.Trim()=="0")
                {
                    v_plan_edit_flag = dr["ARCHIVE_FLAG"].ToString(); 
                }
                else if(false) //放开校验
                {
                    v_plan_edit_flag = dr["CATCH_RESULT"].ToString(); //0-不可编制  1-可编
                    if (v_plan_edit_flag.Trim() == "0")
                    {
                        //暂时注释
                        this.EFMsgInfo = "出钢计划被编制中，不可进行本次操作！";
                        GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                        return;
                    }
                    else
                    {
                        v_plan_edit_flag = catch_div;
                    }
                    if (v_plan_edit_flag == "1") formConfigHelper.SetControlEditValue("LayoutGroupFilter", "CATCH_RESULT", "出钢计划编制"); //1-编制  2-下达
                    else if (v_plan_edit_flag.ToString() == "2") formConfigHelper.SetControlEditValue("LayoutGroupFilter", "CATCH_RESULT", "出钢计划下达");
                    else formConfigHelper.SetControlEditValue("LayoutGroupFilter", "CATCH_RESULT", "出钢计划已下达");

                }

                //放开校验
                v_plan_edit_flag = "1"; //0-不可编制  1-可编
                v_edit_flag = "1";
                return;


            }
            catch (Exception err)
            {
                this.EFMsgInfo = "系统出现异常，请联系系统维护人员。 " + err.Message;
                return;
            }

        }
        #endregion

        #endregion

        #region 定时器查询
        private void timer_plan_Tick(object sender, EventArgs e)
        {
            query("2");  //出钢计划查询
            plan_status_ca("0");
        }

        private void timer_proc_no_Tick(object sender, EventArgs e)
        {
            //queryCurrProcShow();//处理号查询
        }
        #endregion

        private void efRadio_tps_CheckedChanged(object sender, EventArgs e)
        {
            if (efRadio_tps.Checked == true)
            {
                plan_flag = 0;
                query("2");
                //query_view(plan_flag);
            }
        }

        private void efRadio_cast_CheckedChanged(object sender, EventArgs e)
        {
            if (efRadio_cast.Checked == true)
            {
                plan_flag = 1;
                query("2");
                //query_view(plan_flag);
            }
        }

        #region 铸余维护
        private void FormPSSM28SI_EF_PRE_DO_F9(object sender, EF_Args e)
        {
            this.timer_plan.Enabled = false;
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                this.efDevGrid1.SetSelectedColumnChecked(i, true);
            }
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
        }

        private void FormPSSM28SI_EF_CANCEL_DO_F9(object sender, EF_Args e)
        {
            //取消后刷新画面
            query("2");
        }

        private void FormPSSM28SI_EF_DO_F9(object sender, EF_Args e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            int i = 0;

            try
            {
                //获取当前修改数据
                if (this.efDevGrid1.GetSelectedDataRow().Rows.Count < 1)
                {
                    this.EFMsgInfo = "请选择要调整的计划进行操作！";
                    GC.PM_utility2.Dev_messageBoxWarning(this.EFMsgInfo);
                    return;
                }


                inBlock.Tables[0].TableName = "TPSSM11"; //炉次条件
                inBlock.Tables[0].Merge(this.efDevGrid1.GetSelectedDataRow());

                //调用后台
                this.EFMsgInfo = "铸余信息修改中...";
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_cc_remain_upd", inBlock);
                s = outBlock.GetSys();
                //判断调用是否成功
                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    return;
                }

                //执行成功后刷新
                query("2");
                this.EFMsgInfo = "修改成功。";

            }
            catch (Exception ex)
            {
                this.EFMsgInfo = ex.Message;
            }
        }
        #endregion




    }
}
