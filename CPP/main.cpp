#include <iostream>

int f (int a){
    std::cout << a << std::endl;
    return a;
}

int main(){

    char* c = "hello";

    int t[10];

    int i = 11;
    int* p = (t +1);
    *p = 12;

    std::cout << *(p+1) << std::endl;


    int& r = i;

    int a = 22;
    f(a++);
    


    // why const at string ptr
    // lvalue vs rvalue   
    // meg lehet e akadájozni a destruálást?
    //// realloc? 
    //// static hozzáfér e a privát adattagokhoz? - Igen
    // copy ctor -> nincs def ctor !! def ctor -> lesz copy ctor
}