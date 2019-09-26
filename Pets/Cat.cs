using System;
class Cat : Pet {

    public Cat(string n, string o, float w) : base("Cat", n, o, w) { }

    public void Mew(int times) {
        for (int i = 0; i < times; i++) {
            Console.Write("Meow...");
        }
    }

}