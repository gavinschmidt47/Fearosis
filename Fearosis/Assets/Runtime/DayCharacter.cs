using UnityEngine;
using System.Collections.Generic;

public class DayCharacter : MonoBehaviour
{

    public List<Sprite> daySprites;

    private SpriteRenderer spriteRenderer; 
 
    private int randomIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        randomIndex = Random.Range(0, daySprites.Count); 
        
    }

    void OnEnable()
    {
        spriteRenderer.sprite = daySprites[randomIndex];
    }
}
