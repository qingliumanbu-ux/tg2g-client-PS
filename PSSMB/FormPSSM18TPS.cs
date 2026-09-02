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
    /// 出钢计划优化弹出框
    /// <para> 1.提供时间优化及全局优化的选项；</para>
    /// <para> 2.调用优化模型</para>
    /// </summary>
    /// Copyright: Baosight Software LTD.co Copyright (c) 2011
    /// Company: 上海宝信软件股份有限公司
    /// Author:  HYF
    /// Version: 1.0
    /// History:
    /// 2011-12-21 HYF [创建] 

    public partial class FormPSSM18TPS : EF.EFFormBase
    {
        public string factory_div = "";
        public int mode = 0;
        private string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。


         
        public FormPSSM18TPS()
        {
            InitializeComponent();

            if (EF.EF_Args.common_parameter_1.Trim()!="")
            {
                v_curr_part_name = EF.EF_Args.common_parameter_1;//当前画面的分区代码
            }
            
        }

        #region 按钮事件

        /// <summary>
        /// 退出按钮
        /// <para>退出弹出框 </para>
        /// </summary>
        private void efButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 优化按钮
        /// <para>根据选择项分别传入不同参数 </para>
        /// <para>优化完成后关闭窗口 </para>
        /// </summary>
        /// <param name="factory_div">主工序代码</param>
        /// <param name="mode">优化模式</param>
        /// <returns>返回优化是否成功信息</returns>
        private void efButton1_Click(object sender, EventArgs e)
        {
            //判断选择
            if (efDevRadioGroup1.SelectedIndex == 0) //全局
            {
                mode = 0;
            }
            else if (efDevRadioGroup1.SelectedIndex == 1)//时间
            {
                mode = 1;
            }
            else
            {
                mode = 0;
            }
            EI.EIInfo inBlock = new EI.EIInfo();
            EI.EIInfo outBlock;
            EI.EIInfo.eiinfo_sys s;

            try
            {
                if (mode == 2) //mode=2 局部编制，传入选择炉次
                {
                    inBlock = (EI.EIInfo)EF.EF_Args.common_object_1;
                }

                inBlock.Tables.Add("PLAN");
                inBlock.Tables["PLAN"].Columns.Add("FACTORY_DIV");
                inBlock.Tables["PLAN"].Columns.Add("MODE");
                inBlock.Tables["PLAN"].Rows.Add(factory_div, mode);

                outBlock = EI.EIManager.Instance.CallService(v_curr_part_name,"pssm18_create", inBlock);
                s = outBlock.GetSys();

                if (s.flag < 0)
                {
                    this.efStatusBar1.Text = string.Format(GC.GCRS.GCRSC0000015/*系统出现异常，请联系系统维护人员。*/, s.msg);
                    this.DialogResult = DialogResult.None;
                    return;
                }

            }
            catch (Exception err)
            {
                this.efStatusBar1.Text = string.Format(GC.GCRS.GCRSC0000015/*系统出现异常，请联系系统维护人员。*/, err.Message);
                this.DialogResult = DialogResult.None;
                return;
            }

            this.efStatusBar1.Text = GC.GCRS.GCRSC0000009/*处理成功。*/;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

    }
}
