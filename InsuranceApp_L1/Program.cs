//Using
using System.Numerics;

namespace InsuranceApp_L1
{
    internal class Program
    {
        //Global Varibles
        static float totalInsuranceCost = 0f;

        //Methods and Functions
        static void OneDevice()
        {
            //Initialise list
            List<string> Catagory = new List<string>() { "1. Computer", "2. Tablet", "3. Other" };
            Catagory.AsReadOnly();

            //Collect information
            string deviceName = CheckNotBlank("Enter the device name: \n");

            //Get num of devices
            Console.WriteLine("Enter the number of devices: \n");
            float deviceAmount = (float)Convert.ToDouble(CheckInt(1, 99999));

            //Get device cost
            Console.WriteLine("Enter the device cost for 1 device: \n");
            float deviceCost = (float)Convert.ToDouble(CheckInt(1, 99999));

            //Get the catagory
            Console.WriteLine("Choose the catagory of the device:");
            for (int index = 0; index < Catagory.Count; index++)
            {
                Console.WriteLine(Catagory[index]);
            }

            Console.WriteLine(" ");

            //Store input
            int deviceCatagory = CheckInt(1, Catagory.Count);
            //Stop collecting information

            //Check if user gets the discount and calculate the summary
            if (deviceAmount > 5)
            {
                float insuranceCost = (5 * deviceCost) + (((deviceAmount - 5) * deviceCost) * .9f);
                Console.Clear();
                Console.WriteLine($"{deviceName}\n" +
                               $"Total cost for {deviceAmount} x {deviceName} devices is = ${insuranceCost}");
                totalInsuranceCost += insuranceCost;
            }
            else
            {
                float insuranceCost = deviceAmount * deviceCost;
                Console.Clear();
                Console.WriteLine($"{deviceName}\n" +
                              $"Total cost for {deviceAmount} x {deviceName} devices is = ${insuranceCost}");
                totalInsuranceCost += insuranceCost;
            }

            //Show the depreciation
            Console.WriteLine("Month: | Value loss:");

            List<float> valueLoss = new List<float>() { deviceCost };

            for (int month = 1; month < 7; month++)
            {
                valueLoss.Add((float)Convert.ToDouble(valueLoss[month -1] * 0.95));
                Console.WriteLine($"{month}         ${Math.Round(valueLoss[valueLoss.Count - 1], 2)}");
            }

            //Show the catagory
            Console.WriteLine($"Catagory: {Catagory[deviceCatagory-1]}");
        }
        static string CheckProceed()
        {
            while (true)
            {
                //Ask if the want to add another device or quit
                Console.WriteLine("Press <ENTER> to add another device or type 'X' to exit");
                string checkProceed = Console.ReadLine();

                checkProceed = checkProceed.ToUpper();

                if (checkProceed.Equals("") || checkProceed.Equals("X") || checkProceed.Equals("x"))
                {
                    return checkProceed;
                }

                //Display error message
                DisplayErrorMessage("Error: Invalid choice");
            }
        }
        static void DisplayErrorMessage(string error)
        {
            //Display error message
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static int CheckInt(int min, int max)
        {
            while (true)
            {
                try
                {
                    //Convert input to int
                    int userInt = Convert.ToInt32(Console.ReadLine());
                    
                    //Check if input in between min and max
                    if (userInt >= min && userInt <= max)
                    {
                        return userInt;
                    }

                    //Display error message
                    DisplayErrorMessage($"ERROR: You MUST enter an integer between {min} and {max}.");
                }
                catch
                {
                    //Display error message
                    DisplayErrorMessage($"ERROR: You MUST enter an integer between {min} and {max}.");
                }
            }
        }
        static string CheckNotBlank(string question)
        {
            string input;

            while (true)
            {
                //Ask the question
                Console.WriteLine(question);

                input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                //Display the error message
                DisplayErrorMessage("Error: You must enter an input");
            }
        }

        //Main or when run...
        static void Main(string[] args)
        {
            //Display app title
            Console.WriteLine(
                        "  _____                                                                           \n" +
                        " |_   _|                                              /\\                         \n" +
                        "   | |  _ __  ___ _   _ _ __ __ _ _ __   ___ ___     /  \\   _ __  _ __         \n" +
                        "   | | | '_ \\/ __| | | | '__/ _` | '_ \\ / __/ _ \\   / /\\ \\ | '_ \\| '_ \\  \n" +
                        "  _| |_| | | \\__ \\ |_| | | | (_| | | | | (_|  __/  / ____ \\| |_) | |_) |     \n" +
                        " |_____|_| |_|___/\\__,_|_|  \\__,_|_| |_|\\___\\___| /_/    \\_\\ .__/| .__/   \n" +
                        "                                                           | |   | |            \n" +
                        "                                                           |_|   |_|              ");

            string proceed = "";
            while (proceed.Equals(""))
            {
                //Call OneDevice
                OneDevice();

                //Check proceed?
                proceed = CheckProceed();

                Console.Clear();
            }

            //Display total insurance cost
            Console.WriteLine($"Total insurance cost:\n${Math.Round(totalInsuranceCost, 2)}");

            Console.WriteLine("\nThankyou!");
        }
    }
}