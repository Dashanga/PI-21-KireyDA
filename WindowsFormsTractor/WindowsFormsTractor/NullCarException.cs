using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTractor
{
    class NullCarException : Exception
    {
        public NullCarException() : base("Трактор не выбран")
        { }
    }
}
