using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vivael
{
    class ComHelper
    {
        public static dynamic CreateObject(string progId)
        {
            Type type = Type.GetTypeFromProgID(progId);
            if (type == null)
                return null;
            return Activator.CreateInstance(type);
        }
    }
}
