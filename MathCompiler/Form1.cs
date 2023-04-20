using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathCompiler
{
    public partial class Form1 : Form
    {
        Graphics g;

        Pen pen;
        Pen pen2;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            pen = new Pen(Color.Blue, 1);
            pen2 = new Pen(Color.Black, 1);
        }



        static string output = "";
        private void btnDo_Click(object sender, EventArgs e)
        {
            output = toPostfix.Postfix(txtFunction.Text);
            g.Clear(Color.White);
            panel1.ResetText();
            g.DrawLine(pen2, 0, 180, 360, 180);
            g.DrawLine(pen2, 180, 0, 180, 360);
            for (int i = -180; i <= 180; i++)
            {
                float j = Calculate.calculate(output, i) * -1;
                try
                {
                    
                    g.DrawRectangle(pen, i + 180, j*10 + 180, 1, 1);
                }
                catch { break; }

            }
            //g.DrawRectangle(pen,0,0,1,1);
            //g.DrawRectangle(pen, , Calculate.calculate(output, i), i + 1, Calculate.calculate(output, i) + 1);

        }        

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            txtAnswer.Text = Calculate.calculate(output, double.Parse(textX.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("hello");
            Console.Read();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }






        //Node root = newNode(0);

        //string read = "";
        //string function = txtFunction.Text;
        //for (int i = 0; i < function.Length; i++)
        //{
        //    read += function[i];
        //    if (read == "x")
        //    {
        //        root.child.Add(newNode(0));
        //    }
        //    if (isNumber(read))
        //    {
        //        root.child.Add(newNode(int.Parse(read)));
        //    }

        //    if (function[i + 1] == ' ' || i + 1 == function.Length)
        //    {
        //        for (int j = 0; j < Reserved.keywords.Count; j++)
        //        {
        //            if (read == Reserved.keywords[j])
        //            {
        //                if (Reserved.leftAndright.Contains(j))
        //                {
        //                    Node node = new Node() { };
        //                }

        //            }
        //        }
        //    }
        //}

        //Node newNode(int key)
        //{
        //    Node temp = new Node();
        //    temp.key = key;
        //    return temp;
        //}
    }
}
