using System;

namespace CsharpBasics {

    class Program {

        static void Main(string[] args) {

            // declarations
            const byte sample1 = 0x3A;
            byte sample2 = 58;
            int heartRate = 85;
            double deposits = 135002796;
            const float acceleration = 9.800f;
            float mass = 14.6f;
            double distance = 129.763001;
            bool lost = true;
            bool expensive = true;
            int choice = 2;
            const char integral = '\u222B';
            const string greeting = "Hello";
            string name = "Karen";

            // compare samples
            if (sample1.Equals(sample2)) {
                Console.WriteLine("The samples are equal");
            }
            else {
                Console.WriteLine("The samples are not equal");
            }

            // check heart rate
            if (heartRate >= 40 && heartRate <= 80) {
                Console.WriteLine("Heart rate is normal");
            }
            else {
                Console.WriteLine("Heart rate is not normal");
            }

            // check deposits
            if (deposits >= 100000000) {
                Console.WriteLine("You are exceedingly wealthy");
            }
            else {
                Console.WriteLine("Sorry you are so poor");
            }

            // calculate force
            dynamic force = mass * acceleration;
            Console.WriteLine("force = {0}", force);

            // print distance
            Console.WriteLine("{0} is the distance", distance);

            // boolean cases
            if (lost == true && expensive == true) {
                Console.WriteLine("I am really sorry! I will get the manager");
            }
            else if (lost == true && expensive == false) {
                Console.WriteLine("Here is a coupon for 10% off");
            }

            // choice switch block
            switch (choice) {
                case 1:
                    Console.WriteLine("You chose 1");
                    break;
                case 2:
                    Console.WriteLine("You chose 2");
                    break;
                case 3:
                    Console.WriteLine("You chose 3");
                    break;
                default:
                    Console.WriteLine("You made an unknown choice");
                    break;
            }

            // display integral var
            Console.WriteLine("{0} is an integral", integral);

            // for loop
            for (int i = 5; i <= 10; i++) {
                Console.WriteLine("i = {0}", i);
            }

            // while loop
            int age = 0;
            while (age < 6) {
                Console.WriteLine("age = {0}", age);
                age++;
            }

            // display strings
            Console.WriteLine("{0} {1}", greeting, name);

        }
    }
}
