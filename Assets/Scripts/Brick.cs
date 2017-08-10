using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Sprite[] Sprites;
    
    private int maxHits;
    private int timesHit;
    
    // Use this for initialization
    void Start()
    {
        maxHits = Sprites.Length + 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (tag.Equals("Breakable"))
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (Sprites[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = Sprites[spriteIndex];
        }
    }
}