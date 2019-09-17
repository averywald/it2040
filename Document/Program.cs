using System;
using System.IO;

namespace Document {

    class Program {

        // get user input for file name
            // format the input string for filesystem use
            // check filesystem for files matching input
        public string nameFile() {

            // prompt user for input
            Console.WriteLine("\nEnter the name of the file to be created");

            // store file name input
            string fileName = Console.ReadLine();

            // check file name for '.txt' extention
            if (!fileName.Contains(".txt")) {

                // if not, concatenate
                fileName = String.Concat(fileName, ".txt");

            }

            // prepend full directory path to the file name
            fileName = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName +
                "/" + fileName;

            // check if the file already exists
            if (System.IO.File.Exists(fileName)) {

                // print error message
                Console.WriteLine("\n{0} already exists", fileName);

                // re-run function
                return nameFile();

            }

            // return the path with the specified file name
            return fileName;

        }

        static void Main(string[] args) {

            // prompt user for file name
            Console.WriteLine("Document\n");

            // create new obj - cast to string by method
            string fileName = new Program().nameFile();

            // create new input stream in file named after the user's input
            StreamWriter sw = new StreamWriter(fileName);

            try {

                // prompt user for content to write to the file
                Console.WriteLine("\nEnter content for {0}: ", fileName);

                // store content to be written
                sw.WriteLine(Console.ReadLine());


            } catch (Exception e) {

                // print exception to the console
                Console.WriteLine("Exception: " + e.Message);

            } finally {

                // success message for filename
                Console.WriteLine("Successfully wrote and saved {0}", fileName);

                // close the stream writer
                if (sw != null) {
                    sw.Close();
                }

                // read the file contents
                using (StreamReader sr = new StreamReader(fileName)) {

                    // char count
                    int charCount = sr.ReadToEnd().ToCharArray().Length;
                    Console.WriteLine("\nThe document contains {0} characters", charCount);
                    sr.Close();

                }

            }
        }
    }
}
