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
    /// 钢水返送
    /// <para> 选择熔炼号,设置返送钢水量,返送位置,返送日期；</para>
    /// </summary>
    /// Copyright: Baosight Software LTD.co Copyright (c) 2011
    /// Company: 上海宝信软件股份有限公司
    /// Author:  lijie
    /// Version: 1.0
    /// History:
    /// 2011-11-29 lijie [创建] 
    
    public partial class FormPSSM18R : EF.EFPopupForm
    {
        public FormPSSM18R()
        {
            InitializeComponent();
        }
        public string factory_div = " ";
        public string pono = " ";
        public string heat_no = " ";
        private string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。

        #region 窗体事件

        /// <summary>
        /// 画面初始化
        /// <para>查询熔炼号和返送位置</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>无</returns>
        private void FormPSSM21R_Load(object sender, EventArgs e)
        {
            if (EF.EF_Args.common_parameter_1.Trim() != "")
            {
                v_curr_part_name = EF.EF_Args.common_parameter_1;//当前画面的分区代码
            }
            QueryHtnoPos();
            this.efDevDateEdit1.EditValue = DateTime.Now;
            this.efDevComboBox_htno.Text = heat_no;
            this.efDevTextEdit1.Text = " ";
        }

        /// <summary>
        /// 返送确定按钮事件
        /// <para>校验输入项,钢水返送</para>
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
                if ( (efDevComboBox_htno.EditValue ==null) || (efDevComboBox_htno.EditValue.ToString().Trim() == ""))
                {
                    efDevComboBox_htno.Focus();
                    efDevComboBox_htno.ErrorIcon = (new ErrorProvider()).Icon.ToBitmap(); //设置惊叹号
                    efDevComboBox_htno.ErrorText = "熔炼号不能为空";
                   // efDevComboBox_htno.ErrorText = PS.PSSM.PSSMC0000095/*熔炼号不能为空。*/;
                    return;
                }
                if ((efDevSpinEdit1.EditValue == null) || (efDevSpinEdit1.EditValue.ToString().Trim() == "") || (efDevSpinEdit1.EditValue.ToString().Trim() == "0"))
                {
                    efDevSpinEdit1.EditValue = 0;
                    //efDevSpinEdit1.Focus();
                    //efDevSpinEdit1.ErrorIcon = (new ErrorProvider()).Icon.ToBitmap(); //设置惊叹号
                    //efDevSpinEdit1.ErrorText = "返送重量不能为空";
                    //efDevSpinEdit1.ErrorText = PS.PSSM.PSSMC0000092/*返送重量不能为空。*/;
                    //this.statusBarPanel1.Text = PS.PSSM.PSSMC0000092/*返送重量不能为空。*/;
                    //return;
                }
                if ((efDevLookUpEdit_pos.EditValue == null)||(efDevLookUpEdit_pos.ToString().Trim() == ""))
                {
                    efDevLookUpEdit_pos.EditValue = " ";
                    //efDevLookUpEdit_pos.Focus();
                    //efDevLookUpEdit_pos.ErrorIcon = (new ErrorProvider()).Icon.ToBitmap(); //设置惊叹号
                    //efDevLookUpEdit_pos.ErrorText = "返送位置不能为空";
                    //efDevLookUpEdit_pos.ErrorText = PS.PSSM.PSSMC0000093/*返送重量不能为空。*/;
                    //this.statusBarPanel1.Text = PS.PSSM.PSSMC0000093/*返送位置不能为空。*/;
                    //return;
                }
                if(efDevDateEdit1.DateTime.ToString("yyyyMMddHHmmss").Trim() == "" )
                {
                    efDevDateEdit1.EditValue = DateTime.Now;
                    //efDevDateEdit1.Focus();
                    //efDevDateEdit1.ErrorIcon = (new ErrorProvider()).Icon.ToBitmap(); //设置惊叹号
                    //efDevDateEdit1.ErrorText = "返送日期不能为空";
                    //efDevDateEdit1.ErrorText = PS.PSSM.PSSMC0000094/*返送重量不能为空。*/;
                    //this.statusBarPanel1.Text = PS.PSSM.PSSMC0000094/*返送日期不能为空。*/;
                    //return;
                }

                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("HTNO", typeof(String));
                inBlock.Tables[0].Columns.Add("RETURNWT", typeof(String));
                inBlock.Tables[0].Columns.Add("RETURNPOS", typeof(String));
                inBlock.Tables[0].Columns.Add("DATE", typeof(String));
                inBlock.Tables[0].Columns.Add("RETHTNO", typeof(String));
                inBlock.Tables[0].Columns.Add("PONO", typeof(String));

                DataRow row = inBlock.Tables[0].NewRow();
                row["FACTORY_DIV"] = factory_div;
                row["PONO"] = pono;
                row["HTNO"] = efDevComboBox_htno.EditValue.ToString();
                row["RETURNWT"] = efDevSpinEdit1.EditValue.ToString();
                row["RETURNPOS"] = efDevLookUpEdit_pos.EditValue.ToString();
                row["DATE"] = efDevDateEdit1.DateTime.ToString("yyyyMMddHHmmss");
                row["RETHTNO"] = efDevTextEdit1.EditValue.ToString();
                inBlock.Tables[0].Rows.Add(row);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18r_rt_upd", inBlock);
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
        /// 查询熔炼号和返送位置
        /// <para>查询熔炼号和返送位置,初始化下拉框</para>
        /// </summary>
        /// <param name=""></param>
        /// <returns>无</returns>
        private void QueryHtnoPos()
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;
            int k = 0;
            try
            {
                inBlock.Tables[0].Columns.Add("FACTORY_DIV", typeof(String));
                inBlock.Tables[0].Columns.Add("HEAT_NO", typeof(String));
                inBlock.Tables[0].Rows.Add(factory_div,heat_no);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18r_rt_inq", inBlock);
                s = outBlock.GetSys();
                if (s.flag < 0)
                {
                    this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000043/*查询失败：{0}*/, s.msg);
                    return;
                }

                //初始化熔炼号下拉框
                if (outBlock.Tables.Contains("HTNO"))
                {
                    //DataRow row = outBlock.Tables["HTNO"].NewRow();
                    k = 0;
                    efDevComboBox_htno.Properties.Items.Clear();
                    while (k < outBlock.Tables["HTNO"].Rows.Count)
                    {
                        efDevComboBox_htno.Properties.Items.Add(outBlock.Tables[0].Rows[k]["HEAT_NO"].ToString());
                        k++;
                    }
                }
                //初始化返送位置下拉框
                //DataRow row = outBlock.Tables["POSITION"].NewRow();
                efDevLookUpEdit_pos.Properties.DataSource = outBlock.Tables["POSITION"];
                efDevLookUpEdit_pos.Properties.Columns.Clear();
                //efDevLookUpEdit_pos.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATION_NAME", PS.PSSM.PSSMC0000107/*设备名称*/));
                //efDevLookUpEdit_pos.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEV_CODE", PS.PSSM.PSSMC0000108/*设备代码*/));
                efDevLookUpEdit_pos.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATION_NAME", "设备名称"));
                efDevLookUpEdit_pos.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEV_CODE", "设备代码"));
                efDevLookUpEdit_pos.Properties.ShowHeader = true;
                efDevLookUpEdit_pos.Properties.DisplayMember = "STATION_NAME";
                efDevLookUpEdit_pos.Properties.ValueMember = "DEV_CODE";

            }
            catch (Exception err)
            {
                this.statusBarPanel1.Text = string.Format(GC.GCRS.GCRSC0000018/*系统出现异常[{0}]，请联系系统维护人员。*/, err.Message);
            }
        }
        #endregion

       
    }
}
