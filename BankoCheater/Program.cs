using System.Net.Http.Headers;

namespace BankoCheater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankoCard1();
        }
        static void BankoCard1()
        {
            int[] rasmus1Row1 = new int[] { 1, 20, 32, 71, 80 };
            int[] rasmus1Row2 = new int[] { 3, 11, 21, 38, 44 };
            int[] rasmus1Row3 = new int[] { 15, 29, 49, 58, 68 };
                
            //Ny plade

            

            Dictionary<string, int[]> dic = new Dictionary<string, int[]>();
            dic.Add("Rasmus1-row1", rasmus1Row1);
            dic.Add("Rasmus1-row2", rasmus1Row2);
            dic.Add("Rasmus1-row3", rasmus1Row3);

          


            int row1Counter = 0;
            int row2Counter = 0;
            int row3Counter = 0;
            int selectedNumber;
            bool fullPlate = false;


            do
            {
                Console.Write("Enter a number: ");
                try
                {
                    selectedNumber = int.Parse(Console.ReadLine());

                    
                    foreach (var row in dic)
                    {
                        if (row.Value.Contains(selectedNumber))
                        {
                            if (row.Key == "Rasmus1-row1")
                            {
                                row1Counter++;
                            }
                            else if (row.Key == "Rasmus1-row2")
                            {
                                row2Counter++;
                            }
                            else if (row.Key == "Rasmus1-row3")
                            {
                                row3Counter++;
                            }
                        }
                    }

                    if (row1Counter == 5)
                    {
                        Console.WriteLine("BANKO! Row1");
                        row1Counter++;
                    }
                    if (row2Counter == 5)
                    {
                        Console.WriteLine("BANKO! Row2");
                        row2Counter++;
                    }
                    if (row3Counter == 5)
                    {
                        Console.WriteLine("BANKO! Row3");
                        row3Counter++;
                    }

                    if (row1Counter == 6 && row2Counter == 6 && row3Counter == 6)
                    {
                        fullPlate = true;
                    }


                }
                catch (FormatException)
                {
                    Console.WriteLine("Numbers only.");
                }


            } while (fullPlate == false);

            Console.WriteLine("Fuld Plade mester jakel!");
        
        }
    }
}


