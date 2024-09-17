using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beg : MonoBehaviour
{

    //spriteArray is the array --> 0,1,2,3
    public Sprite[] spriteArray;
    //new sprite to swap to
    public Sprite newSprite;
    [SerializeField] public Animator heartAnim;
    
    
     public void onBeg()
    {        
        //if approval rating is over 0
        if (PlayerPrefs.GetInt("Approval") == 4)
        {
            ChangeSprite();
            heartAnimation();
        }
    }
     
    public void ChangeSprite()
    {
        //change closed mouth sprite to open mouth sprite
        newSprite = spriteArray[1];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void heartAnimation()
    {
        heartAnim.Play("HeartMove");
    }
}
