using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBubble;
	public Text nameText;
	public Text dialogueText;

	public GameObject optionsObj;
	public GameObject optionButtonPrefab;
	Button[] optionButtons;

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


	//----- Dispaying player responses/options

	public void DisplayOptions(PlayerResponses options) {
		playerController.inDialogue = true;

		// destorY PREEXISTING BUTTONS FIRST
		optionButtons = optionsObj.GetComponentsInChildren<Button>();
		foreach (Button b in optionButtons) {
			Destroy (b.gameObject);
		}

		int nextYPos = 90;
		// Make the buttons
		for (int i = 0; i < options.responses.Length ; i++) {
			nextYPos -= 90;
			GameObject newButton = Instantiate (optionButtonPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
			newButton.transform.SetParent(optionsObj.transform);
			newButton.transform.localPosition = new Vector3 (0, nextYPos, 0);

			newButton.GetComponent<Button>().onClick.AddListener(EndInteraction);
			newButton.transform.GetComponentInChildren<Text>().text = options.responses[i]; 
		}

		// display options
		optionsObj.SetActive(true);
	}

	public void EndInteraction() {
		playerController.inDialogue = false;
		optionsObj.SetActive(false);
	}

}
