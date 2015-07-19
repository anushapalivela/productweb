using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    //public   class expstatic
    //{
    //    public static expstatic getinstance;

    //    private expstatic()
    //    {
    //        //dbcall
    //        //stores all the data

    //    }
    //    public static expstatic createinstance()
    //    {

           
    //            //expstatic.getinstance = exp;
    //        if (getinstance == null)
    //        {
    //            expstatic exp = new expstatic();
    //            getinstance = exp;
    //        }
            
    //            Console.WriteLine("instance is " + getinstance);
    //            Console.ReadKey();
    //            return getinstance;
               
    //    }
     

    //}

    public class A
    {
        public A()
        {
            Console.WriteLine("in base");
        
        }
    
    }
    public class B : A 
    {

        public B()
        {

            Console.WriteLine("in derived");
        
        }
    
    }

    
}
