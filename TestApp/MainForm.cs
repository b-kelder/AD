using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADLibrary.Collections;
using ADLibrary.Performance;

namespace TestApp
{
    public partial class MainForm : Form
    {
        PerformanceTester pt;

        public MainForm()
        {
            InitializeComponent();

            pt = new PerformanceTester(() =>
            {
                var al = new Arraylist<int>();
                for(int i = 0; i < 1000000; i++)
                {
                    al.add(i);
                }
            }, genericTestCallback);
        }

        private void genericTestCallback(long ms)
        {
            MessageBox.Show("Result: " + ms + "ms");
            logBox.Invoke(new Action(() =>
            {
                logBox.Text += ("Test result: " + ms + "ms\r\n");
            }));
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            pt.run();
        }
    }
}
