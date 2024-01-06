#include <iostream>
#include <vector>
#include <iterator>


bool search(int current, int destination, std::vector<std::vector<int>>& adjacent, std::vector<int>& visited)
{
    if (current == destination) {
        return true;
    }
    visited[current] = 1;
    for(std::vector<int>::iterator it = adjacent[current].begin(); it != adjacent[current].end(); ++it){
        if (!visited[*it]) {
            if (search(*it, destination, adjacent, visited)) {
                return true;
            }
        }
    }
    return false;
}

bool isPath(int source, int destination, std::vector<std::vector<int>>& adjacent, int n)
{
    std::vector<int> visited(n, 0);
    return search(source, destination, adjacent, visited);
}

std::vector<int> findMaxSCC(int n, std::vector<std::vector<int>>& a)
{
    std::vector<std::vector<int>> allSCC;

    std::vector<int> isScc(n, 0);

    std::vector<std::vector<int>> adjacent(n);

    int i = 0;
    for(std::vector<std::vector<int>>::iterator it = a.begin(); it != a.end(); ++it){
        for(std::vector<int>::iterator jt = it->begin(); jt != it->end(); ++jt){
            if(*jt){
                adjacent[i].push_back(distance(it->begin(), jt));
            }
        }
        i++;
    }

    for (int i = 0; i < n; i++) {
        if (!isScc[i]) {

            std::vector<int> scc;
            scc.push_back(i);

            for (int j = i + 1; j < n; j++) {

                if (!isScc[j] && isPath(i, j, adjacent, n) && isPath(j, i, adjacent, n)) {
                    isScc[j] = 1;
                    scc.push_back(j);
                }
            }

            allSCC.push_back(scc);
        }
    }


    std::vector<std::vector<int>>::iterator maxIt = allSCC.begin();
    for(std::vector<std::vector<int>>::iterator it = allSCC.begin(); it != allSCC.end(); it++ ){
        if(maxIt->size() < it->size()){
            maxIt = it;
        }
    }

    return *maxIt;
}


int main()
{
	int V = 5;
    std::vector<std::vector<int>> edgeMatrix {
        { 0, 0, 1, 1, 0},
        { 1, 0, 0, 0, 0},
        { 0, 1, 0, 0, 0},
        { 0, 0, 0, 0, 1},
        { 0, 0, 0, 1, 0}
    };
	std::vector<int> ans = findMaxSCC(V, edgeMatrix);
	std::cout << "Strongly Connected Component with the most vertices (" << ans.size() << ") is:" << std::endl;
    for(std::vector<int>::iterator it = ans.begin(); it != ans.end(); ++it){
        std::cout << *it << " ";
    }
}
