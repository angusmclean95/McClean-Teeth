using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth.Util.UI_Components.Inputs
{
    public abstract class UIInput
    {
        protected Label label;

        public abstract void AddToPanel(Panel panel);

        public abstract object GetValue();

        public virtual void SetPosition(int x, int y)
        {
        }
    }
}
