using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.Odbc;
using LINE_Backup_Restore.lib;

namespace LINE_Backup_Restore.form
{
    public partial class backup : UserControl
    {

        lib.backupData data;

        public backup()
        {
            InitializeComponent();
        }

        private void SFOPButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "LINEバックアップファイル(*.txt)|*.txt";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFilePathBox.Text = fileDialog.FileName;
            }
        }

        private void analysisButton_Click(object sender, EventArgs e)
        {
            string fileName = sourceFilePathBox.Text;
            if (fileName == string.Empty)
            {
                MessageBox.Show("ファイルが選択されていません、選択しなおしてください。", "ファイルエラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var reader = new StreamReader(fileName, Encoding.GetEncoding("UTF-8")))
            {
                int i = 0;
                int emptyCoutn = 0;
                string line;
                string sParson = "";
                string emptyText = "";
                data = new lib.backupData();

                while ((line = reader.ReadLine()) != null)
                {
                    if (i == 0)
                        data.Header = line;
                    else if (i == 1)
                        data.SaveDate = line;
                    else
                    {
                        if (line == string.Empty)
                        {
                            emptyCoutn++;
                            //data.SendMessage.Add(line);
                            emptyText += "\r\n";
                        }
                        else
                        {
                            string[] messageData = line.Split('\t');
                            int msDataLenght = messageData.Length;
                            if (msDataLenght == 1)
                            {
                                if (Regex.IsMatch(line,
                                    @"^(?<year>[0-9]{4}|[0-9]{2})(?<datesep>\/|-|\.)" +
                                    @"(?<month>0?[1-9]|1[012])\k<datesep>" +
                                    @"(?<day>0?[1-9]|[12][0-9]|3[01])"))
                                {
                                    //data.SendMessage.RemoveAt(
                                    //    data.SendMessage.Count);
                                    if (emptyText != string.Empty &&
                                        data.SendMessage.Count != 0)
                                        data.SendMessage[data.SendMessage.Count - 1]
                                            += "\r\n" + emptyText.Remove(emptyText.Length - 2, 2);

                                    data.SendMessage.Add(line);
                                    emptyCoutn = 0;
                                    emptyText = "";
                                }
                                //else if (emptyCoutn != 0)
                                else
                                {
                                    emptyCoutn++;
                                    emptyText += line + "\r\n";
                                }
                            }
                            else if (msDataLenght == 2)
                            {
                                if (emptyCoutn != 0)
                                {
                                    data.SendMessage[data.SendMessage.Count - 1]
                                        += "\r\n" + emptyText.Remove(emptyText.Length - 2, 2);
                                    emptyCoutn = 0;
                                    emptyText = "";
                                }
                                data.SendMessage.Add(line);
                            }
                            else if (msDataLenght == 3)
                            {
                                if (!sParson.Contains(messageData[1]))
                                {
                                    sParson += messageData[1];
                                    data.SendParson.Add(messageData[1]);
                                }
                                if (emptyCoutn != 0)
                                {
                                    data.SendMessage[data.SendMessage.Count - 1]
                                        += "\r\n" + emptyText.Remove(emptyText.Length - 2, 2);
                                    emptyCoutn = 0;
                                    emptyText = "";
                                }
                                data.SendMessage.Add(line);
                            }
                        }

                    }
                    i++;
                }
                if (emptyText != string.Empty)
                {
                    data.SendMessage[data.SendMessage.Count - 1] += emptyText;
                }

                this.SuspendLayout();

                meSendListBox.Items.Clear();
                logListBox.Items.Clear();

                foreach (string tmp in data.SendParson)
                    meSendListBox.Items.Add(tmp);

                foreach (string tmp in data.SendMessage)
                {
                    logListBox.Items.Add(tmp);
                    logListBox.SetItemChecked(
                        logListBox.Items.Count - 1, true);
                }

                this.ResumeLayout();
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            if (meSendListBox.Items.Count == 0 ||
                logListBox.Items.Count == 0)
            {
                MessageBox.Show("バックアップデータの解析を行ってください。", "解析エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string htmlWriteText = "<h1 class=\"Title_H\">" + data.Header + "</h1>\n";

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = data.Header;
            save.Filter = "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";

            if (save.ShowDialog() == DialogResult.OK)
            {
                string me = "";
                for (int i = 0; i < meSendListBox.Items.Count; i++)
                {
                    if (meSendListBox.GetItemChecked(i))
                    {
                        me = meSendListBox.Items[i].ToString();
                        break;
                    }
                }

                if (me == string.Empty)
                {
                    MessageBox.Show("自分の名前を選択して、チェックボックスをオンにしてください。", "選択されていません",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                for (int i = 0; i < logListBox.Items.Count; i++)
                {
                    if (logListBox.GetItemChecked(i))
                    {
                        string logText = logListBox.Items[i].ToString();
                        if (Regex.IsMatch(logText,
                                    @"^(?<year>[0-9]{4}|[0-9]{2})(?<datesep>\/|-|\.)" +
                                    @"(?<month>0?[1-9]|1[012])\k<datesep>" +
                                    @"(?<day>0?[1-9]|[12][0-9]|3[01])"))
                        {
                            htmlWriteText += lib.html.DateTimeText_Create(logText);
                        }
                        else if (logText.Split('\t').Length == 2)
                        {
                            string[] tmp = logText.Split('\t');
                            string writeText = tmp[0] + "<br>" + tmp[1];
                            htmlWriteText += lib.html.DateTimeText_Create(writeText);
                        }
                        else
                        {
                            string[] message = logText.Split('\t');
                            if (message[1] == me)
                                htmlWriteText +=
                                    lib.html.SayRightText_Create(message[1], message[2], message[0]);
                            else
                                htmlWriteText +=
                                    lib.html.SayLeftText_Create(message[1], message[2], message[0]);
                        }
                    }
                }

                lib.html.Title_Create(data.Header);
                lib.html.CSS_Set(customCSSBox.Text);
                htmlWriteText = lib.html.HTMLText_Create(htmlWriteText);
                lib.html.HTMLFile_Create(save.FileName, htmlWriteText);

                MessageBox.Show("ファイルの変換に成功", "完了",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void backup_Load(object sender, EventArgs e)
        {
            if (File.Exists("file\\custom.css"))
            {
                using (StreamReader sr = new StreamReader(
                    "file\\custom.css", Encoding.GetEncoding("UTF-8")))
                {
                    customCSSBox.Text = sr.ReadToEnd();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Encoding sjisEnc = Encoding.GetEncoding("UTF-8");
            using (StreamWriter writer = new StreamWriter("file\\custom.css", false, sjisEnc))
            {
                writer.Write(customCSSBox.Text);
            }
        }
    }
}
