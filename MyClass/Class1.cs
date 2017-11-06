using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{

    //un esempio di classe normale che utilizza solo interi
    public class MyNormalClass
    {
        public int X { get; set; }

        public MyNormalClass(int x)
        {
            X = x;
        }

    }


    //un esempio di classe generica
    public class MyClass <T>
    {
        public T X { get; set; }

        public MyClass(T x)
        {

            X = x;
        }

    }
    //un esempio di classe generica con vincolo
    public class MyClassVincolata<T> where T : new()
    {
        public T X { get; set; }

        public MyClassVincolata( T x)
        {
            X = x;
        }

    }


    //Creazione di interfacce generiche variant (C# e Visual Basic)
    //solo le interfacce hanno in ed out
    //preso dal sito msdn.microsoft.com
    //https://msdn.microsoft.com/it-it/library/vs/alm/dd997386(v=vs.120).aspx/css
    
    //covariante che verrà implementata, la classe non sarà 
    //necessariamente covariante
    public interface ICovariant<out T>
    {
        T GetSomething();
       /*
        * questa riga sotto non può essere fatta
        * infatti da contratto è covariante
        * T deve essere solo un valore di riotno !!! e non un input
        * di un possibile metodo e/o costruttore
        void DoSomething(T t);
        */
    }
    
    //controvariante
    interface IContravariant<in T> { }



    public class SampleImplementation<T> : ICovariant<T>
    {
        //infatti non è covariante
        public void M(T t)
        {
            Console.WriteLine("Called M with param "+ t.ToString() );
            Console.ReadLine();
        }

        public T GetSomething()
        {
            // Some code. 
            return default(T);
        }
    }
    //classe utilizzata dal main per esempio
    public class Button
    {
    }

    //Estensione di interfacce generiche variant
    interface IExtCovariant1<T> : ICovariant<T> { } //invariante in IExt...1

    interface IExtCovariant2<out T> : ICovariant<T> { }//covariante in IExt...2


    /*
     * You can create an interface that extends both 
     * the interface where the generic type parameter T is covariant 
     * and the interface where it is contravariant 
     * if in the extending interface the generic type parameter T is invariant. 
     * This is illustrated in the following code example.
    */
    interface IInvariant<T> : ICovariant<T>, IContravariant<T> { }

    /*
     * Se, tuttavia, un parametro di tipo generico T è dichiarato covariante
        in una interfaccia, non è possibile dichiararlo controvariante
        nell'interfaccia che estende o viceversa, 
        come illustrato nell'esempio di codice riportato di seguito.
        The following statement generates a compiler error. 
         interface ICoContraVariant<in T> : ICovariant<T> { }
    */


}
