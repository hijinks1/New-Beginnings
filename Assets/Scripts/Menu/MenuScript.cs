using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public void onNewGame()
    //basically just deletes all the player prefs that saved your approval stats 
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Intro");
    }

    public void onSavedGame()
    {
        SceneManager.LoadScene("Mom");
    }
    
}
