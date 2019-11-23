1. What are the differences between a Class and a Struct?
    - Classes and Structs differ in C# in a few different ways:
        - Structs cannot have a default (parameter-less) constructor
        - Structs are value types
        - Classes are reference types
        - Structs do not utilize inheritance
2. When and where is the ```finally``` keyword used?
    - The ```finally``` keyword is used after a sequence of ```try``` and ```catch``` blocks
    - A ```finally``` block executes after the previous blocks are finished
3. Name some properties of an array.
    - C# Array Class properties include:
        - ```IsFixedSize```
        - ```IsReadOnly```
        - ```IsSynchronized```
        - ```Length```
        - ```LongLength```
        - ```Rank```
        - ```SyncRoot```
4. What is an escape sequence? Name some String escape sequences.
    - Escape sequences are used to specify text-based actions in terminals and printers
    - Examples of escape sequences include:
        - ```\n```: new line sequence
        - ```\b```: backspace
        - ```\r```: carriage return
        - ```\\```: backslash
        - ```\"```: double quotation mark
5. What are the basic String Operations? Explain.
    - Some basic string operations are:
        - `CompareTo()`:
            - Compares 2 strings and returns 0 or 1 depending on a match
        - `Contains()`:
            - Checks a string for a matching substring
        - `Equals()`:
            - Compares 2 strings and returns a `bool`
        - `Substring()`:
            - Returns the substring between 2 indices
        - `Length`:
            - Returns the length of the string
6. What is the difference between ```continue``` and ```break``` statements?
    - The difference is that `continue` skips the current iteration of a loop, while `break` quits the loop
7. Explain ```get``` and ```set``` accessor properties.
    - Accessors publicly expose class properties, while hiding functionality in their blocks
8. What is an object?
    - An Object in C# is a block of memory allocated according to the rules defined in the object's class definition
9. What is a class?
    - A Class is a definition or blueprint of which to create Objects according to that blueprint
10. Can we use ```this``` command within a static method?
    - The ```this``` keyword cannot be used in a static method because they don't need to reference an object, which ```this``` is used for, to execute
11. What is the difference between "method overriding" and "method overloading?"
    - Overloading:
        - Writing multiple method definitions in the same scope and providing different functionality
    - Overriding:
        - Writing a different method definition in a child class
12. What are the differences between ```static```, ```public``` and ```void```?
    - `static` tells the compiler that the function should be executed without an instance of a class
    - `public` is an access modifier that makes the function global and accessible in any scope
    - `void` is a return type that does not return any value from the function
13. What are value types?
    - Value data types, such as `bool`, `int`, `float`, etc. store data directly.
14. What are reference types?
    - Reference types, such as `Class`, `Object`, `String`, etc. store data indirectly.
    Multiple Reference type variables can reference the same object/data.
15. If a ```return``` is provided in a ```try``` block, does the ```finally``` block execute?
    - The ```finally``` block always executes, even if a ```try``` block returns something
16. How do you sort array elements in descending order?
    - There are several ways to sort an array in descending order in C#:
        - Using LINQ `OrderByDescending()` method
        - Using `Array.Sort()` and `Array.Reverse()` subsequently
17. What is the difference between the ```as``` and ```is``` operators?
    - The `as` operator casts variables between compatible reference or Nullable types
    - The `is` operator checks the run-time type of a variable against a defined type and returns a `bool`
18. What is ```enum```?
    - `enum` is a value type data type with which to define a collection of constants.
19. What is the difference between an interface and an abstract class?
    - In C#, an abstract class can be fully implemented, while an interface can only have method signatures
20. What are partial classes?
    - A partial is a class that gets compiled into a single class file, with all the functionality of each partial within it