using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerSprite : MonoBehaviour
{
    public Sprite[] walkSprites;
    public Sprite deadSprite;
    public float frameDuration = 0.1f;
    [SerializeField] private GameObject player;

    private SpriteRenderer spriteRenderer;
    private int currentFrameIndex = 0;
    private float timer = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //get player walking state
        bool isWalking = player.GetComponent<PlayerController>().getIsWalking();
        bool isDead = player.GetComponent<PlayerController>().deadBodyActive;
        if(!isDead && !player.GetComponent<PlayerController>().inCannon)
        {
            if (isWalking)
            {
                if(player.GetComponent<PlayerController>().isWalkingRight())
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
                // Update the timer
                timer += Time.deltaTime;

                // Check if it's time to change the sprite
                if (timer >= frameDuration)
                {
                    // Reset the timer
                    timer = 0f;

                    // Update the sprite index
                    currentFrameIndex++;

                    // Wrap around if we've reached the end of the sprite array
                    if (currentFrameIndex >= walkSprites.Length)
                    {
                        currentFrameIndex = 0;
                    }

                    // Update the sprite renderer with the new sprite
                    spriteRenderer.sprite = walkSprites[currentFrameIndex];
                }
            }
            else
            {
                // Reset the timer and show the default sprite when not walking
                timer = 0f;
                spriteRenderer.sprite = walkSprites[0]; // Assign the default sprite when not walking
            }
        }
        if(isDead && !player.GetComponent<PlayerController>().inCannon)
        {
            if(player.GetComponent<PlayerController>().isWalkingRight()){
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
            spriteRenderer.sprite = deadSprite;
        }
        if(player.GetComponent<PlayerController>().inCannon)
        {
            //dont show
            spriteRenderer.enabled = false;
        }else{
            spriteRenderer.enabled = true;
        }
    }
}
