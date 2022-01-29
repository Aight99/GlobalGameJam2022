using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Enemy))] 
[RequireComponent(typeof(BoxCollider2D))] // Maybe something else is will be better
public class MikeEnemy : Enemy
{
    [SerializeField] private HealthBar healthBar;
    private BattleManager _battleManager;
    private bool isAlive = true;

    private Command[] _moves = new Command[]
    {
        // int damage, int disasterPoints, bool isForPlayer, bool isForAllEnemies
        new Command(10, 0, true, false),
        new Command(5, 5, true, false),
        new Command(2, 0, false, true)
        // new Command(-5, 0, false, true) // Типа хилка
    };

    public readonly int MaxHealth = 30;
    
    private void UpdateHp() => healthBar.UpdateCounter(Health, MaxHealth);
    
    private void OnMouseDown()
    {
        _battleManager.Target = this;
    }

    private void OnEnable()
    {
        _battleManager = FindObjectOfType<BattleManager>();
        StateOfWorld.OnWorldSwaped += Change;
        Health = MaxHealth;
        UpdateHp();
    }

    private void OnDisable()
    {
        StateOfWorld.OnWorldSwaped -= Change;
    }

    public override bool IsAlive() => isAlive;

    public override Command Act() => _moves[Random.Range(0, 3)];

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
            Die();
        if (Health > MaxHealth)
            Health = MaxHealth;
        UpdateHp();
    }

    public override void Die()
    {
        isAlive = false;
        Debug.Log(this + " умер...");
        var a = GetComponent<SpriteRenderer>();
        a.color = Color.red;
    }

    public override void Change()
    {
        // Implementation
        // Debug.Log(this + " на месте!");
    }
}
