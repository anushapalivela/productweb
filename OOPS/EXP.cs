using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public interface ICalling
    {
         void call();
    
    
    }
    class respondent:ICalling
    {
        bool isbusy=true;
        manager manager;

        
    public respondent(manager manager)
    {
        this.manager = manager;
    }

        public void call()
        {
            if (isbusy)
            {                  
                this.manager.call();
                Console.ReadKey();
            
            }
            else
                Console.WriteLine("Hello from respondent");
            Console.ReadKey();
        }
        
    }
    class manager : ICalling
    {
        bool isbusy=true;
        director director;

        public manager(director director)
        {
            this.director = director;
        }

        public void call()
        {
            if (isbusy)
            {

                this.director.call();
            }
            else
                Console.WriteLine("Hello from manager");
            Console.ReadKey();
        
        }
    
    
    
    }
    class director : ICalling
    {
        
        public void call()
        {
            
                Console.WriteLine("Hello from Director");
                Console.ReadKey();

        }



    }
}
