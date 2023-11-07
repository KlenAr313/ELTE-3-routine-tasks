#include <iostream>

class Matrix
{
private:
    int col;
    int row;
    int *data;

public:
    Matrix(int row = 2, int col = 2)
    {
        this->row = row;
        this->col = col;
        this->data = new int[row * col];

        for (int i = 0; i < row * col; i++)
        {
            data[i] = 0;
        }
    }

    Matrix(const Matrix &other)
    {
        this->row = other.row;
        this->col = other.col;
        this->data = new int[row * col];

        for (int i = 0; i < row * col; ++i)
        {
            data[i] = other.data[i];
        }
    }

    void operator()(int i, int j, int value)
    {
        this->data[i * col + j] = value;
    }

    int operator()(int i, int j) const
    {
        return this->data[i * col + j];
    }

    const Matrix operator+(const Matrix &other) const
    {
        Matrix temp = other;
        if (other.col == col && other.row == row)
        {
            for (int i = 0; i < row * col; ++i)
            {
                temp.data[i] += data[i];
            }
        }
        return temp;
    }

    const Matrix operator*(const Matrix &other) const
    {
        Matrix temp(other.row, this->col);
        if (col == other.row)
        {
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < other.col; ++j)
                {
                    int sum = 0;
                    for (int k = 0; k < col; ++k)
                    {
                        sum += (*this)(i, k) * other(k, j);
                    }
                    temp(i, j, sum);
                }
            }
        }
        return temp;
    }

    void Print() const
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                std::cout << (*this)(i, j) << " ";
            }
            std::cout << "\n";
        }
        std::cout << "\n";
    }

    ~Matrix()
    {
        delete[] data;
    }
};

int main()
{
    Matrix m1;
    m1(0, 0, 2);
    m1(1, 1, 3);

    Matrix m2;
    m2(0, 0, 1);
    m2(1, 1, 2);

    Matrix m3(m1 * m2);

    m1.Print();
    m2.Print();
    m3.Print();
}