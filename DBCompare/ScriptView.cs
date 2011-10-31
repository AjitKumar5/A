using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBCompare
{
    public partial class ScriptView : Form
    {
        public ScriptView(string script)
        {
            InitializeComponent();
            txtScript.Text = script;
        }
    }
}
