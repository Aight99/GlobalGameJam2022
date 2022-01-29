using UnityEngine;

[RequireComponent(typeof(Card))]
[RequireComponent(typeof(BoxCollider2D))] // Maybe something else is will be better
public class ToxicCard : Card
{
    private int _damage = 10;
    private BattleManager _battleManager;
    
    private void OnEnable()
    {
        _battleManager = FindObjectOfType<BattleManager>();
    }
    
    private void OnMouseDown()
    {
        _battleManager.PlayerCard = this;
        Debug.Log(_battleManager.PlayerCard);
    }
    
    public override int Use()
    {
        Debug.Log("А в том ли порядке???");
        return _damage * StateOfWorld.GetDamageBonus();
    }
}
