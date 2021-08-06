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
using System.Collections;
using System.Text.RegularExpressions;

namespace LINE_Backup_Restore.form
{
    public partial class backup_aplit : UserControl
    {
        public backup_aplit()
        {
            InitializeComponent();
        }

        string FileName = "";
        ArrayList ReadTextList;
        string Head = "";
        string SaveDate = "";
        int LineCount = 0;

        private void SFOButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "LINEバックアップファイル(*.txt)|*.txt";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                OFSBox.Text = fileDialog.FileName;
                FileName = Path.GetFileNameWithoutExtension(OFSBox.Text);

                string line = "";
                ArrayList dateList = new ArrayList();

                using (var reader = new StreamReader(OFSBox.Text, Encoding.GetEncoding("UTF-8")))
                {
                    ReadTextList = new ArrayList();
                    int i = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (Regex.IsMatch(line,
                                    @"^(?<year>[0-9]{4}|[0-9]{2})(?<datesep>\/|-|\.)" +
                                    @"(?<month>0?[1-9]|1[012])\k<datesep>" +
                                    @"(?<day>0?[1-9]|[12][0-9]|3[01])"))
                        {
                            dateList.Add(line);
                        }

                        if (i == 0)
                            Head = line;
                        else if (i == 1)
                            SaveDate = line;
                        else
                            ReadTextList.Add(line);

                        i++;
                    }

                    LineCount = i;
                }

                dateFileListBox.Items.Clear();

                foreach (string tmp in dateList)
                {
                    dateFileListBox.Items.Add(tmp);
                    dateFileListBox.SetItemChecked(
                        dateFileListBox.Items.Count - 1, true);
                }
            }
        }

        private void SAButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.RootFolder = Environment.SpecialFolder.Desktop;

            if (folder.ShowDialog(this) == DialogResult.OK)
            {
                SFDBox.Text = folder.SelectedPath;
            }
        }

        private void convartButton_Click(object sender, EventArgs e)
        {
            Encoding sjisEnc = Encoding.GetEncoding("UTF-8");

            int j = 0;
            int writeCount = 0;
            for (int i = 0; i < dateFileListBox.Items.Count; i++)
            {
                if (dateFileListBox.GetItemChecked(i))
                {
                    string nameTmp = dateFileListBox.Items[i].ToString();
                    nameTmp = nameTmp.Replace("/", "_");
                    string fileName =
                        SFDBox.Text + "\\" + FileName + " - " + nameTmp + ".txt";
                    using (StreamWriter writer = new StreamWriter(fileName, false, sjisEnc))
                    {
                        writer.WriteLine(Head);
                        writer.WriteLine(SaveDate);
                        writer.WriteLine();
                        
                        bool writeCheck = false;

                        for (int k = writeCount; k < ReadTextList.Count; k++)
                        {
                            if (Regex.IsMatch((string)ReadTextList[k],
                                    @"^(?<year>[0-9]{4}|[0-9]{2})(?<datesep>\/|-|\.)" +
                                    @"(?<month>0?[1-9]|1[012])\k<datesep>" +
                                    @"(?<day>0?[1-9]|[12][0-9]|3[01])"))
                            {
                                if ((string)ReadTextList[k] == dateFileListBox.Items[i].ToString())
                                {
                                    writeCheck = true;
                                }
                                else
                                {
                                    writeCount = k;
                                    break;
                                }
                            }

                            if (writeCheck)
                                writer.WriteLine(ReadTextList[k]);
                        }
                    }

                    j++;
                }
            }

            MessageBox.Show("変換作業完了", "完了",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
