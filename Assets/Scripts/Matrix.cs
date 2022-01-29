
using UnityEngine;

public class Matrix
{
    private int[,] _field;
    
    // public int Columns { get; private set; }

    public Matrix(int m, int n)
    {
        // Columns = m;
        _field = new int[m, n];
    }
}
