public interface ICreature
{
    public int Health { get; set; }
    public abstract void Change();
    public abstract void TakeDamage(int damage);
    public abstract void Die();
}