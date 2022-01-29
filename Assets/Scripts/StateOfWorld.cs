using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class StateOfWorld : MonoBehaviour
{
    // [SerializeField] [Range(1, 50)] private int disasterInTurn = 10;
    [SerializeField] private TextMeshPro disasterCounter;
    [SerializeField] private Color firstColor = new(0.12f, 1f, 0.45f);
    [SerializeField] private Color secondColor = new(0.6f, 0.12f, 1f);
    private SpriteRenderer _bar;
    public static event Action OnWorldSwaped;
    private static bool _isNegative = false;
    private int _disaster = 0;

    private void OnEnable()
    {
        _bar = GetComponent<SpriteRenderer>();
        UpdateCounter();
    }

    private void UpdateCounter()
    {
        disasterCounter.text = _disaster.ToString();
        _bar.color = Color.Lerp(firstColor, secondColor, (_disaster + 0.1f) / 100f);
    }

    public bool IsNegative() => _isNegative;

    // public static int GetDamageBonus() // Бесполезно же, да?
    // {
    //     if (_isNegative)
    //         return -1;
    //     else
    //         return 1;
    // }

    public void Swap()
    {
        _isNegative = !_isNegative;
        OnWorldSwaped?.Invoke();
    }
    
    public void AddDisaster(int disasterPoints)
    {
        _disaster += disasterPoints;
        if (_disaster >= 100)
        {
            _disaster = 0;
            Swap();
        }
        UpdateCounter();
    }
    
    // public void AddDisaster()
    // {
    //     _disaster += disasterInTurn;
    //     if (_disaster >= 100)
    //     {
    //         _disaster = 0;
    //         Swap();
    //     }
    //     UpdateCounter();
    // }
}