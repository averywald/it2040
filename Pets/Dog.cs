using System;
using System.IO;
using System.Collections.Generic;

class Dog : Pet {

    public Dog(string n, string o, float w) : base("Dog", n, o, w) {}

    public void Bark(int times) {
        for (int i = 0; i < times; i++) {
            Console.Write("WOOF!");
        }
    }

}