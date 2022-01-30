using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(SpriteRenderer))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshPro healthCounter;
    [SerializeField] private Color firstColor = Color.blue;
    [SerializeField] private Color secondColor = Color.red;
    // [SerializeField] private Player player;
    private SpriteRenderer _bar;
    
    private void OnEnable()
    {
        _bar = GetComponent<SpriteRenderer>();
        // player = FindObjectOfType<Player>();
        // UpdateCounter(player.Health, player.MaxHealth);
    }

    public void Disable()
    {
        _bar.enabled = false;
        healthCounter.enabled = false;
    }

    public void UpdateCounter(int currentHp, int maxHp)
    {
        healthCounter.text = currentHp.ToString();
        _bar.color = Color.Lerp( secondColor, firstColor, (currentHp + 0.1f) / maxHp);
    }
}
