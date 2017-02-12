using System;
using System.Windows.Forms;

namespace Moonfish.Forms
{
    public partial class InputBox : Form
    {
        public int Value { get; set; }
        public InputBox()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Value = (int)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close(  );
        }
    }
}
