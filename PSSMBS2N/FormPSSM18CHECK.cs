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
    public partial class FormPSSM18CHECK : EF.EFFormBase
    {
        public FormPSSM18CHECK()
        {
            InitializeComponent();
        }
        public string factory_div = " ";
        public string v_curr_part_name = "BSMES"; //this.ef_args.formPartition; //当前画面的分区代码。
        string flag;

        private void FormPSSM18CHECK_Load(object sender, EventArgs e)
        {
            if (EF.EF_Args.common_parameter_1.Trim() != "")
            {
                v_curr_part_name = EF.EF_Args.common_parameter_1;//当前画面的分区代码
            }
        }
        

        #region efButton3_Click
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void efButton1_Click(object sender, EventArgs e)
        {
            flag = this.efDevRadioGroup1.EditValue.ToString();
            EF.EF_Args.common_parameter_9 = flag;
            this.Close();       
        }
        #endregion

        public delegate void btnClickEventHandler(string flag);
        public btnClickEventHandler btnClickEvent = null;

    }
}
