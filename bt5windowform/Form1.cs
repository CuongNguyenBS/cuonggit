using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bt5windowform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> list = new List<int>();
        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số trước", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                listBox1.Items.Add(textBox1.Text);
                list.Add(int.Parse(textBox1.Text));
                textBox1.Text = null;
                button2.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                textBox1.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar=='-' || e.KeyChar=='.')
            {
                e.Handled = false;
            }
            else { e.Handled = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Bạn phải chọn một số trong danh sách để xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                int x = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(x);
                list.RemoveAt(x);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int tong = 0;
            foreach (int item in list)
            {
                int x = item;
                tong += item;
            }
            label2.Text = tong.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int [] mang = list.ToArray();
            double max = mang[0];
           for(int i = 0; i < mang.Length; i++) {
            if(mang[i]>max)
                {
                    max = mang[i];
                }    
            }
            label3.Text = max.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            label2.Text = null;
            label3.Text = null;
            listBox1.Items.Clear();
            list.Clear();
        }
    }
}
