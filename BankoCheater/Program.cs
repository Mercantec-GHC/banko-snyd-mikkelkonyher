using System.Net.Http.Headers;

namespace BankoCheater
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            //Plate 1
            
            int[] rasmusRow1 = new int[] { 1, 20, 32, 71, 80 };
            int[] rasmusRow2 = new int[] { 3, 11, 21, 38, 44 };
            int[] rasmusRow3 = new int[] { 15, 29, 49, 58, 68 };

            //Plate 2

            int[] mikkelRow1 = new int[] { 1, 11, 21, 40, 51};
            int[] mikkelRow2 = new int[] { 4, 18, 24, 32, 62};
            int[] mikkelRow3 = new int[] { 36, 59, 65, 79, 86};


            // Create a dictionary to hold all players' rows
            Dictionary<string, Dictionary<string, int[]>> playersRows = new Dictionary<string, Dictionary<string, int[]>>();

            // Add Rasmus's rows
            playersRows.Add("Rasmus", new Dictionary<string, int[]>
            {
                { "Rasmus-row1", rasmusRow1 },
                { "Rasmus-row2", rasmusRow2 },
                { "Rasmus-row3", rasmusRow3 }
            });

            // Add Mikkel's rows
            playersRows.Add("Mikkel", new Dictionary<string, int[]>
            {
                { "Mikkel-row1", mikkelRow1 },
                { "Mikkel-row2", mikkelRow2 },
                { "Mikkel-row3", mikkelRow3 }
            });

            //Plate 1 counter

            int row1CounterRasmus = 0;
            int row2CounterRasmus = 0;
            int row3CounterRasmus = 0;

            //Plate 2 counter

            int row1CounterMikkel = 0;
            int row2CounterMikkel = 0;
            int row3CounterMikkel = 0;
            
            int selectedNumber;
            bool fullPlate = false;
            bool rasmusFullPlate = false;
            bool mikkelFullPlate = false;

            HashSet<int> drawnNumbers = new HashSet<int>(); //Makes that sure every drawn number is unique


            do
            {
                Console.Write("Enter a number: ");
                try
                {
                    selectedNumber = int.Parse(Console.ReadLine());
                    if (selectedNumber < 1 || selectedNumber > 90)
                    {
                        Console.WriteLine("Only numbers between 1-90 are valid");
                    }
                    
                    if (drawnNumbers.Contains(selectedNumber))
                    {
                        Console.WriteLine("You have already drawn this number. Please select a different one.");
                        continue; // Restart the loop if the number has already been drawn
                    }

                    drawnNumbers.Add(selectedNumber); // Add the selected number to the set of drawn numbers


                    foreach (var player in playersRows)
                    {
                        foreach (var row in player.Value)
                        {
                            if (row.Value.Contains(selectedNumber))
                            {
                                // If the numbers are found on Rasmus' plate
                                if (row.Key == "Rasmus-row1")
                                {
                                    row1CounterRasmus++;
                                }
                                else if (row.Key == "Rasmus-row2")
                                {
                                    row2CounterRasmus++;
                                }
                                else if (row.Key == "Rasmus-row3")
                                {
                                    row3CounterRasmus++;
                                }

                                // if the numbers are found on Mikkel's plate
                                if (row.Key == "Mikkel-row1")
                                {
                                    row1CounterMikkel++;
                                }
                                else if (row.Key == "Mikkel-row2")
                                {
                                    row2CounterMikkel++;
                                }
                                else if (row.Key == "Mikkel-row3")
                                {
                                    row3CounterMikkel++;
                                }
                            }
                        }
                    }
                
                    //Plade 1. If a row has 5 selected numbers it is set to 6

                    if (row1CounterRasmus == 5)
                    {
                        Console.WriteLine("BANKO! Rasmus Row1");
                        row1CounterRasmus++;
                    }
                    if (row2CounterRasmus == 5)
                    {
                        Console.WriteLine("BANKO! Rasmus Row2");
                        row2CounterRasmus++;
                    }
                    if (row3CounterRasmus == 5)
                    {
                        Console.WriteLine("BANKO! Rasmus Row3");
                        row3CounterRasmus++;
                    }

                    //Plate 2

                    if(row1CounterMikkel == 5)
                    {
                        Console.WriteLine("BANKO! Mikkel row 1 madafaka!");
                        row1CounterMikkel++;
                    }
                    if (row2CounterMikkel == 5)
                    {
                        Console.WriteLine("BANKO! Mikkel row 2 madafaka!");
                        row2CounterMikkel++;
                    }
                    if (row3CounterMikkel == 5)
                    {
                        Console.WriteLine("BANKO! Mikkel row 3 madafaka!");
                        row3CounterMikkel++;
                    }

                    //Checks if any of the plates are full

                    if (row1CounterRasmus == 6 && row2CounterRasmus == 6 && row3CounterRasmus == 6 && !rasmusFullPlate)
                    {
                        Console.WriteLine("Rasmus Fuld Plade !");
                        rasmusFullPlate = true;
                    }
                        
                    if (row1CounterMikkel == 6 && row2CounterMikkel == 6 && row3CounterMikkel == 6 && !mikkelFullPlate)
                    {
                        Console.WriteLine("Mikkel Fuld Plade");
                        mikkelFullPlate = true;
                    }
                    if(rasmusFullPlate && mikkelFullPlate)
                    {
                        fullPlate = true;
                    }

                }
                catch (FormatException)
                {

                    Console.WriteLine("Numbers only.");
                }


            } while (fullPlate == false); //Is set to true when all plates are full

            Console.WriteLine("All Plates are Full !");
        }
        
    }
}



