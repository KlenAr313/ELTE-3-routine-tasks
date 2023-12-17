#ifndef SETFILTER_H
#define SETFILTER_H

/*
template <typename T>
struct Less{
public:
    bool operator < (const T& right) const{
        return *this < right;
    }
};*/

template <typename T, typename Comp = std::less<T>>
class set_filtering{
    typedef std::set<T, Comp> CompSet;
public:
    set_filtering(CompSet& original) : original(original){
    }

    ~set_filtering(){
        // for(CompSet::iterator it = filtered.begin(); it != filtered.end(); ++it){
        //     original.insert(*it);
        // }

        // std::copy(filtered.begin(), filtered.end(), std::inserter(original, original.end()));

        original.insert(filtered.begin(), filtered.end());
    }

    void filter(const T& item){
        typename CompSet::iterator it = original.find(item);
        if(it != original.end()){
            filtered.insert(*it);
            original.erase(it);
        }
    }

    void unfilter(const T& item){
        typename CompSet::iterator it = filtered.find(item);
        if(it != filtered.end()){
            original.insert(*it);
            filtered.erase(it);
        }
    }

    void inverse(){
        original.swap(filtered);
    }

    void operator~(){
        inverse();
    }

    template <typename F>
    void operator+=(F f){
        for(typename CompSet::iterator it = original.begin(); it != original.end();){
            if(f(*it)){
                filtered.insert(*it);
                original.erase(it++);
            }
            else{
                ++it;
            }
        }
    }

    template <typename F>
    void operator-=(F f){
        for(typename CompSet::iterator it = filtered.begin(); it != filtered.end();){
            if(f(*it)){
                original.insert(*it);
                filtered.erase(it++);
            }
            else{
                ++it;
            }
        }
    }

private:
    CompSet& original;
    CompSet filtered;
};

#endif