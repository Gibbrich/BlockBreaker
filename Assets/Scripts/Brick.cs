using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int breakableCount;
    
    public Sprite[] Sprites;
    public AudioClip crack ;
    public GameObject Smoke;
    
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
            AudioSource.PlayClipAtPoint(crack, transform.position, 0.2f);
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            PuffSmoke();
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void PuffSmoke()
    {
        GameObject smoke = Instantiate(Smoke, transform.position, Quaternion.identity);
            
        Color brickColor = GetComponent<SpriteRenderer>().color;
        Color smokeColor = new Color(brickColor.r, brickColor.g, brickColor.b, 0.5f);
            
        ParticleSystem.MainModule mainModule = smoke.GetComponent<ParticleSystem>().main;
        mainModule.startColor = smokeColor;
        
        Destroy(smoke, 1.5f);
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