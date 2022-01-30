using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Sprites;

public class CardEvent : MonoBehaviour
{
    [SerializeField] private MeshRenderer _damage;
    [SerializeField] private MeshRenderer _nameText;
    [SerializeField] private MeshRenderer _descName;
    [SerializeField] private SortingGroup _nameS ;
    [SerializeField] private SortingGroup _descS ;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;
    private float X_scale;
    private float Y_scale;
    private const float Z = 1f;
    
    public void OnMouseOver()
    {
        transform.localScale = new Vector3(X_scale * 1.5f, Y_scale * 1.5f, Z);
        _spriteRenderer.sortingOrder = 10;
        _damage.sortingOrder = 100;
        _nameS.sortingOrder = 100;
        _descS.sortingOrder = 1000;
    }

    public void OnMouseExit()
    {
        transform.localScale = new Vector3(X_scale, Y_scale, Z);
        _spriteRenderer.sortingOrder = 0;
        _damage.sortingOrder = 0;
        _nameS.sortingOrder = 0;
        _descS.sortingOrder = 0;
    }

    public void OnMouseDown()
    {
        transform.position = new Vector3(0, 0, transform.position.z);
        //transform.position = new Vector3(X_position, Y_position + 5f, transform.position.z);

        Invoke("delay", 1f);
    }

    void delay()
    {
        Color color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0f);
        _spriteRenderer.color = color;
        _descName.enabled = false;
        _nameText.enabled = false;
        _damage.enabled = false;
    }

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        X_scale = transform.localScale.x;
        Y_scale = transform.localScale.y;
    }

}
