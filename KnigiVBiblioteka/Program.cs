using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KnigiVBiblioteka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<BeleziNaKniga> list = new List<BeleziNaKniga>();
                Console.Write("Izberi janr:\npoeziq, povest ili roman\n=> ");
                string janr = Console.ReadLine();                            
                switch (janr)
                {
                    case "povest":
                        {
                            BeleziNaKniga kniga1 = new BeleziNaKniga("Nemili-nedragi", "Ivan Vazov", "spisanie Nauka", 1883, 9);
                            BeleziNaKniga kniga2 = new BeleziNaKniga("Geracite", "Elin Pelin", "Al. Paskalev", 1911, 8);
                            BeleziNaKniga kniga3 = new BeleziNaKniga("Kradecut na praskovi", "Emiliqn Stanev", "Narodna kultura", 1948, 3);
                            list.Add(kniga1);
                            list.Add(kniga2);
                            list.Add(kniga3);
                            break;
                        }
                    case "roman":
                        {
                            BeleziNaKniga kniga1 = new BeleziNaKniga("Tutun", "Dimitur Dimov", "Narodna kultura", 1951, 6);
                            BeleziNaKniga kniga2 = new BeleziNaKniga("Jelezniqt svetilnik", "Dimitur Talev", "Bulgarski pisatel", 1952, 2);
                            BeleziNaKniga kniga3 = new BeleziNaKniga("Osudeni dushi", "Dimitur Dimov", "Hemus", 1945, 5);
                            list.Add(kniga1);
                            list.Add(kniga2);
                            list.Add(kniga3);
                            break;
                        }
                    case "poeziq":
                        {
                            BeleziNaKniga kniga1 = new BeleziNaKniga("Haiduti", "Hristo Botev", "Narodna kultura", 1871, 1);
                            BeleziNaKniga kniga2 = new BeleziNaKniga("Gramada", "Ivan Vazov", "Bulgarski pisatel", 1879, 4);
                            BeleziNaKniga kniga3 = new BeleziNaKniga("Cis moll", "Pencho Slaveikov", "spisanie Misul", 1892, 2);
                            list.Add(kniga1);
                            list.Add(kniga2);
                            list.Add(kniga3);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Nevaliden janr!");
                            return;
                        }
                }
                //Izvejda cqlata informaciq za knigite.
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------Vsichki knigi:---------------------------------------------");
                list.ForEach(x => x.Print());
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                //Izvejda dannite za kniga po zadadeno zaglavie na kniga.
                

                bool foundBook = false;
                while (!foundBook)
                {
                    Console.Write("Vuvedete zaglavie na knigata za tursene: ");
                    string knigaZaTursene = Console.ReadLine();
                    var namerenaKniga = list.FirstOrDefault(x => x.Zaglavie.Equals(knigaZaTursene, StringComparison.OrdinalIgnoreCase));
                    if (namerenaKniga != null)
                    {
                        Console.WriteLine("-------------------------------------------Namerenata kniga:-------------------------------------------");
                        namerenaKniga.Print();
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        foundBook = true;
                    }
                    else
                    {
                        Console.WriteLine("Knigata ne e namerena. Opitai pak!");
                    }
                    Console.WriteLine();
                }

                //Izvejda nai-starata kniga
                Console.WriteLine("-------------------------------------------Nai-starata kniga:------------------------------------------");
                list.OrderBy(x => x.Godina).Take(1).ToList().ForEach(x => x.Print());
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                //izchislqva sredna vuzrast na knigite v bibliotekata.
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                if (list.Count > 0)
                {
                    BeleziNaKniga book = list.First();
                    book.AverageAge(list);
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine();

                //Sortirane po avtor i nomer v kataloga.
                IComparerBook comparerBook = new IComparerBook();
                list.Sort(comparerBook);
                Console.WriteLine("-----------------------------------------Knigi sled sortirane:-----------------------------------------");
                list.ForEach(x => x.Print());
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.ReadKey();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
