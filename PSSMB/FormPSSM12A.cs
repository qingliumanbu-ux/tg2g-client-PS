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
    public partial class FormPSSM12A : EF.EFForm
    {
        private EI.EIInfo.eiinfo_sys s;
        private string factory_div = "";
        private string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。
        public FormPSSM12A()
        {
            InitializeComponent();
        }

        #region 窗体加载 Load
        private void FormPSSM12A_Load(object sender, EventArgs e)
        {
            this.dS_PSSM12.SMELT_MODE.Rows.Clear();
            this.dS_PSSM12.SMELT_MODE.Rows.Add("1", "常规");
            this.dS_PSSM12.SMELT_MODE.Rows.Add("2", "大渣");
            this.dS_PSSM12.SMELT_MODE.Rows.Add("3", "双渣");
            this.dS_PSSM12.SMELT_MODE.Rows.Add("4", "双联");

            this.dS_PSSM12.TD_CHG.Rows.Clear();
            this.dS_PSSM12.TD_CHG.Rows.Add(" ", " ");
            this.dS_PSSM12.TD_CHG.Rows.Add("D", "换中包");
            this.dS_PSSM12.TD_CHG.Rows.Add("X", "插铁板");
            this.dS_PSSM12.TD_CHG.Rows.Add("DX", "换中包+插铁板");

            //查询炉次条件
            query();

        }

        #endregion

        #region 查询函数，无翻页功能
        /// <summary>
        /// 炼钢出钢计划查询
        /// <para>出钢计划。</para>
        /// </summary>
        private void query()
        {
            //查询条件
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;

            try
            {
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));

                inBlock.Tables[0].Rows.Add();
                inBlock.Tables[0].Rows[0]["FACTORY_DIV"] = factory_div;
                //调用后台
                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm12a_inq", inBlock);
                s = outBlock.GetSys();
                //判断调用是否成功
                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    return;
                }
                else
                {
                    this.dS_PSSM12.TPSSM12A.Rows.Clear();
                    outBlock.Tables[0].TableName = "TPSSM12A";
                    outBlock.ConvertToStrongType(this.dS_PSSM12);
                    //this.dS_PSSM12.TPSSM12A.Merge(outBlock.Tables[0]);
                    this.dS_PSSM12.TPSSM12A.AcceptChanges();
                }
                this.EFMsgInfo = "查询成功。";

            }
            catch (Exception ex)
            {
                this.EFMsgInfo = ex.Message;
            }

        }
        #endregion

        #region F2查询
        private void FormPSSM12A_EF_DO_F2(object sender, EF.EF_Args e)
        {
            query();
        }
        #endregion

        #region F3 调整
        private void FormPSSM12A_EF_PRE_DO_F3(object sender, EF.EF_Args e)
        {

        }

        private void FormPSSM12A_EF_DO_F3(object sender, EF.EF_Args e)
        {
            //查询条件
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;

            try
            {
                //获取当前修改数据
                DataTable dt = this.dS_PSSM12.TPSSM12A.GetChanges();
                //if (dt.Rows.Count == 0)
                //{
                //    EF.EFMessageBox.Show("没有选择要修改的炉次,请选择后操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                inBlock.Tables[0].TableName = "TPSSM12A"; //炉次条件
                inBlock.Tables[0].Merge(dt);


                //调用后台
                this.EFMsgInfo = "炉次条件修改中...";
                outBlock = EI.EITuxedo.CallService("pssm12a_upd", inBlock);
                s = outBlock.GetSys();
                //判断调用是否成功
                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    return;
                }

                query();
                this.EFMsgInfo = "修改成功。";

            }
            catch (Exception ex)
            {
                this.EFMsgInfo = ex.Message;
            }
        }

        private void FormPSSM12A_EF_CANCEL_DO_F3(object sender, EF.EF_Args e)
        {

        }
        #endregion

        #region F9 优化
        private void FormPSSM12A_EF_DO_F9(object sender, EF.EF_Args e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;

            try
            {
                //整体时间优化，无参数
                //inBlock.Tables[0].Columns.Add("OP_FLAG", typeof(string)); //下达：0  删除：1
                //inBlock.Tables[0].Rows.Add("0");

                this.EFMsgInfo = "计划优化中...";
                outBlock = EI.EITuxedo.CallService("pssm11_opti", inBlock);
                s = outBlock.GetSys();

                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    this.EFArgs.buttonStatusHold = true;
                    return;
                }
                else
                {
                    //query();
                    this.EFMsgInfo = "计划优化完成!";

                    this.EFCallForm("PSSM11");  //跳转到出钢计划画面
                    this.Close();
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

        #region F11 >>浇铸计划
        private void FormPSSM12A_EF_DO_FB(object sender, EF.EF_Args e)
        {
            //EF.EF_Args.common_parameter_1 = this.gridView1.GetFocusedDataRow()["ST_NO"].ToString();
            this.EFCallForm("PSSM10");
            this.Close();
        }
        #endregion

        #region F12 >>出钢计划
        private void FormPSSM12A_EF_DO_FC(object sender, EF.EF_Args e)
        {
            this.EFCallForm("PSSM11");
            this.Close();
        }
        #endregion

        private void repItemTimeEdit_pour_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {

        }

        #region Grid数据变更
        private void bandedGridView_plan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rownum = e.RowHandle;
            string colname = e.Column.FieldName;

            if (colname == "CC_REQ_TIME" || colname == "POUR_TIME") //浇注周期列，有值修改
            {
                string _pour_time = "";
                string _plan_no = this.bandedGridView_plan.GetRowCellValue(rownum, "SM_PLAN_NO").ToString();

                //CC_REQ_TIME列为DateTime 类型
                if(colname == "CC_REQ_TIME")
                {
                    var val = this.bandedGridView_plan.GetRowCellValue(rownum, "CC_REQ_TIME");
                    if(val.ToString() == "")
                    {
                        _pour_time = "";
                    }
                    else
                    {
                        _pour_time = ((DateTime)val).ToString("HHmm");
                    }
                }
                else
                {
                    _pour_time = this.bandedGridView_plan.GetRowCellValue(rownum, "POUR_TIME").ToString();
                }
                //指定开浇时刻修改
                SetPourTime(_plan_no, _pour_time);
            }
        }
        #endregion

        #region 开浇时刻修改
        private void SetPourTime(string sm_plan_no, string _pour_time)
        {
            //查询条件
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;

            try
            {
                //修改指定计划号开浇时刻
                inBlock.Tables[0].TableName = "POURTIME"; //炉次条件
                inBlock.Tables[0].Columns.Add("SM_PLAN_NO", typeof(string)); //计划号
                inBlock.Tables[0].Columns.Add("CC_REQ_TIME", typeof(string)); //指定开浇时刻（4位，HHmm）
                DataRow row = inBlock.Tables[0].Rows.Add();
                row["SM_PLAN_NO"] = sm_plan_no;
                row["CC_REQ_TIME"] = _pour_time;

                //解析输入时刻，校验是否正确
                if (_pour_time != "")
                {
                    try
                    {
                        DateTime _time_now = DateTime.Now;
                        _time_now = DateTime.ParseExact(
                            _time_now.ToString("yyyyMMdd") + _pour_time + "00",
                            "yyyyMMddHHmmss",
                            null
                            );
                    }
                    catch (Exception err)
                    {
                        EF.EFMessageBox.Show("输入的开浇时刻不正确，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //this.EFArgs.buttonStatusHold = true;
                        return;
                    }
                }

                //调用后台
                outBlock = EI.EITuxedo.CallService("pssm12a_cctime", inBlock);
                s = outBlock.GetSys();
                //判断调用是否成功
                if (s.flag < 0)
                {
                    this.EFSysInfo = s;
                    return;
                }
                else
                {
                    //this.dS_PSSM12.TPSSM12A.Rows.Clear();
                    //outBlock.Tables[0].TableName = "TPSSM12A";
                    //outBlock.ConvertToStrongType(this.dS_PSSM12);
                    ////this.dS_PSSM12.TPSSM12A.Merge(outBlock.Tables[0]);
                    //this.dS_PSSM12.TPSSM12A.AcceptChanges();
                }
                this.EFMsgInfo = "开浇时刻修改成功。";//"开浇时刻设定功能开发中，尽快完成。" ;

            }
            catch (Exception ex)
            {
                this.EFMsgInfo = ex.Message;
            }
        }
        #endregion

        private void FormPSSM12A_EF_START_FORM_BY_EP(object sender, EF.EF_Args i_args)
        {
            factory_div = i_args.GetCallParamsByName("factory_div");

            //若ES没有配置参数, 默认取“1”
            if (factory_div.Trim() == "") factory_div = "A10";
        }

    }


}
