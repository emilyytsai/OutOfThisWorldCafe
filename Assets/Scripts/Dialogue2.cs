using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Dialogue2 : MonoBehaviour
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

        dialogueQueue.Enqueue("Dog: Bunny is jumping for joy for his ice cream!");
        dialogueQueue.Enqueue("You’ve unlocked Purple Ice Cream and Sun Candy Toppers!");
        dialogueQueue.Enqueue("Dog: Woof, We’re so hungry, help us get our treats so we can go home!");
        dialogueQueue.Enqueue("The Pidges need more dessert.");

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