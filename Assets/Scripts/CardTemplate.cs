using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCardTemplate", menuName = "CardTemplate")]
public class CardTemplate : ScriptableObject
{
    public string punkName;
    public string punkDescription;
    public string naturalName;
    public string naturalDescription;
    public int damage;
    public int disasterPoints = 10;
    public Types type;
    public bool isHaveTarget; // Else - AoE
    public bool isWorldSwap;
    public bool isTakeCards;
    public Sprite punkSprite;
    public Sprite naturalSprite;
    public Sprite specialSprite;
}
