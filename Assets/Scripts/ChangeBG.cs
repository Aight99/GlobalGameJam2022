using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] 
public class ChangeBG : MonoBehaviour
{
    [SerializeField] private Sprite punkSprite;
    [SerializeField] private Sprite naturalSprite;
    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StateOfWorld.OnWorldSwaped += Change;
    }

    private void OnDisable()
    {
        StateOfWorld.OnWorldSwaped -= Change;
    }

    public void Change()
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
