using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour {
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;
    private int timeshit;
    private LevelManager levelManager;
    private bool isBreakable;


    // Use this for initialization
    void Start()
    {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }
        timeshit = 0;

        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collisioned");
        if (isBreakable)
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timeshit++;
        int maxHits = hitSprites.Length + 1;
        if (timeshit >= maxHits)
        {
            breakableCount--;
            AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);
            levelManager.BrickDestroyed();
            puffSmoke();
            Destroy(gameObject);
        }
    }

    private void LoadSprites()
    {
        int spriteIndex = timeshit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }


    }

    private void puffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
        var psmain = ps.main;
        psmain.startColor = gameObject.GetComponent<SpriteRenderer>().color;




    }
}
