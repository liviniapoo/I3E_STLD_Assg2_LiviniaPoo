/*
 * Author: Livinia Poo
 * Date: 01/07/2024
 * Description: 
 * Dialogue pop-ups UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    /// <summary>
    /// Setting up UI dialogues
    /// </summary>
    public Dialogue dialogue;

    /// <summary>
    /// Function to start dialogue UI
    /// </summary>
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    /// <summary>
    /// Calls function on trigger enter
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Dialogue triggered");
        if (other.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }
}
