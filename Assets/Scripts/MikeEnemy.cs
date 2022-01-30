using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Enemy))] 
[RequireComponent(typeof(SpriteRenderer))] 
[RequireComponent(typeof(BoxCollider2D))] // Maybe something else is will be better
public class MikeEnemy : Enemy
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Sprite punkSprite;
    [SerializeField] private Sprite naturalSprite;
    private BattleManager _battleManager;
    private SpriteRenderer _spriteRenderer;
    private bool _isAlive = true;

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
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StateOfWorld.OnWorldSwaped += Change;
        Health = MaxHealth;
        UpdateHp();
    }

    private void OnDisable()
    {
        StateOfWorld.OnWorldSwaped -= Change;
    }

    public override bool IsAlive() => _isAlive;

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
        _isAlive = false;
        Debug.Log(this + " умер...");
        GetComponent<SpriteRenderer>().enabled = false;
        healthBar.Disable();
    }

    public override void Change()
    {
        if (_spriteRenderer.sprite == punkSprite)
        {
            _spriteRenderer.sprite = naturalSprite;
        }
        else
        {
            _spriteRenderer.sprite = punkSprite;
        }
    }
}
