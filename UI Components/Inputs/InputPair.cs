using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McClean_Teeth.Util.UI_Components.Inputs.types;

namespace McClean_Teeth.Util.UI_Components.Inputs
{
    public class InputPair<T> where T : UIInput
    {
        public T First { get; }
        public T Second { get; }

        public InputPair(T first, T second)
        {
            this.First = first;
            this.Second = second;
        }
    }
}
