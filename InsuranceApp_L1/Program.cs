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
            List<string> catagory = new List<string>() { "1. Computer", "2. Tablet", "3. Other" };

            //Collect information
            Console.WriteLine("Enter the device name: \n");
            string deviceName = Console.ReadLine();

            Console.WriteLine("Enter the number of devices: \n");
            float deviceAmount = (float)Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the device cost for 1 device: \n");
            float deviceCost = (float)Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Choose the catagory of the device:");
            for (int index = 0; index < catagory.Count; index++)
            {
                Console.WriteLine(catagory[index]);
            }

            Console.WriteLine(" ");

            int deviceCatagory = CheckInt(1, catagory.Count);
            //Stop collecting information

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
            
            Console.WriteLine("Month: | Value loss:");

            List<float> valueLoss = new List<float>() { deviceCost };

            for (int month = 1; month < 7; month++)
            {
                valueLoss.Add((float)Convert.ToDouble(valueLoss[month -1] * 0.95));
                Console.WriteLine($"{month}      ${Math.Round(valueLoss[valueLoss.Count - 1], 2)}");
            }

            Console.WriteLine($"Catagory: {catagory[deviceCatagory-1]}");
        }
        static string CheckProceed()
        {
            while (true)
            {
                Console.WriteLine("Press <ENTER> to add another device or type 'X' to exit");
                string checkProceed = Console.ReadLine();

                checkProceed = checkProceed.ToUpper();

                if (checkProceed.Equals("") || checkProceed.Equals("X") || checkProceed.Equals("x"))
                {
                    return checkProceed;
                }

                DisplayErrorMessage("Error: Invalid choice");
            }
        }
        static void DisplayErrorMessage(string error)
        {
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
                    int userInt = Convert.ToInt32(Console.ReadLine());

                    if (userInt >= min && userInt <= max)
                    {
                        return userInt;
                    }

                    DisplayErrorMessage($"ERROR: You MUST enter an integer between {min} and {max}.");
                }
                catch
                {
                    DisplayErrorMessage($"ERROR: You MUST enter an integer between {min} and {max}.");
                }
            }
        }

        //Main or when run...
        static void Main(string[] args)
        {
            string proceed = "";
            while (proceed.Equals(""))
            {
                OneDevice();

                proceed = CheckProceed();

                Console.Clear();
            }

            Console.WriteLine($"${totalInsuranceCost}");
        }
    }
}