using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{

    private Queue<string> sentences;

    private DialogueSystem instance;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueSentence;
    public TextMeshProUGUI nextButton;

    public GameObject dialogueBox;
    private Animator dialogueAni;

    // to control when the dialogue shows up, the player cannot move
    public static bool noDialogue = true;


    // make the DialogueSysyem as Singleton, only one instance exist in the scene
    //private void Awake()
    //{
    //    if (instance != this & instance != null)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}

    void Start()
    {
        //create a queue for stroing dialogue sentences
        sentences = new Queue<string>();
        dialogueAni = dialogueBox.GetComponent<Animator>();
        dialogueAni.SetBool("noDialogue", noDialogue);
    }

    //input the dialogue sentences into queue, and output the first sentence in the queue
    public void StartDialogue(Dialogue dialogue)
    {

        noDialogue = false;
        dialogueAni.SetBool("noDialogue", noDialogue);

        nameText.text = dialogue.name;

        //Set the next text to continue;
        nextButton.text = "CONTINUE>>";

        // clear all the object in sentences
        sentences.Clear();

        // enqueue the sentences in Dialogue script
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        //if there is no sentence in queue, said"ENd" and return
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // output the first sentence in the queue
        string dialogueSentence = sentences.Dequeue();
        this.dialogueSentence.text = dialogueSentence;
        //Debug.Log(dialogueSentence);
    }

    void EndDialogue()
    {
        Debug.Log("The dialogue is end.");
        //The dialogue ends.
        noDialogue = true;
        dialogueAni.SetBool("noDialogue", noDialogue);
    }

}
