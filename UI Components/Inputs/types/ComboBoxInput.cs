using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth.Util.UI_Components.Inputs.types
{
    public class ComboBoxInput : SingleInput<ComboBox>
    {
        public ComboBoxInput(string label, int x, int y, int width, List<string> items) : base(label, x, y, width)
        {
            control = new ComboBox();

            control.Size = new Size(width, 50);
            control.Location = new Point(x, y);
            control.Font = new Font("Segoe UI", 18);

            control.Items.AddRange(items.ToArray());
        }

        public override object GetValue()
        {
            return control.SelectedItem;
        }
    }
}
