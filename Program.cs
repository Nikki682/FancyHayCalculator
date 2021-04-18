using System;
using System.Collections.Generic;
using System.IO;


namespace FancyHayCalculator

//**********************************************************
// Application:     My Fancy Hay Calculator
// Author:          Fink, Nikki
// Description:     App calculates suggested amount of hay for horses
// Date Created:    03/31/2021
// Date Revised:    04/18/2021
//**********************************************************
{
    class Program
    {          
              
      
        public static void Main(string[] args)
        {

          

            int horseAge = 0;
            string horseName = "";
            string horseBreed = "";
            double horseWeight = 0;


            SetTheme();
            WelcomeScreen();
            DisplayMainMenu();
            WriteHorseInformation( horseName, horseBreed,  horseAge, horseWeight);
            ReadDisplayInformation();
            DisplayContinuePrompt();
            DisplayClosingScreen();
            // HorseInfo = new List<HorseInfo>();

            Environment.Exit(0);
        }


       // static List<HorseInfo> HorseInfo;     

        
            

        /// <summary>
        /// Set Console theme
        /// </summary>
        static void SetTheme()
        {

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
        }

        /// <summary>
        /// Main Menu
        /// </summary>
        public static void DisplayMainMenu()
        {
            bool quitCalc = false;
            string menuChoice;
            int horseAge = 0;
            string horseName ="";
            string horseBreed = "";
            double horseWeight = 0;
            double hayPrice = 0;

            

            do
            {
                DisplayScreenHeader("My Fancy Hay Calculator Main Menu");
                Console.WriteLine();
                Console.WriteLine("\tPlease go through each menu option and enter your data");
                Console.WriteLine();
                Console.WriteLine("\ta) Horse Name");
                Console.WriteLine("\tb) Breed of Horse");
                Console.WriteLine("\tc) Age of Horse");
                Console.WriteLine("\td) Enter Horse's Weight");
                Console.WriteLine("\te) Enter Current Hay Price");
                Console.WriteLine("\tf) Calculate Cost Of Hay Needed");
                Console.WriteLine("\tg) Display Current Horse");
                Console.WriteLine("\th) Read Horse Info File");
                //Console.WriteLine("\ti)  Profile....");
                Console.WriteLine("\tq) Quit");
                Console.WriteLine();
                Console.Write("\t\tPlease enter a menu choice:");
                menuChoice = Console.ReadLine().ToLower();

                switch (menuChoice)
                {
                    case "a":
                        horseName = HorseName();
                        break;

                    case "b":
                        horseBreed = HorseBreed();
                        break;

                    case "c":
                        horseAge = HorseAge();
                        break;

                    case "d":
                        horseWeight = HorseWeight();
                        break;

                    case "e":
                        hayPrice = CurrentHayCost();
                        break;

                    case "f":
                        CalculateHayCost(hayPrice, horseWeight);
                        break;

                    case "g":
                        DisplayInformation( horseName, horseBreed, horseAge, horseWeight);
                        break;

                    case "h":
                        ReadDisplayInformation();
                        break;

                    //case "i":
                    //    SeeHorse();
                    //    break;

                    case "q":
                        DisplayClosingScreen();
                        break;
                }

            } while (!quitCalc);

        }

       



        /// <summary>
        /// get horse age from user
        /// </summary>
        /// <returns>horseAge</returns>
        public static int HorseAge()
        {
            DisplayScreenHeader("Horse Age");
            bool validAge = false;
            string userInput;
            int horseAge;
           
            do
            {

                Console.Write("\tHow old is your horse?:");
                userInput = Console.ReadLine();
                validAge = int.TryParse(userInput, out  horseAge);
                if (!validAge)
                {
                    Console.Write("\tPlease enter an age in whole numbers[2, 5, 26]:");
                }

            } while (!validAge);

            Console.WriteLine();
            Console.WriteLine($"\t{horseAge} is a nice age.");
                
                DisplayContinuePrompt();
                                            
                return horseAge;
        }  
         
                             
      
        /// <summary>
        /// get horse breed from user
        /// </summary>
        /// <returns>horseBreed</returns>
        public static string HorseBreed()
        {
            DisplayScreenHeader("Horse Breed");

            Console.Write("\tPlease enter the breed of your horse?");
            string horseBreed = Console.ReadLine();
            while (string.IsNullOrEmpty(horseBreed))
            {
                Console.WriteLine("\tPlease enter the horse breed!");
                horseBreed = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine($"\tThat's awesome! I love {horseBreed}s!");

            DisplayContinuePrompt();

            return horseBreed;


        }

        /// <summary>
        /// get horse name from user
        /// </summary>
        /// <returns>horseName</returns>
        public static string HorseName()
        {
                      
            DisplayScreenHeader("Horse Name");

            
            Console.Write("\tWhat is the name of your horse?:");
            string horseName = Console.ReadLine();
            while (string.IsNullOrEmpty(horseName))
            {
                Console.WriteLine("\tPlease enter the Name of the horse!");
                horseName = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine($"\tNice, I think {horseName} is a good name for a horse. ");

                        
            DisplayContinuePrompt();
                       
            return horseName;
          

        }

        /// <summary>
        /// get horse weight
        /// </summary>
        /// <returns>horseWeight</returns>
        public static double HorseWeight()
        {
            bool validWeight = false;
            string userInput;
            double horseWeight;
            DisplayScreenHeader("Horse Weight");

            do
            {

            
                Console.Write("\tWhat is the current weight of your horse in pounds?: If you are not sure, we can use 1200lbs ");
                userInput = Console.ReadLine();
                validWeight = double.TryParse(userInput, out horseWeight);

                if (!validWeight)
                {
                    Console.WriteLine("\tPlease enter a digit for the weight of the horse[500, 1200, 1550]:");
                }
            
            } while (!validWeight);
                
            DisplayContinuePrompt();
            
            return horseWeight;

        }  
          
                      
                 
        
        /// <summary>
        /// Display horse info to user
        /// </summary>
        public static void DisplayInformation( string horseName, string horseBreed, int horseAge, double horseWeight)
        {
           

            DisplayScreenHeader("Current Horse Information");

            Console.WriteLine($"\tHorse Profile ");
            Console.WriteLine();
            Console.WriteLine($"\tName: {horseName}");
            Console.WriteLine($"\tBreed: {horseBreed}");
            Console.WriteLine($"\tAge: {horseAge}");          
            Console.WriteLine($"\tWeight: {horseWeight}");
            Console.WriteLine();
            Console.WriteLine("\tWhat a nice horse!");

            
            
            WriteHorseInformation(horseName, horseBreed, horseAge, horseWeight);

            
        }

        


        /// <summary>
        /// calculate cost of feeding hay
        /// </summary>
        /// <param name="hayPrice"></param>
        /// <param name="horseWeight"></param>
        /// <returns>hayCost</returns>
        static double CalculateHayCost(double hayPrice, double horseWeight)
        {
            double hayCost = 0;
            double hayAday = horseWeight * .02;
            double hayAyear = (hayAday / 50)*hayPrice;
            // horses eat 2% of their body weight a day

            DisplayScreenHeader("Calculate Hay Amount and Cost");


            Console.WriteLine($"\tHay needed per day is:{(hayAday = horseWeight * .02)}pounds");
            Console.WriteLine();
            Console.WriteLine($"\tCost per day at ${hayPrice} dollars/bale, is: ${(hayAday/50)* hayPrice}/day");
            Console.WriteLine();
            Console.WriteLine($"\tTotal hay cost in a year for this horse is: ${hayAyear * 365}/year ");
            Console.WriteLine();
            Console.WriteLine("\tWe really love our horses don't we?!");
            Console.WriteLine();
            Console.WriteLine("\t\tPlease note: This information is an aproxomation. Lots of other factors are");
            Console.WriteLine("\t\tinvolved in properly feeding a horse. This is a GUIDE ONLY for average forage intake");
           

            Console.WriteLine();
            DisplayContinuePrompt();

            return hayCost;

        }

        /// <summary>
        /// Current price of hay bale
        /// </summary>
        /// <returns>hayPrice</returns>
        private static double CurrentHayCost()
        {

            bool validInput = false;
            do
            {

                string userInput;
                double hayPrice;


                DisplayScreenHeader("Cost of a Hay Bale in your Area");

                Console.WriteLine("\tNow for the serious part..");
                Console.WriteLine();
                Console.Write("\tWhat is the current price of hay per bale, in your area? (Sorry 50lbs+ square bales ONLY):");
                userInput = Console.ReadLine();
                while (!double.TryParse(userInput, out hayPrice))
                {
                    Console.WriteLine();
                    Console.WriteLine("\tYou have entered an invalid number. Enter price in dollars [2, 5.50]:");
                    userInput = Console.ReadLine();
                }

                
               DisplayContinuePrompt();

                return hayPrice;

            } while (!validInput);
            

        }

                    
       

        /// <summary>
        /// write to data file
        /// </summary>
        /// <param name="horseWeight"></param>
        /// <param name="horseName"></param>
        /// <param name="horseBreed"></param>
        /// <param name="horseAge"></param>
        public static void WriteHorseInformation( string horseName, string horseBreed, int horseAge, double horseWeight )
        {
             string dataPath = @"Data\horse1.txt";

                                   
            //File.WriteAllLines("dataPath", horse);

            File.AppendAllText(dataPath, horseName.ToString()+ "\n");
            File.AppendAllText(dataPath , horseBreed.ToString() + "\n");
            File.AppendAllText(dataPath, horseAge.ToString() + "\n");
            File.AppendAllText(dataPath, horseWeight.ToString() + "\n");
                     
                                 
            DisplayContinuePrompt();

        }

        public static  void ReadDisplayInformation()
        {
            DisplayScreenHeader("Read Horse Data File");


            string dataPath = @"Data\horse1.txt";
            string readText = File.ReadAllText(dataPath);
            Console.Write("\n" + readText);

            DisplayContinuePrompt();

        }

       
        //static void SeeHorse()
        //{
        //    DisplayScreenHeader("SEE");

        //    Console.WriteLine($"Name:{HorseInfo} ");

        //    DisplayContinuePrompt();
        //}


        #region SCREEN DISPLAYS
        /// <summary>
        /// Welcome Screen
        /// </summary>
        static void WelcomeScreen()
        {

            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t\t*My Fancy Hay Calculator*");
            Console.WriteLine();
            Console.WriteLine("\t\tHello and Welcome!");
            Console.WriteLine();
            Console.WriteLine("\tDo you own horses? Do they eat hay?");
            Console.WriteLine("\t(Well of course they do!)");
            Console.WriteLine();
            Console.WriteLine("\tThis Application is designed to help you with how much hay to feed, and what it can cost.");
            Console.WriteLine();
           


            DisplayContinuePrompt();
        }

        /// <summary>
        /// Continue Prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to keep going.");
            Console.ReadKey();
        }

        /// <summary>
        /// Closing Screen
        /// </summary>
        static  void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using My Fancy Hay Calculator!");
            Console.WriteLine();
            Console.WriteLine("\t\tPress <ENTER> key to exit");

           
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Environment.Exit(0);


            //DisplayContinuePrompt();

            //return ;



        }
        /// <summary>
        /// Screen header
        /// </summary>
        /// <param name="headerText"></param>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t\t" + headerText);
            Console.WriteLine();
        }
         #endregion
        
       

    }

        //class HorseInfo
        //{

       
        //public HorseInfo(string name, string breed, int age, double weight)
        //    {
        //        Name = name;
        //        Breed = breed;
        //        Age = age;
        //        Weight = weight;
        //    }

        //    public string Breed { get;  private set; }
        //    public int Age { get; private set; }
        //    public double Weight { get; private set; }
        //    public string Name { get;  private set; }
        //}


}
