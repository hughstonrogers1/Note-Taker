using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTaking
{
    public partial class textBox : Form
    {
        DataTable table;
        public textBox()
        {
            InitializeComponent();
        }

        private void textBox_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Messages", typeof(string));

            dataGridView1.DataSource = table;

            dataGridView1.Columns["Messages"].Visible = false;
            dataGridView1.Columns["Title"].Width = 230;
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            textTitle.Clear();
            textMessage.Clear();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(textTitle.Text, textMessage.Text);

            textTitle.Clear();
            textMessage.Clear();
        }

        private void bRead_Click(object sender, EventArgs e)
        {
            int readText = dataGridView1.CurrentCell.RowIndex;
            if (readText > -1)
            {
                textTitle.Text = table.Rows[readText].ItemArray[0].ToString();
                textMessage.Text = table.Rows[readText].ItemArray[1].ToString();
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            int readText = dataGridView1.CurrentCell.RowIndex;

            table.Rows[readText].Delete();

        }
    }
}
