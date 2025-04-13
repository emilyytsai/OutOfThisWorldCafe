using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Dialogue2 : MonoBehaviour
{
    public TMP_Text dialogueText;
    public float delayBetweenLines = 10f;

    private Queue<string> dialogueQueue;

    void Start()
    {
        dialogueQueue = new Queue<string>();

        dialogueQueue.Enqueue("Dog: Bunny is jumping for joy for his ice cream!");
        dialogueQueue.Enqueue("You’ve unlocked Purple Ice Cream and Sun Candy Toppers!");
        dialogueQueue.Enqueue("Woof, We’re so hungry, help us get our treats so we can go home!");
        dialogueQueue.Enqueue("The Pidges need more dessert.");

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
