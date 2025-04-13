using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Dialogue1 : MonoBehaviour
{
    public TMP_Text dialogueText;

    private Queue<string> dialogueQueue;
    private bool dialogueStarted = false;

    void Start()
    {
        dialogueQueue = new Queue<string>();

        // Add dialogue lines
        dialogueQueue.Enqueue("Dog: You really won the hearts of Cat and Rat!");
        dialogueQueue.Enqueue("You’ve unlocked: Blue Ice Cream and White Star Sprinkles!");
        dialogueQueue.Enqueue("Me: Wait I hear more animals coming in…");
        dialogueQueue.Enqueue("Cat: Tropi Tripi!");

        DisplayNextLine();
        dialogueStarted = true;
    }

    void Update()
    {
        if (dialogueStarted && Input.GetMouseButtonDown(0)) // Left-click to continue
        {
            DisplayNextLine();
        }
    }

    void DisplayNextLine()
    {
        if (dialogueQueue.Count > 0)
        {
            string line = dialogueQueue.Dequeue();
            dialogueText.text = line;
        }
        else
        {
            dialogueText.text = ""; // Optional: clear text when done
            dialogueStarted = false;
        }
    }
}