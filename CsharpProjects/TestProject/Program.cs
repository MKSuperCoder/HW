using System;

string[] pettingZoo =
{
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
};

#region Design Specification and Pseudo Code
/*- There will be three visiting schools
   - School A has six visiting groups (the default number)
   - School B has three visiting groups
   - School C has two visiting groups

- For each visiting school, perform the following tasks
    - Randomize the animals
    - Assign the animals to the correct number of groups
    - Print the school name
    - Print the school name
    - Pritn the animal groups
 Pseudo-code for one school

Pseudo-code method for randomizing the petting zoo animals
RandomizeAnimals();

Pseudo-code method to assign animal group
AssignGroup();

Print school name using Console.Write
Console.WriteLine("School A");

Print animal groups
PrintGroup(group);
We added a parameter to this method. We know that we need to print
different groups of animals several times, so you use a method to 
perform this task with the groyp as the input parameter

We can assign the group argument by storing the value returned by 
AssignGroup() into a variable.
var group = AssignGroup();
We used the var keyword so that it can store variables of any data type

Now let's consider what data type to assign to the group variable.
we want School A to have animals assigned into six groups. We also know 
that there are 18 animals and that they are represented using string.

So, we can use a 2D array that contains six groups of three animals each.
Instead of using var, we can use the string data type
string[,] group = AssignGroup();
THe default group value is six so we don't have to add any arguments to 
the AssignGroup method in this case. */
#endregion

PlanSchoolVisit("School A");
PlanSchoolVisit("School B", 3);
PlanSchoolVisit("School C", 2);

void PlanSchoolVisit(string schoolName, int groups = 6)
{
    RandomizeAnimals();
    string[,] group = AssignGroup(groups);
    Console.WriteLine(schoolName);
    PrintGroup(group);
}

void RandomizeAnimals()
{
    Random random = new Random();
    // Initialize a random object to generate a random number

    for (int i = 0; i < pettingZoo.Length; i++) 
    {
        int r = random.Next(i, pettingZoo.Length);
        // Initialize r to a random integer between i and the length of the pettingZoo array
        // This ensures that we don't go out of bounds of the array

        string temp = pettingZoo[i];
        pettingZoo[i] = pettingZoo[r];
        pettingZoo[r] = temp;
    }
}
//The default group size is 6
string[,] AssignGroup(int groups = 6)
{
    string[,] result =new string[groups, pettingZoo.Length/groups];
    /* groups represents the number of animal groups you want to 
    create.
    pettingZoo.length/groups reflects how many animals are assigned to each group
    For example, since pettingZoo is a fixed array of 18 elements, the 2D array size 
    for School A is [6, 3] */

    int start = 0;
    //The outer for loop cycles through each group
    for (int i = 0; i < groups; i++)
    {
        // The inner for loop cycles for the number of animals the group should contain
        for (int j = 0; j < result.GetLength(1); i++)
        {
            result[i,j] = pettingZoo[start++];
        }
    }
    return result;
}
void PrintGroup(string[,] group)
{
    //We use GetLength(0) to get the number of rows in the array, and GetLength(1) for 
    // the number of columns
    for (int i = 0; i < group.GetLength(0); i++)
    {
        Console.Write($"Group {i + 1}: ");
        for (int j = 0; j < group.GetLength(1); j++)
        {
            //We use Console.Write to print the element with some extra spaces 
            //between the animals
            Console.Write($"{group[i,j]} ");
        }
        Console.WriteLine();
    }
}
#region Test RandomizeAnimals() method
/*foreach (string animal in pettingZoo)
{
    Console.WriteLine(animal);
} */
#endregion

