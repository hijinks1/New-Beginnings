using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOut : MonoBehaviour
{
    //spriteArray is the array --> 0,1,2,3
    public Sprite[] spriteArray;
    //new sprite to swap to
    public Sprite newSprite;
    public int spriteNumber = 0;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        // if space is clicked and the spriteNumber is less than the SpriteArray length, changesprite
        //spriteArray.Length basically just means that if the array had 0,1,2,3, the length is 4 
        if (Input.GetMouseButtonDown(0) && spriteNumber < spriteArray.Length)
        {
            Debug.Log ("crack");
            ChangeSprite();
        }
        
    }
    void ChangeSprite()
    { 
        audioSource.Play();
        //Run through the sprites starting from 0 and ending at 3 and add one to the spriteNumber
        newSprite = spriteArray[spriteNumber];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        spriteNumber++;
    }
}
