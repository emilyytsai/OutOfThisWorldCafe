using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour
{
    public TMP_Text dialogueText;

    private Queue<string> dialogueQueue;
    private bool dialogueStarted = false;

    [SerializeField]
    private GameObject continue_button = null;

    [SerializeField]
    private GameObject continue_text = null;

    void Start()
    {
        dialogueQueue = new Queue<string>();

        dialogueQueue.Enqueue("Dog: Woof! Hey ice creamer!");
        dialogueQueue.Enqueue("Dog: We’re a group of animals who call themselves The Pidges. We were in the mood for some dessert, and I heard the best little ice cream place in the galaxy is located right here, on the moon!");
        dialogueQueue.Enqueue("Dog: Woof, We’re so hungry, help us get our treats so we can go home!");
        dialogueQueue.Enqueue("Serve some ice cream to the starving Pidges.");

        DisplayNextLine();
        dialogueStarted = true;
        continue_button.SetActive(false);
    }

    void Update()
    {
        if (dialogueStarted && Input.GetMouseButtonDown(0))
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
            continue_button.SetActive(true);
            continue_text.SetActive(false);
            dialogueStarted = false;
        }
    }
}