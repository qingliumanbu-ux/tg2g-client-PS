using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using EF;
using System.Data;

namespace PS
{
    class PSUtils
    {

        #region 获取功能号列信息
        /// <summary>
        /// 获取功能号列信息
        /// </summary>
        /// <param name="part_name">分区名</param>
        /// <param name="func_id">ed54功能号</param>
        /// <returns></returns>
        public static EI.EIInfo Get_ED54_edit_flag(string part_name, string func_id)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            string v_sql = "select item_ename,form_edit_flag,item_key_flag from ted54 where upper(func_id) = upper('?') order by class_code , seq_no";
            v_sql = v_sql.Replace("?", func_id);    //ed54功能号
            inBlock.SetColName(1, 1, "v_sql");
            inBlock.SetColVal(1, 1, "v_sql", v_sql);
            EI.EIInfo outBlock = EI.EIManager.Instance.CallService(part_name, "eped_dyn_sql", inBlock);
            outBlock.Tables[0].TableName = "EDIT_FLAG";
            return outBlock;
        }
        #endregion

        #region 校验数据安全性

        /// <summary>不安全的</summary>
        /// <param name="edit_flag">功能号列信息</param>
        /// <returns></returns>
        public static bool harmful(EI.EIInfo edit_flag)
        {
            return edit_flag == null || edit_flag.Tables.Count <= 0 || edit_flag.Tables[0].Rows.Count <= 0
                || !edit_flag.Tables[0].Columns.Contains("item_ename")
                || !edit_flag.Tables[0].Columns.Contains("form_edit_flag")
                || !edit_flag.Tables[0].Columns.Contains("item_key_flag");
        }

        #endregion

        #region 获取可更新列字符串（主键不可更新）
        [Obsolete("ED54中的列名与数据库不一定匹配！")]
        public static string Get_ED54_fieldToUpdate(EI.EIInfo edit_flag)
        {
            if (harmful(edit_flag)) return "";  //校验

            string fieldToUpdate = "";
            for (int i = 0; i < edit_flag.Tables[0].Rows.Count; i++)
            {
                if ("1" == edit_flag.Tables[0].Rows[i]["form_edit_flag"].ToString() && "0" == edit_flag.Tables[0].Rows[i]["item_key_flag"].ToString() && "" != edit_flag.Tables[0].Rows[i]["item_ename"].ToString().Trim())
                {
                    if (fieldToUpdate != "") fieldToUpdate += ",";
                    fieldToUpdate += edit_flag.Tables[0].Rows[i]["item_ename"].ToString();
                }
            }
            return fieldToUpdate;
        }
        #endregion

        #region 根据功能号列信息修改列
        /// <summary>
        /// 根据功能号列信息修改列
        /// </summary>
        /// <param name="outBlock">功能号列信息</param>
        /// <param name="efDevGrid">对应的efDevGrid</param>
        /// <param name="editing">正在编辑为true,停止编辑为false</param>
        public static void SetColumnEditableBy_edit_flag(EI.EIInfo edit_flag, EF.EFDevGrid efDevGrid, bool editing)
        {
            if (harmful(edit_flag)) return; //校验
            for (int i = 0; i < edit_flag.blk_info[0].row; i++)
            {
                string item_ename = edit_flag.Tables[0].Rows[i]["item_ename"].ToString().Trim().ToUpper();  //ed54列名
                string form_edit_flag = edit_flag.Tables[0].Rows[i]["form_edit_flag"].ToString().Trim();    //1为可编辑
                string item_key_flag = edit_flag.Tables[0].Rows[i]["item_key_flag"].ToString().Trim();      //1为主键
                //如果该列存在，如果ED54可编辑(form_edit_flag == "1")且不为主键(item_key_flag == "0")且正在编辑(editing=true)，则该列可编辑
                if (EFX.EFCGrid.GetEFCGridBase(efDevGrid).Columns.ContainsKey(item_ename))
                    EFX.EFCGrid.GetEFCGridBase(efDevGrid).Columns[item_ename].EnableEdit =
                        "1" == form_edit_flag       //可编辑
                        && "0" == item_key_flag     //不为主键
                        && editing;                 //正在编辑时
            }
        }
        #endregion

        #region 列标题颜色变化方法
        /// <summary>
        /// 列标题颜色变化方法定义
        /// 不可编辑列为红色
        /// 可编辑列:正在编辑时为蓝色,停止编辑时为黑色
        /// </summary>
        /// <param name="outBlock">功能号可编辑列信息</param>
        /// <param name="efDevGrid">对应的efDevGrid</param>
        /// <param name="editing">正在编辑为true,停止编辑为false</param>
        public static void ChangeTitleForeColor(EI.EIInfo edit_flag, EF.EFDevGrid efDevGrid, bool editing)
        {
            //根据查询的结果设置列标题颜色，以及编辑时变化颜色的方法
            for (int i = 0; i < edit_flag.blk_info[0].row; i++)
            {
                string item_ename = edit_flag.Tables[0].Rows[i]["item_ename"].ToString().Trim().ToUpper();  //ed54列名
                string form_edit_flag = edit_flag.Tables[0].Rows[i]["form_edit_flag"].ToString().Trim();    //1为可编辑
                string item_key_flag = edit_flag.Tables[0].Rows[i]["item_key_flag"].ToString().Trim();      //1为主键
                if (EFX.EFCGrid.GetEFCGridBase(efDevGrid).Columns.ContainsKey(item_ename))
                {
                    EFX.EFCGrid.GetEFCGridBase(efDevGrid).Columns[item_ename].TitleForeColor =
                     "1" == item_key_flag ? Color.Red :                     //主键为红色
                   ("1" == form_edit_flag && editing) ? Color.DodgerBlue :  //可编辑列 编辑时为蓝色
                   Color.Black;                                             //否则为黑色
                }
            }
        }
        #endregion

        #region 可编辑与颜色整合

        #endregion

        #region ★查询与分页查询★
        /// <summary>
        /// <para>查询函数模板</para>
        /// </summary>
        /// <param name="part_name">分区名</param>
        /// <param name="svc_name">查询调用的后台程序名称</param>
        /// <param name="inBlock">查询的条件</param>
        /// <param name="efDevGrid">显示查询结果的Grid</param>
        /// <param name="paged">是否分页</param>
        /// <returns>返回调用后台得到的完整数据</returns>

        public delegate EI.EIInfo Query();
        public static event PSUtils.Query query0;
        public static EI.EIInfo Query0(string part_name, string svc_name, EI.EIInfo inBlock, EF.EFDevGrid efDevGrid, bool paged)
        {
            if (paged) Add_PageInfo(inBlock, efDevGrid);    //添加分页信息
            EI.EIInfo outBlock = EI.EIManager.Instance.CallService(part_name, svc_name, inBlock);   //后台查询
            if (paged) Solve_PageInfo(outBlock, efDevGrid); //处理分页信息
            EF.Utility.SetCustomGridValue(efDevGrid, outBlock);  //显示查询结果
            if (efDevGrid.MainView is DevExpress.XtraGrid.Views.Grid.GridView) (efDevGrid.MainView as DevExpress.XtraGrid.Views.Grid.GridView).BestFitColumns();    //自动调整列宽
            return outBlock;
        }
        /// <summary>
        /// 0参的默认查询方法定义
        /// </summary>
       
        #region 例
        /// <summary>
        /// <para>动态的查询方法</para>
        /// <para>例：query += () => { Utils.Query0(inBlock, pssmsif_inq, efDevGrid_Result); };</para>
        /// </summary>
        public event PSUtils.Query query;
        #endregion
        /// <summary>
        /// <para>使efDevGrid能分页</para>
        /// <para>需提供分页时调用的查询方法</para>
        /// <para>如果查询变化了应重新绑定分页</para>
        /// </summary>
        /// <param name="query">分页时调用的查询方法</param>
        /// <param name="efDevGrid">要实现分页功能的efDevGrid</param>
        public static void Paged(Query query, EF.EFDevGrid efDevGrid)//使efDevGrid能分页的方法
        {
            efDevGrid.IsUseCustomPageBar = true;        //使用分页条
            efDevGrid.ShowPageToButton = true;          //显示分页跳转按钮
            efDevGrid.ShowRecordCountMessage = true;    //显示记录数信息
            efDevGrid.InitRowOrdinal = 1;               //第一条序号为1（默认是0）

            //添加分页按钮事件
            efDevGrid.EF_GridBar_First_Event += new EF.EFDevGrid.EFGridBarClickEvent((sender, e) =>
            {
                efDevGrid.InitRowOrdinal = 1;   //起始记录数归0
                query();   //查询
            }); //第一页按钮事件
            efDevGrid.EF_GridBar_PrePage_Event += new EF.EFDevGrid.EFGridBarClickEvent((sender, e) =>
            {
                efDevGrid.InitRowOrdinal -= efDevGrid.PageSize;   //起始记录数减去每一页的数量 先减再判断有没有多减
                if (efDevGrid.InitRowOrdinal < 1) efDevGrid.InitRowOrdinal = 1;   //减多了
                query();   //查询
            }); //上一页按钮事件
            efDevGrid.EF_GridBar_NextPage_Event += new EF.EFDevGrid.EFGridBarClickEvent((sender, e) =>
            {
                if (efDevGrid.TotalRecordCount == 0) efDevGrid.InitRowOrdinal = 1;
                else if (efDevGrid.InitRowOrdinal + efDevGrid.PageSize <= efDevGrid.TotalRecordCount)    //判断加完不超过总数
                    efDevGrid.InitRowOrdinal += efDevGrid.PageSize;     //起始记录数加上每一页的数量 判断加完不超过总数再加
                query();   //查询
            }); //下一页按钮事件
            efDevGrid.EF_GridBar_Last_Event += new EF.EFDevGrid.EFGridBarClickEvent((sender, e) =>
            {
                if (efDevGrid.TotalRecordCount - efDevGrid.PageSize <= 0) efDevGrid.InitRowOrdinal = 1;
                else efDevGrid.InitRowOrdinal = efDevGrid.TotalRecordCount - efDevGrid.TotalRecordCount % efDevGrid.PageSize + 1; //总记录数减去最后一页的剩余数量(模)得 最后一页的起始记录数(数据库查询的起始记录数) 为使前台显示更准确 加一
                //efDevGrid.InitRowOrdinal = efDevGrid.TotalRecordCount - efDevGrid.PageSize + 1; //总记录数减去每一页的数量得最后一页的起始记录数 //最后一页显示满用这句
                query();   //查询
            }); //最后页按钮事件
            efDevGrid.EF_GridBar_PageTo_Event += new EF.EFDevGrid.EFGridBarPageToClickEvent((sender, e) =>
            {
                efDevGrid.PageSize = e.PageSize; //更新每页大小
                efDevGrid.InitRowOrdinal = (e.PageTo - 1) * e.PageSize + 1;   //更新起始记录数
                query();   //查询
            }); //添加跳转按钮事件
        }
        /// <summary>
        /// 在查询条件里添加efDevGrid的分页信息
        /// </summary>
        /// <param name="inBlock">查询条件</param>
        /// <param name="efDevGrid">显示结果的efDevGrid</param>
        /// <returns></returns>
        public static EI.EIInfo Add_PageInfo(EI.EIInfo inBlock, EF.EFDevGrid efDevGrid)
        {
            string table_name = "PageInfo";
            if (inBlock.Tables.Contains(table_name)) inBlock.Tables[table_name].Clear();
            else inBlock.Tables.Add(table_name);
            inBlock.Tables[table_name].Merge(new EF.DSUtility.PageInfoDataTable().AddPageInfoRow(efDevGrid.InitRowOrdinal - 1, efDevGrid.PageSize).Table);   //添加分页信息
            return inBlock;
        }
        /// <summary>
        /// 处理后台返回的分页信息（获取总记录数，并计算当前页数和总页数，然后显示的efDevGrid上）
        /// </summary>
        /// <param name="outBlock">后台传回的数据</param>
        /// <param name="efDevGrid">显示结果的efDevGrid</param>
        /// <returns></returns>
        public static EI.EIInfo Solve_PageInfo(EI.EIInfo outBlock, EF.EFDevGrid efDevGrid)
        {
            string table_name = "PageInfo";
            if (outBlock.Tables.Contains(table_name) && outBlock.Tables[table_name].Columns.Contains("TotalRecordCount"))
                efDevGrid.TotalRecordCount = Convert.ToInt32(outBlock.Tables[table_name].Rows[0]["TotalRecordCount"]);  //获取后台查询的总记录数
            int CurrentPage = efDevGrid.InitRowOrdinal;    //如果每页一条：当前页数即为起始记录数
            if (efDevGrid.PageSize > 1) CurrentPage = efDevGrid.InitRowOrdinal / efDevGrid.PageSize + 1;  //起始记录数除以每一页的数量(向下取整) 得 上一页页数 再加一 //每页为一条时不适用
            int TotalPageCount = (int)Math.Ceiling((decimal)efDevGrid.TotalRecordCount / efDevGrid.PageSize);   //总记录数除以每一页的数量(向上取整) 得 总页数
            efDevGrid.RecordCountMessage = string.Format("第 {0}/{1} 页，共 {2} 条记录", CurrentPage, TotalPageCount, efDevGrid.TotalRecordCount);
            return outBlock;
        }
        #endregion

        #region 自动选中更新的行
        /// <summary>
        /// 自动选中更新的行
        /// </summary>
        public static void AutoSelectUpdateRow(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.CellValueChanged += (_s, _e) => { if (_e.Column.FieldName != EF.EFDevGrid.SelectionColumnFieldName) gridView.SetRowCellValue(_e.RowHandle, EF.EFDevGrid.SelectionColumnFieldName, true); };
        }
        #endregion

        #region 设置efDevGrid所有列可编辑属性
        /// <summary>
        /// 设置efDevGrid所有列可编辑属性
        /// </summary>
        /// <param name="efDevGrid"></param>
        /// <param name="p"></param>
        public static void SetAllColumnEditable(EF.EFDevGrid efDevGrid, bool p)
        {
            foreach (EFX.EFCGridImp.EFCGridColumn col in EFX.EFCGrid.GetEFCGridBase(efDevGrid).Columns.Values)
            {
                col.EnableEdit = p && col.ColumnInfo.ItemHideFlag == EFX.EFCGridImp.EFCGridColumnInfo.EnumItemHideFlag.NONE;
            }
        }
        #endregion

        #region EI.Info
        public static EI.EIInfo GetRow(EI.EIInfo inblock, string[] colmn_name)
        {
            try
            {
                EI.EIInfo outBlock_sub = new EI.EIInfo();
                outBlock_sub.Merge(inblock.Tables[0]);
                DataRow sub_row = inblock.Tables[0].Rows[0];
                int i = 0;
                for (i = 0; i < inblock.Tables["SUB"].Rows.Count; i++)
                {
                    DataRow dr = inblock.Tables["SUB"].Rows[i];
                    if (sub_row["PONO"].ToString() == dr["PONO"].ToString())
                    {
                        int a = 1;
                    }
                    if (sub_row["PONO"].ToString() == dr["PONO"].ToString()
                        //&& sub_row["SM_PLAN_NO"].ToString() == dr["SM_PLAN_NO"].ToString()
                        && sub_row["FACTORY_DIV"].ToString() == dr["FACTORY_DIV"].ToString()
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

        public static EI.EIInfo OrderByRow(EI.EIInfo inblock_sou, string blk_name_sou, EI.EIInfo inblock_tar, string blk_name_tar, string[] colmn_name, bool if_muli)
        {
            try
            {
                EI.EIInfo outBlock_Tmp = new EI.EIInfo();
                if (!outBlock_Tmp.Tables.Contains(blk_name_sou)) outBlock_Tmp.Tables.Add(blk_name_sou);
                outBlock_Tmp.Tables[blk_name_sou].Merge(inblock_sou.Tables[blk_name_sou].Clone());
                int index = 0;
                //准备tmp数据
                for (int i = 0; i < inblock_tar.Tables[blk_name_tar].Rows.Count; i++)
                {
                    DataRow dr_tar = inblock_tar.Tables[blk_name_tar].Rows[i];
                    int charge = 0;
                    for (int t = 0; t < inblock_sou.Tables[blk_name_sou].Rows.Count; t++)
                    {
                        DataRow dr_sou = inblock_sou.Tables[blk_name_sou].Rows[t];
                        charge = 0;
                        for (int n = 0; n < colmn_name.Length; n++)
                        {
                            if (dr_sou[colmn_name[n]].ToString() == dr_tar[colmn_name[n]].ToString())
                            {
                                charge++;
                            }
                        }
                        if (charge == colmn_name.Length)
                        {
                            outBlock_Tmp.Tables[blk_name_sou].ImportRow(dr_sou);
                            if (if_muli) continue;
                            else break;
                        }
                    }
                }


                //delete row
                for (int i = inblock_sou.Tables[blk_name_sou].Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr_sou = inblock_sou.Tables[blk_name_sou].Rows[i];
                    int charge = 0;
                    for (int t = 0; t < outBlock_Tmp.Tables[blk_name_sou].Rows.Count; t++)
                    {
                        DataRow dr_tmp = outBlock_Tmp.Tables[blk_name_sou].Rows[t];
                        charge = 0;
                        for (int n = 0; n < colmn_name.Length; n++)
                        {
                            if (dr_sou[colmn_name[n]].ToString() == dr_tmp[colmn_name[n]].ToString())
                            {
                                charge++;
                            }
                        }
                        if (charge == colmn_name.Length)
                        {
                            //outBlock_Tmp.Tables[blk_name_sou].ImportRow(dr_sou);
                            inblock_sou.Tables[blk_name_sou].Rows.RemoveAt(i);
                            index = i;
                            break;
                        }
                    }

                }
                int row_sou = inblock_sou.Tables[blk_name_sou].Rows.Count;
                //还原到起始行
                for (int x = 0; x < outBlock_Tmp.Tables[blk_name_sou].Rows.Count; x++)
                {
                    DataRow dr_ins = inblock_sou.Tables[blk_name_sou].NewRow();
                    dr_ins.ItemArray = outBlock_Tmp.Tables[blk_name_sou].Rows[x].ItemArray;
                    //outBlock_Tmp.Tables[blk_name_sou].Rows[x];
                    inblock_sou.Tables[blk_name_sou].Rows.InsertAt(dr_ins, index + x);
                }
                return inblock_sou;
            }
            catch (Exception err)
            {

                //this.EFMsgInfo = "未找到相应控件。请设置：PSSM11A_CONST 或： " + err_msg ;
                string prompt = err.Message;
                //this.EFMsgInfo = prompt;
                GC.PM_utility2.Dev_messageBoxWarning(prompt);
                //this.EFMsgInfo = err_msg + err.Message;


                return inblock_sou;
            }
        }

        //计算工序时间
        //public EI.EIInfo plan_time_cal(EI.EIInfo inBlock, string cc_mach_no,string cc_req_time,string cal_type)
        public static EI.EIInfo plan_time_cal(EI.EIInfo inBlock, Dictionary<String, String> paras_cal)
        {
            try
            {
                EI.EIInfo iblk_dev = new EI.EIInfo();
                iblk_dev.Tables[0].Columns.Add("DEV_CODE", typeof(String));
                if (!inBlock.Tables.Contains("PLAN") || !inBlock.Tables.Contains("SUB"))
                {
                    return inBlock;
                }
                //DateTime time = DateTime.Now.AddHours(1);
                DateTime time = DateTime.Now;

                string cc_req_time = paras_cal.ContainsKey("CC_REQ_TIME") ? paras_cal["CC_REQ_TIME"] : time.ToString("yyyyMMddHHmmss");
                string cal_type = paras_cal.ContainsKey("CAL_TYPE") ? paras_cal["CAL_TYPE"] : " ";
                string cal_cast = paras_cal.ContainsKey("CAL_CAST") ? paras_cal["CAL_CAST"] : "1";
                string start_pono = paras_cal.ContainsKey("PONO") ? paras_cal["PONO"] : " ";
                string v_cc_mach_no = paras_cal.ContainsKey("CC_MACH_NO") ? paras_cal["CC_MACH_NO"] : " ";
                string continue_flag = "0";
                string cast_start = start_pono;
                string cast_time = cc_req_time;
                if (cc_req_time.CompareTo(time.ToString("yyyyMMddHHmmss")) < 0)
                {
                    cast_time = time.ToString("yyyyMMddHHmmss");
                }

                string move_time = "0";

                #region 根据传入PONO获取浇次第一炉的PONO及开浇时间
                //获取本浇次第一炉的开浇时间
                if (cal_cast.Trim() == "1")
                {
                    for (int n = inBlock.Tables["PLAN"].Rows.Count - 1; n >= 0; n--)
                    {
                        DataRow dr = inBlock.Tables["PLAN"].Rows[n];
                        if (dr["PONO"].ToString() == start_pono
                            && continue_flag == "0")
                        {
                            continue_flag = "1";
                            if (dr["RESTRAND_FLG"].ToString() == "1")
                            {
                                cast_start = start_pono;
                                break;
                            }

                        }
                        else
                        {//若不是第一炉，则继续往上找
                            if (continue_flag == "0") continue;
                            else
                            {
                                if (dr["RESTRAND_FLG"].ToString() == "1")
                                {
                                    cast_start = dr["PONO"].ToString();
                                    break;
                                }
                            }
                        }
                    }

                    for (int n = inBlock.Tables["SUB"].Rows.Count - 1; n >= 0; n--)
                    {
                        DataRow dr_sub = inBlock.Tables["SUB"].Rows[n];
                        if (dr_sub["PONO"].ToString() == cast_start
                            && dr_sub["AREA_ID"].ToString() == "5"
                            )//&& dr_sub["START_TIME"].ToString().Length >= 14
                        {
                            int last_row = 0;
                            if (n > 0)    //本浇次前还有计划  检查是否比该计划早开始
                            {
                                for (int i = n - 1;i > 0; i--)
                                {
                                    if (inBlock.Tables["SUB"].Rows[i]["AREA_ID"].ToString() == "5")
                                    {
                                        last_row = i;
                                        break;
                                    }
                                    else continue;
                                }

                                string end_time_real = inBlock.Tables["SUB"].Rows[last_row]["END_TIME_REAL"].ToString();
                                string end_time = inBlock.Tables["SUB"].Rows[last_row]["END_TIME"].ToString();

                                if (end_time_real.Trim().Length >= 14
                                    && end_time_real.CompareTo(dr_sub["START_TIME"].ToString()) > 0)
                                {
                                    cast_time = end_time_real;
                                    break;
                                }
                                if (end_time.Trim().Length >= 14
                                   && end_time_real.CompareTo(dr_sub["START_TIME"].ToString()) > 0)
                                {
                                    cast_time = end_time;
                                    break;
                                }

                            }
                            else
                            {
                                cast_time = dr_sub["START_TIME"].ToString();
                            }

                        }



                    }
                }



                #endregion

                #region 计算连铸时间
                continue_flag = "0";
                if (cal_cast == "1") start_pono = cast_start;
                if (cal_type == "1")
                {

                    //DateTime cc_cal_time = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(cc_req_time));//前台CC要求时刻
                    DateTime cc_cal_time = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(cast_time));//CC要求时刻与本浇次第一炉中取一个
                    for (int row = 0; row < inBlock.Tables["SUB"].Rows.Count; row++)
                    {
                        //先计算开浇时间
                        DataRow sub_plan_row = inBlock.Tables["SUB"].Rows[row];

                        if ((sub_plan_row["DEV_CODE"].ToString().Substring(0, 1) == "C" || sub_plan_row["DEV_CODE"].ToString().Substring(0, 1) == "I")
                            && sub_plan_row["START_TIME_REAL"].ToString().Length < 14)
                        {
                            if (v_cc_mach_no != sub_plan_row["DEV_CODE"].ToString() && v_cc_mach_no.Trim() != "") continue;
                            if (start_pono != sub_plan_row["PONO"].ToString() && start_pono.Trim() != "" && continue_flag == "0")
                            {
                                continue;
                            }
                            else
                            {
                                continue_flag = "1";
                            }
                            int proc_time = Convert.ToInt32(sub_plan_row["PROC_TIME"]);
                            sub_plan_row["START_TIME"] = cc_cal_time.ToString("yyyyMMddHHmmss");
                            cc_cal_time = cc_cal_time.AddMinutes(proc_time);
                            sub_plan_row["END_TIME"] = cc_cal_time.ToString("yyyyMMddHHmmss");
                        }

                    }
                }
                #endregion

                #region 计算其他工序时间
                continue_flag = "1";
                DateTime cc_start_time = new DateTime();
                string dev_move_start = "";
                string dev_move_end = "";
                for (int row = inBlock.Tables["SUB"].Rows.Count - 1; row >= 0; row--)
                {
                    //计算工序时间

                    DataRow sub_plan_row = inBlock.Tables["SUB"].Rows[row];
                    DataRow sub_plan_rowpre = inBlock.Tables["SUB"].Rows[row];


                    string sub_time = sub_plan_row["START_TIME"].ToString();

                    //if (v_cc_mach_no != sub_plan_row["DEV_CODE"].ToString() && v_cc_mach_no.Trim() != "") continue;
                    if ((start_pono == sub_plan_row["PONO"].ToString() && start_pono.Trim() != "")
                        || continue_flag == "1")
                    {
                        continue_flag = "1";
                    }
                    else
                    {
                        continue_flag = "0";
                        break;
                    }


                    int proc_time = Convert.ToInt32(sub_plan_row["PROC_TIME"]);
                    int move_time_ini = 0;


                    int backlog_time = proc_time + move_time_ini;
                    if (sub_plan_row["DEV_CODE"].ToString().Substring(0, 1) == "C" || sub_plan_row["DEV_CODE"].ToString().Substring(0, 1) == "I")
                    {
                        //continue;
                        sub_time = sub_plan_row["START_TIME"].ToString();
                        cc_start_time = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(sub_time));
                    }
                    else
                    {
                        //sub_plan_row["END_TIME"] = cc_start_time.ToString("yyyyMMddHHmmss");
                        if (inBlock.Tables.Contains("MOVE_TIME"))
                        {
                            sub_plan_rowpre = inBlock.Tables["SUB"].Rows[row + 1];
                            if (sub_plan_row["sm_plan_no"].ToString() == sub_plan_rowpre["sm_plan_no"].ToString())
                            {
                                dev_move_start = sub_plan_row["DEV_CODE"].ToString();
                                dev_move_end = sub_plan_rowpre["DEV_CODE"].ToString();
                                move_time = GetMoveTime(inBlock, "MOVE_TIME", "START_DEV", "END_DEV", "MOVE_TIME", dev_move_start, dev_move_end);
                            }
                            else
                            {
                                move_time = "0";
                            }
                            move_time_ini = Convert.ToInt32(move_time);
                        }
                        if (sub_plan_row["DEV_CODE"].ToString().Substring(0, 1) == "B" || sub_plan_row["DEV_CODE"].ToString().Substring(0, 1) == "A")
                        {
                            int f_id = 0;
                            for (int d_row = 0; d_row < iblk_dev.Tables[0].Rows.Count; d_row++)
                            {
                                if (iblk_dev.Tables[0].Rows[d_row]["DEV_CODE"].ToString() == sub_plan_row["DEV_CODE"].ToString())
                                {
                                    f_id = 1;
                                    break;
                                }
                                else continue;
                            }
                            if (f_id == 0)
                            {
                                iblk_dev.Tables[0].Rows.Add();
                                int row_now = iblk_dev.Tables[0].Rows.Count-1;
                                iblk_dev.Tables[0].Rows[row_now]["DEV_CODE"] = sub_plan_row["DEV_CODE"].ToString();
                            }
                        }
                        sub_plan_row["END_TIME"] = cc_start_time.AddMinutes(move_time_ini * -1).ToString("yyyyMMddHHmmss"); ;  //结束时间 = 下工序时刻-下工序传搁时间
                        cc_start_time = cc_start_time.AddMinutes(move_time_ini * -1);
                        sub_plan_row["START_TIME"] = cc_start_time.AddMinutes(proc_time * -1).ToString("yyyyMMddHHmmss");   //开始时间= 结束时间-处理时间
                        cc_start_time = cc_start_time.AddMinutes(proc_time * -1);
                    }

                }
                #endregion

                for (int t = 0; t < iblk_dev.Tables[0].Rows.Count; t++)
                {
                    string dev_code_in = iblk_dev.Tables[0].Rows[t]["DEV_CODE"].ToString();
                    if (dev_code_in.Trim() != "") dev_time_cut(inBlock, dev_code_in, "A", cast_start, "0");
                }
                return inBlock;
            }
            catch (Exception ex)
            {
                return inBlock;
            }
        }
        public static EI.EIInfo plan_time_cal_bof(EI.EIInfo inBlock, Dictionary<String, String> paras_cal)
        {
            try
            {
                EI.EIInfo iblk_dev = new EI.EIInfo();
                iblk_dev.Tables[0].Columns.Add("DEV_CODE", typeof(String));
                if (!inBlock.Tables.Contains("PLAN") || !inBlock.Tables.Contains("SUB"))
                {
                    return inBlock;
                }
                DateTime time = DateTime.Now;

                string cc_req_time = paras_cal.ContainsKey("CC_REQ_TIME") ? paras_cal["CC_REQ_TIME"] : time.ToString("yyyyMMddHHmmss");
                string cal_type = paras_cal.ContainsKey("CAL_TYPE") ? paras_cal["CAL_TYPE"] : " ";
                string cal_cast = paras_cal.ContainsKey("CAL_CAST") ? paras_cal["CAL_CAST"] : "1";
                string start_pono = paras_cal.ContainsKey("PONO") ? paras_cal["PONO"] : " ";
                string v_cc_mach_no = paras_cal.ContainsKey("CC_MACH_NO") ? paras_cal["CC_MACH_NO"] : " ";
                string v_bof_no = paras_cal.ContainsKey("BOF_NO") ? paras_cal["BOF_NO"] : " ";
                string continue_flag = "0";
                string cast_start = start_pono;
                string cast_time = cc_req_time;
                if (cc_req_time.CompareTo(time.ToString("yyyyMMddHHmmss")) < 0)
                {
                    cc_req_time = time.ToString("yyyyMMddHHmmss");
                }
                string move_time = "0";

                #region 根据传入PONO获取浇次第一炉的PONO及开吹时间
                //获取设备上一炉的开吹时间
                if (cal_cast.Trim() == "1")
                {
                    for (int n = inBlock.Tables["SUB"].Rows.Count - 1; n > 0; n--)
                    {
                        DataRow dr = inBlock.Tables["SUB"].Rows[n];
                        if (dr["AREA_ID"].ToString() != "3") continue;
                        if (dr["DEV_CODE"].ToString() != v_bof_no) continue;
                        if (dr["END_TIME"].ToString().Length >= 14)
                        {
                            if (dr["END_TIME_REAL"].ToString().Length >= 14)
                            {
                                continue_flag = "1";
                                cast_time = dr["END_TIME_REAL"].ToString();
                                continue;
                            }
                            else
                            {
                                cast_start = start_pono;
                                cast_time = dr["END_TIME"].ToString();
                                break;
                            }

                        }
                        if (continue_flag == "1")
                        {
                            cast_start = start_pono;
                        }
                    }

                }
                if (cast_time.CompareTo(cc_req_time) < 0) cast_time = cc_req_time;



                #endregion

                #region 计算转炉时间
                continue_flag = "0";
                if (cal_cast == "1") start_pono = cast_start;
                if (cal_type == "1")
                {

                    //DateTime cc_cal_time = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(cc_req_time));//前台CC要求时刻
                    DateTime cc_cal_time = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(cast_time));//CC要求时刻与本浇次第一炉中取一个
                    for (int row = 0; row < inBlock.Tables["SUB"].Rows.Count; row++)
                    {
                        //先计算开吹时间
                        DataRow sub_plan_row = inBlock.Tables["SUB"].Rows[row];

                        if (sub_plan_row["DEV_CODE"].ToString().Substring(0, 1) == "B"
                            && sub_plan_row["START_TIME_REAL"].ToString().Length < 14)
                        {
                            if (v_bof_no != sub_plan_row["DEV_CODE"].ToString() && v_bof_no.Trim() != "") continue;
                            if (start_pono != sub_plan_row["PONO"].ToString() && start_pono.Trim() != "" && continue_flag == "0")
                            {
                                continue;
                            }
                            else
                            {
                                continue_flag = "1";
                            }
                            int proc_time = Convert.ToInt32(sub_plan_row["PROC_TIME"]);
                            sub_plan_row["START_TIME"] = cc_cal_time.ToString("yyyyMMddHHmmss");
                            cc_cal_time = cc_cal_time.AddMinutes(proc_time);
                            sub_plan_row["END_TIME"] = cc_cal_time.ToString("yyyyMMddHHmmss");
                        }

                    }
                }
                #endregion

                #region 计算转炉后续工序时间
                continue_flag = "1";
                DateTime cc_start_time = new DateTime();
                string dev_move_start = "";
                string dev_move_end = "";
                for (int row = 0; row < inBlock.Tables["SUB"].Rows.Count; row++)
                {
                    //计算工序时间

                    DataRow sub_plan_row = inBlock.Tables["SUB"].Rows[row];
                    DataRow sub_plan_rowpre = inBlock.Tables["SUB"].Rows[row];


                    string sub_time = sub_plan_row["START_TIME"].ToString();

                    //if (v_cc_mach_no != sub_plan_row["DEV_CODE"].ToString() && v_cc_mach_no.Trim() != "") continue;
                    if ((start_pono == sub_plan_row["PONO"].ToString() && start_pono.Trim() != "")
                        || continue_flag == "1")
                    {
                        continue_flag = "1";
                    }
                    else
                    {
                        continue_flag = "0";
                        break;
                    }


                    int proc_time = Convert.ToInt32(sub_plan_row["PROC_TIME"]);
                    int move_time_ini = 0;


                    int backlog_time = proc_time + move_time_ini;
                    if (sub_plan_row["DEV_CODE"].ToString().Substring(0, 1) == "B")
                    {
                        //continue;
                        sub_time = sub_plan_row["END_TIME"].ToString();
                        cc_start_time = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(sub_time));
                    }
                    else
                    {
                        //sub_plan_row["END_TIME"] = cc_start_time.ToString("yyyyMMddHHmmss");
                        if (inBlock.Tables.Contains("MOVE_TIME"))
                        {
                            sub_plan_rowpre = inBlock.Tables["SUB"].Rows[row - 1];
                            if (sub_plan_row["sm_plan_no"].ToString() == sub_plan_rowpre["sm_plan_no"].ToString())
                            {
                                dev_move_start = sub_plan_rowpre["DEV_CODE"].ToString();
                                dev_move_end = sub_plan_row["DEV_CODE"].ToString();
                                move_time = GetMoveTime(inBlock, "MOVE_TIME", "START_DEV", "END_DEV", "MOVE_TIME", dev_move_start, dev_move_end);
                            }
                            else
                            {
                                move_time = "0";
                            }
                            move_time_ini = Convert.ToInt32(move_time);
                        }
                        sub_plan_row["START_TIME"] = cc_start_time.AddMinutes(move_time_ini).ToString("yyyyMMddHHmmss");   //开始时间= 前结束时间+ 传搁时间
                        cc_start_time = cc_start_time.AddMinutes(move_time_ini);

                        sub_plan_row["END_TIME"] = cc_start_time.AddMinutes(proc_time).ToString("yyyyMMddHHmmss"); ;  //结束时间 = 下工序时刻+处理时间
                        cc_start_time = cc_start_time.AddMinutes(proc_time);

                        if (sub_plan_row["DEV_CODE"].ToString().Substring(0, 1) == "C")
                        {
                            int f_id = 0;
                            for (int d_row = 0; d_row < iblk_dev.Tables[0].Rows.Count; d_row++)
                            {
                                if (iblk_dev.Tables[0].Rows[d_row]["DEV_CODE"].ToString() == sub_plan_row["DEV_CODE"].ToString())
                                {
                                    f_id = 1;
                                    break;
                                }
                                else continue;
                            }
                            if (f_id == 0)
                            {
                                iblk_dev.Tables[0].Rows.Add();
                                iblk_dev.Tables[0].Rows[0]["DEV_CODE"] = sub_plan_row["DEV_CODE"].ToString();
                            }
                        }


                    }

                }
                #endregion

                for (int t = 0; t < iblk_dev.Tables[0].Rows.Count; t++)
                {
                    string dev_code_in = iblk_dev.Tables[0].Rows[t]["DEV_CODE"].ToString();
                    if (dev_code_in.Trim() != "") dev_time_cut(inBlock, dev_code_in, "D", cast_start, "0");
                }

                return inBlock;
            }
            catch (Exception ex)
            {
                return inBlock;
            }
        }
        //获取工序时间
        public static string GetDealTime(EI.EIInfo inBlock, string table_name, string col_name, EI.EIInfo inBlock_paras)
        {
            try
            {
                //查询条件项

                //string findkey = paras.ContainsKey("FINDKEY") ? paras["FINDKEY"] : " ";
                //string findcol = paras.ContainsKey("FINDCOL") ? paras["FINDCOL"] : " ";
                //string dev_code = paras.ContainsKey("DEV_CODE") ? paras["DEV_CODE"] : " ";
                //string v_pono = paras.ContainsKey("PONO") ? paras["PONO"] : " ";

                string DealTime = "0";
                string DealTime_default = "0";
                string fetch_flag = "1";
                string def_flag = "0";
                if (inBlock_paras.Tables[0].Rows.Count <= 0)
                {
                    return DealTime;
                }
                DataRow dr_para = inBlock_paras.Tables[0].Rows[0];
                for (int i = 0; i < inBlock.Tables[table_name].Rows.Count; i++)
                {

                    for (int n = 0; n < inBlock_paras.Tables[0].Columns.Count; n++)
                    {
                        string para_col = inBlock_paras.Tables[0].Columns[n].ColumnName;
                        if (dr_para[para_col].ToString() == inBlock.Tables[table_name].Rows[i][para_col].ToString().Trim())
                        {
                            fetch_flag = "1";
                            continue;
                        }
                        else if (inBlock.Tables[table_name].Rows[i][para_col].ToString().Trim() == "")
                        {
                            def_flag = "1";
                            continue;
                        }
                        else
                        {
                            fetch_flag = "0";
                            def_flag = "0";
                            break;
                        }
                    }
                    if (fetch_flag == "1")
                    {
                        DealTime = inBlock.Tables[table_name].Rows[i][col_name].ToString();
                        return DealTime;
                    }
                    else if (def_flag == "1")
                    {
                        DealTime_default = inBlock.Tables[table_name].Rows[i][col_name].ToString();
                        continue;
                    }
                    else
                    {
                        continue;
                    }

                }
                if (DealTime_default != "0")
                {
                    return DealTime_default;
                }

                string prod_time = "20";
                if (table_name.Trim() == "PROC_TIME")
                {
                    //switch (dev_code.Substring(0, 1))
                    //{
                    //case "B":
                    //    prod_time = "30";
                    //    break;
                    //case "E":
                    //    prod_time = "35";
                    //    break;
                    //case "L":
                    //    prod_time = "25";
                    //    break;
                    //case "R":
                    //    prod_time = "25";
                    //    break;
                    //case "C":
                    //    prod_time = "35";
                    //    break;
                    /// <summary>
                    /////双联脱磷转炉处理时间
                    ///// </summary>
                    //static int PLDDealTime = 20;
                    ///// <summary>
                    ///// 双联转炉处理时间
                    ///// </summary>
                    //static int CLDDealTime = 25;
                    ///// <summary>
                    ///// 双联转炉准备时间
                    ///// </summary>
                    //static int LDPrepTime = 15;
                    ///// <summary>
                    ///// 双联转炉传搁时间
                    ///// </summary>
                    //static int Trantime_PC = 7;
                    ///// <summary>
                    ///// 转炉处理时间
                    ///// </summary>
                    //static int LDDealTime = 30;
                    ///// <summary>
                    ///// 精炼处理时间
                    ///// </summary>
                    //static int RCDealTime = 25;
                    ///// <summary>
                    ///// 连铸等待时间
                    ///// </summary>
                    //static int CWDealTime = 6;
                    ///// <summary>
                    ///// 连铸处理时间
                    ///// </summary>
                    //static int CCDealTime = 35;
                    ///// <summary>
                    ///// 常规传搁时间
                    ///// </summary>
                    //static int NormalTranTime = 17;
                    ///// <summary>
                    ///// 虚拟浇次号
                    ///// </summary>
                    //public static double dummynumber = 0;
                    ///// <summary>
                    ///// 转炉推功能间隔时间，单位分钟
                    ///// </summary>
                    //private static int LDPushTime = 3;
                    ///// <summary>
                    ///// 连铸正常间隔时间，单位分钟
                    ///// </summary>
                    //private static int CCPushTime_Normal = 0;//3;
                    ///// <summary>
                    ///// 连铸T间隔时间，单位分钟

                    //}
                }

                return prod_time;

            }
            catch (Exception err)
            {
                string prompt = err.Message;
                GC.PM_utility2.Dev_messageBoxWarning(prompt);
                return "0";
            }

        }

        public static string GetMoveTime(EI.EIInfo inBlock, string table_name, string col_name_start, string col_name_end, string col_name_time, string DEV_MOVE_START, string DEV_MOVE_END)
        {
            string MoveTime = "0";
            try
            {
                for (int i = 0; i < inBlock.Tables[table_name].Rows.Count; i++)
                {
                    DataRow date_row = inBlock.Tables[table_name].Rows[i];
                    if (date_row[col_name_start].ToString().Trim() == DEV_MOVE_START.Trim()
                        && date_row[col_name_end].ToString().Trim() == DEV_MOVE_END.Trim())
                    {
                        MoveTime = date_row[col_name_time].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MoveTime = "0";
                string erro = ex.Message;
                return MoveTime;
            }
            return MoveTime;
        }

        public static EI.EIInfo dev_time_cut(EI.EIInfo inBlock, string dev_code, string order_by_seq, string start_pono, string if_span)
        {
            try
            {
                if (!inBlock.Tables.Contains("PLAN") || !inBlock.Tables.Contains("SUB"))
                {
                    return inBlock;
                }
                DateTime time = DateTime.Now;
                DateTime time_tmp = DateTime.Now;
                string cast_time = time.ToString("yyyyMMddHHmmss");
                string pre_pono = "";
                string last_pono = "";
                string pre_endtime = "";
                DateTime base_time = DateTime.Now; ;
                int proc_time = 0;
                int row_temp = 0;
                //先获取第一个计划的最早开始事件
                for (int row = 0; row < inBlock.Tables["SUB"].Rows.Count; row++)
                {
                    //计算工序时间
                    DataRow d_row = inBlock.Tables["SUB"].Rows[row];


                    if (d_row["PONO"].ToString() != start_pono.Trim())
                    {
                        pre_pono = d_row["PONO"].ToString();
                        pre_endtime = d_row["END_TIME"].ToString();
                        continue;
                    }

                    if (pre_endtime.CompareTo(cast_time) > 0)
                    {
                        cast_time = pre_endtime;
                    }


                }


                string find_flag = "";

                if (order_by_seq.Trim() == "A")
                {
                    for (int row = 0; row < inBlock.Tables["SUB"].Rows.Count; row++)
                    {
                        //计算工序时间
                        DataRow sub_plan_row = inBlock.Tables["SUB"].Rows[row];
                        if (sub_plan_row["DEV_CODE"].ToString() != dev_code.Trim()) continue;
                        if (sub_plan_row["PONO"].ToString() != start_pono.Trim() && find_flag != "1")
                        {
                            continue;
                        }
                        else if (sub_plan_row["PONO"].ToString() == start_pono.Trim())
                        {
                            find_flag = "1";
                            base_time = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(sub_plan_row["END_TIME"].ToString()));
                            time_tmp = base_time;
                        }
                        else
                        {
                            proc_time = Convert.ToInt32(sub_plan_row["PROC_TIME"]);
                            sub_plan_row["START_TIME"] = time_tmp.ToString("yyyyMMddHHmmss");
                            time_tmp = time_tmp.AddMinutes(proc_time);
                            sub_plan_row["END_TIME"] = time_tmp.ToString("yyyyMMddHHmmss");
                            last_pono = sub_plan_row["PONO"].ToString();
                            row_temp = row;
                        }
                    }
                }
                else
                {
                    for (int row = inBlock.Tables["SUB"].Rows.Count - 1; row > 0; row--)
                    {
                        //计算工序时间
                        DataRow sub_plan_row = inBlock.Tables["SUB"].Rows[row];
                        if (sub_plan_row["DEV_CODE"].ToString() != dev_code.Trim()) continue;

                        if (row == inBlock.Tables["SUB"].Rows.Count - 1)
                        {
                            base_time = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(sub_plan_row["START_TIME"].ToString()));
                            time_tmp = base_time;
                        }
                        else
                        {
                            proc_time = Convert.ToInt32(sub_plan_row["PROC_TIME"]);
                            sub_plan_row["END_TIME"] = time_tmp.ToString("yyyyMMddHHmmss");
                            time_tmp = time_tmp.AddMinutes(proc_time * -1);
                            sub_plan_row["START_TIME"] = time_tmp.ToString("yyyyMMddHHmmss");
                            last_pono = sub_plan_row["PONO"].ToString();
                            if (sub_plan_row["PONO"].ToString() == start_pono.Trim())
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }

                        }
                    }
                }
                if (if_span.Trim() == "0") return inBlock;

                int time_div = 0;
                //可以根据最终时间 计算与下工序的时间差  再进一步调整当前工序的开始时间
                double timeSpan = 0;
                if (order_by_seq.Trim() == "A")
                {
                    //顺推 与下工序时间比较
                    for (int i = row_temp; i < inBlock.Tables["SUB"].Rows.Count; i++)
                    {
                        DataRow sub_row = inBlock.Tables["SUB"].Rows[i];
                        if (sub_row["PONO"].ToString() == last_pono
                            && sub_row["DEV_CODE"].ToString() != dev_code.Trim())
                        {
                            string next_time = sub_row["START_TIME"].ToString();
                            DateTime time_next = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(next_time));
                            timeSpan = (time_tmp - time_next).TotalMinutes;

                            if (inBlock.Tables.Contains("MOVE_TIME"))
                            {
                                string dev_move_start = dev_code;
                                string dev_move_end = sub_row["DEV_CODE"].ToString();
                                string move_time = GetMoveTime(inBlock, "MOVE_TIME", "START_DEV", "END_DEV", "MOVE_TIME", dev_move_start, dev_move_end);
                                timeSpan = timeSpan + Convert.ToDouble(move_time);
                            }
                            break;

                        }
                    }
                    //将时间差计算到第一炉
                    double timesp = (base_time.AddMinutes(timeSpan * -1) - base_time).TotalMinutes;
                    double t_time = 0;
                    if (timesp >= 0)  //比前续时间晚 大胆前进！
                    {
                        t_time = timesp;
                    }
                    else
                    {
                        t_time = timesp + timeSpan;
                    }
                    //进行推移
                    for (int row = 0; row < inBlock.Tables["SUB"].Rows.Count; row++)
                    {
                        //计算工序时间
                        DataRow r_row = inBlock.Tables["SUB"].Rows[row];
                        if (r_row["DEV_CODE"].ToString() != dev_code.Trim()) continue;
                        if (r_row["PONO"].ToString() != start_pono.Trim() && find_flag != "1")
                        {
                            continue;
                        }
                        else if (r_row["PONO"].ToString() == start_pono.Trim())
                        {
                            find_flag = "1";
                            r_row["START_TIME"] = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(r_row["START_TIME"].ToString())).AddMinutes(t_time * -1).ToString("yyyyMMddHHmmss");
                            r_row["END_TIME"] = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(r_row["END_TIME"].ToString())).AddMinutes(t_time * -1).ToString("yyyyMMddHHmmss");
                        }
                        else
                        {
                            r_row["START_TIME"] = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(r_row["START_TIME"].ToString())).AddMinutes(t_time * -1).ToString("yyyyMMddHHmmss");
                            r_row["END_TIME"] = Convert.ToDateTime(Common.DateTimeConvert.ConvertFrom14ByteString(r_row["END_TIME"].ToString())).AddMinutes(t_time * -1).ToString("yyyyMMddHHmmss");
                        }
                    }



                }
                else
                {
                    //逆推 与上工序时间比较
                }

                return inBlock;
            }
            catch (Exception ex)
            {
                return inBlock;
            }
        }
        #endregion

    }




}
