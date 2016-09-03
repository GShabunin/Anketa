using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{
    class NetConnectionChecker
    {

    }
    class Mthrd
    {

        public char[] delimiterChars = { '"', ' ', ';', };
        string trdname;
        public Mthrd(string name)
        {
            trdname = name;
        }
        public void Getter()
        {


            do
            {
                Console.Clear();
                int fc = 0, mc = 0;
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] raw = wc.DownloadData("http://api.lod-misis.ru/testassignment");

                string webData = System.Text.Encoding.UTF8.GetString(raw);

                string[] words = webData.Split(delimiterChars);
                Console.Write("Recent events:\n");
                foreach (string item in words)
                {
                    Console.WriteLine(item);
                    
                    if (item == "Male:Died")
                    {
                        mc = mc - 1;
                    }
                    else
                    {
                        if (item == "Male:Born")
                        {
                            mc = mc + 1;
                        }
                        else
                        {
                            if (item == "Female:Died")
                            {
                                fc = fc - 1;
                            }
                            else
                            {
                                if (item == "Female:Born")
                                {
                                    fc = fc + 1;
                                }
                            }
                        }
                    }

                    // надо разобрать эту ахинею
                }
                Console.WriteLine("_________________");
                if (mc < 0)
                {
                    Console.WriteLine("Погибло мужчин: "+ Math.Abs(mc));
                }
                if (mc > 0)
                {
                    Console.WriteLine("Родилось мужчин: " + Math.Abs(mc));
                }
                if (fc < 0)
                {
                    Console.WriteLine("Погибло женщин: " + Math.Abs(fc));
                }
                if (fc > 0)
                {
                    Console.WriteLine("Родилось женщин: " + Math.Abs(fc));
                }
                Console.WriteLine("_________________");
                Thread.Sleep(5000);
            } while (true);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mthrd thread1 = new Mthrd("Поток_1");
            Thread alala = new Thread(thread1.Getter);
            alala.Start();
            // Допиши евенты 

        }
    }
}
