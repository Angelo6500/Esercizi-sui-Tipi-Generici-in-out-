using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass;
using System.Windows;
namespace ConsoleApp1
{
    //https://msdn.microsoft.com/it-it/library/vs/alm/dd997386(v=vs.120).aspx/css
    class Program
    {
        static void Main(string[] args)
        {
            // The interface is covariant.
            ICovariant<Button> ibutton = new SampleImplementation<Button>();
            ICovariant<Object> iobj = ibutton;

            // The class is invariant.
            SampleImplementation<Button> button = new SampleImplementation<Button>();
            // The following statement generates a compiler error 
            // because classes are invariant. 
            // SampleImplementation<Object> obj = button;


            var y = new SampleImplementation<int>();
            y.M(0);


        }
    }
}
