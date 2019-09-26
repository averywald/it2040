using System;
using System.IO;
using System.Collections.Generic;

// consider turning into abstract class
abstract class Pet {

    string type, name, owner;
    float weight;

    public Pet(string t, string n, string o, float w) {
        this.type = t;
        this.name = n;
        this.owner = o;
        this.weight = w;
    }

    public void GetTag() {
        Console.WriteLine("\nName: {0}", this.name);
        Console.WriteLine("Weight: {0}", this.weight);
        Console.WriteLine("If lost, call {0}", this.owner);
    }

}