using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApprovalBar : MonoBehaviour
{
   
   public Slider slider;

   void Start()
   {
      //moves the approval slider up and down
      slider.value = PlayerPrefs.GetInt("Approval");
   }
   
}
