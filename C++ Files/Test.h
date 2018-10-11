
//
//  Test.h
//  Toying
//
//  Created by Daniel Alemu on 3/21/15.
//  Copyright (c) 2015 YaddaYaddaYadda. All rights reserved.
//

#ifndef __Toying__Tests__
#define __Toying__Tests__

#include <stdio.h>

#endif /* defined(__Toying__Tests__) */

#include <iostream>

using namespace std;

struct Records {
    
    int z, n, m, number;
    
};


int mult (int o, int p)
{
    return o * p;
}


void repricate ()
{
    cout << "Oh, that's not too hot or too cold! :)/n";
}


int main (){
    
    char x, r, j, y;
    
    int z;
    
    cout << "What is your chosen path?/n";
    
    cin.get();
    
    cin >> x, r, j;
    
    cin.ignore();
    
    cout << "So if you're going to follow the " << x << r << j << " path, then what will you do to get there?/n";
    
    cin.get();
    
    cin >> y;
    
    cin.ignore();
    
    
    cout << "Do you believe you can make it? Type 1 for yes, type 2 for no./n";
    
    cin.get();
    
    cin >> z;
    
    if (z == 1) {
        
        for (int continous = 0; continous < 5; continous++){
            
            cout << "Why?/n";
            
            cin.get();
            
        }
    }
    
    cout << "Choose two numbers that best represent you./n";
    
    int o, p;
    
    cin.get();
    
    cin >> o >> p;
    
    cout << "This number represents both of your numbers" << mult (o,p) << "/n";
    
    cin.get();
    
    int number;
    
    while (number == 0) {
    
        
    cout << "1. You like to play it safe.\n";
    cout << "2. You are in the middle and utilize the cards in your hand.\n";
    cout << "3. You are a huge gambler.\n";
    
    cin >> number;
    
    switch (number) {
        case 2: //Hint: if number is equal to two (hence the two) this case will be executed
            repricate ();
            break;
        
        case 1:
            cout << "That's a small number./n";
            break;
        
        case 3:
            cout <<"Oh, thats a big number./n";
            break;
        
        default: //Hint: if the other cases aren't chosen.
            cout << "Try again./n";
            number = 0;
            break;
        }
    }
    cin.get();
    
}
