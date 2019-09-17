using System;

namespace Dog {

    public enum Gender {
        MALE,
        FEMALE
    };

    public class Dog {

        // attributes
        public string name, owner;
        public int age;
        public Gender gender;

        // constructor
        public Dog(
            string n = "Fido",
            string o = "None",
            int a = 0,
            Gender g = Gender.MALE) {

            // assign arguments to object
            this.name = n;
            this.owner = o;
            this.age = a;
            this.gender = g;

        }

        // print 'Woof!' to the console the number of times in the argument
        public void Bark(int count) {

            for (int i = 0; i < count; i++) {
                Console.WriteLine("Woof! ");
            }

        }

        // print Dog object's attributes on his or her collar
        public string GetTag() {

            // get correct pronouns
            string[] pronouns = new string[2];
            if (this.gender == Gender.FEMALE) {
                pronouns[0] = "Her";
                pronouns[1] = "she";
            } else {
                pronouns[0] = "His";
                pronouns[1] = "he";
            }

            // check for 'year(s)' pluralization
            string pluralizer;
            if (this.age == 1) {
                pluralizer = " year";
            } else {
                pluralizer = " years";
            }

            // return text on Dog's collar
            return "\nIf lost, call " + this.owner +
                "\n" + pronouns[0] + " name is " + this.name +
                ", and " + pronouns[1] + " is " + this.age +
                pluralizer + " old\n";     
        }

    }

    class Program {
        static void Main(string[] args) {

            // new Dog object
            Dog puppy = new Dog("Orion", "Shawn", 1, Gender.MALE);
            puppy.Bark(3);
            Console.WriteLine(puppy.GetTag());

            // another Dog object
            Dog myDog = new Dog("Kaluah", "Avery", 0, Gender.FEMALE);
            puppy.Bark(5);
            Console.WriteLine(myDog.GetTag());

        }
    }
}
