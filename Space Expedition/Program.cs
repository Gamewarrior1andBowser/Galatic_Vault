using static System.IO.File;
using static System.IO.Directory;

namespace Space_Expedition
{
    static void Main(string[] args) {
        Bootup();
    }

    static void Bootup() {
        if (!File.Exists("C:\\TempData\\Galatic_Vault.txt")) {
            CreateDirectory("C:\\TempData");
            Create("C:\\TempData\\Galatic_Vault.txt");
            Console.WriteLine("New Data has been created in: \"C:\\TempData\\Galatic_Vault.txt\"");
            //Add a continue here
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
            //start the user interface here
        }
    }
}
