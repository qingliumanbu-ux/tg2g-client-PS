using System;
using DevExpress.XtraEditors;
using EF;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;

namespace PS
{
    public partial class FormPSSM28AddDlgSI : EF.EFFormBase
    {
        EI.EIInfo.eiinfo_sys s;
        public string factory_div = "";
        public string factory = "";
        private string query_type = "1";
        private int i_show_change = 0; //是否刷新子信息。
        public string time_div = "1";   // 1-连铸  2-转炉
        public string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。
        private EI.EIInfo inBlock_Tpssm26 = new EI.EIInfo();
        public EI.EIInfo inBlock_All = new EI.EIInfo();
        private EI.EIInfo inBlock_para = new EI.EIInfo();

        private string g_form = "PSSM28AddDlg"; //SI配置画面名
        private DataSet DS;
        private BE2.FormConfig.FormConfigHelper formConfigHelper;
        private BE2.Common.LayoutDataChecker layoutDataCheckerMain = new BE2.Common.LayoutDataChecker();
        public FormPSSM28AddDlgSI()
        {
            InitializeComponent();
        }

        private void FormPSSM28AddDlgSI_Load(object sender, EventArgs e)
        {
            //获取传入参数
            //=================
            //分区代码
            //v_curr_part_name = this.ef_args.formPartition;
            if (EF.EF_Args.common_parameter_1.Trim() != "")
            {
                v_curr_part_name = EF.EF_Args.common_parameter_1;
            }

            //块信息
            inBlock_All = (EI.EIInfo)EF.EF_Args.common_object_1;




            //画面低代码加载
            //=================
            formConfigHelper = new BE2.FormConfig.FormConfigHelper(v_curr_part_name, g_form, string.Empty, "#", " ", "pssm_form_get");
            DS = formConfigHelper.FormDataSet;

            // 初始化数据源
            BindingSource ps_cast = formConfigHelper.CreateBindingSourceForLayoutOrView("gridView_main");
            BindingSource ps_pono = formConfigHelper.CreateBindingSourceForLayoutOrView("gridView_pono");


            // 单记录条件
            formConfigHelper.LoadLayoutControlsForEdit(this, layoutControl1, layoutControlGroup4, "LayoutGroupFilter");
            formConfigHelper.LoadGridView(this, "gridView_main", this.efDevGrid_main, this.gridView_main, null);
            formConfigHelper.LoadGridView(this, "gridView_pono", this.efDevGrid_pono, this.gridView_pono, null);


            ////获取Layout中的控件,根据厂别  重新获取设备 20230110 zhengqq
            if (factory_div!="")
            {
                //formConfigHelper.SetControlEditValue();此方法赋值有问题，暂时注释

                EF.EFDevLookUpEdit control = formConfigHelper.GetControl(layoutControlGroup4, "DP_BOF_NO") as EF.EFDevLookUpEdit;
                if (control != null && control is EF.EFDevLookUpEdit)
                {
                    string sqlStr = string.Format("SELECT DEV_CODE CODE,STATION_NAME CODE_NAME FROM TPSSMD1 WHERE 1=1 " + "AND FACTORY_DIV  = '{0}' AND AREA_ID = '{1}' ORDER BY STATION_NO", factory_div, "2");
                    GC.PM_utility2.DEV_init_LookUpEdit(control, "eped_dyn_sql", "XX", sqlStr, "CODE", "CODE_NAME", v_curr_part_name);    
                }

                control = formConfigHelper.GetControl(layoutControlGroup4, "BOF_NO") as EF.EFDevLookUpEdit;
                if (control != null && control is EF.EFDevLookUpEdit)
                {
                    string sqlStr = string.Format("SELECT DEV_CODE CODE,STATION_NAME CODE_NAME FROM TPSSMD1 WHERE 1=1 " + "AND FACTORY_DIV  = '{0}' AND AREA_ID = '{1}' ORDER BY STATION_NO", factory_div, "3");
                    GC.PM_utility2.DEV_init_LookUpEdit(control, "eped_dyn_sql", "XX", sqlStr, "CODE", "CODE_NAME", v_curr_part_name);

                    //设置默认选项
                    control.ItemIndex = 0;

                }

                control = formConfigHelper.GetControl(layoutControlGroup4, "SR1_DEV_CODE") as EF.EFDevLookUpEdit;
                if (control != null && control is EF.EFDevLookUpEdit)
                {
                    string sqlStr = string.Format("SELECT DEV_CODE CODE,STATION_NAME CODE_NAME FROM TPSSMD1 WHERE 1=1 " + "AND FACTORY_DIV  = '{0}' AND AREA_ID = '{1}' ORDER BY STATION_NO", factory_div, "4");
                    GC.PM_utility2.DEV_init_LookUpEdit(control, "eped_dyn_sql", "XX", sqlStr, "CODE", "CODE_NAME", v_curr_part_name);
                }

                control = formConfigHelper.GetControl(layoutControlGroup4, "SR2_DEV_CODE") as EF.EFDevLookUpEdit;
                if (control != null && control is EF.EFDevLookUpEdit)
                {
                    string sqlStr = string.Format("SELECT DEV_CODE CODE,STATION_NAME CODE_NAME FROM TPSSMD1 WHERE 1=1 " + "AND FACTORY_DIV  = '{0}' AND AREA_ID = '{1}' ORDER BY STATION_NO", factory_div, "4");
                    GC.PM_utility2.DEV_init_LookUpEdit(control, "eped_dyn_sql", "XX", sqlStr, "CODE", "CODE_NAME", v_curr_part_name);
                }

                control = formConfigHelper.GetControl(layoutControlGroup4, "SR3_DEV_CODE") as EF.EFDevLookUpEdit;
                if (control != null && control is EF.EFDevLookUpEdit)
                {
                    string sqlStr = string.Format("SELECT DEV_CODE CODE,STATION_NAME CODE_NAME FROM TPSSMD1 WHERE 1=1 " + "AND FACTORY_DIV  = '{0}' AND AREA_ID = '{1}' ORDER BY STATION_NO", factory_div, "4");
                    GC.PM_utility2.DEV_init_LookUpEdit(control, "eped_dyn_sql", "XX", sqlStr, "CODE", "CODE_NAME", v_curr_part_name);
                }

                control = formConfigHelper.GetControl(layoutControlGroup4, "SR4_DEV_CODE") as EF.EFDevLookUpEdit;
                if (control != null && control is EF.EFDevLookUpEdit)
                {
                    string sqlStr = string.Format("SELECT DEV_CODE CODE,STATION_NAME CODE_NAME FROM TPSSMD1 WHERE 1=1 " + "AND FACTORY_DIV  = '{0}' AND AREA_ID = '{1}' ORDER BY STATION_NO", factory_div, "4");
                    GC.PM_utility2.DEV_init_LookUpEdit(control, "eped_dyn_sql", "XX", sqlStr, "CODE", "CODE_NAME", v_curr_part_name);
                }

                control = formConfigHelper.GetControl(layoutControlGroup4, "CC_MACH_NO") as EF.EFDevLookUpEdit;
                if (control != null && control is EF.EFDevLookUpEdit)
                {
                    string sqlStr = string.Format("SELECT DEV_CODE CODE,STATION_NAME CODE_NAME FROM TPSSMD1 WHERE 1=1 " + "AND FACTORY_DIV  = '{0}' AND AREA_ID = '{1}' ORDER BY STATION_NO", factory_div, "5");
                    GC.PM_utility2.DEV_init_LookUpEdit(control, "eped_dyn_sql", "XX", sqlStr, "CODE", "CODE_NAME", v_curr_part_name);

                    //设置默认选项
                    control.ItemIndex = 0;

                }

            
            }



            //画面原有控件初始化
            //=================
            this.efDevDateEdit_CC.DateTime = DateTime.Now;

            queryinit();
            query();
            string cc_mach_no = "";
            if (this.gridView_main.RowCount > 0)
            {
                cc_mach_no = this.gridView_main.GetFocusedDataRow()["CC_MACH_NO"].ToString().Trim();
            }


            if (cc_mach_no != "" || cc_mach_no != null)
            {
                query_pono(cc_mach_no);
            }
            if (time_div.Trim() == "1")
            {
                efRadio_cc.Checked = true;
                efRadio_bof.Visible = false;
                efRadio_cc.Visible = true;
            }
            else
            {
                efRadio_bof.Checked = true;
                efRadio_cc.Visible = false;
                efRadio_bof.Visible = true;
            }

            //设置控件默认参数
            formConfigHelper.SetControlEditValue("LayoutGroupFilter", "CC_MACH_NO", "C"+cc_mach_no);

          

        }


        #region 按钮事件
        private void efButton_inq_Click(object sender, EventArgs e)
        {
            query();
        }

        private void efButton_add_Click(object sender, EventArgs e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo inBlock_Plan = new EI.EIInfo();
            //EI.EIInfo outBlock;

            try
            {
                if ((this.efDevGrid_pono.GetSelectedDataRow().Rows.Count) <= 0)
                {
                    string str = "请选择需要编入计划的制造命令。";
                    EF.EFMessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.efStatusBar1.Text = str;
                    this.DialogResult = DialogResult.None;
                    return;
                }


                //指定开浇时间，放到各炉次信息中，此处不再定义
                inBlock.Tables[0].TableName = "POUR";
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", System.Type.GetType("System.String"));
                inBlock.Tables[0].Columns.Add("CC_REQ_TIME", System.Type.GetType("System.String"));
                inBlock.Tables[0].Rows.Add(factory_div, ((DateTime)efDevDateEdit_CC.EditValue).ToString("yyyyMMddHHmmss"));


                //选择的PONO
                DataTable table_pono = inBlock.Tables.Add("PONO");
                inBlock.Tables["PONO"].Merge(this.efDevGrid_pono.GetSelectedDataRow());



                //outBlock.Tables[0].Merge(inBlock_All);

                //选择的默认设备
                inBlock.Tables.Add("DEV");  //定义默认设备块
                inBlock.Tables["DEV"].Columns.Add("STATION_ID");
                inBlock.Tables["DEV"].Columns.Add("STATION_NO");
                inBlock.Tables["DEV"].Columns.Add("DEV_CODE");
                inBlock.Tables["DEV"].Columns.Add("FACTORY_DIV");
                this.efStatusBar1.Text = "计划编入中...";

                add_pono(inBlock);

                this.efStatusBar1.Text = "计划编入中...";


            }
            catch (Exception ex)
            {
                GC.PM_utility2.Dev_messageBoxError(ex.Message);
            }
        }

        private void efButton_quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void efRadio_cc_CheckedChanged(object sender, EventArgs e)
        {
            if (efRadio_cc.Checked == true)
            {
                time_div = "1";
                efLabel3.Text = "*计划开浇时刻";
                //plan_flag = 0;
                // query("2");
                //query_view(plan_flag);
            }
        }

        private void efRadio_bof_CheckedChanged(object sender, EventArgs e)
        {
            if (efRadio_bof.Checked == true)
            {
                time_div = "2";
                efLabel3.Text = "*计划开吹时刻";
                //plan_flag = 1;
                //query("2");
                //query_view(plan_flag);
            }
        }
        #endregion

        #region 画面空间事件
        //废弃不用
        private void gridView_dev_MouseDown(object sender, MouseEventArgs e)
        {
            //废弃
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo HitInfo = this.gridView_dev.CalcHitInfo(e.Location);//获取鼠标点击的位置
            //if (gridView_dev.RowCount == 0 || /*记录数大于0*/
            //        !HitInfo.InRowCell /*有效的单元格*/||
            //    e.Button != MouseButtons.Left /*鼠标左键*/||
            //        e.Clicks != 1  /*单击*/
            //    )
            //{
            //    return;
            //}

            //if (HitInfo.Column.FieldName == "SELECTION_Unbound")
            //{
            //    //强转当前行（避免鼠标点击的行与焦点行FocusedRowHandle不一致，鼠标点击时，焦点行FocusedRowHandle还未转换）
            //    gridView_dev.FocusedRowHandle = HitInfo.RowHandle;
            //    int i = 0;

            //    string focuse_dev,rownum_dev = "";
            //    for (i = 0; i < this.gridView_dev.RowCount; i++)
            //    {
            //        focuse_dev = this.gridView_dev.GetRowCellValue(this.gridView_dev.FocusedRowHandle, "STATION_ID").ToString();
            //        rownum_dev = this.gridView_dev.GetRowCellValue(i, "STATION_ID").ToString();

            //        if ((focuse_dev.Substring(0, 1) == "B"|| focuse_dev.Substring(0, 1) == "E")
            //            && (rownum_dev.Substring(0, 1) == "B" || rownum_dev.Substring(0, 1) == "E"))
            //        {
            //            if (i != this.gridView_dev.FocusedRowHandle)
            //            {
            //                // gridView_dev.SetRowCellValue(HitInfo.RowHandle, "需要接受值列的FieldName",从窗体获取到的值);
            //                //使用SetRowCellValue会触发gViewActPara_CellValueChanged事件
            //                this.gridView_dev.SetRowCellValue(i, "SELECTION", "0");
            //            }
            //            else if (i == this.gridView_dev.FocusedRowHandle)
            //            {
            //                this.gridView_dev.SetRowCellValue(i, "SELECTION", "1");
            //            }
            //        }
            //        else if ((focuse_dev.Substring(0, 1) == "C" || focuse_dev.Substring(0, 1) == "I" || focuse_dev.Substring(0, 1) == "W")
            //            && (rownum_dev.Substring(0, 1) == "C" || rownum_dev.Substring(0, 1) == "I" || rownum_dev.Substring(0, 1) == "W"))
            //        {
            //            if (i != this.gridView_dev.FocusedRowHandle)
            //            {
            //                // gridView_dev.SetRowCellValue(HitInfo.RowHandle, "需要接受值列的FieldName",从窗体获取到的值);
            //                //使用SetRowCellValue会触发gViewActPara_CellValueChanged事件
            //                this.gridView_dev.SetRowCellValue(i, "SELECTION", "0");
            //            }
            //            else if (i == this.gridView_dev.FocusedRowHandle)
            //            {
            //                this.gridView_dev.SetRowCellValue(i, "SELECTION", "1");
            //            }
            //        }
            //        else
            //        {
            //            if ((i != this.gridView_dev.FocusedRowHandle)
            //               && (focuse_dev == rownum_dev))
            //            {
            //                // gridView_dev.SetRowCellValue(HitInfo.RowHandle, "需要接受值列的FieldName",从窗体获取到的值);
            //                //使用SetRowCellValue会触发gViewActPara_CellValueChanged事件
            //                this.gridView_dev.SetRowCellValue(i, "SELECTION", "0");
            //            }

            //            if (i == this.gridView_dev.FocusedRowHandle)
            //            {
            //                if (this.gridView_dev.GetRowCellValue(i, "SELECTION").ToString() == "1")
            //                {
            //                    this.gridView_dev.SetRowCellValue(i, "SELECTION", "0");
            //                }
            //                else if (this.gridView_dev.GetRowCellValue(i, "SELECTION").ToString() == "0")
            //                {
            //                    this.gridView_dev.SetRowCellValue(i, "SELECTION", "1");
            //                }
            //            }

            //        }
            //    }
            //}
        }

        //20230227 zheng add by 用于炉次焦点转换时，根据炉次的精炼路径带出 精炼设备
        private void gridView_pono_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            //控件赋空值
            formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR1_DEV_CODE", "");
            formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR2_DEV_CODE", "");
            formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR3_DEV_CODE", "");
            formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR4_DEV_CODE", "");


            if (gridView_pono.RowCount == 0)
            {
                return;
            }

            string refine_div = "";
            refine_div = this.gridView_pono.GetFocusedDataRow()["REFINE_ROUTE_CODE"].ToString().Trim();


            //目前按4重精炼
            if (refine_div.Length == 1)
            {
                formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR1_DEV_CODE", refine_div.Substring(0, 1).ToString() + "1");
                if (factory_div == "12" && refine_div.Substring(0, 1).ToString()=="L")
                {
                    formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR1_DEV_CODE", refine_div.Substring(0, 1).ToString() + "3");
                }
                else if (factory_div == "12" && refine_div.Substring(0, 1).ToString() == "V")
                {
                    formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR1_DEV_CODE", refine_div.Substring(0, 1).ToString() + "2");
                }

                //(formConfigHelper.GetControl(layoutControlGroup4, "SR1_DEV_CODE") as EF.EFDevLookUpEdit).ItemIndex = 0;
            }
            else if (refine_div.Length == 2)
            {
                formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR1_DEV_CODE", refine_div.Substring(0, 1).ToString() + "1");
                formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR2_DEV_CODE", refine_div.Substring(1, 1).ToString() + "1");

                if (factory_div=="12")
                {
                    formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR1_DEV_CODE", refine_div.Substring(0, 1).ToString() + "3");
                    formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR2_DEV_CODE", refine_div.Substring(1, 1).ToString() + "2");
                }
                //(formConfigHelper.GetControl(layoutControlGroup4, "SR1_DEV_CODE") as EF.EFDevLookUpEdit).ItemIndex = 0;
                //(formConfigHelper.GetControl(layoutControlGroup4, "SR2_DEV_CODE") as EF.EFDevLookUpEdit).ItemIndex = 0;

            }
            else if (refine_div.Length == 3)
            {
                formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR1_DEV_CODE", refine_div.Substring(0, 1).ToString() + "1");
                formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR2_DEV_CODE", refine_div.Substring(1, 1).ToString() + "1");
                formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR3_DEV_CODE", refine_div.Substring(2, 1).ToString() + "1");
            }
            else if (refine_div.Length == 4)
            {
                formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR1_DEV_CODE", refine_div.Substring(0, 1).ToString() + "1");
                formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR2_DEV_CODE", refine_div.Substring(1, 1).ToString() + "1");
                formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR3_DEV_CODE", refine_div.Substring(2, 1).ToString() + "1");
                formConfigHelper.SetControlEditValue("LayoutGroupFilter", "SR4_DEV_CODE", refine_div.Substring(3, 1).ToString() + "1");
            }

        }


        //获取铸机默认设备
        private void gridView_main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (i_show_change == 0)
            {
                return;
            }

            string cc_mach_no = "";
            cc_mach_no = this.gridView_main.GetFocusedDataRow()["CC_MACH_NO"].ToString().Trim();
            query_pono(cc_mach_no);

            formConfigHelper.SetControlEditValue("LayoutGroupFilter", "CC_MACH_NO", "C" + cc_mach_no);
          
        }

        //修改铸机默认设备
        private void grid_EFCGridDev_CellValueChanged(object sender, EFX.EFCGridImp.EFCGridEventArgs.EFCGridDevCellValueChangedEevntArgs e)
        {
            try
            {
                if (e.ColumnInfo.ItemEname == "BOF_NO")
                {
                    //需要先判断是否有双联设备
                    

                    var lookupEdit = efDevGrid_dev.RepositoryItems["BOF_NO"] as RepositoryItemLookUpEdit;
                    var lookupEdit1 = efDevGrid_dev.RepositoryItems["DP_BOF_NO"] as RepositoryItemLookUpEdit;
                    //var lookupEdit1 = efDevGrid_dev.RepositoryItems["DP_BOF_NO"] as RepositoryItemLookUpEdit;
                    var vhn = EFX.EFCGrid.GetEFCGridBase(this.efDevGrid_dev).GetGridCellValue(0, "BOF_NO").ToString();
                    //string bof_dev = lookupEdit.GetDataSourceValue("BOF_NO",0).ToString();
                    var rowView = lookupEdit.GetDataSourceRowByKeyValue(vhn) as DataRowView;
                    var rowView1 = lookupEdit1.GetDataSourceRowByKeyValue(vhn) as DataRowView;
                    var row = rowView.Row;
                   // var row1 = rowView1.Row;


                    if (rowView1!=null)
                    {
                        EFX.EFCGrid.GetEFCGridBase(efDevGrid_dev).SetGridCellValue(0, "DP_BOF_NO", row["CODE"]);
                    }
                    else
                    {
                        EFX.EFCGrid.GetEFCGridBase(efDevGrid_dev).SetGridCellValue(0, "DP_BOF_NO", " ");
                    }

                }


                EI.EIInfo inBlock_dev = new EI.EIInfo();

                string dp_bof_no = EFX.EFCGrid.GetEFCGridBase(efDevGrid_dev).GetGridCellValue(0, "DP_BOF_NO").ToString();
                string bof_no = EFX.EFCGrid.GetEFCGridBase(efDevGrid_dev).GetGridCellValue(0, "BOF_NO").ToString();
                string sr1_dev_code = EFX.EFCGrid.GetEFCGridBase(efDevGrid_dev).GetGridCellValue(0, "SR1_DEV_CODE").ToString();
                string sr2_dev_code = EFX.EFCGrid.GetEFCGridBase(efDevGrid_dev).GetGridCellValue(0, "SR2_DEV_CODE").ToString();
                string sr3_dev_code = EFX.EFCGrid.GetEFCGridBase(efDevGrid_dev).GetGridCellValue(0, "SR3_DEV_CODE").ToString();
                string sr4_dev_code = EFX.EFCGrid.GetEFCGridBase(efDevGrid_dev).GetGridCellValue(0, "SR4_DEV_CODE").ToString();
                string v_cc_mach_no = EFX.EFCGrid.GetEFCGridBase(efDevGrid_dev).GetGridCellValue(0, "CC_MACH_NO").ToString();

                inBlock_dev = EF.Utility.GetSingleGridValue(this.efDevGrid_dev);
                inBlock_dev.Tables[0].Rows.Clear();
                inBlock_dev.Tables[0].Rows.Add(dp_bof_no, bof_no, sr1_dev_code, sr2_dev_code, sr3_dev_code, sr4_dev_code, v_cc_mach_no);

                EFX.EFCGrid.GetEFCGridBase(efDevGrid_dev).ClearGridData();
                EF.Utility.SetSingleGridValue(efDevGrid_dev, inBlock_dev, 0);

                //列名：e.ColumnInfo.ItemEname;
                //if (e.ColumnInfo.ItemEname == "DP_BOF_NO")
                //{
                //string dp_bof_no = EFX.EFCGrid.GetEFCGridBase(efDevGrid_dev).GetGridCellValue(0, "DP_BOF_NO").ToString();
                ////根据hold_cause_code 查找封锁原因注释
                //EI.EIInfo outInfo = EF.Utility.ExecQuery("select code_desc_1_content as hold_remark from tep0002 where code_class='M01Q' and CODE='" + hold_cause_code + "'");
                //if (outInfo.sys_info.flag == 0)
                //{
                //    EFX.EFCGrid.GetEFCGridBase(this.efDevGrid1).SetGridValue(outInfo);
                //}
                //}
            }
            catch (Exception ex)
            {
                this.efStatusBar1.Text = ex.Message;
            }

        }
        
        
        #endregion


        #region 自定义函数
        /// <summary>
        /// 炼钢出钢计划查询
        /// <para>出钢计划。</para>
        /// </summary>
        /// 获取TPSSM26表铸机设备对照关系
        private void queryinit()
        {
            //查询条件
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            i_show_change = 0;

            try
            {
                //查询条件项
                inBlock.Tables[0].Columns.Add("FACTORY_DIV"); //炼钢单元号

                DataRow row = inBlock.Tables[0].Rows.Add();
                row["FACTORY_DIV"] = factory_div;

                //调用后台
                string str_sql = "SELECT * FROM TPSSM26 WHERE FACTORY_DIV = '" + factory_div + "' ORDER BY CC_MACH_NO ASC";
                //outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm11add_init", inBlock);
                inBlock_Tpssm26 = EF.Utility.ExecQueryPart(v_curr_part_name, str_sql);
                //outBlock = EF.Utility.ExecQueryPart("BSPES", str_sql);
                s = inBlock_Tpssm26.GetSys();
                if (s.flag < 0)
                {
                    this.efStatusBar1.Text = s.msg;
                    return;
                }
                else
                {
                    //将信息压入指定的GRID
                    //EF.Utility.SetCustomGridValue(this.efDevGrid_dev, outBlock);
                    this.gridView_dev.BestFitColumns();
                    i_show_change = 1;
                }
                if (inBlock_Tpssm26.Tables[0].Rows.Count <= 0)
                {
                    this.efStatusBar1.Text = "分区" + v_curr_part_name + "连铸公共条件表无记录";
                }

            }
            catch (Exception ex)
            {
                this.efStatusBar1.Text = ex.Message;
            }

        }
        private void query()
        {
            //查询条件
            EI.EIInfo inBlock = new EI.EIInfo();
            i_show_change = 0;
            try
            {
                inBlock.Tables.Clear();
                DataTable dt = inBlock.Tables.Add();
                dt.Columns.Add("CC_MACH_NO", typeof(String));  //铸机号
                dt.Columns.Add("TOTAL_NUM", typeof(String));  //可编计划数
                dt.Columns.Add("PONO_NUM", typeof(String));  //编入计划数
                dt.Columns.Add("CAST_SHOW", typeof(String));  //当前CAST号
                if (inBlock_Tpssm26.Tables[0].Rows.Count <= 0)
                {
                    this.efStatusBar1.Text = "分区" + v_curr_part_name + "厂别" + factory_div + "连铸公共条件表无记录";
                    return;
                }
                for (int n = 0; n < inBlock_Tpssm26.Tables[0].Rows.Count; n++)
                {
                    DataRow dt_row = dt.Rows.Add();
                    dt_row["CC_MACH_NO"] = inBlock_Tpssm26.Tables[0].Rows[n]["CC_MACH_NO"];
                    dt_row["CAST_SHOW"] = inBlock_Tpssm26.Tables[0].Rows[n]["CAST_NO"].ToString()
                                        + "-" + inBlock_Tpssm26.Tables[0].Rows[n]["CAST_DIV_NO"].ToString();
                    int[] num = query_plan_num(inBlock_All, dt_row["CC_MACH_NO"].ToString());

                    dt_row["TOTAL_NUM"] = num[0];
                    dt_row["PONO_NUM"] = num[1];

                }

                //EF.Utility.SetCustomGridValue(this.efDevGrid_main, inBlock);
                this.formConfigHelper.MergeDataToGrid(inBlock.Tables[0], efDevGrid_main);
                this.gridView_main.BestFitColumns();
                i_show_change = 1;

            }
            catch (Exception err)
            {
                this.efStatusBar1.Text = err.Message;
            }

        }
        //设置设备区默认值
        private void query_pono(string cc_mach_no)
        {
            //查询条件
            EI.EIInfo inBlock_PonoShow = new EI.EIInfo();
            //EI.EIInfo outBlock_2;
            i_show_change = 0;
            try
            {
                inBlock_PonoShow.Tables[0].Merge(inBlock_All.Tables["PONO"]);




                for (int row = inBlock_PonoShow.Tables[0].Rows.Count - 1; row >= 0; row--)
                {
                    DataRow dr = inBlock_PonoShow.Tables[0].Rows[row];
                    if (dr["cc_mach_no"].ToString() != cc_mach_no.Trim()) inBlock_PonoShow.Tables[0].Rows.RemoveAt(row);
                }
                //将信息压入指定的GRID
                //EF.Utility.SetCustomGridValue(this.efDevGrid_pono, inBlock_PonoShow);
                this.formConfigHelper.MergeDataToGrid(inBlock_PonoShow.Tables[0], efDevGrid_pono);
                this.gridView_pono.BestFitColumns();
                i_show_change = 1;


                //设置默认设备
                string default_dp = "";
                string default_bof = "";
                string default_eaf = "";
                string default_sr = "";
                string default_sr1 = "";
                string default_sr2 = "";
                string default_sr3 = "";
                string default_sr4 = "";
                //string cc_mach_no_26 =  this.gridView_main.GetFocusedDataRow()["CC_MACH_NO"].ToString().Trim();
                string cc_mach_no_26 = "";
                string cc_dev_no_26 = "";
                string sr_dev = "";
                EI.EIInfo inBlock_defaule_dev = new EI.EIInfo();
                //inBlock_defaule_dev = EF.Utility.GetSingleGridValue(this.efDevGrid_dev);

                //加载查询条件Layout里面的值
                DataTable dt = formConfigHelper.GetAllControlEditValue("LayoutGroupFilter");
                inBlock_defaule_dev.Tables[0].Merge(dt);

                for (int t_26 = 0; t_26 < inBlock_Tpssm26.Tables[0].Rows.Count; t_26++)
                {
                    default_dp = inBlock_Tpssm26.Tables[0].Rows[t_26]["DP_BOF_NO"].ToString();
                    default_bof = inBlock_Tpssm26.Tables[0].Rows[t_26]["BOF_NO"].ToString();
                    default_eaf = inBlock_Tpssm26.Tables[0].Rows[t_26]["EAF_NO"].ToString();
                    default_sr = inBlock_Tpssm26.Tables[0].Rows[t_26]["DEFAULT_SR_DEV"].ToString();
                    default_sr1 = default_sr.Trim().Length >= 2 ? default_sr.Substring(0, 2) : default_sr;
                    default_sr2 = default_sr.Trim().Length >= 4 ? default_sr.Substring(2, 2) : " ";
                    default_sr3 = default_sr.Trim().Length >= 6 ? default_sr.Substring(4, 2) : " ";
                    default_sr4 = default_sr.Trim().Length >= 8 ? default_sr.Substring(6, 2) : " ";
                    cc_mach_no_26 = inBlock_Tpssm26.Tables[0].Rows[t_26]["CC_MACH_NO"].ToString();//铸机号
                    cc_dev_no_26 = inBlock_Tpssm26.Tables[0].Rows[t_26]["DEV_CODE"].ToString();//用设备代码比较
                    if (cc_mach_no.Trim() == cc_mach_no_26.Trim())
                    {
                        //inBlock_defaule_dev.Tables[0].Rows.Clear();
                        //inBlock_defaule_dev.Tables[0].Rows.Add(default_dp, default_bof, default_sr1, default_sr2, default_sr3, default_sr4, cc_dev_no_26);
                        ////EFX.EFCGrid.SetSingleGridValue(efDevGrid_dev, inBlock_defaule_dev.Tables[0], 0);
                        //EFX.EFCGrid.GetEFCGridBase(efDevGrid_dev).ClearGridData();
                        //EF.Utility.SetSingleGridValue(efDevGrid_dev, inBlock_defaule_dev, 0);

                        //this.gridView_dev.RefreshData();
                        //this.gridView_dev.SetFocusedRowCellValue("DP_BOF_NO", default_dp);
                        //this.gridView_dev.SetFocusedRowCellValue("BOF_NO", default_bof);
                        //this.gridView_dev.SetFocusedRowCellValue("SR1_DEV_CODE", default_sr.Trim().Length >= 2 ? default_sr.Substring(0, 2) : default_sr);
                        //this.gridView_dev.SetFocusedRowCellValue("SR2_DEV_CODE", default_sr.Trim().Length >= 4 ? default_sr.Substring(2, 2) : " ");
                        //this.gridView_dev.SetFocusedRowCellValue("SR3_DEV_CODE", default_sr.Trim().Length >= 6 ? default_sr.Substring(4, 2) : " ");
                        //this.gridView_dev.SetFocusedRowCellValue("SR4_DEV_CODE", default_sr.Trim().Length >= 8 ? default_sr.Substring(6, 2) : " ");
                        //this.gridView_dev.SetFocusedRowCellValue("CC_MACH_NO", cc_dev_no_26);
                        //this.gridView_dev.SetRowCellValue(0, "BOF_NO", default_bof);
                        //this.gridView_dev.RefreshData();
                        //gridView_dev.Columns["DP_BOF_NO"].d
                        //this.gridView_dev.SetRowCellValue();
                        //this.gridView_dev.GetDataRow(0).                        //this.gridView_dev.RefreshData();
                        break;
                    }


                }




            }
            catch (Exception err)
            {
                this.efStatusBar1.Text = err.Message;
            }

        }
        //获取铸机计划数
        private int[] query_plan_num(EI.EIInfo inBlock, string cc_mach_no)
        {
            //获取铸机计划数
            try
            {
                int[] numbers = new int[2] { 0, 0 };
                int plan_num = 0;
                int pono_num = 0;
                for (int row = 0; row < inBlock.Tables["PLAN"].Rows.Count; row++)
                {
                    if (inBlock.Tables["PLAN"].Rows[row]["CC_MACH_NO"].ToString().Trim() == cc_mach_no.Trim()) plan_num++;
                }
                for (int row = 0; row < inBlock.Tables["PONO"].Rows.Count; row++)
                {
                    if (inBlock.Tables["PONO"].Rows[row]["CC_MACH_NO"].ToString().Trim() == cc_mach_no.Trim()) pono_num++;
                }
                numbers[0] = pono_num;
                numbers[1] = plan_num;
                return numbers;
            }
            catch (Exception ex)
            {
                this.efStatusBar1.Text = ex.Message;
                int[] numbers = new int[2] { 0, 0 };
                return numbers;
            }
        }
        //计划新增
        private void add_pono(EI.EIInfo inBlock)
        {
            try
            {
                EI.EIInfo inBlock_Plan = new EI.EIInfo();
                EI.EIInfo inBlock_dev = new EI.EIInfo();


                inBlock_dev.Tables.Clear();
                //inBlock_dev = EF.Utility.GetSingleGridValue(this.efDevGrid_dev);
                //inBlock_dev.Tables.Add(EF.Utility.GetSingleGridValue(efDevGrid_dev).Tables[0].Copy());

                //获取设备代码记录 20230109
                DataTable dt = formConfigHelper.GetAllControlEditValue("LayoutGroupFilter");
                inBlock_dev.Tables.Add(dt);



                if (inBlock_dev.Tables[0].Rows[0]["BOF_NO"].ToString().Trim() == "")
                {
                    string str = "请选择需要编入的转炉/电炉设备。";
                    EF.EFMessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.efStatusBar1.Text = str;
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (inBlock_dev.Tables[0].Rows[0]["CC_MACH_NO"].ToString().Trim() == "")
                {
                    string str = "请选择需要编入的连铸/模铸设备。";
                    EF.EFMessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.efStatusBar1.Text = str;
                    this.DialogResult = DialogResult.None;
                    return;
                }

                string i_pono = "";
                string s_pono = "";
                string is_flag = "";
                inBlock_Plan.Tables[0].Merge(inBlock_All.Tables["PONO"]);
                if (!inBlock_All.Tables.Contains("PONO_ADD")) 
                    inBlock_All.Tables.Add("PONO_ADD");

                for (int pono_all = inBlock_Plan.Tables[0].Rows.Count - 1; pono_all >= 0; pono_all--)
                {
                    is_flag = "0";
                    i_pono = inBlock_Plan.Tables[0].Rows[pono_all]["PONO"].ToString();
                    for (int pono_num = 0; pono_num < inBlock.Tables["PONO"].Rows.Count; pono_num++)
                    {
                        s_pono = inBlock.Tables["PONO"].Rows[pono_num]["PONO"].ToString();
                        if (i_pono == s_pono)
                        {
                            is_flag = "1";
                            break;
                        }
                        is_flag = "0";
                    }
                    if (is_flag == "1")
                    {
                        inBlock_All.Tables["PONO"].Rows.RemoveAt(pono_all);
                    }
                    else
                    {
                        inBlock_Plan.Tables[0].Rows.RemoveAt(pono_all);
                    }


                }
                inBlock_All.Tables["PONO_ADD"].Merge(inBlock_Plan.Tables[0]);
                inBlock_Plan.Tables.Add("PLAN");
                inBlock_Plan.Tables["PLAN"].Merge(inBlock_All.Tables["PLAN"].Clone());
                inBlock_Plan.Tables["PLAN"].Merge(inBlock_Plan.Tables[0]);
                inBlock_Plan.Tables.Add("SUB");
                inBlock_Plan.Tables["SUB"].Merge(inBlock_All.Tables["SUB"].Clone());

                string dp_bof_no = inBlock_dev.Tables[0].Rows[0]["DP_BOF_NO"].ToString().Trim() == "" ? "  " : inBlock_dev.Tables[0].Rows[0]["DP_BOF_NO"].ToString().Trim();
                string bof_no = inBlock_dev.Tables[0].Rows[0]["BOF_NO"].ToString().Trim() == "" ? "  " : inBlock_dev.Tables[0].Rows[0]["BOF_NO"].ToString().Trim();
                string sr1_dev_code = inBlock_dev.Tables[0].Rows[0]["SR1_DEV_CODE"].ToString().Trim() == "" ? "  " : inBlock_dev.Tables[0].Rows[0]["SR1_DEV_CODE"].ToString().Trim();
                string sr2_dev_code = inBlock_dev.Tables[0].Rows[0]["SR2_DEV_CODE"].ToString().Trim() == "" ? "  " : inBlock_dev.Tables[0].Rows[0]["SR2_DEV_CODE"].ToString().Trim();
                string sr3_dev_code = inBlock_dev.Tables[0].Rows[0]["SR3_DEV_CODE"].ToString().Trim() == "" ? "  " : inBlock_dev.Tables[0].Rows[0]["SR3_DEV_CODE"].ToString().Trim();
                string sr4_dev_code = inBlock_dev.Tables[0].Rows[0]["SR4_DEV_CODE"].ToString().Trim() == "" ? "  " : inBlock_dev.Tables[0].Rows[0]["SR4_DEV_CODE"].ToString().Trim();
                string cc_mach_no = inBlock_dev.Tables[0].Rows[0]["CC_MACH_NO"].ToString().Trim();

                string p_st_no = "";
                //string proc_time_bof = "";
                //string proc_time_sr1 = "";
                //string proc_time_sr2 = "";
                //string proc_time_sr3 = "";
                //string proc_time_sr4 = "";
                //string proc_time_cc = "";

                string sr1_dev_act = "";
                string sr2_dev_act = "";
                string sr3_dev_act = "";
                string sr4_dev_act = "";
                string sr_route = "";


                inBlock_para.Tables[0].Rows.Clear();
                inBlock_para.Tables[0].Columns.Clear();

                inBlock_para.Tables[0].Columns.Add("ST_NO", typeof(String));
                inBlock_para.Tables[0].Columns.Add("DEV_CODE", typeof(String));

                for (int row = 0; row < inBlock_Plan.Tables["PLAN"].Rows.Count; row++)
                {
                    sr_route = inBlock_Plan.Tables["PLAN"].Rows[row]["REFINE_ROUTE_CODE"].ToString().Trim();

                    DataRow plan_row = inBlock_Plan.Tables["PLAN"].Rows[row];
                    //plan_row["REFINE_ROUTE_CODE"] = sr1_dev_code.Trim() + sr2_dev_code.Trim() + sr3_dev_code.Trim() + sr4_dev_code.Trim();
                    plan_row["CURR_WP_NO"] = "0";
                    plan_row["PLAN_EDIT_FLAG"] = "N";
                    plan_row["FACTORY_DIV"] = factory_div;
                    plan_row["PONO_STATUS"] = "18";
                    p_st_no = plan_row["ST_NO"].ToString().Trim();

                    int i_charge_no = 1;
                    if (dp_bof_no.Trim() == "" && plan_row["SMELT_MODE"].ToString() == "2")
                    {
                    //    string str = "编入制造命令[" + plan_row["PONO"].ToString()+"]是双联模式，未找到默认设备号，请检查设备配置！";
                    //    EF.EFMessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    this.efStatusBar1.Text = str;
                    //    this.DialogResult = DialogResult.None;
                    //    return;
                        dp_bof_no = bof_no;
                    }
                    if (dp_bof_no.Trim() != "" && plan_row["SMELT_MODE"].ToString() == "2")
                    {
                        DataRow sub_plan_row = inBlock_Plan.Tables["SUB"].Rows.Add();
                        sub_plan_row["FACTORY_DIV"] = plan_row["FACTORY_DIV"];
                        sub_plan_row["PONO"] = plan_row["PONO"];
                        sub_plan_row["CHARGE_NO"] = i_charge_no++;
                        sub_plan_row["SUB_CHARGE_NO"] = "0";
                        sub_plan_row["DEV_CODE"] = dp_bof_no;
                        sub_plan_row["AREA_ID"] = "2";
                        inBlock_para.Tables[0].Rows.Clear();
                        inBlock_para.Tables[0].Rows.Add(p_st_no, dp_bof_no);
                        //sub_plan_row["PROC_TIME"] = GetDealTime(p_st_no, dp_bof_no, "PROC_TIME");
                        sub_plan_row["PROC_TIME"] = PSUtils.GetDealTime(inBlock_All, "PROC_TIME", "PROC_TIME", inBlock_para);
                    }
                    if (bof_no.Trim() != "")
                    {
                        DataRow sub_plan_row = inBlock_Plan.Tables["SUB"].Rows.Add();
                        sub_plan_row["FACTORY_DIV"] = plan_row["FACTORY_DIV"];
                        sub_plan_row["PONO"] = plan_row["PONO"];
                        sub_plan_row["CHARGE_NO"] = i_charge_no++;
                        sub_plan_row["SUB_CHARGE_NO"] = "0";
                        sub_plan_row["DEV_CODE"] = bof_no;
                        sub_plan_row["AREA_ID"] = "3";
                        //sub_plan_row["PROC_TIME"] = GetDealTime(p_st_no, bof_no, "PROC_TIME");

                        inBlock_para.Tables[0].Rows.Clear();
                        inBlock_para.Tables[0].Rows.Add(p_st_no, bof_no);
                        sub_plan_row["PROC_TIME"] = PSUtils.GetDealTime(inBlock_All, "PROC_TIME", "PROC_TIME", inBlock_para);
                    }
                    string[] sr_dev_act = ",,,,,".Split(',');
                    for (int r = 1; r <= sr_route.Length; r++)
                    {
                        if (sr_route.Substring(r - 1, 1) == sr1_dev_code.Substring(0, 1))
                        {
                            sr_dev_act[r - 1] = sr1_dev_code;
                            continue;
                        }
                        else if (sr_route.Substring(r - 1, 1) == sr2_dev_code.Substring(0, 1))
                        {
                            sr_dev_act[r - 1] = sr2_dev_code;
                            continue;
                        }
                        else if (sr_route.Substring(r - 1, 1) == sr3_dev_code.Substring(0, 1))
                        {
                            sr_dev_act[r - 1] = sr3_dev_code;
                            continue;
                        }
                        else if (sr_route.Substring(r - 1, 1) == sr4_dev_code.Substring(0, 1))
                        {
                            sr_dev_act[r - 1] = sr4_dev_code;
                            continue;
                        }
                        else
                        {
                            //三钢如果不根据精炼路径取  后续可注释
                            //从设备表取
                            for (int dr = 0; dr < inBlock_All.Tables["DEV"].Rows.Count; dr++)
                            {
                                DataRow dev_row = inBlock_All.Tables["DEV"].Rows[dr];
                                if (sr_route.Substring(r - 1, 1) == dev_row["DEV_CODE"].ToString().Substring(0, 1)
                                    && dev_row["CLASS_ID"].ToString() == "4")
                                {
                                    sr_dev_act[r - 1] = dev_row["DEV_CODE"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < sr_dev_act.Length; i++)
                    {
                        if (sr_dev_act[i].Trim() != "")
                        {
                            DataRow sub_plan_row = inBlock_Plan.Tables["SUB"].Rows.Add();
                            sub_plan_row["FACTORY_DIV"] = plan_row["FACTORY_DIV"];
                            sub_plan_row["PONO"] = plan_row["PONO"];
                            sub_plan_row["CHARGE_NO"] = i_charge_no++;
                            sub_plan_row["SUB_CHARGE_NO"] = "0";
                            sub_plan_row["DEV_CODE"] = sr_dev_act[i];
                            sub_plan_row["AREA_ID"] = "4";
                            //sub_plan_row["PROC_TIME"] = GetDealTime(p_st_no, sr_dev_act[i], "PROC_TIME");

                            inBlock_para.Tables[0].Rows.Clear();
                            inBlock_para.Tables[0].Rows.Add(p_st_no, sr_dev_act[i]);
                            sub_plan_row["PROC_TIME"] = PSUtils.GetDealTime(inBlock_All, "PROC_TIME", "PROC_TIME", inBlock_para);
                        }
                    }
                    //if (sr1_dev_code.Trim() != "")
                    //{
                    //    DataRow sub_plan_row = inBlock_Plan.Tables["SUB"].Rows.Add();
                    //    sub_plan_row["FACTORY_DIV"] = plan_row["FACTORY_DIV"];
                    //    sub_plan_row["PONO"] = plan_row["PONO"];
                    //    sub_plan_row["CHARGE_NO"] = i_charge_no++;
                    //    sub_plan_row["SUB_CHARGE_NO"] = "0";
                    //    sub_plan_row["DEV_CODE"] = sr1_dev_code;
                    //    sub_plan_row["AREA_ID"] = "4";
                    //    sub_plan_row["PROC_TIME"] = GetDealTime(p_st_no, sr1_dev_code, "PROC_TIME");
                    //}
                    //if (sr2_dev_code.Trim() != "")
                    //{
                    //    DataRow sub_plan_row = inBlock_Plan.Tables["SUB"].Rows.Add();
                    //    sub_plan_row["FACTORY_DIV"] = plan_row["FACTORY_DIV"];
                    //    sub_plan_row["PONO"] = plan_row["PONO"];
                    //    sub_plan_row["CHARGE_NO"] = i_charge_no++;
                    //    sub_plan_row["SUB_CHARGE_NO"] = "0";
                    //    sub_plan_row["DEV_CODE"] = sr2_dev_code;
                    //    sub_plan_row["AREA_ID"] = "4";
                    //    sub_plan_row["PROC_TIME"] = GetDealTime(p_st_no, sr2_dev_code, "PROC_TIME");
                    //}
                    //if (sr3_dev_code.Trim() != "")
                    //{
                    //    DataRow sub_plan_row = inBlock_Plan.Tables["SUB"].Rows.Add();
                    //    sub_plan_row["FACTORY_DIV"] = plan_row["FACTORY_DIV"];
                    //    sub_plan_row["PONO"] = plan_row["PONO"];
                    //    sub_plan_row["CHARGE_NO"] = i_charge_no++;
                    //    sub_plan_row["SUB_CHARGE_NO"] = "0";
                    //    sub_plan_row["DEV_CODE"] = sr3_dev_code;
                    //    sub_plan_row["AREA_ID"] = "4";
                    //    sub_plan_row["PROC_TIME"] = GetDealTime(p_st_no, sr3_dev_code, "PROC_TIME");
                    //}
                    //if (sr4_dev_code.Trim() != "")
                    //{
                    //    DataRow sub_plan_row = inBlock_Plan.Tables["SUB"].Rows.Add();
                    //    sub_plan_row["FACTORY_DIV"] = plan_row["FACTORY_DIV"];
                    //    sub_plan_row["PONO"] = plan_row["PONO"];
                    //    sub_plan_row["CHARGE_NO"] = i_charge_no++;
                    //    sub_plan_row["SUB_CHARGE_NO"] = "0";
                    //    sub_plan_row["DEV_CODE"] = sr4_dev_code;
                    //    sub_plan_row["AREA_ID"] = "4";
                    //    sub_plan_row["PROC_TIME"] = GetDealTime(p_st_no, sr4_dev_code, "PROC_TIME");
                    //}
                    if (cc_mach_no.Trim() != "")
                    {
                        inBlock_para.Tables[0].Rows.Clear();
                        inBlock_para.Tables[0].Columns.Clear();

                        inBlock_para.Tables[0].Columns.Add("PONO", typeof(String));
                       

                        DataRow sub_plan_row = inBlock_Plan.Tables["SUB"].Rows.Add();
                        sub_plan_row["FACTORY_DIV"] = plan_row["FACTORY_DIV"];
                        sub_plan_row["PONO"] = plan_row["PONO"];
                        sub_plan_row["CHARGE_NO"] = i_charge_no++;
                        sub_plan_row["SUB_CHARGE_NO"] = "0";
                        sub_plan_row["DEV_CODE"] = cc_mach_no;
                        sub_plan_row["AREA_ID"] = "5";
                        //sub_plan_row["PROC_TIME"] = GetDealTime(p_st_no, cc_mach_no, "PONO_ADD");  //从PONO取处理时间

                        inBlock_para.Tables[0].Rows.Clear();
                        inBlock_para.Tables[0].Rows.Add(plan_row["PONO"].ToString());
                        sub_plan_row["PROC_TIME"] = PSUtils.GetDealTime(inBlock_All, "PONO_ADD", "POUR_TIME", inBlock_para);


                        inBlock_para.Tables[0].Rows.Clear();
                        inBlock_para.Tables[0].Columns.Clear();
                        inBlock_para.Tables[0].Columns.Add("ST_NO", typeof(String));
                        inBlock_para.Tables[0].Columns.Add("DEV_CODE", typeof(String));
                    }

                }


                string cc_time = ((DateTime)efDevDateEdit_CC.EditValue).ToString("yyyyMMddHHmmss");
                string p_pono = inBlock_Plan.Tables["PLAN"].Rows[0]["PONO"].ToString();
               // if(restrand_flg)

                Dictionary<String, String> paras_cal = new Dictionary<String, String>();
                if (cc_mach_no.Trim() != "") paras_cal.Add("CC_MACH_NO", cc_mach_no);
                if (bof_no.Trim() != "") paras_cal.Add("BOF_NO", bof_no);
                if (p_pono.Trim() != "") paras_cal.Add("PONO", p_pono);
                if (cc_time.Trim() != "") paras_cal.Add("CC_REQ_TIME", cc_time);
                paras_cal.Add("CAL_TYPE", "1");
                paras_cal.Add("CAL_CAST", "1");//若要根据浇次第一炉开浇时间顺序计算，则传此参数
               
                


                //inBlock_Plan = plan_time_cal(inBlock_Plan, cc_time);
                inBlock_All.Tables["PLAN"].Merge(inBlock_Plan.Tables["PLAN"]);
                inBlock_All.Tables["SUB"].Merge(inBlock_Plan.Tables["SUB"]);
                //先压后计算，要给出截止PONO
                if (time_div.Trim() == "1")
                {
                    PSUtils.plan_time_cal(inBlock_All, paras_cal);
                }
                else
                {
                    PSUtils.plan_time_cal_bof(inBlock_All, paras_cal);
                }
            }
            catch (Exception ex)
            {
                this.efStatusBar1.Text = "系统出现异常，请联系系统维护人员。 " + ex.Message;
                return;
            }
        }
       
        #endregion

    }
}
