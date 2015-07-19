using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.Factory
{
    public  class BondFactory
    {
        public static Bond createBond(string type)
        {
            if (type == "muni")
                return new MuniBond();
            if (type == "corp")
                return new CorpBond();

            return null;
        }

      
    }

}
