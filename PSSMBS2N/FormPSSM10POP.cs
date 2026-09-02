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
    public partial class FormPSSM10POP : EF.EFFormMain
    {
        //操作区分
        private string v_div = " ";
        private string v_func_id = " ";
        private string v_func_id2 = " ";
        private string v_service = " ";
        private string v_factory_div = " ";
        private string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。


        EI.EIInfo outBlock1 = new EI.EIInfo();
        public FormPSSM10POP()
        {
            InitializeComponent();
        }

        private void FormPSSMPOP_Load(object sender, EventArgs e)
        {
            try
            {
                //增加以下信息
                //=================
                //画面对应的当前分区= v_curr_part
                v_curr_part_name = this.ef_args.formPartition; //画面在 EPESOBJ 中维护的分区代码。

                //获取传入的参数
                v_div = EF.EF_Args.common_parameter_1;
                v_func_id = EF.EF_Args.common_parameter_2;
                v_factory_div = EF.EF_Args.common_parameter_3;
                v_service = EF.EF_Args.common_parameter_4;
                v_func_id2 = EF.EF_Args.common_parameter_5;
                outBlock1 = (EI.EIInfo)EF.EF_Args.common_object_1;

                EF.EF_Args.common_parameter_1 = " ";
                EF.EF_Args.common_parameter_2 = " ";
                EF.EF_Args.common_parameter_3 = " ";
                EF.EF_Args.common_parameter_4 = " ";
                EF.EF_Args.common_parameter_5 = " ";
                EF.EF_Args.common_object_1 = null;

                //EFX.EFCGrid.InitSingleGridColumn(efDevGrid1, v_func_id,  v_curr_part_name);

                EFX.EFCGrid.InitSingleGridColumn(efDevGrid1, v_func_id, v_curr_part_name);
                //EPED54中初始化缺省信息。
                (EFX.EFCGrid.GetEFCGridBase(efDevGrid1) as EFX.EFCGridImp.SingleDev.EFCGridSingleDev).ResetGridValue();
                EF.Utility.SetGridColumn(new EF.EFDevGrid[] { this.efDevGrid2 }, new string[] { v_func_id2 }, v_curr_part_name);

                this.efDevGrid2.DataSource = outBlock1.Tables["PONO_SLAB"];

                if (v_div != "I")
                {
                    EF.Utility.SetSingleGridValue(efDevGrid1, outBlock1, 0);
                }

                if (v_div == "Q") //如果是查询的，则确定按钮无效
                {
                    this.efButton1.Visible = false;
                }

                if (v_div == "U")
                {
                    foreach (var col in EFX.EFCGrid.GetEFCGridBase(efDevGrid1).Columns.Values)
                    {
                        if (col.ColumnInfo.ItemKeyFlag)
                        {
                            var colName = col.ColumnInfo.ItemEname;
                            EFX.EFCGrid.GetEFCGridBase(efDevGrid1).Columns[colName].EnableEdit = false;
                        }
                    }
                }

                EFX.EFCGrid.GetEFCGridBase(efDevGrid1).SetGridCellValue(0, "PONO", " ");

                //将可编辑列设置成[绿色+粗体]标题
                //================================
                EFX.EFCGrid.GetEFCGridBase(efDevGrid1).TitleEditEnableColor = Color.DodgerBlue; //设置成蓝色  //Color.Green; //设置成绿色。 
                EFX.EFCGrid.GetEFCGridBase(efDevGrid1).TitleEditEnableFont = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold); //设置成指定字体[粗体]。 
                this.efDevGrid2.EFMultiSelect = false;
            }
            catch (Exception ex)
            {
                EF.EFMessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 新增。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void efButton1_Click(object sender, EventArgs e)
        {
            try
            {
                EI.EIInfo inBlock = new EI.EIInfo();
                EI.EIInfo inBlock2 = new EI.EIInfo();
                EI.EIInfo inBlock_Copy = new EI.EIInfo();
                EI.EIInfo outBlock;
                inBlock.Tables[0].Clear();
                inBlock = EF.Utility.GetSingleGridValue(efDevGrid1);

                DataTable dt =this.efDevGrid2.DataSource as DataTable;
                dt.AcceptChanges();

                inBlock2.Tables[0].Merge(dt);


                //必须项的内容校验。 
                if (!EFX.EFCGrid.GetEFCGridBase(efDevGrid1).ValidateGridDataEx())
                {
                    EF.EFMessageBox.Show("请输入必输信息。");
                    return;
                }

                if (!inBlock.Tables[0].Columns.Contains("FACTORY_DIV"))
                {
                    inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(System.String));
                    inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = v_factory_div;
                }

                inBlock_Copy.Tables[0].Merge(inBlock2.Tables[0]);
                inBlock_Copy.Tables.Add();
                inBlock_Copy.Tables[1].Merge(outBlock1.Tables["PLAN"]);
                inBlock_Copy.Tables.Add();
                inBlock_Copy.Tables[2].Merge(inBlock.Tables[0]);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, v_service, inBlock_Copy);

                EF.EF_Args.common_object_2 = outBlock;
                string v_msg = outBlock.sys_info.msg + "\n" + outBlock.sys_info.sysmsg;

                //判断调用是否正确
                if (outBlock.sys_info.flag < 0)
                {
                    GC.PM_utility2.Dev_messageBoxError(v_msg);
                    return;
                }


                this.Close();

            }
            catch (Exception ex)
            {
                EF.EFMessageBox.Show(ex.Message);
            }

        }

        private void efButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.efDevGrid2.SetSelectedColumnChecked(e.FocusedRowHandle, true);
        }



    }
}
