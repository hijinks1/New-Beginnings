using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoButton : MonoBehaviour
{
  public Button endTurnButton;

  public void StartTimer()
  {
    StartCoroutine(EndTurnButton());
  }

  public IEnumerator EndTurnButton()
  {
    endTurnButton.interactable = false;
    yield return new WaitForSeconds(1f);
    endTurnButton.interactable = true;
  }
}
