using System;
using System.IO;

namespace Pets {
    class Program {
        static void Main(string[] args) {

            // pet instances
            Cat mowgli = new Cat("Mowgli", "Don", 500);
            mowgli.GetTag();
            mowgli.Mew(8);

            Dog trouble = new Dog("Trouble", "Gio", 10);
            trouble.GetTag();
            trouble.Bark(4);

            Dog kaluah = new Dog("Kaluah", "Avery", 25);
            kaluah.GetTag();
            kaluah.Bark(10);

        }
    }
}
