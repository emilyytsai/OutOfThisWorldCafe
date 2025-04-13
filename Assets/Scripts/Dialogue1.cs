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

        dialogueQueue.Enqueue("You really won the hearts of Cat and Rat!");
        dialogueQueue.Enqueue("You’ve unlocked: Blue Ice Cream and White Star Sprinkles!");
        dialogueQueue.Enqueue("Wait I hear more animals coming in…");
        dialogueQueue.Enqueue("Tropi Tripi!");

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
