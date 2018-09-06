using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBubblePrefab;
    private Queue<string> sentences;

	void Start () {
        sentences = new Queue<string>();
	}
    

    // begins the dialogue
    // called from player interaction with target NPC
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("starting dialogue");

        // clear old dialogue
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }

    void EndDialogue()
    {
        Debug.Log("end of conversation");
    }


}
