using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour, ICreature
{
    private BattleManager _battleManager;
    public int Health { get; set; } = 100;

    private void OnEnable()
    {
        _battleManager = FindObjectOfType<BattleManager>();
        StateOfWorld.OnWorldSwaped += Change;
    }

    private void OnDisable()
    {
        StateOfWorld.OnWorldSwaped -= Change;
    }

    private void OnMouseDown()
    {
        _battleManager.Target = this;
        Debug.Log(_battleManager.Target);
    }
    
    public void Change()
    {
        // Implementation
        Debug.Log(this + " на месте!");
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
}
