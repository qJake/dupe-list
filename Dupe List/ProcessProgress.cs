using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DupeList
{
    public partial class ProcessProgress : Form
    {
        public ProcessProgress(int maxValue, string verb)
        {
            InitializeComponent();

            progressBar.Maximum = maxValue;

            lVerb.Text = verb + "...";
        }

        public void UpdateProgress(int amount)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate()
                {
                    _updateProg(amount);
                });
            }
            else
            {
                _updateProg(amount);
            }
        }

        private void _updateProg(int amt)
        {
            progressBar.Value = (amt > progressBar.Maximum) ? progressBar.Maximum : amt;
            Application.DoEvents();
        }
    }
}
