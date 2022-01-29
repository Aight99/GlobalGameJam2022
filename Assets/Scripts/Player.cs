using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour, ICreature
{
    [SerializeField] private HealthBar healthBar;
    private BattleManager _battleManager;
    private readonly int MaxHealth = 100;
    public int Health { get; set; } = 100;

    private void OnEnable()
    {
        _battleManager = FindObjectOfType<BattleManager>();
        StateOfWorld.OnWorldSwaped += Change;
        UpdateHp();
    }

    private void OnDisable()
    {
        StateOfWorld.OnWorldSwaped -= Change;
    }

    private void OnMouseDown()
    {
        _battleManager.Target = this;
        // Debug.Log(_battleManager.Target);
    }
    
    private void UpdateHp() => healthBar.UpdateCounter(Health, MaxHealth);
    
    public void Change()
    {
        // Implementation
        // Debug.Log(this + " на месте!");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
            Die();
        if (Health > MaxHealth)
            Health = MaxHealth;
        UpdateHp();
    }

    public void Die()
    {
        Debug.Log(this + " умер...");
        var a = GetComponent<SpriteRenderer>();
        a.color = Color.red;
    }
}
