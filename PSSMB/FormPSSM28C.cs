using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EF;
using System.Runtime.InteropServices;
using System.Collections;
using System.Globalization;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

using DevExpress.XtraLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;




namespace PS
{
    public partial class FormPSSM28C : EF.EFFormBase // Form
    {
        #region 全局变量设置
        private int i_CurrentPage = 0;      //当前页
        private int i_TotalPageCount = 0;   //总页数
        private string i_service = "";   //后台程序名
        private string i_factory_div = ""; //厂别区分
        private string i_plan_date = ""; //计划日期
        private string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。
        private bool canDragPono = false;
        ToolTipControlInfo info = null;
        private int i_key_num = 0;
        private string para_FACTORY_DIV = "";
        private string para_CC_MACH_NO_1 = "";
        private string para_CAST_LOT_NO = "";
        private string para_PLAN_DATE = "";
        private string v_cast_lot_no = "";
        private string v_cast_no = "";
        private string v_cast_no_before = ""; 
        private string v_cast_no_after = "";

        public EI.EIInfo inBlock_cast = new EI.EIInfo();
        public EI.EIInfo inBlock_All = new EI.EIInfo();
        private string colname;
        private string factory_div;
        private string cc_mach_no;
        private string pono;
        private string bof_no;
        private string sm_plan_no;
        private string refine_route_code;
        private string device_code;
        private string device_name;
        private string service_name_inq;
        public int mov_flag = 0;
        private string i_func_id = "PSSM28C_CAST";
        #endregion

        public FormPSSM28C()
        {
            InitializeComponent();
        }

        #region 窗体加载
        private void FormPSSM28C_Load(object sender, EventArgs e)
        {
            try
            {
                #region 提取参数
                Dictionary<String, String> paras = (Dictionary<String, String>)EF.EF_Args.common_object_1;
                v_curr_part_name = paras.ContainsKey("V_CURR_PART_NAME") ? paras["V_CURR_PART_NAME"] : "BSMES";
                colname = paras.ContainsKey("COLNAME") ? paras["COLNAME"] : "";//switch条件
                factory_div = paras.ContainsKey("FACTORY_DIV") ? paras["FACTORY_DIV"] : "";
                cc_mach_no = paras.ContainsKey("CC_MACH_NO") ? paras["CC_MACH_NO"] : "";
                pono = paras.ContainsKey("PONO") ? paras["PONO"] : "";
                sm_plan_no = paras.ContainsKey("SM_PLAN_NO") ? paras["SM_PLAN_NO"] : "";
                bof_no = paras.ContainsKey("BOF_NO") ? paras["BOF_NO"] : "";
                refine_route_code = paras.ContainsKey("REFINE_ROUTE_CODE") ? paras["REFINE_ROUTE_CODE"] : "";


                inBlock_All = (EI.EIInfo)EF.EF_Args.common_object_2;
                #endregion
                string cc_sql = "select DEV_CODE,STATION_NAME from tpssmd1 where area_id = '5' and factory_div = '" + factory_div.Trim() + "'";
                EI.EIInfo outBlock_code = EF.Utility.ExecQueryPart(v_curr_part_name, cc_sql);
                efDevLookUpEdit_CC_MACH_NO_1.Properties.DataSource = outBlock_code.Tables[0];
                efDevLookUpEdit_CC_MACH_NO_1.Properties.DisplayMember = "STATION_NAME";
                efDevLookUpEdit_CC_MACH_NO_1.Properties.ValueMember = "DEV_CODE";
                efDevLookUpEdit_CC_MACH_NO_1.Properties.Columns.Clear();
                efDevLookUpEdit_CC_MACH_NO_1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEV_CODE", "设备号"));
                efDevLookUpEdit_CC_MACH_NO_1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATION_NAME", "设备描述"));
                //if (sm_plan_no.Trim()!="")
                //{
                //    for(int i =0;i<inBlock_All.Tables["SUB"].Rows.Count;i++)
                //    {
                //        DataRow dr_p = inBlock_All.Tables["SUB"].Rows[i];
                //        if(dr_p["SM_PLAN_NO"].ToString()==sm_plan_no
                //            &&dr_p["AREA_ID"].ToString()=="5")
                //        {
                //            cc_mach_no = dr_p["DEV_CODE"].ToString();
                //            break;
                //        }
                //    }
                //}
                //else
                //{
                //    for (int i = 0; i < inBlock_All.Tables["SUB"].Rows.Count; i++)
                //    {
                //        DataRow dr_p = inBlock_All.Tables["SUB"].Rows[i];
                //        if (dr_p["AREA_ID"].ToString() == "5"
                //            && dr_p["DEV_CODE"].ToString().Substring(1, 1) == cc_mach_no)
                //        {
                //            cc_mach_no = dr_p["DEV_CODE"].ToString();
                //            break;
                //        }
                //    }
                //}
                efDevLookUpEdit_CC_MACH_NO_1.EditValue = cc_mach_no;

                EF.Utility.SetGridColumn(new EF.EFDevGrid[] { this.efDevGrid1 }, new string[] { i_func_id }, v_curr_part_name);//多行记录信息。

                ////初始化GRID 的基本设置。
                //GC.PM_utility2.DEV_Init_grid2(efDevGrid1, "1");

                //GRID是只允许单选。
                efDevGrid1.EFMultiSelect = false;

                //单记录模式的信息初始化，采用 EFX.dll中的方法。 

                //设置主信息GROUP的属性
                //GC.PM_utility2.DEV_Init_LayoutGroup(this.layoutControlGroup4);
                p_query();

            
            }
            catch (Exception ex) //引发调用异常
            {
                EF.EFMessageBox.Show(ex.Message, EF.EF_Args.epEname, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

       

       


        #region 查询调用
        private void p_query()
        {//分页模式的查询
            try
            {
                if (inBlock_cast.Tables.Count > 0) inBlock_cast.Tables.Clear();
                inBlock_cast.Tables.Add("PLAN");
                inBlock_cast.Tables["PLAN"].Merge(inBlock_All.Tables["PLAN"].Clone());

                for(int row=0;row<inBlock_All.Tables["PLAN"].Rows.Count;row++)
                {
                    DataRow pr= inBlock_All.Tables["PLAN"].Rows[row];
                    if (pr["CC_MACH_NO"].ToString().Trim() == cc_mach_no.Trim().Substring(1,1)
                        &&Convert.ToInt32(pr["CURR_WP_NO"])<5
                        &&Convert.ToInt32(pr["PONO_STATUS"]) < 83)
                    {
                        inBlock_cast.Tables["PLAN"].ImportRow(pr);
                    }

                   
                }
                inBlock_cast.Tables["PLAN"].Columns.Add("CAST_NO_SHOW", typeof(System.String));
                for (int row = 0; row < inBlock_cast.Tables["PLAN"].Rows.Count; row++)
                {
                    DataRow pr = inBlock_cast.Tables["PLAN"].Rows[row];
                    for (int sub_row = 0; sub_row < inBlock_All.Tables["SUB"].Rows.Count; sub_row++)
                    {
                        DataRow ps = inBlock_All.Tables["SUB"].Rows[sub_row];
                        if (ps["AREA_ID"].ToString().Trim() != "5") continue;
                        if (ps["PONO"].ToString().Trim() == pr["PONO"].ToString().Trim())
                        {
                            pr["CC_REQ_TIME"] = ps["START_TIME"].ToString();
                        }
                    }
                    if (pr["RESTRAND_FLG"].ToString().Trim() == "1") pr["RESTRAND_FLG"] = "T";
                    else pr["RESTRAND_FLG"] = " ";
                    pr["CAST_NO_SHOW"] = pr["CAST_NO"].ToString() + "-" + pr["CAST_DIV_NO"];
                }
                

                //将信息压入指定的GRID, 
                EF.Utility.SetCustomGridValue(efDevGrid1, inBlock_cast, false);

              

                this.efDevGrid1.AllowDragRow = true;
                this.gridView1.BestFitColumns();

                //根据功能号，设置可编辑列。
                //GC.PM_utility2.DEV_SetColEdit_multi4(this.efDevGrid1, i_func_id, "2", v_curr_part_name);
                
            }
            catch (Exception ex)
            {
                GC.PM_utility2.Dev_messageBoxError(ex.Message);
            }
        }

        #endregion

            
        #region 自定义方法(获取连铸机号)

        

        private GridHitInfo GetHitInfo(EFDevGrid grid, Point pt)
        {
            GridView view = grid.MainView as GridView;

            return view.CalcHitInfo(pt);
        }
        private GridHitInfo GetHitInfo(EFDevGrid grid, int x, int y)
        {
            GridView view = grid.MainView as GridView;

            return view.CalcHitInfo(grid.PointToClient(new Point(x, y)));
        }

        /// <summary>
        /// 获取单元格
        /// </summary>
        private object GetCellValue(EFDevGrid grid, int row, string colname)
        {
            try
            {
                GridView view = grid.MainView as GridView;
                return view.GetRowCellValue(row, colname);
            }
            catch (System.NullReferenceException ex)
            {
                return null;
            }
        }

        #endregion

    

        #region 事件
        private void efButton_inq_Click(object sender, EventArgs e)
        {
            p_query();
        }
        private void efButton_add_Click(object sender, EventArgs e)
        {
            EI.EIInfo inBlock_grid = new EI.EIInfo();
            EI.EIInfo inBlock_tmp = new EI.EIInfo();
            inBlock_grid.Tables[0].Merge((DataTable)this.efDevGrid1.DataSource);
            inBlock_tmp.Tables[0].Merge(inBlock_All.Tables["PLAN"].Clone());

            inBlock_grid.SetBlkName(1,"CAST_SHOW");
            string c_cast_show = "";
            string c_cast_no = "";
            string c_cast_div_no = "";
            for (int i = 0; i < inBlock_All.Tables["PLAN"].Rows.Count; i++)
            {
                DataRow dr_plan = inBlock_All.Tables["PLAN"].Rows[i];
                for(int n = 0;n<inBlock_grid.Tables[0].Rows.Count;n++)
                {
                    DataRow dr_grid = inBlock_grid.Tables[0].Rows[n];
                    if(dr_plan["PONO"].ToString()==dr_grid["PONO"].ToString()
                        && dr_plan["SM_PLAN_NO"].ToString() == dr_grid["SM_PLAN_NO"].ToString())
                    {
                        dr_plan["RESTRAND_FLG"] = dr_grid["RESTRAND_FLG"].ToString()=="T"? "1":"0";
                        dr_plan["CC_REQ_TIME"] = dr_grid["CC_REQ_TIME"].ToString();
                        c_cast_show = dr_grid["CAST_NO_SHOW"].ToString();
                        c_cast_no = c_cast_show.Substring(0, c_cast_show.IndexOf("-"));
                        c_cast_div_no = c_cast_show.Substring(c_cast_show.IndexOf("-")+1, c_cast_show.Length - c_cast_show.IndexOf("-")-1);
                        dr_plan["CAST_NO"] = c_cast_no;
                        dr_plan["CAST_DIV_NO"] = c_cast_div_no;
                    }
                }
            }

            for (int i = 0; i < inBlock_grid.Tables[0].Rows.Count; i++)
            {
                DataRow dr_plan1 = inBlock_grid.Tables[0].Rows[i];
                for (int n = 0; n < inBlock_All.Tables["SUB"].Rows.Count; n++)
                {
                    DataRow dr_sub = inBlock_All.Tables["SUB"].Rows[n];
                    if (dr_plan1["PONO"].ToString() == dr_sub["PONO"].ToString()
                        && dr_sub["AREA_ID"].ToString()=="5")
                    {
                        string cc_req_time = dr_plan1["CC_REQ_TIME"].ToString();
                        int proc_time = Convert.ToInt32(dr_sub["PROC_TIME"]);
                        DateTime cc_start_time = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(cc_req_time));
                        dr_sub["START_TIME"] = cc_start_time.ToString("yyyyMMddHHmmss");
                        //cc_start_time = cc_start_time.AddMinutes(proc_time);
                        dr_sub["END_TIME"] = (cc_start_time.AddMinutes(proc_time)).ToString("yyyyMMddHHmmss");
                    }
                }

            }

            
            string[] colmn= {"PONO"};
            PSUtils.OrderByRow(inBlock_All,"PLAN",inBlock_grid,"CAST_SHOW",colmn,false);
            PSUtils.OrderByRow(inBlock_All, "SUB", inBlock_grid, "CAST_SHOW",colmn, true);

            this.DialogResult = DialogResult.OK;
            this.Close(); 
        }
        private void efButton_quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); 
        }
        private void efDevGrid1_DragDrop(object sender, DragEventArgs e)
        {
            mov_flag = 1;
           // gridView1.RefreshData();
            
            //EI.EIInfo inBlock_grid = new EI.EIInfo();
            //EI.EIInfo inBlock_tmp = new EI.EIInfo();
            //inBlock_grid.Tables[0].Merge((DataTable)this.efDevGrid1.DataSource);
           
                
            //将信息压入指定的GRID, 
            //EF.Utility.SetCustomGridValue(efDevGrid1, inBlock_grid, false);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //进入事件后，由于以下代码会造成事件重复无限发生，所以先关闭事件，以下代码运行完后重新开启事件
            this.gridView1.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            string v_restrand_flg = gridView1.GetFocusedDataRow()["RESTRAND_FLG"].ToString(); //得到当前焦点行的RESTRAND_FLG值
            string v_pono = gridView1.GetFocusedDataRow()["PONO"].ToString(); 
            if(e.Column.FieldName=="RESTRAND_FLG")
            {
                for(int i = 0;i<inBlock_cast.Tables["PLAN"].Rows.Count;i++)
                {
                    DataRow dr = inBlock_cast.Tables["PLAN"].Rows[i];
                    if (dr["PONO"].ToString() == v_pono) dr["RESTRAND_FLG"] = v_restrand_flg;
                    break;
                }
            }
           // string v_restrand_flg = gridView1.GetFocusedDataRow()["RESTRAND_FLG"].ToString(); //得到当前焦点行的RESTRAND_FLG值
                //if (efDevGrid1.GetSelectedColumnChecked(gridView1.FocusedRowHandle))
                //{
                //    /*遍历所有行，具有相同的cast_lot_no的行全部勾选上*/
                //    for (int i = 0; i < gridView1.RowCount; i++)
                //    {
                //        if (v_cast_lot_no == gridView1.GetDataRow(i)["CAST_LOT_NO"].ToString())
                //        {
                //            efDevGrid1.SetSelectedColumnChecked(i, true);
                //        }
                //    }
                    
                //}
                //else
                //{
                //    /*遍历所有行，具有相同的cast_lot_no的行全部勾选上*/
                //    for (int i = 0; i < gridView1.RowCount; i++)
                //    {
                //        if (v_cast_lot_no == gridView1.GetDataRow(i)["CAST_LOT_NO"].ToString())
                //        {
                //            efDevGrid1.SetSelectedColumnChecked(i, false);
                //        }
                //    }
                //}
           

            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);

        }
        
        #endregion

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (mov_flag == 1)
            {
                EI.EIInfo inBlock_grid = new EI.EIInfo();
                EI.EIInfo inBlock_tmp = new EI.EIInfo();
                inBlock_grid.Tables[0].Merge((DataTable)this.efDevGrid1.DataSource);
                inBlock_tmp.Tables[0].Merge(inBlock_cast.Tables["PLAN"]);
                string[] col_fix = "RESTRAND_FLG,CC_REQ_TIME,CAST_NO_SHOW".Split(',');
                for (int n = 0; n < inBlock_grid.Tables[0].Rows.Count; n++)
                {
                    DataRow dr = inBlock_grid.Tables[0].Rows[n];
                    for (int i = 0; i < col_fix.Length; i++)
                    {
                        dr[col_fix[i]] = inBlock_cast.Tables["PLAN"].Rows[n][col_fix[i]].ToString();
                    }
                }
                

                //将信息压入指定的GRID, 
                EF.Utility.SetCustomGridValue(efDevGrid1, inBlock_grid, false);
                mov_flag = 0;
            }
        }

        

        

        

       

    
        
    }

}  

