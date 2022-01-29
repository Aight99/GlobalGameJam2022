using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class StateOfWorld
{
    [SerializeField] [Range(1, 20)] private int _disasterMultiplyer = 5;
    public static event Action OnWorldSwaped;
    private static bool _isNegative = false;
    private int _disaster = 0;

    public bool IsNegative() => _isNegative;

    public static int GetDamageBonus()
    {
        if (_isNegative)
            return -1;
        else
            return 1;
    }

    public void Swap()
    {
        _isNegative = !_isNegative;
        OnWorldSwaped?.Invoke();
    }
    
    public void AddDisaster()
    {
        _disaster += Random.Range(1, 3) * _disasterMultiplyer;
        if (Random.Range(0, 100) > _disaster)
        {
            _disaster = 0;
            Swap();
        }
    }
}