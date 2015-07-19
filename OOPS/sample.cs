using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
//   class sample<T>
//   {

//       //public T a;
//       //public T b;
//       //public void Add()
//       //{
//       //    dynamic da = a;
//       //    dynamic db = b;
//       //    T c = da + db;
//       //    Console.Write(c);
//       //    Console.ReadKey();
//       //}
    

    
//}

    //create interface to prnt a string
    //implement interfaces in two ways
    //create a generic class of type interface and maintain list of all interface objects
   //public interface Isampleinterface
   //{
   //    void print();

   //}
   //public class FilePrint : Isampleinterface
   //{



   //    public void print()
   //    {
   //        Console.WriteLine("Print the damn file");
   //    }
   //}
   //public class DatabasePrint : Isampleinterface
   //{

   //    public void print()
   //    {
   //        Console.WriteLine("Print database file");
   //    }
   //}

   //public class Mygeneric<T> where T : Isampleinterface
   //{

   //    List<T> lists = new List<T>();

   //    public void addprinter(T printer)
   //    {
   //        lists.Add(printer);

   //    }
   //    public void print()
   //    {
   //        foreach (var l in lists)
   //        {
   //            l.print();

   //        }


   //    }


   //}


   //public class Customer
   //{
   //    //public int id;
   //    //public string name;
   //    public string print(string firstname,string lastname)
   //    {

   //        return firstname+" "+ lastname;
   //    }
   
   //}
    public class Mygeneric<T>
    {

        public Mygeneric(T t)
        {
            _t = t;
            Console.WriteLine( "GenericClass<{0}>( {1} ) created", 
                    typeof( T ).FullName, _t.ToString() );
        }
        
        private T _t = default(T);

        
        public T Getvalue()
        {
            Console.WriteLine("Returning" + _t.ToString());
            return _t;

        }

        public static U StaticGetValue<U>(U u)
        {
            Console.WriteLine("StaticGetValue<{0}>( {1} ) invoked",
                    typeof(U).FullName, u.ToString());
            return u;
        }
    }

}
