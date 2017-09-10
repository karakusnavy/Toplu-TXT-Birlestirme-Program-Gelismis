using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxtBirlestirme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] isimsoyisim = new String[listBox1.Items.Count];

            listBox1.Items.CopyTo(isimsoyisim, 0);
            System.IO.File.WriteAllLines("karakus.txt", isimsoyisim);
            System.Diagnostics.Process.Start(Application.StartupPath);
        }
        int a = 0, b = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string tarih = DateTime.Now.Month.ToString();
            if (tarih!="9")
            {
                MessageBox.Show("Program Lisansı Bitmiştir. Lütfen Yenileyin Skype: idarki38");
                Application.Exit();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                StreamReader oku = new StreamReader(openFileDialog1.FileName);
                OpenFileDialog x = new OpenFileDialog();
                x.Multiselect = true;
                if (x.ShowDialog() == DialogResult.OK)
                {
                    string[] result = x.FileNames;
                    for (int i = 0; i < result.Length; i++)
                    {
                        var satirlar = File.ReadLines(result[i]);
                        foreach (var satir in satirlar)
                        {
                            listBox1.Items.Add(satir);
                        }
                        listBox1.Items.Add("");
                        listBox1.Items.Add(textBox1.Text);
                        listBox1.Items.Add("");
                        int sonuc;
                        sonuc = listBox1.FindStringExact(textBox2.Text);
                        if (sonuc < 0) { }

                        else
                            listBox1.SelectedIndex = sonuc;
                        listBox1.Items.Remove(listBox1.SelectedItem);
                        int sonuc2;
                        sonuc2 = listBox1.FindStringExact(textBox3.Text);
                        if (sonuc2 < 0) { }

                        else
                            listBox1.SelectedIndex = sonuc2;
                        listBox1.Items.Remove(listBox1.SelectedItem);

                    }
                    a++;
                    label5.Text = a.ToString();
                    
                    label4.Text = listBox1.Items.Count.ToString();
                    
                }
            }
        }
    }
}
