using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.calitha.goldparser;
using com.calitha.commons;

namespace compiler
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        MyParser pars;
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            pars= new MyParser(Application.StartupPath + "\\prolog.cgt");
            pars.Parse(richTextBox1.Text);
            if (pars.message == "")
                richTextBox2.Text = "correct";
            else
                richTextBox2.Text = pars.message;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
