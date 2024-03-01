using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

            int[] mikkelRow1 = new int[] { 1, 11, 21, 40, 51 };
            int[] mikkelRow2 = new int[] { 4, 18, 24, 32, 62 };
            int[] mikkelRow3 = new int[] { 36, 59, 65, 79, 86 };


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

            string quitGame = "exit";

            HashSet<int> drawnNumbers = new HashSet<int>(); //Makes that sure every drawn number is unique


            do
            {

                Console.Write("Enter a number: ");
                try
                {
                    selectedNumber = int.Parse(Console.ReadLine());
                    if (selectedNumber < 1 || selectedNumber > 90)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOnly numbers between 1-90 are valid");
                        Console.ResetColor();
                        continue; //Restarts loop if the enter number is not 1-90
                    }

                    if (drawnNumbers.Contains(selectedNumber))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou have already drawn this number. Please select a different one.");
                        Console.ResetColor();
                        continue; // Restart the loop if the number has already been drawn
                    }

                    drawnNumbers.Add(selectedNumber); // Add the selected number to the set of drawn numbers
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nDrawn Numbers: " + string.Join(", ", drawnNumbers) + " (Last added: " + DateTime.Now.ToString() + ")\n");
                    Console.ResetColor();

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

                    //Plate 1. If a row has 5 selectedNumbers it is set to 6 which indicates banko in row (By setting it to 6 we make sure it's not displayed multiple times)

                    if (row1CounterRasmus == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("BANKO! Rasmus Row 1\n");
                        Console.ResetColor();
                        row1CounterRasmus++;
                    }
                    if (row2CounterRasmus == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nBANKO! Rasmus Row 2\n");
                        Console.ResetColor();
                        row2CounterRasmus++;
                    }
                    if (row3CounterRasmus == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nBANKO! Rasmus Row 3\n");
                        Console.ResetColor();
                        row3CounterRasmus++;
                    }

                    //Plate 2

                    if (row1CounterMikkel == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("BANKO! Mikkel Row 1 madafaka!\n");
                        Console.ResetColor();
                        row1CounterMikkel++;
                    }
                    if (row2CounterMikkel == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("BANKO! Mikkel Row 2 madafaka!\n");
                        Console.ResetColor();
                        row2CounterMikkel++;
                    }
                    if (row3CounterMikkel == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("BANKO! Mikkel Row 3 madafaka!\n");
                        Console.ResetColor();
                        row3CounterMikkel++;
                    }

                    //Checks if any of the plates are full

                    if (row1CounterRasmus == 6 && row2CounterRasmus == 6 && row3CounterRasmus == 6 && !rasmusFullPlate)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("------------\nRASMUS FULD PLADE\n------------\n");
                        Console.ResetColor();
                        rasmusFullPlate = true;
                    }

                    if (row1CounterMikkel == 6 && row2CounterMikkel == 6 && row3CounterMikkel == 6 && !mikkelFullPlate)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("------------\nMIKKEL FULD PLADE\n------------\n");
                        Console.ResetColor();
                        mikkelFullPlate = true;
                    }
                    if (rasmusFullPlate && mikkelFullPlate) //If all plates are full you can exit game
                    {
                        Console.Write("All PLATES ARE FULL, you cheater!\n\nType 'exit' and press enter to close the game: ");
                        quitGame = Console.ReadLine().ToLower().Trim();

                        if (quitGame == "exit")
                        {
                            fullPlate = true;
                        }

                    }

                }
                catch (FormatException) //Catches all inputs that are not numbers and prompts player.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNumbers only.");
                    Console.ResetColor();
                }


            } while (fullPlate == false); //Is set to true when all plates are full and there's been typed exit. Game closes.



            //SELENIUM EKSPERIMENTERING

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://mags-template.github.io/Banko/");



        }

    }
}



