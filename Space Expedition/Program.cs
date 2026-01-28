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
                } catch (IOException) {
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
                    AddToVault();
                } else if (userInput == "2") {
                    ViewVault();
                } else if (userInput == "3") {
                    ViewLogs();
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Have a good rest of your day!");
            Console.WriteLine("Shutting down...");
        }

        static void AddToVault() {
            string userInput = "";
            string name = "";
            string location = "";
            string year = "";
            string log = "";
            while (userInput != "Y") {
                Console.Clear();
                Console.Write("What's the name of Artifact: ");
                name = Console.ReadLine().ToString();
                Console.Write($"Where was the {name} found: ");
                location = Console.ReadLine().ToString();
                Console.Write($"What year was {name} found in {location} (use format YYYY): ");
                year = Console.ReadLine().ToString();
                Console.WriteLine();
                Console.Write($"So {name} was found in {location} on {year}? (Y/N): ");
                userInput = Console.ReadKey().KeyChar.ToString().ToUpper();
            }
            Console.WriteLine("");
            while (userInput != "1" && userInput != "2") {
                Console.Clear();
                Console.WriteLine($"1: Use the following prompt as the Journey Log for this artifact -> ({name} was found in {location} on {year})");
                Console.WriteLine("2: Write your own Journey Log for this artifact");
                Console.Write($"Please choose a number for an option from above: ");
                userInput = Console.ReadKey().KeyChar.ToString().ToUpper();
            }
            if (userInput == "2") {
                Console.Clear();
                Console.WriteLine($"Reference: (name: {name}, location: {location}, year: {year})");
                Console.WriteLine($"Use the reference above when writing, hit the Enter key when you're done!");
                Console.WriteLine($"");
                log = Console.ReadLine();
            }
            Console.WriteLine("");


            UpdateData(name, location, year, log);
            Console.WriteLine("");
            Console.WriteLine("Artifact data has been saved to: \"C:\\TempData\\Galatic_Vault.txt\"");

            Continue();
        }

        static void ViewLogs() {

        }

        static void ViewVault() {
            Console.WriteLine("All registered Artifacts in the Vault:");
            Artifact[] data = LoadVault();
            Console.WriteLine("");
            for (int i = 1; i < data.Length + 1; i++) {
                data[i - 1].Decode();
                Console.WriteLine($"{i}: {data[i - 1].Print()}");
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Continue();
        }


        static Artifact[] LoadVault() {
            int count = 1;
            string data = ReadAllText("C:\\TempData\\Galatic_Vault.txt");
            for (int i = 0; i < data.Length; i++) {
                if (data[i].ToString() == ",") {
                    count += 1;
                }
            }
            Artifact[] output = new Artifact[count];
            count = 0;
            int index = 0;
            for (int j = 0; j < output.Length; j++) {
                string[] temp = new string[4];
                string word = "";
                int tempCount = 0;
                for (int i = index; i < data.Length; i++) {
                    if (data[i].ToString() == ",") {
                        i = data.Length - 1;
                    } else {
                        if (data[i].ToString() == " ") {
                            if (data[i + 1].ToString() == "|") {
                                temp[tempCount] = word;
                                word = "";
                                tempCount += 1;
                                i += 2;
                            } else {
                                word = word + data[i].ToString();
                            }
                        } else {
                            word = word + data[i].ToString();
                        }
                        if (i + 1 == data.Length) {
                            temp[tempCount] = word;
                        } else if (data[i + 1].ToString() == ",") {
                            temp[tempCount] = word;
                            index = i + 3;
                        }
                    }
                }
                output[count] = new Artifact(temp[0], temp[1], temp[2], temp[3]);
                count += 1;
            }
            return output;
        }


        static void UpdateData(string name, string location, string year, string log) {
            Artifact temp = new Artifact(name, location, year, log);
            Artifact[] artifactData = LoadVault();
            Artifact[] artifactOutput = new Artifact[artifactData.Length + 1];
            int dataIndex = 0;
            bool addedNewData = false;
            for (int i = 0; i < artifactOutput.Length; i++) {
                if (i < artifactData.Length && addedNewData == false) {
                    if (int.Parse(artifactData[i].Year) > int.Parse(temp.Year)) {
                        addedNewData = true;
                        artifactOutput[i] = temp;
                    } else {
                        artifactOutput[i] = artifactData[dataIndex];
                        dataIndex += 1;
                    }
                } else if (i == artifactData.Length && addedNewData == false) {
                    addedNewData = true;
                    artifactOutput[i] = temp;
                } else {
                    artifactOutput[i] = artifactData[dataIndex];
                    dataIndex += 1;
                }
            }
            string artifactFile = "";
            for (int i = 0; i < artifactOutput.Length; i++) {
                artifactFile += artifactOutput[i].Save();
                if (i != artifactOutput.Length - 1) {
                    artifactFile += ", ";
                }
            }
            WriteAllText("C:\\TempData\\Galatic_Vault.txt", artifactFile);
        }

        static void Continue() {
            Console.WriteLine("");
            Console.WriteLine("(Press any Key to Return to the Menu)");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
