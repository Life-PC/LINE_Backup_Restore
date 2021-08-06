using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINE_Backup_Restore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void バックアップ解析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.backup backup = new form.backup();
            backup.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            backup.Parent = panel1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form.backup backup = new form.backup();
            backup.Dock = DockStyle.Fill;

            backup.Parent = panel1;
        }

        private void バックアップデータ分割ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.backup_aplit backup_Aplit = new form.backup_aplit();
            backup_Aplit.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            backup_Aplit.Parent = panel1;
        }
    }
}
