#include <windows.h>
#include <stdlib.h>
#include <string>
#include <iostream>
#include <ctime>
#include <cstdlib>

//make my own function if the dumb one isn't working
//              SAME FUNCTION
//          SAME FUNCTION
//      SAME FUNCTION
//  SAME FUNCTION
int stoi(wchar_t *word){

    int num = 0;
    int placeholder = 1;

    int size = sizeof(word)/sizeof(char *);
    for(int i = 0; i < size; i++){

        char cur = word[i];
        cur -= 48;
            if(!((cur >= 0) && (cur <= 9))) return -1;


        num += cur * placeholder;

        placeholder *= 10;
    }


    return num;
}

void print(char *word){
    std::cout << word << std::endl;
}

            //FOR BETTER USAGE CODE THESE BLOCKS SHOULD BE THEIR OWN FUNCTION
        //good reusablity
    //function();

//rewrote
int write(HANDLE FileHandle, char c){
    DWORD BytesWritten;
    DWORD BytesToWrite;

    BytesToWrite = sizeof(c);
    WriteFile(FileHandle, &c, BytesToWrite, &BytesWritten, 0);

    //casting it as a char pointer means I'M assking to print the string at the address
    // of diff's value, so duh that's wrong

    if(BytesWritten != BytesToWrite) return -1;

    return 0;
}

int write(HANDLE FileHandle, char* string){
    DWORD BytesWritten;
    DWORD BytesToWrite;

    BytesToWrite = sizeof(string);
    WriteFile(FileHandle, string, BytesToWrite, &BytesWritten, 0);

    //casting it as a char pointer means I'M assking to print the string at the address
    // of diff's value, so duh that's wrong

    if(BytesWritten != BytesToWrite) return -1;

    return 0;
}

void PrintNum(int num){
    std::cout << num << std::endl;
}

int part1(int* size, int** lenofEach, int* lenofAData, int argc, wchar_t *argv[]){
    if(argc < 3){
        print("Program Supplements, Needs At Least Two Arguments");

        *size = 50;
        *lenofAData = 3;
        *lenofEach = new int[*lenofAData];
        (*lenofEach)[0] = 5;
        (*lenofEach)[1] = 2;
        (*lenofEach)[2] = 3;
    }
    else{

    *size = stoi(argv[1]);
        if((*size) == -1) return -1;

            //FOR BETTER USAGE CODE THESE BLOCKS SHOULD BE THEIR OWN FUNCTION
        //good reusablity
    //function();

        *lenofAData = argc-2;
        *lenofEach = new int[*lenofAData];
        for(int i = 0; i < *lenofAData; i++){
            (*lenofEach)[i] = stoi(argv[i]);
                if((*lenofEach)[i] == -1) return -1;
        }
    }
}



int part2(int* size, int** lenofEach, int* lenofAData){
    char *path = "C:/Users/adani/Desktop/I,O Level/testCase.txt";
    //CREATEFILE can't create a new directory
    //  (makes sense, use CREATEDIRECTORY INSTEAD)

    char* newline = "\r\n";
    char* space = " ";

    //looked up solution to random seeds for rand()
    srand(time(NULL));

    HANDLE FileHandle = CreateFileA(path, GENERIC_WRITE, 0, 0, CREATE_ALWAYS, 0, 0);
        for(int i = 0; i < *size; i++){
            for(int j = 0; j < *lenofAData; j++){
                for(int k = 0; k < (*lenofEach)[j]; k++){
                    char byte = 0;
                    byte = rand() % 256;

                    if(write(FileHandle, byte) == -1){
                        print("Error for byte writting");
                        return -1;
                    }
                }
                if(write(FileHandle, space) == -1){
                    print("Error for space");
                    return -1;
                }
            }

            if(write(FileHandle, newline) == -1){
                print("Error for newline");
                return -1;
            }
        }

    CloseHandle(FileHandle);
}




//NICE ASS CODE
int wmain(int argc, wchar_t *argv[], wchar_t *envp[]){

    print("\nProgram Start!");
    print(" ");
    int size;
    int *lenofEach; //needs to be defined before new int []; as a pointer
    int lenofAData;

    if(part1(&size, &lenofEach, &lenofAData, argc, argv) == -1){
        print("Part 1 failed");
        return -1;
    }
    if(part2(&size, &lenofEach, &lenofAData) == -1){
        print("Part 2 failed");
        return -1;
    }

    //FEEDBACK is nice
    //this is a pretty good idea
    print("");
    print("Program Finished Perfectly");

    delete lenofEach;
    return 0;
}
