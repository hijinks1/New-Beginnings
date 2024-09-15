using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Approval : MonoBehaviour
{
    public Slider approvalSlider;
    
    public int currentApproval;
    public int maxApproval;
    
    public TurnBased state;
    
    
    public void SetUI(Approval app)
    {
        approvalSlider.maxValue = app.maxApproval;
        approvalSlider.value = app.currentApproval;
    }

    public void SetApproval(int yay)
    {
        approvalSlider.value = yay;
    }

    void Update()
    {
        if (state == TurnBased.WON)
        {
            currentApproval++;
        }
    }
    

}
