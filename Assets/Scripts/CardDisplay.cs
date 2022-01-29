using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private CardTemplate template;
    [SerializeField] private TextMeshPro nameText;
    private SpriteRenderer _sprite;
    private Types _type;

    // Знаю, что так делать очень плохо, но времени мало
    public CardTemplate GetTemplate() => template;

    private void OnEnable()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _type = template.type;
        SetTypeVisual();
    }

    private void SetTypeVisual()
    {
        switch (_type)
        {
            case Types.Natural:
            {
                _sprite.color = Color.green;
                nameText.text = template.naturalName;
                break;
            }
            case Types.SteamPunk:
            {
                _sprite.color = Color.yellow;
                nameText.text = template.punkName;
                break;
            }
            case Types.Special:
            {
                _sprite.color = Color.blue;
                nameText.text = template.naturalName;
                break;
            }
        }
    }

    private void SwapType()
    {
        if (_type == Types.Natural)
        {
            _type = Types.SteamPunk;
        } else if (_type == Types.SteamPunk)
        {
            _type = Types.Natural;
        }
    }

    public void SwapTexture()
    {
        SwapType();
        SetTypeVisual();
    }
}
