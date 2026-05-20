using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth.Util.UI_Components.Inputs.types
{
    public class ComboBoxInput : SingleControlInput<ComboBox>
    {
        public ComboBoxInput(
            string label,
            int x,
            int y,
            int width,
            List<string> items
        ) : base(label, x, y, width)
        {
            _control = new ComboBox();

            _control.Size = new Size(width, 50);
            _control.Location = new Point(x, y);
            _control.Font = new Font("Segoe UI", 18);

            _control.Items.AddRange(items.ToArray());
        }

        public override object GetValue()
        {
            return _control.SelectedItem;
        }
    }
}
