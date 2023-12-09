#include <iostream>
#include <vector>
#include <algorithm>
#include <set>

int main(){
    std::vector<int> v1;

    v1.push_back(1);
    v1.push_back(2);
    v1.push_back(3);

    std::vector<int> v2;
    std::set<int> s;

    std::copy(v1.begin(), v1.end(), std::back_inserter(v2));

    std::copy(v1.begin(), v2.end(), std::inserter(s, s.begin()));
    std::set<int> s2(v1.begin(), v1.end());

    std::sort(v1.rbegin(), v1.rend());

    
}