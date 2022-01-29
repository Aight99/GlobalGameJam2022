using UnityEngine;

public abstract class Enemy : MonoBehaviour, ICreature
{
    public abstract Command Act();

    public int Health { get; set; } 
    public abstract void Change();
    public abstract bool IsAlive();

    public abstract void TakeDamage(int damage);

    public abstract void Die();
}