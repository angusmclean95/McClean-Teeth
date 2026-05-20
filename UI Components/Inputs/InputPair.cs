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
        private T first;
        private T second;

        public InputPair(T first, T second)
        {
            this.first = first;
            this.second = second;
        }

        public T GetFirst()
        {
            return first;
        }

        public T GetSecond()
        {
            return second;
        }
    }
}
