using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum TurnBased { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class turnbased : MonoBehaviour
{
//Lists out the states that can be picked from, which are above
    public TurnBased state;

//Drag and drop gameobjects
    public GameObject player;
    public GameObject enemy;

    public UIjunk playerUI;
    public UIjunk enemyUI;
//Calls upon stats from the stats script
    public stats playerUnit;
    public stats enemyUnit;

//Animations for player
    [SerializeField] public Animator playerAnim;

//Drag and drop UI for dialogue text
    [SerializeField] public TextMeshProUGUI dialogueText;

      void Start()
    {
    //On start, the state is START
        state = TurnBased.START;
    //calls on the SetupFight function and changes text
        SetupFight();
        StartCoroutine(SetupFight());
        dialogueText.text = "A chonky boy has risen.";
    }

//Waits for a second before making it the player's turn + dialogue
    IEnumerator SetupFight()
    {
    yield return new WaitForSeconds(1f);
    state = TurnBased.PLAYERTURN;
    dialogueText.text = "Your turn!.";
    Debug.Log("Player turn");
    }


    IEnumerator PlayerAttack()
    {
    playerAnim.Play("playerAttack");
    bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
    enemyUI.SetHP(enemyUnit.currentHP);

    yield return new WaitForSeconds(1f);

    if (isDead)
    {
    //If enemy is dead, you won! Starts EndBattle sequence
    state = TurnBased.WON;
    EndBattle();
    }
    else
    {
    //If enemy is not dead, swap turns
    state = TurnBased.ENEMYTURN;
    StartCoroutine(EnemyTurn());
    }
    }

    IEnumerator EnemyTurn()
   {
   //Hahaha chonky's turn
       dialogueText.text = "Chonky's turn.";
       Debug.Log("Enemy turn");
    yield return new WaitForSeconds(1f);

    bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
    playerUI.SetHP(playerUnit.currentHP);

    yield return new WaitForSeconds(1f);

    if(isDead)
    {
    //If player is dead, you lost
    state = TurnBased.LOST;
    }
    else
    {
    //If player isn't dead, it's players turn
    state = TurnBased.PLAYERTURN;
        dialogueText.text = "Your turn!";
        Debug.Log("Player turn");
    }

   }

    public void OnAttackButton()
    {
    //On button click, start the PlayerAttack
    if (state != TurnBased.PLAYERTURN)
        return;
    StartCoroutine(PlayerAttack());
    }

    public void EndBattle()
    {
    //Why did you kill chonky
    if (state == TurnBased.WON);
    dialogueText.text = "YOU'VE SLAIN CHONKY!";
    //go to win scene
    }

}
