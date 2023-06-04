using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLeverSprite : MonoBehaviour
{
    public Sprite deactiveSprite;
    public Sprite activeSprite;
    [SerializeField] private GameObject lever;

    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(lever.GetComponent<LeverTrigger>().isActive)
        {
            spriteRenderer.sprite = activeSprite;
        }
        else
        {
            spriteRenderer.sprite = deactiveSprite;
        }
        
    }
}
