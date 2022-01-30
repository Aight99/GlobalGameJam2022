using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private CardTemplate template;
    [SerializeField] private TextMeshPro nameText;
    [SerializeField] private TextMeshPro descText;
    [SerializeField] private TextMeshPro damageText;

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
        damageText.text = template.damage.ToString();
        switch (_type)
        {
            case Types.Natural:
            {
                descText.text = template.naturalDescription;
                _sprite.sprite = template.naturalSprite;
                nameText.text = template.naturalName;
                break;
            }
            case Types.SteamPunk:
            {
                descText.text = template.punkDescription;
                _sprite.sprite = template.punkSprite;
                nameText.text = template.punkName;
                break;
            }
            case Types.Special:
            {
                descText.text = template.naturalDescription;
                _sprite.sprite = template.specialSprite;
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
