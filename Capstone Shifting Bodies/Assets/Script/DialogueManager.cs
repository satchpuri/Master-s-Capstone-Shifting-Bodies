using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBubble;
	public Text nameText;
	public Text dialogueText;

    private Queue<string> sentences;

	Controller playerController;

	void Start () {
        sentences = new Queue<string>();
		playerController = GameObject.Find ("Player").GetComponent<Controller> ();
	}
    

    // begins the dialogue
    // called from player interaction with target NPC
	public void StartDialogue(Dialogue dialogue, string charName)
    {
		dialogueBubble.SetActive (true);
		nameText.text = charName;
		playerController.inDialogue = true;	// Set to being in dialogue (to disable movement)

        // clear old dialogue
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

	// continues dialogue
    public void DisplayNextSentence() {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

		// display text
		StopAllCoroutines();	// make sure other coroutines end if user proceeds past previous text before it completes
		StartCoroutine (TypeSentence (sentence));
    }

	// "animate" typing out letters
	private IEnumerator TypeSentence(string sentence) {
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;

			yield return null;	// wait one frame
		}
	}

	// closes dialogue
    void EndDialogue() {
		dialogueBubble.SetActive (false);
		playerController.inDialogue = false;
    }


}
