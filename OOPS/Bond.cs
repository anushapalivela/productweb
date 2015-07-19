using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public  class Bond
    {
        private int price;
        //private String Name;
        public int getPrice()
        {
            return this.price;
        }

        public void setPrice(int value)
        {
            this.price = value;
        }


        

        public virtual  string GetMaturedDate()
        {
            return "";
        }

    }

    public class MuniBond : Bond
    {
        public override string GetMaturedDate()
        {
            return "muni";
        }
    }

    public class CorpBond : Bond
    {
        public override string GetMaturedDate()
        {
            return "corp";
        }
    }

}
