/*
 * Author: Livinia Poo
 * Date: 01/07/2024
 * Description: 
 * Dialogue pop-ups UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    /// <summary>
    /// Attaching dialogue parameters
    /// </summary>
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;

    /// <summary>
    /// Deciding how many sentences and characters speak
    /// </summary>
    private Queue<string> names;
    private Queue<string> sentences;

    /// <summary>
    /// Whether clicking should fire gun
    /// </summary>
    public static bool canShoot;

    /// <summary>
    /// Sets up but disables UI dialogue
    /// </summary>
    private void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    /// <summary>
    /// Function to start dialogue based on characters and sentences, locks game, words in typing animation
    /// </summary>
    /// <param name="dialogue"></param>
    public void StartDialogue(Dialogue dialogue)
    {
        canShoot = false;
        dialogueBox.SetActive (true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        names.Clear();
        sentences.Clear();

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    /// <summary>
    /// Function to move from one dialogue sentence to another
    /// </summary>
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string name = names.Dequeue();
        string sentence = sentences.Dequeue();

        nameText.text = name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    /// <summary>
    /// Animation
    /// </summary>
    /// <param name="sentence"></param>
    /// <returns></returns>
    IEnumerator TypeSentence(string  sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    /// <summary>
    /// Closes dialogue, resumes game per normal
    /// </summary>
    void EndDialogue()
    {
        Debug.Log("End of conversation");
        dialogueBox.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        canShoot = true;
    }
}
