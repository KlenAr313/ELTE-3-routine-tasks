#ifndef SETFILTER_H
#define SETFILTER_H

template <typename T>
class set_filtering{
public:
    set_filtering(std::set<T>& original) : original(original){
    }

    ~set_filtering(){
        // for(std::set<T>::iterator it = filtered.begin(); it != filtered.end(); ++it){
        //     original.insert(*it);
        // }

        // std::copy(filtered.begin(), filtered.end(), std::inserter(original, original.end()));

        original.insert(filtered.begin(), filtered.end());
    }

    void filter(const T& item){
        typename std::set<T>::iterator it = original.find(item);
        if(it != original.end()){
            filtered.insert(*it);
            original.erase(it);
        }
    }

    void unfilter(const T& item){
        typename std::set<T>::iterator it = filtered.find(item);
        if(it != filtered.end()){
            original.insert(*it);
            filtered.erase(it);
        }
    }

    void inverse(){
        original.swap(filtered);
    }
private:
    std::set<T>& original;
    std::set<T> filtered;
};

#endif