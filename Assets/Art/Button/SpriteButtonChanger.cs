using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteButtonChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite deactiveSprite;
    public Sprite activeSprite;
    [SerializeField] private GameObject button;

    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(button.GetComponent<Button>().isPressed)
        {
            spriteRenderer.sprite = activeSprite;
        }
        else
        {
            spriteRenderer.sprite = deactiveSprite;
        }
        
    }
}
