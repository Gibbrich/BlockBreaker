using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int breakableCount;
    
    public Sprite[] Sprites;
    public AudioClip crack ;
    
    private int maxHits;
    private int timesHit;
    private LevelManager levelManager;
    
    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        maxHits = Sprites.Length + 1;

        if (tag.Equals("Breakable"))
        {
            breakableCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (tag.Equals("Breakable"))
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            print("Bricks left: " + breakableCount);
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