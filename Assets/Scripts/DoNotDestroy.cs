using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   void Awake()
   { 
      //Keeps the audiosource from scene one and brings it into scene 2
      GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
      if (musicObj.Length > 1)
      {
         Destroy(this.gameObject);
      }
      DontDestroyOnLoad(this.gameObject);
      
   }
    
    
}