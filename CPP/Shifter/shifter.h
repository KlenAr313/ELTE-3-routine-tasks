#ifndef SHIFTER
#define SHIFTER
#include <vector>
#include <map>
#include <string>
#include <type_traits>

template<typename T> struct template_type;

template<template<typename T, typename B, typename...> class t, typename T, typename B, typename ...Args>
struct template_type<t<T, B, Args...>> {
    typedef T type_t;
    typedef B type_b;
};

template<typename T>
using first_template_type_t = typename template_type<T>::type_t;

template<typename B>
using second_template_type_b = typename template_type<B>::type_b;

template <typename C, typename T = second_template_type_b<C>, typename K = first_template_type_t<C>>
class shifter
{
private:
    C& Cont;
public:
    shifter(C& cont) : Cont(cont){} 
    ~shifter(){}

    void shift(int value){
        if(value != 0){
            int size = Cont.size();
            C temp(size);
            value = value % size;
            if(value > 0){
                typename C::iterator it = Cont.begin();
                for(int i = 0; i < size - value; ++i ){
                    try{
                        temp[i + value] = it->second;
                    }
                    catch(){
                        temp[i + value] = *it;
                    }
                    ++it;
                }
                int j = 0;
                for(int i = size - value; i < size; ++i ){
                    try{
                        temp[i + value] = it->second;
                    }
                    catch(){
                        temp[i + value] = *it;
                    }
                    ++j;
                    ++it;
                }
            }
            else if(value < 0){
                int j = 0;
                value = value * -1;
                typename C::iterator it = Cont.begin();
                for(int i = 0; i < value; ++i){
                    ++it;
                }
                for(int i = value; i < size; ++i){
                    try{
                        temp[i + value] = it->second;
                    }
                    catch(){
                        temp[i + value] = *it;
                    }
                    ++j;
                }
                it = Cont.begin();
                for(int i = 0; i < value; ++i){
                    try{
                        temp[i + value] = it->second;
                    }
                    catch(){
                        temp[i + value] = *it;
                    }
                    ++j;
                    ++it;
                }
            }
            
            typename C::iterator it = Cont.begin();
            for(int i = 0; i < size; ++i){
                try{
                    temp[i + value] = it->second;
                }
                catch(){
                    temp[i + value] = *it;
                }
                ++it;
            }
        }
    }

    void operator >> (int value){
        shift(value);
    }

    void operator << (int value){
        shift(-1 * value);
    }

    friend void operator >> (const int& value, shifter& other){
        other.shift(-1 * value);
    } 

    friend void operator << (const int& value, shifter& other){
        other.shift(value);
    }  
};
 

#endif