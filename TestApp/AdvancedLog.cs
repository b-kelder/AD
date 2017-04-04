using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class AdvancedLog : Form
    {
        public AdvancedLog()
        {
            InitializeComponent();
        }

        public void printUnsorted(IComparable[] testData)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < testData.Length; i++)
            {
                sb.AppendLine(testData[i].ToString());
            }
            unsortedLog.AppendText(sb.ToString());
        }

        public void printSorted(IComparable[] testData)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < testData.Length; i++)
            {
                sb.AppendLine(testData[i].ToString());
            }
            sortedLog.AppendText(sb.ToString());
            sortedLog.SelectionStart = 0;
            sortedLog.SelectionLength = 1;
            sortedLog.ScrollToCaret();
        }
    }
}
