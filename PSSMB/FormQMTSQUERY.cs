using BE2.Common;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Container;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Services;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using EF;
using EI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Services;


namespace QM
{

    public partial class FormQMTSQUERY : EF.EFFormDX
    {
        private int iPageIndex = 1;        // 当前页数
        private int iPageCount = 0;        // 总页数
        private int iPageNum = 0;        // 数量11
        private string formName;
        private string mat_line_type;
        private string mat_kind;
        private string v_curr_part_name = " ";
        private EI.EIInfo keepMid = new EI.EIInfo();
        private EI.EIInfo keep_value = new EI.EIInfo();
        private string old_text;
        public FormQMTSQUERY()
        {
            InitializeComponent();
        }

        private async void FormQMTSQUERY_Load(object sender, EventArgs e)
        {
            try
            {
                v_curr_part_name = this.ef_args.formPartition;
                ((RichEditControl)this.efDevRichEditControl1).ReplaceService<ISyntaxHighlightService>((ISyntaxHighlightService)new CustomSyntaxHighlightService(((RichEditControl)this.efDevRichEditControl1).Document));
                query();
                old_text = efDevRichEditControl1.Text;
            }
            catch (Exception ex)
            {
                EF.EFMessageBox.Show(ex.Message);
            }
        }


        private void FormQMTSQUERY_EF_DO_F2(object sender, EF_Args e)
        {
            string arr = this.efDevRichEditControl1.Text.Replace("\r\n", " ");
            var selection = efDevRichEditControl1.Document.Selection;
            string str = this.efDevRichEditControl1.Text;


            if (selection.Length > 0)
            {
                int arr_len = selection.Length <= arr.Length ? selection.Length : arr.Length;
                int start = selection.Start.ToInt();
                str = arr.Substring(start, arr_len);
                str = str.Replace("\r", " ");
                str = str.Replace("\n", " ");
            }
            if (!str.Trim().ToLower().StartsWith("select")
                && !str.Trim().ToLower().StartsWith("with"))
            {
                ((EFFormMain)this).EFMsgInfo = "禁止使用非查询语句";
                MessageUtils.ShowWarningDialog(((EFFormMain)this).EFMsgInfo);
                return;
            }
            EI.EIInfo inBlock = new EI.EIInfo();
            inBlock.Tables[0].Columns.Add("SQL", typeof(string));
            inBlock.Tables[0].Rows.Add(str);
            var outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "qmtsquery_inq", inBlock);
            if (outBlock.sys_info.flag < 0)
            {
                ((EFFormMain)this).EFMsgInfo = outBlock.sys_info.msg;
                MessageUtils.ShowWarningDialog(((EFFormMain)this).EFMsgInfo);
                return;
            }
            ((GridControl)this.efDevGrid1).DataSource = (object)((DataSet)outBlock).Tables[0];
            ((GridControl)this.efDevGrid1).DefaultView.PopulateColumns();
            this.gridView1.OptionsView.BestFitMode = GridBestFitMode.Fast;
            if (((DataSet)outBlock).Tables[0].Rows.Count * ((DataSet)outBlock).Tables[0].Columns.Count <= 1000000)
                this.gridView1.BestFitColumns();
        }

        private void FormQMTSQUERY_EF_DO_F3(object sender, EF_Args e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            var outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "qmts_send_all", inBlock);
            if (outBlock.sys_info.flag < 0)
            {
                ((EFFormMain)this).EFMsgInfo = outBlock.sys_info.msg;
                MessageUtils.ShowWarningDialog(((EFFormMain)this).EFMsgInfo);
                return;
            }
        }
        #region 保存
        private void FormQMTSQUERY_EF_DO_F5(object sender, EF_Args e)
        {

            if (old_text.Trim() == efDevRichEditControl1.Text.Trim())
            {
                this.EFMsgInfo = "当前数据无更改!";
                int num2 = (int)EFMessageBox.Show(this.EFMsgInfo, EF_Args.epEname, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            EI.EIInfo inBlock = new EI.EIInfo();
            // 新增一个Table,存放要新增的数据库表名 
            string str = efDevRichEditControl1.Text.Trim();
            var arr = str.Split(new string[] { "\r", "\n" }, 2, StringSplitOptions.RemoveEmptyEntries);
            inBlock.Tables[0].Columns.Add("USER_ID");
            inBlock.Tables[0].Columns.Add("SQL_CONTEXT");
            foreach (var str1 in arr)
            {
                inBlock.Tables[0].Rows.Add(EFUserId, str1);
            }
            EI.EIInfo outBlock = new EI.EIInfo();
            if (inBlock.Tables[0].Rows.Count <= 0)
            {
                this.EFMsgInfo = "当前无数据";
                int num2 = (int)EFMessageBox.Show(this.EFMsgInfo, EF_Args.epEname, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "qmtsquery_upd", inBlock);
            if (outBlock.sys_info.flag < 0)
            {
                int sqlcode = outBlock.sys_info.sqlcode;
                if (sqlcode == 1)
                {
                    this.EFMsgInfo = "存在重复数据，不能进行新增";
                    this.ef_args.buttonStatusHold = true;
                    return;
                }
                this.EFMsgInfo = outBlock.sys_info.msg;
                this.ef_args.buttonStatusHold = true;
                return;
            }


        }
        #endregion

        private void FormQMTSQUERY_EF_DO_F4(object sender, EF_Args e)
        {
            EI.EIInfo inBlock = new EI.EIInfo();
            inBlock.Tables[0].Columns.Add("MAT_NO", typeof(string));
            inBlock.Tables[0].Rows.Add(this.efDevRichEditControl1.Text);
            var outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "qmts_test", inBlock);
            if (outBlock.sys_info.flag < 0)
            {
                ((EFFormMain)this).EFMsgInfo = outBlock.sys_info.msg;
                MessageUtils.ShowWarningDialog(((EFFormMain)this).EFMsgInfo);
                return;
            }
        }
        private void query()
        {
            string str = "SELECT SQL_CONTEXT FROM TQMTSQUERY WHERE USER_ID = '" + EFUserId + "'";
            EI.EIInfo inBlock = new EI.EIInfo();
            inBlock.Tables[0].Columns.Add("SQL", typeof(string));
            inBlock.Tables[0].Rows.Add(str);
            var outBlock = EI.EIManager.Instance.CallService(v_curr_part_name, "qmtsquery_inq", inBlock);
            if (outBlock.sys_info.flag < 0)
            {
                ((EFFormMain)this).EFMsgInfo = outBlock.sys_info.msg;
                MessageUtils.ShowWarningDialog(((EFFormMain)this).EFMsgInfo);
                return;
            }
            string str_return = "";
            for (int i = 0; i < outBlock.Tables[0].Rows.Count; i++)
            {
                str_return += outBlock.Tables[0].Rows[i][0];
                if (i < outBlock.Tables[0].Rows.Count - 1)
                {
                    str_return += "\r\n";
                }
            }
            efDevRichEditControl1.Text = str_return;
        }

        private void efButton1_Click(object sender, EventArgs e)
        {
            this.efDevRichEditControl1.Text = " ";
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = "C://";

            fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            fileDialog.FilterIndex = 1;

            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)

            {
                string s_con = string.Empty;
                using (StreamReader sr = new StreamReader(fileDialog.FileName))
                {

                    string line;
                    // 从文件读取并显示行，直到文件的末尾 
                    while ((line = sr.ReadLine()) != null)
                    {
                        s_con += line + "\r\n";
                    }
                }
                efDevRichEditControl1.Text = s_con;

            }
        }

        private void efButton2_Click(object sender, EventArgs e)
        {
            string[] arr = this.efDevRichEditControl1.Text.Replace("\r\n", ",").Split(',');
            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.InitialDirectory = "C://";

            fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            fileDialog.FilterIndex = 1;

            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)

            {

                using (StreamWriter sw = new StreamWriter(fileDialog.FileName))
                {

                    foreach (string s in arr)
                    {
                        sw.WriteLine(s);

                    }
                }


            }

        }




        /// <summary>
        /// 自定义语法高亮服务
        /// </summary>
        public class CustomSyntaxHighlightService : ISyntaxHighlightService
        {
            #region 私有变量

            //文档
            private readonly Document _document;
            //默认语法高亮颜色
            private readonly SyntaxHighlightProperties _defaultSettings = new SyntaxHighlightProperties() { ForeColor = Color.Brown };
            //关键字语法高亮颜色
            private readonly SyntaxHighlightProperties _keywordSettings = new SyntaxHighlightProperties() { ForeColor = Color.Blue };
            //字符串语法高亮颜色
            private readonly SyntaxHighlightProperties _stringSettings = new SyntaxHighlightProperties() { ForeColor = Color.Black };

            readonly string[] _keywords = { "select", "from", "left join", "where", "on", "right join", "full join", "trim", "=", "(", ")", "like", ">" };

            #endregion

            #region 构造函数

            public CustomSyntaxHighlightService(Document document)
            {
                this._document = document;
            }

            #endregion

            #region 接口成员
            public void ForceExecute()
            {
                Execute();
            }

            public void Execute()
            {
                _document.ApplySyntaxHighlight(ParseTokens());
            }

            #endregion

            #region 私有函数

            /// <summary>
            /// 解析标记
            /// </summary>
            /// <returns>语法高亮标记列表</returns>
            private List<SyntaxHighlightToken> ParseTokens()
            {
                List<SyntaxHighlightToken> tokens = new List<SyntaxHighlightToken>();
                // 搜索标记
                DocumentRange[] ranges = _document.FindAll("\"", SearchOptions.None);
                for (int i = 0; i < ranges.Length / 2; i++)
                {
                    tokens.Add(new SyntaxHighlightToken(ranges[i * 2].Start.ToInt(),
                        ranges[i * 2 + 1].Start.ToInt() - ranges[i * 2].Start.ToInt() + 1, _stringSettings));
                }
                // 搜索关键词
                foreach (var t in _keywords)
                {
                    ranges = _document.FindAll(t, SearchOptions.None);
                    foreach (var t1 in ranges)
                    {
                        if (!IsRangeInTokens(t1, tokens))
                            tokens.Add(new SyntaxHighlightToken(t1.Start.ToInt(), t1.Length, _keywordSettings));
                    }
                }
                // 排序
                tokens.Sort(new SyntaxHighlightTokenComparer());
                // 添加
                AddPlainTextTokens(tokens);
                return tokens;
            }

            /// <summary>
            /// 添加明文标记
            /// </summary>
            /// <param name="tokens">标记列表</param>
            private void AddPlainTextTokens(List<SyntaxHighlightToken> tokens)
            {
                int count = tokens.Count;
                if (count == 0)
                {
                    tokens.Add(new SyntaxHighlightToken(0, _document.Range.End.ToInt(), _defaultSettings));
                    return;
                }
                tokens.Insert(0, new SyntaxHighlightToken(0, tokens[0].Start, _defaultSettings));
                for (int i = 1; i < count; i++)
                {
                    tokens.Insert(i * 2, new SyntaxHighlightToken(tokens[i * 2 - 1].End, tokens[i * 2].Start - tokens[i * 2 - 1].End, _defaultSettings));
                }
                tokens.Add(new SyntaxHighlightToken(tokens[count * 2 - 1].End, _document.Range.End.ToInt() - tokens[count * 2 - 1].End, _defaultSettings));
            }

            /// <summary>
            /// 是否在DocumentRange范围内
            /// </summary>
            /// <param name="range">DocumentRange范围</param>
            /// <param name="tokens">标记</param>
            /// <returns></returns>
            private bool IsRangeInTokens(DocumentRange range, List<SyntaxHighlightToken> tokens)
            {
                foreach (var t in tokens)
                {
                    if (range.Start.ToInt() >= t.Start && range.End.ToInt() <= t.End)
                        return true;
                }

                return false;
            }

            #endregion
        }

        #region 比较器
        public class SyntaxHighlightTokenComparer : IComparer<SyntaxHighlightToken>
        {
            public int Compare(SyntaxHighlightToken x, SyntaxHighlightToken y)
            {
                if (x == null || y == null)
                    return 0;
                return x.Start - y.Start;
            }
        }
        #endregion
    }
}
