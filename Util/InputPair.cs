using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth
{
    public class InputPair
    {
        private TextBox _first;
        private TextBox _second;

        public InputPair(TextBox first, TextBox second)
        {
            _first = first;
            _second = second;
        }

        public TextBox GetFirst()
        {
            return _first;
        }

        public TextBox GetSecond()
        {
            return _second;
        }

        // Optional convenience (you'll likely want this)
        public (string First, string Second) GetValues()
        {
            return (_first.Text, _second.Text);
        }
    }
}
