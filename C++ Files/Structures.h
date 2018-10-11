//
//  Playing Around 3.h
//  Toying
//
//  Created by Daniel Alemu on 3/18/15.
//  Copyright (c) 2015 YaddaYaddaYadda. All rights reserved.
//

#ifndef __Toying__Playing_Around_3__
#define __Toying__Playing_Around_3__

#include <stdio.h>

#endif /* defined(__Toying__Playing_Around_3__) */

#include <iostream>

using namespace std;

//this is a structure it will be used later on

struct Ready { //ready is the name of the structure
    //the members of the structure go here
    
    char Yellow
    
};

struct go; // this is a single structure named go

int main(){
    
   //Pointers
    
    int *hi;
        //to simply add a pointer just follow the basic variable methods but just add a start just before the variable name
    
        //you can make the variable and declare a pointer to go with it
    int *point, var;
    
        //you can save space and add two pointers
    int *point1, *point2

    
    variable(point);
        //you can give a variable the actual address of another variable
    
    variablept(*point1)
        //or you can give it a star to receive the memory location and the value it's stored with
    
    &variable = pointer;
        //this ampersand is the variables location so it is setting the location of variable equal to pointer
    
    
        //another usage and example
    
    
    int x;            // A normal integer
    int *p;           // A pointer to an integer
    
    p = &x;           // Read it, "assign the address of x to p"
    cin>> x;          // Put a value in x, we could also use *p here
    cin.ignore();
    cout<< *p <<"\n"; // Note the use of the * to get the value
    
    
    int *ptr = new int;
        //this uses memory to store the address of ptr in a int type
    
    delete ptr;
        //the variable ptr would be lost
    
    
    //Structures
    
    //they are used to group variables together (organization)
    
    //NORMALLY THE STRUCTURE SHOULD BE DEFINED BEFORE THE MAIN FUNCTION!
    
 
    Ready blue; //this makes the ready structure into a variable called blue (blue is modifiable)
    
    blue.Yellow = t; //this is how you access the members in a structure (in this case im reassigning the variable's value
    
    Ready fn(); //you can return the structures from functions like this (maybe?)
    
    Ready *ptr; //you can use pointers with structures
    
    ptr = &blue //here you must use an & symbol
    
    cout<< ptr->Yellow; //the pointer takes the value in the structure
    
    cin.get();
}
