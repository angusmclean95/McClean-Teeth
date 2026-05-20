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
        private T _first;
        private T _second;

        public InputPair(T first, T second)
        {
            _first = first;
            _second = second;
        }

        public T GetFirst()
        {
            return _first;
        }

        public T GetSecond()
        {
            return _second;
        }
    }
}
