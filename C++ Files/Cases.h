//
//  Playing Around 2.h
//  Toying
//
//  Created by Daniel Alemu on 3/14/15.
//  Copyright (c) 2015 YaddaYaddaYadda. All rights reserved.
//

#ifndef __Toying__Playing_Around_2__
#define __Toying__Playing_Around_2__

#include <stdio.h>

#endif /* defined(__Toying__Playing_Around_2__) */

#include <iostream>

using namespace std;

//for the example:
void playgame()
{
    cout << "Play game called";
}
void loadgame()
{
    cout << "Load game called";
}
void playmultiplayer()
{
    cout << "Play multiplayer game called";
}


int main()

{
    //Switch Cases
    
    int a = 7
    
    switch (a) {
            //in a switch case first the expression that will be a refrence must be defined
            
        case a == 7:
            //the a condition must be set (more than one condition may be include in a switch block)
            //cases must start with case (unless default) and end with a colon
            
            return "Hey it works!/n";
            break; //exits the code block
            
        default:
            //if the condition isn't met then this code will be executed
            
            return "It didn't work :(/n"
            break;
    
            //Example: (it will not run, becuase of the undefined functions that aren't given bodies)
            int input;
            
            cout<<"1. Play game\n";
            cout<<"2. Load game\n";
            cout<<"3. Play multiplayer\n";
            cout<<"4. Exit\n";
            cout<<"Selection: ";
            cin>> input;
            switch ( input ) {
                case 1:            // Note the colon, not a semicolon
                    playgame();
                    break;
                case 2:            // Note the colon, not a semicolon
                    loadgame();
                    break;
                case 3:            // Note the colon, not a semicolon
                    playmultiplayer();
                    break;
                case 4:            // Note the colon, not a semicolon
                    cout<<"Thank you for playing!\n";
                    break;
                default:            // Note the colon, not a semicolon
                    cout<<"Error, bad input, quitting\n";
                break;    }
    
    cin.get();
}