#ifndef ARVIOPS
#define ARVIOPS
#include <algorithm>

template<typename T>
class array_view_operations
{
private:
    T* outer;
    T* original;
    int size;
public:
    array_view_operations(T* outer, int size) : outer(outer), size(size) {
        original = new T[size];
        for(int i = 0; i < size; ++i){
            original[i] = outer[i];
        }
    }

    template<int N>
    array_view_operations(T (&outer) [N] ) : outer(outer){
        size = N;
        original = new T[size];
        for(int i = 0; i < size; ++i){
            original[i] = outer[i];
        }
    } 

    ~array_view_operations() {
        delete[] original;
    }

    void reverse(){
        for (int i = 0; i < size; ++i){
            outer[i] = original[size - i - 1];
        }
    }

    void reset(){
        for (int i = 0; i < size; i++)
        {
            outer[i] = original[i];
        }
        
    }

    void shift(int value){
        if(value != 0){
            T temp[size];
            value = value % size;
            if(value > 0){
                int i;
                for(i = 0; i < size - value; ++i){
                    temp[i + value] = outer[i];
                }
                for(int j = 0; j < value; ++j){
                    temp[j] = outer[i];
                    ++i;
                }
            }
            else{
                value = value * -1;
                int i;
                for(i = 0; i < size - value; ++i){
                    temp[i] = outer[i + value];
                }
                for(int j = 0; j < value; ++j){
                    temp[i] = outer[j];
                    ++i;
                }
            }

            for(int i = 0; i < size; ++i){
                outer[i] = temp[i];
            }
        }
    }

    void sort(){
        std::sort(outer, outer + size);
    }

    template<typename F>
    void sort(F f){
        std::sort(outer, outer + size, f);
    }

    template<typename F>
    int get_first_index_if(F f){
        for(int i = 0; i < size; ++i){
            if(f(outer[i])){
                return i;
            }
        }
        return -1;
    }
};

#endif