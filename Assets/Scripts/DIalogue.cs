using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class SceneDialogueTMP : MonoBehaviour
{
    public TMP_Text dialogueText;
    public float delayBetweenLines = 5f;

    private Queue<string> dialogueQueue;

    void Start()
    {
        dialogueQueue = new Queue<string>();

        dialogueQueue.Enqueue("Woof! Hey ice creamer!");
        dialogueQueue.Enqueue("We’re a group of animals who call themselves The Pidges. We were in the mood for some dessert, and I heard the best little ice cream place in the galaxy is located right here, on the moon!");
        dialogueQueue.Enqueue("Woof, We’re so hungry, help us get our treats so we can go home!");
        dialogueQueue.Enqueue("Serve some ice cream to the starving Pidges.");

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
