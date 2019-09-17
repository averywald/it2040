using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace URLEncoder {

    class Program {

        // prompts the user for input
        // returns an array of the user's input as strings
        static string[] Prompt() {

            // correct specs for user prompts
            string[] prompts = { "project", "activity" };

            // array to hold inputs corresponding to the prompts
            String[] inputs = new string[2];

            // get user input for each prompt
            for (int i = 0; i < 2; i++) {

                do {

                    // prompt for input and read it in
                    Console.Write("Enter the {0} name: ", prompts[i]);
                    inputs[i] = Console.ReadLine();

                    // check input for hexadecimal control chars
                    if (Regex.IsMatch(inputs[i], @"0x(([0-1]([0-9]|[A-F]))|7F)")) {

                        // nullify input to redo loop
                        inputs[i] = null;
                        Console.WriteLine("!! Oops, cant use control characters. Try again.");

                    }

                } while (String.IsNullOrEmpty(inputs[i]));

            }

            return inputs;

        }

        // encodes user input to be URI safe
            // returns encoded URL string
        static string Encode(string[] input) {

            // replacement values for each unsafe character
            Dictionary<string, string> encoders
                = new Dictionary<string, string> {
                    { "<", "%3C" },
                    { ">", "%3E" },
                    { "#", "%3C" },
                    { "\"", "%22" },
                    { "%", "%25" },
                    { " ", "%20" },
                    { ";", "%3B" },
                    { "/", "%2F" },
                    { "?", "%3F" },
                    { ":", "%3A" },
                    { "@", "%40" },
                    { "&", "%26" },
                    { "=", "%3D" },
                    { "+", "%2B" },
                    { "$", "%24" },
                    { "{", "%7B" },
                    { "}", "%7D" },
                    { "|", "%7C" },
                    { "\\", "%5C" },
                    { "^", "%5E" },
                    { "[", "%5B" },
                    { "]", "%5D" },
                    { "`", "%60" },
                    { ".", "%2E" }
                };

            // check if inputs need encoding
            for (int i = 0; i < input.Length; i++) {
                foreach(var k in encoders) {
                    // if input has a bad character
                    if (input[i].Contains(k.Key)) {
                        // replace with dictionary value
                        input[i] = input[i].Replace(k.Key, k.Value);
                    }
                }
            }

            // build newly cleaned url
            string url = "https://www.companyserver.com/content/"
                + input[0]
                + "/files/"
                + input[1] + "/"
                + input[1] + "Report.pdf";

            return url;
            
        }

        // driver function
        static void Main(string[] args) {

            Console.WriteLine("\n===== URL Encoder =====\n");

            // main loop
            do {

                // execute script
                Console.WriteLine(Encode(Prompt()));

                // prompt for retry
                Console.Write("Would you like to encode another project? : ");

            } while (Regex.IsMatch(Console.ReadLine(), @"\A(y|Y)"));

        }

    }

}
