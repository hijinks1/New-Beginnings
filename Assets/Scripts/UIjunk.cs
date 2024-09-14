using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIjunk : MonoBehaviour
{
       public Slider hpSlider;

       public void SetUI(stats stat)
       {
            hpSlider.maxValue = stat.maxHP;
            hpSlider.value = stat.currentHP;
       }

       public void SetHP(int hp)
         {
               hpSlider.value = hp;
         }

}
