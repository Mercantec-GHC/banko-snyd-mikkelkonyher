using System.Net.Http.Headers;

//1. Optimer koden så det bliver mere overskueligt, hvis man spiller med flere plader(methods, parametre etc.)
//2. Hav mulighed for at spille videre selvom en af pladerne er "fuld plade".


//Gem tallene i Json fil


namespace BankoCheater
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            //Plade 1
            
            int[] rasmus1Row1 = new int[] { 1, 20, 32, 71, 80 };
            int[] rasmus1Row2 = new int[] { 3, 11, 21, 38, 44 };
            int[] rasmus1Row3 = new int[] { 15, 29, 49, 58, 68 };

            //Plade 2

            int[] mikkel1Row1 = new int[] { 1, 11, 21, 40, 51};
            int[] mikkel1Row2 = new int[] { 4, 18, 24, 32, 62};
            int[] mikkel1Row3 = new int[] { 36, 59, 65, 79, 86};

            
            Dictionary<string, int[]> dic = new Dictionary<string, int[]>();

            dic.Add("Rasmus1-row1", rasmus1Row1);
            dic.Add("Rasmus1-row2", rasmus1Row2);
            dic.Add("Rasmus1-row3", rasmus1Row3);

            dic.Add("Mikkel1-row1", mikkel1Row1);
            dic.Add("Mikkel1-row2", mikkel1Row2);
            dic.Add("Mikkel1-row3", mikkel1Row3);

            //Plade 1 counter
            
            int row1Counter = 0;
            int row2Counter = 0;
            int row3Counter = 0;

            //Plade 2 counter

            int row1Counter2 = 0;
            int row2Counter2 = 0;
            int row3Counter2 = 0;

            int selectedNumber;
            bool fullPlate = false;
           

            do
            {
                Console.Write("Enter a number: ");
                try
                {
                    selectedNumber = int.Parse(Console.ReadLine());
                    if (selectedNumber < 1 ||selectedNumber > 90)
                    {
                        Console.WriteLine("Only numbers between 1-90 is valid");
                    }

                    
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

                            //Plade 2

                            if(row.Key == "Mikkel1-row1")
                            {
                                row1Counter2++;
                            }
                            else if(row.Key == "Mikkel1-row2")
                            {
                                row2Counter2++;
                            }
                            else if( row.Key == "Mikkel1-row3")
                            {
                                row3Counter2++;
                            }

                        }
                    }

                    if (row1Counter == 5)
                    {
                        Console.WriteLine("BANKO! Rasmus Row1");
                        row1Counter++;
                    }
                    if (row2Counter == 5)
                    {
                        Console.WriteLine("BANKO! Rasmus Row2");
                        row2Counter++;
                    }
                    if (row3Counter == 5)
                    {
                        Console.WriteLine("BANKO! Rasmus Row3");
                        row3Counter++;
                    }

                    //plade2

                    if(row1Counter2 == 5)
                    {
                        Console.WriteLine("BANKO! Mikkel row 1 madafaka!");
                        row1Counter2++;
                    }
                    if (row2Counter2 == 5)
                    {
                        Console.WriteLine("BANKO! Mikkel row 2 madafaka!");
                        row2Counter2++;
                    }
                    if (row3Counter2 == 5)
                    {
                        Console.WriteLine("BANKO! Mikkel row 3 madafaka!");
                        row3Counter2++;
                    }

                    if (row1Counter == 6 && row2Counter == 6 && row3Counter == 6 || row1Counter2 == 6 && row2Counter2 == 6 && row3Counter2 == 6)
                    {
                        fullPlate = true;
                    }


                }
                catch (FormatException)
                {

                    Console.WriteLine("Numbers only.");
                }


            } while (fullPlate == false);

            if(row1Counter == 6 && row2Counter == 6 && row3Counter == 6) //Rasmus counter
            {
                Console.WriteLine("Fuld Plade Rasmus!");
            }
            else if(row1Counter2 == 6 && row2Counter2 == 6 && row3Counter2 == 6) //Mikkel counter
            {
                Console.WriteLine("Fuld Plade Mikkel");
            }

        }
        
    }
}



