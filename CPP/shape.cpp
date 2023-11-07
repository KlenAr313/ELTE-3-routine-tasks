#include <iostream>

class Shape
{
private:
    int x;
    int y;

public:
    Shape(int x = 0, int y = 0)
    {
        this->x = x;
        this->y = y;
    }

    virtual double size()
    {
        return 0;
    }
};

class Circle : public Shape
{
private:
    int r;

public:
    Circle(int r = 1, int x = 0, int y = 0) : Shape(x, y)
    {
        this->r = r;
    }

    double size()
    {
        return this->r * this->r * 3.14;
    }
};

class Rectangle : public Shape
{
private:
    int a;
    int b;

public:
    Rectangle(int a = 1, int b = 1, int x = 0, int y = 0) : Shape(x, y)
    {
        this->a = a;
        this->b = b;
    }

    double size()
    {
        return this->a * this->b;
    }

    ~Rectangle() {}
};

int main()
{
    Shape *thing[2];
    thing[0] = new Circle();
    thing[1] = new Rectangle();

    double sum = 0;

    for (int i = 0; i < 2; ++i)
    {
        sum += thing[i]->size();
    }

    std::cout << sum << std::endl;
}