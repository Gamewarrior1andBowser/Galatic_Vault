using static System.IO.File;
using static System.IO.Directory;

namespace Space_Expedition
{
    internal class Program {
        static void Main(string[] args) {
            Bootup();
        }

        static void Bootup() {
            if (!File.Exists("C:\\TempData\\Galatic_Vault.txt")) {
                CreateDirectory("C:\\TempData");
                Create("C:\\TempData\\Galatic_Vault.txt");
                Console.WriteLine("New Data has been created in: \"C:\\TempData\\Galatic_Vault.txt\"");
                Continue();
                try {
                    WriteAllText("C:\\TempData\\Galatic_Vault.txt", "Hopeium | Meme World | 2021 | A rainbow colored crystal filled with immense power, it only appears when all hope seems lost.");
                } catch (System.IO.IOException) {
                    Console.WriteLine("Error, failed to preset file.");
                    Console.WriteLine("Please open \"C:\\TempData\\Galatic_Vault.txt\" and paste \"Hopeium | Meme World | 2021 | A rainbow colored crystal filled with immense power, it only appears when all hope seems lost.\" into the text file after you close the application.");
                    Console.WriteLine("");
                    Console.WriteLine("Then reboot the Space Expedition tracker!");
                    Console.WriteLine("");
                }
            } else {
                MainMenu();
            }
        }

        static void MainMenu() {
            string userInput = "";
            while (userInput != "4") {
                Console.WriteLine("Welcome to the Space Expedition tracker!");
                Console.WriteLine("");
                Console.WriteLine("1: Add an Artifact and Journey Log to the Galatic Vault");
                Console.WriteLine("2: View all Artifacts in the Galatic Vault");
                Console.WriteLine("3: View all Journey Logs in the Galatic Vault");
                Console.WriteLine("4: Exit the tracker");
                Console.Write("Please choose a number for any of the options from above: ");
                userInput = Console.ReadKey().KeyChar.ToString();
                if (userInput != "4") {
                    Console.Clear();
                }
                if (userInput == "1") {
                    //Add To Vault;
                } else if (userInput == "2") {
                    //View items in Vault;
                } else if (userInput == "3") {
                    //View Logs in Vault;
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Have a good rest of your day!");
            Console.WriteLine("Shutting down...");
        }


        static void Continue() {
            Console.WriteLine("");
            Console.WriteLine("(Press any Key to Return to the Menu)");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
