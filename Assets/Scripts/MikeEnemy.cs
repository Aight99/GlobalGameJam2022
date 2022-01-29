using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))] 
[RequireComponent(typeof(BoxCollider2D))] // Maybe something else is will be better
public class MikeEnemy : Enemy, ICreature
{
    private BattleManager _battleManager;
    public int Health { get; set; } = 30;

    private void OnMouseDown()
    {
        _battleManager.Target = this;
        Debug.Log(_battleManager.Target);
    }

    private void OnEnable()
    {
        _battleManager = FindObjectOfType<BattleManager>();
        StateOfWorld.OnWorldSwaped += Change;
    }

    private void OnDisable()
    {
        StateOfWorld.OnWorldSwaped -= Change;
    }

    public override int Act()
    {
        Debug.Log("Братан атакует");
        return 15; // HACK PLEASE CHANGE THIS IMMEDIATELY ASAP 
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
            Die();
    }

    public void Die()
    {
        Debug.Log(this + " умер...");
        var a = GetComponent<SpriteRenderer>();
        a.color = Color.red;
    }

    public void Change()
    {
        // Implementation
        Debug.Log(this + " на месте!");
    }
}
