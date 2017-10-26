using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Hilos222
{
    class Program
    {
        static Thread myThread = null;
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "principal";
            myThread = new Thread(new ThreadStart(MiFun));
            myThread.Name = "Mifun";
            Thread mithread2 = new Thread(new ThreadStart(MiFun2));
            mithread2.Name = "Mifun2";
            myThread.Start();
            mithread2.Start();
            myThread.Join(10000);
            mithread2.Join(10000);
           // MiFun();
            Console.WriteLine("Finalizado threads");
            Console.ReadKey();
        }
        public static void MiFun()
        {
            Console.WriteLine(Thread.CurrentThread.Name+ "Inicio de la iteración");
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name+ " It: " + i);
                if (i == 5)
                {
                    myThread.Suspend();

                }
            }
            Console.WriteLine("..Proceso finalizado fun1..");
        }
        public static void MiFun2()
        {
            Console.WriteLine("Holaa....aaa"+Thread.CurrentThread.Name.ToString());
            for (char j = 'a'; j <= 'z'; j++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " It: " + j);
            }
            myThread.Resume();
            Console.WriteLine("Finalizado fun2..");
        }
    }
}
