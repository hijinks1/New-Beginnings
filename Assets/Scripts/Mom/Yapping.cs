using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class Yapping : MonoBehaviour
{
    public TextAsset _InkJsonFile;
    public Story _StoryScript;

    public TMP_Text DialogueText;

    public static Story story;
    public float typingSpeed = .05f;

    public void Start()
    {
        LoadStory();
    }

    void Update()
    {
        //If space is pressed, show next line
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextLine();
        }
    }

    void LoadStory()
    {
        _StoryScript = new Story(_InkJsonFile.text);
    }

    public void DisplayNextLine()
    {
        if (_StoryScript.canContinue) //Checks if there's content to go through
        {
            string text = _StoryScript.Continue(); //gets next line
            text = text?.Trim(); //removes white space from the text
            DialogueText.text = text; //sets the text in the dialogue box to the next piece of text

            StopAllCoroutines();
            StartCoroutine(TypeSentence(text));
        }
    }

    //Types out each letter in dialogue box
    IEnumerator TypeSentence(string sentence)
    {
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}