using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Approval : MonoBehaviour
{
    
    public int currentApproval;
  
    public int maxApproval;
    
    public TurnBased state;

    public ApprovalBar approvalBar;
    
    
    void Update()
    {
        if (state == TurnBased.WON)
        {
            //if you won, increase approval by 1 and set the bar to that
            currentApproval++;
           // approvalBar.SetApproval(currentApproval);
            
            PlayerPrefs.SetInt("Approval", currentApproval);

            
           // Debug.Log("+1 approval");
        }

        if (state == TurnBased.LOST && currentApproval > 0)
        {
            //if you lost, subtract approval by 1 and set the bar to that
            currentApproval--;
            //approvalBar.SetApproval(currentApproval);
            //Debug.Log("-1 approval");
        }
    }
    

}
