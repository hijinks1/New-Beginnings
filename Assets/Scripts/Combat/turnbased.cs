using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

//Animations for player and enemy
    [SerializeField] public Animator playerAnim;
    [SerializeField] public Animator enemyAnim;

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
        //playerAnim.Play("playerIdle");
    }

//Waits for a second before making it the player's turn + dialogue
    IEnumerator SetupFight()
    {
        yield return new WaitForSeconds(2f);
        state = TurnBased.PLAYERTURN;
        dialogueText.text = "Your turn!";
    }

   public void OnAttackButton()
       {
       //On button click, start the PlayerAttack
       if (state != TurnBased.PLAYERTURN)
           return;
       StartCoroutine(PlayerAttack());
       }

       public void OnRunButton()
       {
           SceneManager.LoadScene("Mom");

           //-1 approval
           //Debug.Log("-1 Approval");
           PlayerPrefs.SetInt("Approval", PlayerPrefs.GetInt("Approval") - 1);
       }

    IEnumerator PlayerAttack()
    {
        //animation
        playerAnim.Play("playerAttack");
        Debug.Log("Player attack anim");

        //bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyUI.SetHP(enemyUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            //If enemy is dead, you won! Starts EndBattle sequence
            state = TurnBased.WON;
            StartCoroutine(EndBattle());
            Debug.Log("+2 Approval");
            
            //+1 approval
            PlayerPrefs.SetInt("Approval", PlayerPrefs.GetInt("Approval") + 2);
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
        yield return new WaitForSeconds(1f);

        //animation
        enemyAnim.Play("enemyAttack");

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerUI.SetHP(playerUnit.currentHP);
        
        yield return new WaitForSeconds(1f);

        if(isDead)
        {          
            //If player is dead, you lost
            state = TurnBased.LOST;
            dialogueText.text = "YOU'VE BEEN SLAIN BY CHONKY! YEOWCH!";
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Mom");
            PlayerPrefs.SetInt("Approval", PlayerPrefs.GetInt("Approval") - 2);

        }
        else
        {
            //If player isn't dead, it's players turn
            state = TurnBased.PLAYERTURN;
            dialogueText.text = "Your turn!";
        }

   }

    //public void EndBattle()
    IEnumerator EndBattle()
    {
        //Why did you kill chonky
        if (state == TurnBased.WON);
        dialogueText.text = "YOU'VE SLAIN CHONKY!";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Mom");
        //Add to approval
    }

}
