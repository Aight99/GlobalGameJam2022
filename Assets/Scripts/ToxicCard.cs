using System;
using UnityEngine;

[RequireComponent(typeof(CardDisplay))]
[RequireComponent(typeof(Card))]
[RequireComponent(typeof(BoxCollider2D))] // Maybe something else is will be better
public class ToxicCard : Card
{
    private int _damage;
    private CardDisplay _cardDisplay;
    private BattleManager _battleManager;
    private CardTemplate _template;

    private void OnEnable()
    {
        _battleManager = FindObjectOfType<BattleManager>();
        _cardDisplay = GetComponent<CardDisplay>();
        _template = _cardDisplay.GetTemplate();
        _damage = _template.damage;
        StateOfWorld.OnWorldSwaped += Change;
    }

    private void OnDisable()
    {
        StateOfWorld.OnWorldSwaped -= Change;
    }

    private void OnMouseDown()
    {
        Debug.Log("}e]]e]e]e]e]");
        _battleManager.PlayerCard = this;
    }
    
    public void Change()
    {
        _damage *= -1;
        _cardDisplay.SwapTexture();
    }
    
    public override Command Use()
    {
        Debug.Log("А в том ли порядке???");
        return new Command(_damage, _template.disasterPoints, _template.isHaveTarget, _template.isWorldSwap,
            _template.isTakeCards);
    }
}
