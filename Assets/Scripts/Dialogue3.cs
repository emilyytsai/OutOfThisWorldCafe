using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class SceneDialogueTMP : MonoBehaviour
{
    public TMP_Text dialogueText;
    public float delayBetweenLines = 10f;

    private Queue<string> dialogueQueue;

    void Start()
    {
        dialogueQueue = new Queue<string>();

        dialogueQueue.Enqueue("Dog: Hurruff! you served the pidges!");
        dialogueQueue.Enqueue("Rat: Ratatata!");
        dialogueQueue.Enqueue("Dog: Woof, time to go home! Thanks for helping us Ice Creamer!");
        delayBetweenLines = 20f;
        dialogueQueue.Enqueue("And the Pidges went home satisfied, and they were happy with the best ice cream in the galaxy.");
        delayBetweenLines = 10f;
        dialogueQueue.Enqueue("Capybara: “We’re coming back here for sure!”");

        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        while (dialogueQueue.Count > 0)
        {
            string line = dialogueQueue.Dequeue();
            dialogueText.text = line;
            yield return new WaitForSeconds(delayBetweenLines);
        }

        dialogueText.text = "";
    }
}
