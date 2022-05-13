using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //input the dialogue in the inspector
    public Dialogue dialogue;

    private void Start()
    {
        //gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "player")
        //{
        //    Debug.Log("player!");
        //    TriggerDialogue();
        //    gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //}
    }

    public void TriggerDialogue()
    {
        //start the first line of the dialogue
        FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);
    }
}
