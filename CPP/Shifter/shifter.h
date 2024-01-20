#ifndef SHIFTER
#define SHIFTER
#include <vector>
#include <map>
#include <string>
#include <type_traits>
#include <iostream>

template<typename T> struct template_type;

template<template<typename T, typename B, typename...> class t, typename T, typename B, typename ...Args>
struct template_type<t<T, B, Args...>> {
    typedef T type_t;
    typedef B type_b;
};

template <typename C, typename T = typename template_type<C>::type_b>
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
            std::vector<T> temp(size);
            if(value > 0){
                value = value % size;
                typename C::iterator it = Cont.begin();
                for(int i = 0; i < size - value; ++i ){
                    temp[i + value] = *it;
                    ++it;
                }
                int j = 0;
                for(int i = size - value; i < size; ++i ){
                    temp[j] = *it;
                    ++j;
                    ++it;
                }
                
                
            }
            else if(value < 0){
                value = value * -1;
                value = value % size;
                typename C::iterator it = Cont.begin();
                std::advance(it, value);
                int j = 0;
                for(int i = value; i < size; ++i){
                    temp[j] = *it;
                    ++it;
                    ++j;
                }
                it = Cont.begin();
                for(int i = 0; i < value; ++i){
                    temp[j] = *it;
                    ++j;
                    ++it;
                }
            }
            
            typename C::iterator it = Cont.begin();
            for(int i = 0; i < size; ++i){
                *it = temp[i];
                //std::cout << *it << ' ';
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

template< typename C >
class shifter<C, typename template_type<C>::type_b>{
private:
    C& Cont;
public:
    shifter(C& cont) : Cont(cont){}
    ~shifter(){} 

    void shift(int value){
        if(value != 0){
            int size = Cont.size();
            std::vector<typename template_type<C>::type_b> temp(size);
            if(value > 0){
                value = value % size;
                typename C::iterator it = Cont.begin();
                for(int i = 0; i < size - value; ++i ){
                    temp[i + value] = it->second;
                    ++it;
                }
                int j = 0;
                for(int i = size - value; i < size; ++i ){
                    temp[j] = it->second;
                    ++j;
                    ++it;
                }
                
                
            }
            else if(value < 0){
                value = value * -1;
                value = value % size;
                typename C::iterator it = Cont.begin();
                std::advance(it, value);
                int j = 0;
                for(int i = value; i < size; ++i){
                    temp[j] = it->second;
                    ++it;
                    ++j;
                }
                it = Cont.begin();
                for(int i = 0; i < value; ++i){
                    temp[j] = it->second;
                    ++j;
                    ++it;
                }
            }
            
            typename C::iterator it = Cont.begin();
            for(int i = 0; i < size; ++i){
                it->second = temp[i];
                //std::cout << *it << ' ';
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