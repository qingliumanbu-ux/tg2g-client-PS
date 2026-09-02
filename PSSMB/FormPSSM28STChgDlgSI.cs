using DevExpress.Utils;
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
    public partial class FormPSSM28STChgDlgSI : EF.EFFormBase
    {
        private EI.EIInfo.eiinfo_sys s;
        public string factory_div = "";
        public string cc_mach_no = "";
        public string pono = "";
        public string heat_no = "";
        public string st_no = "";
        public string sm_plan_no = "";
        public string v_curr_part_name = " "; //this.ef_args.formPartition; //当前画面的分区代码。
        private DataTable dt_TQMTS25 = new DataTable();

        private string g_form = "PSSM28STChgDlg"; //SI配置画面名
        private DataSet DS;
        private BE2.FormConfig.FormConfigHelper formConfigHelper;
        private BE2.Common.LayoutDataChecker layoutDataCheckerMain = new BE2.Common.LayoutDataChecker();

        public FormPSSM28STChgDlgSI()
        {
            InitializeComponent();
        }

        public void SetPONOInfo()
        {
            formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SM_PLAN_NO", sm_plan_no);
            formConfigHelper.SetControlEditValue("LayoutGroupFilter", "PONO", pono);
            formConfigHelper.SetControlEditValue("LayoutGroupFilter", "HEAT_NO", heat_no);
            formConfigHelper.SetControlEditValue("LayoutGroupFilter", "ST_NO", st_no);
            formConfigHelper.SetControlEditValue("LayoutGroupFilter", "CC_MACH_NO", cc_mach_no);
            formConfigHelper.SetControlEditValue("LayoutGroupFilter", "CC_MACH_NO_EX", cc_mach_no);
            //this.sM_PLAN_NOEFTextBox.Text = sm_plan_no;
            //this.pONOEFTextBox.Text = pono;
            //this.sT_NOEFTextBox.Text = st_no;
            //this.cC_MACH_NOEFTextBox.Text = cc_mach_no;
        }

        private void FormPSSM28STChgDlgSI_Load(object sender, EventArgs e)
        {
            if (EF.EF_Args.common_parameter_1.Trim() != "")
            {
                v_curr_part_name = EF.EF_Args.common_parameter_1;//当前画面的分区代码
            }
            //EF.Utility.SetGridColumn(new EF.EFDevGrid[] { this.efDevGrid1 }, new string[] { "PSSM28_CHG" }, v_curr_part_name);
            //this.efDevGrid1.ShowSelectionColumn = true;
            //this.efDevGrid1.EFMultiSelect = false;

            formConfigHelper = new BE2.FormConfig.FormConfigHelper(v_curr_part_name, g_form, string.Empty, "#", " ", "pssm_form_get");
            DS = formConfigHelper.FormDataSet;

            // 初始化数据源
            BindingSource ps_pono = formConfigHelper.CreateBindingSourceForLayoutOrView("GridView1");

            // 单记录条件
            formConfigHelper.LoadLayoutControlsForFilter(this, layoutControl1, layoutControlGroup2, "LayoutGroupFilter");

            formConfigHelper.LoadGridView(this, "GridView1", this.efDevGrid1, this.gridView1, null);
            formConfigHelper.LoadGridView(this, "GridView3", this.efDevGrid3, this.gridView3, null);


            layoutControl1.BestFit();

            SetPONOInfo();

            //initQuery();
            query();

            //过程成分
            p_query_elem(2, -1, 1, this.efDevGrid2.PageSize);
        }

        #region 过程成分查询及颜色
        private void p_query_elem(int query_flag, int rowsel, int tarGetPageNo, int pageSize)
        {
            try
            {
                EI.EIInfo inBlock = new EI.EIInfo();
                EI.EIInfo outBlock;
                EI.EIInfo.eiinfo_sys s;
                inBlock.Tables[0].Merge(formConfigHelper.GetAllControlEditValue("LayoutGroupFilter"));

                inBlock.Tables[0].Columns.Add("flag", typeof(Int32));
                //inBlock.Tables[0].Columns.Add("heat_no", typeof(String));
                //inBlock.Tables[0].Columns.Add("st_no", typeof(String));
                inBlock.Tables[0].Columns.Add("rec_create_time_from", typeof(String));
                inBlock.Tables[0].Columns.Add("rec_create_time_to", typeof(String));
                inBlock.Tables[0].Columns.Add("analyse_time_from", typeof(String));
                inBlock.Tables[0].Columns.Add("analyse_time_to", typeof(String));
                inBlock.Tables[0].Columns.Add("st_sample_div", typeof(String));
                inBlock.Tables[0].Columns.Add("gas_type_div", typeof(String));
                inBlock.Tables[0].Columns.Add("whole_backlog_code", typeof(String));

                
                inBlock.Tables[0].Columns.Add("now_record", typeof(Int32));
                inBlock.Tables[0].Columns.Add("every_page", typeof(Int32));

                //inBlock.Tables[0].Rows.Clear();
                inBlock.Tables[0].Rows.Add();

                inBlock.Tables[0].Rows[0]["flag"] = query_flag;
                //inBlock.Tables[0].Rows[0]["heat_no"] = "23B400265";

                //2023.1.16 hq
                inBlock.Tables[0].Columns.Add("factory_div", typeof(String));
                //inBlock.Tables[0].Rows[0]["factory_div"] = factory_div;

                //分页信息
                inBlock.Tables.Add("PageInfo");
                inBlock.Tables["PageInfo"].Columns.Add("now_record");/*当前记录序号*/
                inBlock.Tables["PageInfo"].Columns.Add("every_page");/*每页最大行*/

                int v_now_record = pageSize * (tarGetPageNo - 1);
                int _currentPageNo = tarGetPageNo, _pageNum = 0;

                inBlock.Tables["PageInfo"].Rows.Add(v_now_record, this.efDevGrid1.PageSize);

                //outBlock = EI.EITuxedo.CallService("qmts29_inq", inBlock);
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "qmts25_inq", inBlock);
                s = outBlock.GetSys();

                //判断调用是否正确
                if (s.flag < 0)
                {
                    this.efStatusBar1.Text = s.msg;
                    return;
                }
                BindingSource bindsource = new BindingSource();
                bindsource.DataSource = outBlock.DataSet;
                outBlock.Tables[0].TableName = "TQMTS29";
                bindsource.DataMember = "TQMTS29";
                dt_TQMTS25.Merge(outBlock.Tables[0]);

                if (query_flag == 0) //进入画面load元素信息
                {
                    efDevGrid2.DataSource = bindsource;
                    efDevGrid2.ShowSelectionColumn = true;
                    this.gridView2.BestFitColumns();
                }
                else
                {
                    if (bindsource.Count > 0)
                    {
                        efDevGrid2.DataSource = bindsource;
                        efDevGrid2.ShowSelectionColumn = true;
                        this.gridView2.BestFitColumns();
                        if (rowsel != -1)
                        {
                            this.gridView2.FocusedRowHandle = rowsel;
                        }
                        this.efDevGrid2.TotalRecordCount = Convert.ToInt32(outBlock.Tables[1].Rows[0]["TOTAL_COUNT"].ToString());
                        //总页数
                        _pageNum = ((this.efDevGrid2.TotalRecordCount - 1) / this.efDevGrid2.PageSize) + 1;

                        //页数信息(第几页共几页)
                        //this.efDevGrid2.RecordCountMessage = string.Format(QM.QM00.QM00C0001165/*第{0}/{1}页，共{2}条记录*/, tarGetPageNo, _pageNum, efDevGrid2.TotalRecordCount);
                        //此属性设置efDevGrid中前面的行号,开始值(一般都是从0 开始,如果查询的是其他页 ,那应该是从 (当前页 * 每页大小+1) 开始
                        this.efDevGrid2.InitRowOrdinal = (tarGetPageNo - 1) * this.efDevGrid2.PageSize + 1;
                        int maxRowNum = this.efDevGrid2.InitRowOrdinal + this.efDevGrid2.PageSize;
                        if (maxRowNum <= 1000)
                        {
                            gridView2.IndicatorWidth = 35; //调整行号列的宽度
                        }
                        else if (maxRowNum > 1000 && maxRowNum <= 10000)
                        {
                            gridView2.IndicatorWidth = 42;
                        }
                        else if (maxRowNum > 10000 && maxRowNum <= 100000)
                        {
                            gridView2.IndicatorWidth = 52;
                        }
                        else
                        {
                            gridView2.IndicatorWidth = 60;
                        }
                        //this.EFMsgInfo = "查询到" + this.efDevGrid2.TotalRecordCount + "条记录";
                    }
                    else
                    {
                        efDevGrid2.DataSource = bindsource;
                        efDevGrid2.ShowSelectionColumn = true;
                        this.gridView2.BestFitColumns();
                        this.efDevGrid2.TotalRecordCount = 0;

                        _currentPageNo = 0;
                        _pageNum = 0;

                        this.efDevGrid2.RecordCountMessage = string.Format("Page {0} of {1}", _currentPageNo, _pageNum);
                        //this.EFMsgInfo = GC.GCRS.GCRSC0000006/*没有满足条件的记录。*/;
                    }
                }
            }
            catch (Exception ex)
            {
                this.efStatusBar1.Text = ex.Message;
            }
            //设置grid列名居中，值居中或右对齐
            this.gridView2.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            for (int i = 0; i < this.gridView2.Columns.Count; i++)
            {
                if (this.gridView2.Columns[i].FieldName.ToLower().Trim() == "heat_no"
                    || this.gridView2.Columns[i].FieldName.ToLower().Trim() == "pono"
                    || this.gridView2.Columns[i].FieldName.ToLower().Trim() == "st_no"
                    || this.gridView2.Columns[i].FieldName.ToLower().Trim() == "rec_creator"
                    || this.gridView2.Columns[i].FieldName.ToLower().Trim() == "rec_create_time"
                    || this.gridView2.Columns[i].FieldName.ToLower().Trim() == "rec_revisor"
                    || this.gridView2.Columns[i].FieldName.ToLower().Trim() == "rec_revise_time")
                {
                    this.gridView2.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default;
                }
                else
                {
                    this.gridView2.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                }
                if (this.gridView2.Columns[i].FieldName.IndexOf("OK") > 0)
                {
                    this.gridView2.Columns[i].Visible = false;
                }
            }
        }

        private void p_efgrid_set()
        {
            int i;
            {
                for (i = 0; i < this.gridView2.Columns.Count; i++)
                {
                    this.gridView2.Columns[i].OptionsColumn.AllowEdit = false;
                }
                this.gridView2.Columns[i - 1].OptionsColumn.AllowEdit = true;
                this.efDevGrid2.ShowContextMenuAddCopyNew = false;
                this.efDevGrid1.ShowContextMenuAddNew = false;
                this.efDevGrid1.ShowContextMenuChoose = false;
                this.efDevGrid1.ShowContextMenuChooseAll = false;
                this.efDevGrid1.ShowContextMenuUnChoose = false;
                this.efDevGrid1.ShowContextMenuUnChooseAll = false;
            }
        }
        #endregion

        #region 设置单元格风格事件(颜色区分元素合否)
        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0)
            {
                return;
            }
            if (dt_TQMTS25.Columns.Contains(e.Column.FieldName + "_OK"))
            {
                //string elem_ok = dt_TQMTS25.Rows[e.RowHandle][e.Column.FieldName + "_OK"].ToString();
                switch (gridView2.GetRowCellValue(e.RowHandle, e.Column.FieldName + "_OK").ToString())
                {
                    case "9":
                    case "8":
                        e.Appearance.ForeColor = Color.Black;
                        break;
                    //主试不合且特采不合,主试不合且无特采统一设置红色
                    case "1":
                    case "3":
                        e.Appearance.ForeColor = Color.Red;
                        break;
                    //大于主试最大且无特采，设置红色
                    case "2":
                        e.Appearance.ForeColor = Color.Red;
                        break;
                    //小于主试最小且无特采，设置绿色
                    case "4":
                        e.Appearance.ForeColor = Color.Green;
                        break;
                    default:
                        e.Appearance.ForeColor = Color.Blue;
                        break;
                }
            }
            return;
        }
        #endregion

        #region 对话框初始化查询函数
        /// <summary>
        /// 对话框初始化查询函数
        /// <para>连铸设备查询</para>
        /// </summary>
        //private void initQuery()
        //{
        //    //查询条件
        //    EI.EIInfo inBlock = new EI.EIInfo();
        //    EI.EIInfo outBlock;

        //    try
        //    {

        //        //查询条件项
        //        inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
        //        inBlock.Tables[0].Rows.Add();
        //        inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;

        //        //查询未编入计划的炉次，否则编制方法要修改
        //        //调用后台
        //        this.efStatusBar1.Text = "初始化查询中...";
        //        outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm11stdlg_inq", inBlock);
        //        s = outBlock.GetSys();
        //        //判断调用是否成功
        //        if (s.flag < 0)
        //        {
        //            this.efStatusBar1.Text = s.msg;
        //            return;
        //        }
        //        else
        //        {
        //            if (outBlock.Tables[0] != null)
        //            {
        //                //if(outBlock.Tables[0].Rows.Count>0)
        //                //{
        //                //    Common.Utility.SetLookUpEditProperty(efDevLookUpEdit_CC_MACH_NO, outBlock.Tables[0], "STATION_NAME", "CC_MACH_NO", true);
        //                //    Common.Utility.SetLookUpEditProperty(efDevLookUpEdit_CC_MACH_NO_1, outBlock.Tables[0], "STATION_NAME", "CC_MACH_NO", true);
        //                //}

        //                //20150909 lj Common.Utility.SetLookUpEditProperty 方法在roucount=0时下拉出来仍是上次的值
        //                DataRow row = outBlock.Tables[0].NewRow();
        //                row["DEV_NO"] = " ";
        //                row["DEV_DESC"] = " ";
        //                outBlock.Tables[0].Rows.InsertAt(row, 0);
        //                this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.DataSource = outBlock.Tables[0];
        //                this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.DisplayMember = "DEV_DESC";
        //                this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.ValueMember = "DEV_NO";
        //                this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.Columns.Clear();
        //                this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEV_NO", "选项代码"));
        //                this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEV_DESC", "选项描述"));
        //            }                    
        //        }

        //        this.efStatusBar1.Text = "初始化成功。";

        //    }
        //    catch (Exception err)
        //    {
        //        this.efStatusBar1.Text = err.Message;
        //    }

        //}
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
                row["CC_MACH_NO"] = formConfigHelper.GetControlEditValue("LayoutGroupFilter", "CC_MACH_NO_EX").ToString();

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
                    //EF.Utility.SetCustomGridValue(this.efDevGrid1, outBlock, false);
                    this.formConfigHelper.MergeDataToGrid(outBlock.Tables[0], efDevGrid1);
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

        /// <summary>
        /// 查询满足工序成分的标准
        /// </summary>
        private void query_elm_ok_stno()
        {
            //查询条件
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;

            try
            {

                //查询条件项
                DataRow dr_elem = this.gridView2.GetFocusedDataRow();
                if (dr_elem == null)
                {
                    //this.efStatusBar1.Text = "请选择一条比对的【工序成分】进行操作！";
                    //GC.PM_utility2.Dev_messageBoxWarning(this.efStatusBar1.Text);
                    //return;
                }

                //整条记录
                inBlock.Tables[0].Merge(this.efDevGrid2.GetSelectedDataRow());
                DataRow row = inBlock.Tables[0].Rows.Add();
                if(dr_elem != null)
                    row.ItemArray = dr_elem.ItemArray.Clone() as object[];
                //其它条件
                inBlock.Tables[0].Columns.Add("FACTORY_DIV");
                inBlock.Tables[0].Columns.Add("CC_MACH_NO"); //连铸机号
                row["FACTORY_DIV"] = factory_div;
                row["CC_MACH_NO"] = formConfigHelper.GetControlEditValue("LayoutGroupFilter", "CC_MACH_NO_EX").ToString();

                //查询未编入计划的炉次，否则编制方法要修改
                //调用后台
                this.efStatusBar1.Text = "查询中...";
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm11stchg_stno_inq", inBlock);
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
                    //EF.Utility.SetCustomGridValue(this.efDevGrid1, outBlock, false);
                    this.formConfigHelper.MergeDataToGrid(outBlock.Tables[0], efDevGrid3);
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

        #region 查询选中的出钢记号标准成分
        private void p_query_std_elm(int query_flag)
        {
            int rowsel = 0; int tarGetPageNo = 1; int pageSize = 100;
            try
            {
                EI.EIInfo inBlock = new EI.EIInfo();
                EI.EIInfo outBlock;
                EI.EIInfo.eiinfo_sys s;

                inBlock.Tables[0].Columns.Add("flag", typeof(Int32));
                inBlock.Tables[0].Columns.Add("factory_div", typeof(String));
                inBlock.Tables[0].Columns.Add("st_no", typeof(String));
                inBlock.Tables[0].Columns.Add("whole_backlog_code", typeof(String));
                inBlock.Tables[0].Columns.Add("now_record", typeof(Int32));
                inBlock.Tables[0].Columns.Add("every_page", typeof(Int32));
                inBlock.Tables[0].Columns.Add("base_code", typeof(String));

                int v_now_record = pageSize * (tarGetPageNo - 1);
                //this._currentPageNo = tarGetPageNo;

                DataTable dt_stno = this.efDevGrid3.GetSelectedDataRow();
                //ST对选中的st_no循环处理
                //ST-1.删除原来哎数据中，出钢记号在选中st_no不存在的
                for (int i = gridView4.RowCount - 1; i >= 0; i-- )
                {
                    bool find_stno_flag = false;
                    for (int j = dt_stno.Rows.Count - 1; j >= 0; j--)
                    {
                        if (gridView4.GetDataRow(i)["ST_NO"].ToString().CompareTo(dt_stno.Rows[j]["ST_NO"].ToString()) == 0)
                        {
                            find_stno_flag = true;
                            dt_stno.Rows[j].Delete();
                            break;
                        }
                    }
                    if (!find_stno_flag)
                    {
                        gridView4.DeleteRow(i);
                    }
                }
                //ST-2. 选中的st_no剩余不存在 gridView4 的，后台查询；然后插入gridView4
                for (int fi = 0; fi < dt_stno.Rows.Count; fi++ )
                {

                    inBlock.Tables[0].Rows.Clear();
                    //factory_div
                    inBlock.Tables[0].Rows.Add(query_flag, "A", dt_stno.Rows[fi]["ST_NO"], "C", v_now_record, pageSize, "");

                    // outBlock = EI.EITuxedo.CallService("qmts02_inq", inBlock);
                    outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "qmts02_inq", inBlock);
                    s = outBlock.GetSys();

                    //判断调用是否正确
                    if (s.flag < 0)
                    {
                        this.efStatusBar1.Text = s.msg;
                        return;
                    }
                    BindingSource bindsource = new BindingSource();
                    bindsource.DataSource = outBlock.DataSet;
                    outBlock.Tables[0].TableName = "TQMTS02";
                    bindsource.DataMember = "TQMTS02";

                    if (query_flag == 0) //进入画面load元素信息
                    {
                        efDevGrid1.DataSource = bindsource;
                        efDevGrid1.ShowSelectionColumn = true;
                        this.gridView1.BestFitColumns();
                        gridView1.AddNewRow();
                        return;
                    }

                    if (bindsource.Count > 0)
                    {
                        
                        int rowCount = gridView4.RowCount;
                        if(rowCount == 0)
                        {
                            efDevGrid4.DataSource = bindsource;
                            efDevGrid4.ShowSelectionColumn = true;
                            this.gridView4.BestFitColumns();
                            if (rowsel != -1)
                            {
                                this.gridView4.FocusedRowHandle = rowsel;
                            }
                        }else
                        {
                            //gridView4.AddNewRow();
                            //gridView4.EndInit();
                            //DataRow dr = gridView4.GetDataRow(rowCount);
                            //dr.ItemArray = outBlock.Tables[0].Rows[0].ItemArray as object[];
                            DataTable dt_grid = ((EI.EIInfo)((BindingSource)efDevGrid4.DataSource).DataSource).Tables[0];
                            //模糊查询防止重复
                            bool hi_find = false;
                            for(int hi=0; hi<dt_grid.Rows.Count;hi++)
                            {
                                if(dt_grid.Rows[hi]["ST_NO"].ToString().CompareTo(outBlock.Tables[0].Rows[0]["ST_NO"].ToString()) == 0)
                                {
                                    hi_find = true;
                                    break;
                                }
                            }
                            if(!hi_find)
                            {
                                DataRow dr = dt_grid.Rows.Add(outBlock.Tables[0].Rows[0].ItemArray as object[]);
                            }
                                
                        }

                        //EF.Utility.SetCustomGridValue(efDevGrid4, outBlock, false, true);
                        
                        this.efDevGrid4.TotalRecordCount = gridView4.RowCount;
                        //总页数
                        int _pageNum = ((this.efDevGrid4.TotalRecordCount - 1) / this.efDevGrid4.PageSize) + 1;

                        //页数信息(第几页共几页)
                        //this.efDevGrid4.RecordCountMessage = string.Format(QM.QM00.QM00C0001165/*第{0}/{1}页，共{2}条记录*/, tarGetPageNo, _pageNum, efDevGrid4.TotalRecordCount);
                        //此属性设置efDevGrid中前面的行号,开始值(一般都是从0 开始,如果查询的是其他页 ,那应该是从 (当前页 * 每页大小+1) 开始
                        this.efDevGrid4.InitRowOrdinal = (tarGetPageNo - 1) * this.efDevGrid4.PageSize + 1;
                        int maxRowNum = this.efDevGrid4.InitRowOrdinal + this.efDevGrid4.PageSize;
                        if (maxRowNum <= 1000)
                        {
                            gridView4.IndicatorWidth = 35; //调整行号列的宽度
                        }
                        else if (maxRowNum > 1000 && maxRowNum <= 10000)
                        {
                            gridView4.IndicatorWidth = 42;
                        }
                        else if (maxRowNum > 10000 && maxRowNum <= 100000)
                        {
                            gridView4.IndicatorWidth = 52;
                        }
                        else
                        {
                            gridView4.IndicatorWidth = 60;
                        }

                        //add by chenwenqiong
                        //this.EFMsgInfo = "查询到" + this.efDevGrid1.TotalRecordCount + "条记录";
                    }
                }
                    
               
            }
            catch (Exception ex)
            {
                this.efStatusBar1.Text = ex.Message;
            }

            //设置grid列名居中，值居中或右对齐
            this.gridView4.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            for (int i = 0; i < this.gridView4.Columns.Count; i++)
            {
                if (this.gridView4.Columns[i].FieldName.ToLower().Trim() == "st_no"
                    || this.gridView4.Columns[i].FieldName.ToLower().Trim() == "factory_div"
                    || this.gridView4.Columns[i].FieldName.ToLower().Trim() == "whole_backlog_code"
                    || this.gridView4.Columns[i].FieldName.ToLower().Trim() == "whole_backlog_seq"
                    || this.gridView4.Columns[i].FieldName.ToLower().Trim() == "rec_creator"
                    || this.gridView4.Columns[i].FieldName.ToLower().Trim() == "rec_create_time"
                    || this.gridView4.Columns[i].FieldName.ToLower().Trim() == "rec_revisor"
                    || this.gridView4.Columns[i].FieldName.ToLower().Trim() == "rec_revise_time"
                    || this.gridView4.Columns[i].FieldName.ToLower().Trim() == "archive_flag")
                {
                    this.gridView4.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default;
                }
                else
                {
                    this.gridView4.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                }
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
                //if (this.gridView1.SelectedRowsCount != 1)
                if (this.efDevGrid1.GetSelectedDataRow().Rows.Count != 1)
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
                inBlock.Tables[0].Rows[0]["PONO_OUT"] = formConfigHelper.GetControlEditValue("LayoutGroupFilter", "PONO").ToString();
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

        #region 推荐钢种
        private void efButton1_Click(object sender, EventArgs e)
        {
            query_elm_ok_stno();
        }

        #endregion

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //太慢
            //if (e.Column != null && e.Column.VisibleIndex == 0)
            //{
            //    p_query_std_elm(2);
            //}
        }

        private void gridView3_MouseUp(object sender, MouseEventArgs e)
        {
            p_query_std_elm(2);
        }

    }
}
