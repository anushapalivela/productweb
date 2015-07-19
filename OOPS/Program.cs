using OOPS.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;

namespace OOPS
{
    class Program
    {
        static void Main(string[] args)
        {
            
            B b = new B();
            //expstatic expinstance=expstatic.createinstance();
            //expstatic exp2 = expstatic.createinstance();
           
           

            //ICalling respondent = new respondent(new manager(new director()));
            //respondent.call();

           

    //        //--------The below is equivalent to Mygeneric<int> mygeneric = new Mygeneric<int>(3);
    //        //Assembly assemblyexecuting = Assembly.GetExecutingAssembly();
    //        //string Typename = "OOPS.Mygeneric<>";
    //        //Type genericclass = assemblyexecuting.GetType(Typename);
    //        var genericclass = typeof(Mygeneric<>);
    //        Type[] typeArgs = { typeof(int) };
    //        //Type t=typeof(OOPS.Mygeneric);
    //        var genericclasstype = genericclass.MakeGenericType(typeArgs);
    //        object genericinstance = Activator.CreateInstance(genericclasstype,79);
    //        object rv = genericclasstype.InvokeMember("Getvalue", BindingFlags.InvokeMethod, null, genericinstance, new object[0]);
    //        Console.WriteLine("GetValue() returned {0}", rv.ToString());
           

    //        MethodInfo openGenericMethod = genericclasstype.GetMethod("StaticGetValue");
    //// typeof(Mygeneric<>).GetMethod("StaticGetValue");

    //        // get the close generic method type, by supplying the generic parameter type
    //        Type[] typeArgs1 = { typeof(int) };
    //        MethodInfo closedGenericMethod =
    //            openGenericMethod.MakeGenericMethod(typeArgs1);

    //        object o2 = closedGenericMethod.Invoke(null, new object[] { 4 });
               

    //        Console.WriteLine("o2 = {0}", o2.ToString());
    //        Console.ReadKey();
            //------------reflection
           // Assembly assemblyexecuting = Assembly.GetExecutingAssembly();
           // Type customerType = assemblyexecuting.GetType("OOPS.Customer");
           //// customerType.
           // object customerinstance = Activator.CreateInstance(customerType);
           // MethodInfo getprint = customerType.GetMethod("print");
           // string[] parameters = new string[2];
           // parameters[0] = "Anusha";
           // parameters[1] = "Palivela";
           // string fullname = (string)getprint.Invoke(customerinstance, parameters);
           // Console.WriteLine("Fullname is" + fullname);
           // Console.ReadKey();
            
            //Mygeneric<Isampleinterface> newgen=new Mygeneric<Isampleinterface>();

            //Isampleinterface f = new FilePrint();
            //Isampleinterface d = new DatabasePrint();
            //newgen.addprinter(f);
            //newgen.addprinter(d);
            //newgen.print();
            //Console.ReadKey();
          
            //sample<int> mg = new sample<int>();
            //mg.a = 2;
            //mg.b = 5;
            //mg.Add();

            //string type = "muni";
            //string a = "a";
            //string b = "b";
            //string c = "c";
            //a = b;
            //b = c;
            //Console.WriteLine(a);
            //Console.WriteLine(b);
            //Console.WriteLine(c);

            //BondFactory f = new BondFactory();
            
            ////Bond b = BondFactory.createBond(type);
            //b.setPrice(10);
           // b.GetMaturedDate();
        }
    }

   
}
