//
//  Beginning.h
//  Toying
//
//  Created by Daniel Alemu on 3/8/15.
//  Copyright (c) 2015 YaddaYaddaYadda. All rights reserved.
//

#include <iostream>
//adds a prewritten function, iostream includes cout


using namespace std;
//tells compiler to use functions that are a part of the library std
// semicolons indicate the end of a command

int math (int j, int v);
//this is a function that is specified for later use


int main(int argc, const char * argv[])
//it informs the compiler that there is a function called main, and it returns an integer (int)

{  //curly braces signal the start and ending of functions or other code blocks
    
    
    std::cout << "Hello, World!\n";
    //the cout command displays text
    
    //the '<<' are telling cout what to output, they are called insertion operators
    
    //like in Python, the quotes ("") tells the command to output the text inside as a string
    
    //the \n tells the command to make a new line and moves your cursor to the new line
    
    
    //std is the library, as mention before
    
    cin.get();
    //this allows for the program to keep running until the user hits the enter button, when that person does so the program will close
    
    int y;
    
    cin>> y;
    //accepts input from the user and stores it into the variable 'variable_letter.'
    
    //the input will have to be stored in variable
    //variables are created by listing the type followed by the name
    
    char variable_letter;
    // can be a char (single character)
    int x;
    // int which stores integers
    float decimal;
    // float which stores numbers with decimals, and more
    int a, b, c, d;
    //multiple variables can be made in a single line (seperated by a comma)
    
    
    //Uses for variables
    
    char joy;
    
    cout<<"What's your favorite letter?: ";
    cin>> joy;
    //the code waits for the user to press enter before it reads the input
    //remember, the variable only accepts letters
    //notice how the '<<' are in reverse
    cin.ignore();
    //the code reads the enter, so this tells it to ignore it and instead store the rest of the input
    //if the variable was a int and a float was inputed, then the decimal would be ignored
    cout<< joy << " is your favorite letter!\n";
    //displays the variable followed by the string, each part, will have to be seperate by a <<, and end with a string form of \n.
    
    
    //If statements, changing/comparing variables
    
    //comparing variables is the same for C++ as it is for python ( == , < , > , != , etc.)
    //same for modifying them (a = 5, a + b = c)
    
    if(true){
        cout<<"1\n";
    }       //must include parenthesis around the              condition
    //this if statement will always run
    else if(false){
        //else if statements have to be spelled out (not like elif from python)
    }
    else{
        //else statements are no different in C++
    }
    
    char color;
    
    cout<<"What is the first letter of your favorite color?\n";
    
    cin>>color;
    
    cin.ignore();
    
    if (color == 'b'){
        cout<<"Oh yeah, I like that color too!\n";
    }
    
    else if (color == 'r'){
        cout<<"That color is pretty nice.\n";
    }
    
    else{
        cout<<"It seems we have different tastes :l\n";
    }
    
    return 1;
    //returns the value 1 to the main function, can be used to determine if the program was successful
    
    //other operators include the not, and, and or operators, but they all funciton like they do as in python
    
    //IMPORTANT: 1 = True, 0 = False
    
    //the not operator is written as '!'
    //!1 = 0
    //!0 = 1
    
    
    //the and operator is written as '&&'
    //1 && 0 = 0, which means it's falso
    //1 && 1 = 1
    //0 && 0 = 0
    
    
    //the or  operator is written as '||', if either of the values are true, it returns true
    //1 || 0 = 1
    //0 || 0 = 0
    
    
    //these operators can be combined in a single function
    
    if (!((1 | 0) && 0)){
        cout<<"This function is true.\n"; //By following the order of operations, the final answer becomes 1, which is true so the function is performed
    }
    
    //Loops
    
    for (int z = 1; z < 5; z++){
        //this is a for loop, so first is the variable initialization that allows you to define a variable, second is the condition that will continue the function if it is true, and lastly is the variable update that will update the variable everytime the code block is completed
        // the ++ after z adds z by one
        cout << "Hi!/n";
    }
    
    x = 0;
    
    while(x < 10){;
        //then there is the while loop that only has a condition statement but will run forever if it stays true
        cout << x;
        x++;
    }
    do { cout<<"Hey!/n";
    }while (x != 0);
    //and finally there are do while loops which are just like the while loop but there is a do function before the while where the code goes, a do while loop will loop the code at least once even if the condition is false, such as the condition that was insert in the do while function
    
    //Functions
    
    int func = rand();
    //variables can be set to equal to functions, a function must be specificed before the main function is executed
    
    int j;
    int v;
    cout<<"Please input two numbers to be multiplied:";
    cin>> j >> v;
    cin.ignore();
    cout<<"The product of your two numbers is " <<math (c, v) <<"\n";
    cin.get();
}

int math (int c, int v)
{
    //this has two argument types so it will accept two values that are integers, and the math function has been specified to return an integer
    //and the funciton's protocol's must be specified after the main function
    return c * v; //the function returns this value
}



//if was a success and it isn't required to return a value, it will return a 0