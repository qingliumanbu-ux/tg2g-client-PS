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
    /// 状态回退
    /// <para> 选择制造命令号和回退到的位置,把已有连铸实绩的计划状态回退到连铸之前；</para>
    /// </summary>
    /// Copyright: Baosight Software LTD.co Copyright (c) 2011
    /// Company: 上海宝信软件股份有限公司
    /// Author:  lijie
    /// Version: 1.0
    /// History:
    /// 2011-11-29 lijie [创建] 
    public partial class FormPSSM18S : EF.EFPopupForm
    {
        public FormPSSM18S()
        {
            InitializeComponent();
        }
        public string factory_div = " ";
        public string heat_no = "";
        public string pono = "";
        public string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。

        #region 窗体事件

        /// <summary>
        /// 画面初始化
        /// <para>查询制造命令号和返送到的位置</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>无</returns>
        private void FormPSSM21S_Load(object sender, EventArgs e)
        {
            if (EF.EF_Args.common_parameter_1.Trim() != "")
            {
                v_curr_part_name = EF.EF_Args.common_parameter_1;//当前画面的分区代码
            }
            QueryHtno();
            efDevComboBoxEdit1.Text = heat_no;
            ShowPos();
        }


        /// <summary>
        /// 返送确定按钮事件
        /// <para>校验输入项,状态回退</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>无</returns>
        private void efBtnOk_Click(object sender, EventArgs e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;
            try
            {
                //if ((efDevComboBoxEdit1.EditValue == null) || (efDevComboBoxEdit1.EditValue.ToString().Trim() == ""))
                //{
                //    efDevComboBoxEdit1.Focus();
                //    efDevComboBoxEdit1.ErrorIcon = (new ErrorProvider()).Icon.ToBitmap(); //设置惊叹号
                //    efDevComboBoxEdit1.ErrorText = "请选择机组号";
                //    //efDevComboBoxEdit1.ErrorText = PS.PSSM.PSSMC0000095/*请选择机组号。*/;
                //    //this.statusBarPanel1.Text = PS.PSSM.PSSMC0000095/*熔炼号不能为空。*/;
                //    return;
                //}
                if ((efDevLookUpEdit1.EditValue == null) || (efDevLookUpEdit1.EditValue.ToString().Trim() == ""))
                {
                    efDevLookUpEdit1.Focus();
                    efDevLookUpEdit1.ErrorIcon = (new ErrorProvider()).Icon.ToBitmap(); //设置惊叹号
                    efDevLookUpEdit1.ErrorText = "回退位置不能为空";
                    // efDevLookUpEdit1.ErrorText = PS.PSSM.PSSMC0000096/*回退位置不能为空。*/;
                    //this.statusBarPanel1.Text = PS.PSSM.PSSMC0000096/*回退位置不能为空。*/;
                    return;
                }
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("HTNO", typeof(String));
                inBlock.Tables[0].Columns.Add("AREA_ID", typeof(String));
                inBlock.Tables[0].Columns.Add("SM_PLAN_NO", typeof(String));

                DataRow row = inBlock.Tables[0].NewRow();
                row["FACTORY_DIV"] = factory_div;
                row["HTNO"] = this.efDevComboBoxEdit1.EditValue.ToString();
                row["SM_PLAN_NO"] = this.efDevComboBoxEdit2.EditValue.ToString();
                row["AREA_ID"] = this.efDevLookUpEdit1.EditValue.ToString();
                inBlock.Tables[0].Rows.Add(row);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_sk_upd", inBlock);
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000017/*处理失败[{0}]。*/, s.msg);
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            catch (Exception err)
            {
                this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000018/*系统出现异常[{0}]，请联系系统维护人员。*/, err.Message);
                this.DialogResult = DialogResult.None;
            }
            this.statusBarPanel1.Text = GC.GCRS.GCRSC0000009/*处理成功。*/;
            this.DialogResult = DialogResult.OK;
            this.Close();
            return;
        }

        /// <summary>
        /// 返送取消按钮事件
        /// <para></para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>无</returns>
        private void efBtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region 内部函数

        /// <summary>
        /// 查询制造命令号
        /// <para>查询制造命令号,初始化下拉框</para>
        /// </summary>
        /// <param name=""></param>
        /// <returns>无</returns>
        private void QueryHtno()
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;
            int k = 0;
            try
            {
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("PONO", typeof(String));
                inBlock.Tables[0].Rows.Add(factory_div,pono);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "pssm18_sk_inq", inBlock);
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000043/*查询失败：{0}*/, s.msg);
                    return;
                }

                //初始化HTNO下拉框
                if (outBlock.Tables.Contains("HTNO"))
                {
                    //DataRow row = outBlock.Tables["HTNO"].NewRow();
                    k = 0;
                    efDevComboBoxEdit1.Properties.Items.Clear();
                    efDevComboBoxEdit2.Properties.Items.Clear();
                    while (k < outBlock.Tables["HTNO"].Rows.Count)
                    {
                        efDevComboBoxEdit1.Properties.Items.Add(outBlock.Tables[0].Rows[k]["HTNO"].ToString());
                        efDevComboBoxEdit2.Properties.Items.Add(outBlock.Tables[0].Rows[k]["SM_PLAN_NO"].ToString());
                        if(k == 0)
                        {
                            efDevComboBoxEdit2.Text = outBlock.Tables[0].Rows[k]["SM_PLAN_NO"].ToString();
                            efDevTextEdit1.Text = outBlock.Tables[0].Rows[k]["SM_PLAN_NOL2"].ToString();
                        }
                        k++;
                    }
                }

            }
            catch (Exception err)
            {
                this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000018/*系统出现异常[{0}]，请联系系统维护人员。*/, err.Message);
            }
        }

        /// <summary>
        /// 查询回退的位置
        /// <para>查询回退的位置,初始化下拉框</para>
        /// </summary>
        /// <param name=""></param>
        /// <returns>无</returns>
        private void ShowPos()
        {
            //初始化POSITION下拉框
            DataTable dt = new DataTable();
            int i = 0;

            dt.Columns.Add("STATION_NAME");
            dt.Columns.Add("AREA_ID");
            dt.Rows.Add();
            dt.Rows[i]["STATION_NAME"] = "未生产";
            dt.Rows[i]["AREA_ID"] = "0";
            dt.Rows.Add();
            i++;

            //dt.Rows[0]["STATION_NAME"] = PS.PSSM.PSSMC0000109/*吹炼前*/;
            dt.Rows[i]["STATION_NAME"] = "吹炼前";
            dt.Rows[i]["AREA_ID"] = "3";
            dt.Rows.Add();
            i++;

            dt.Rows[i]["STATION_NAME"] = "前一精炼前";
            dt.Rows[i]["AREA_ID"] = "4";
            dt.Rows.Add();
            i++;

            //dt.Rows[1]["STATION_NAME"] = PS.PSSM.PSSMC0000110/*开浇前*/;
            dt.Rows[i]["STATION_NAME"] = "开浇前";
            dt.Rows[i]["AREA_ID"] = "5";

            //DataRow row = outBlock.Tables["POSITION"].NewRow();
            efDevLookUpEdit1.Properties.DataSource = dt;
            efDevLookUpEdit1.Properties.Columns.Clear();
            //efDevLookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATION_NAME", PS.PSSM.PSSMC0000107/*设备名称*/));
            //efDevLookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AREA_ID", PS.PSSM.PSSMC0000111/*区域标识*/));
            efDevLookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATION_NAME", "设备名称"));
            efDevLookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AREA_ID", "区域标识"));
            efDevLookUpEdit1.Properties.ShowHeader = true;
            efDevLookUpEdit1.Properties.DisplayMember = "STATION_NAME";
            efDevLookUpEdit1.Properties.ValueMember = "AREA_ID";

        }
        #endregion



    }
}
