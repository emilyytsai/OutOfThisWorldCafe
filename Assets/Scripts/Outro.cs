using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Outro : MonoBehaviour
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

        dialogueQueue.Enqueue("So the Pidges went home satisfied, and they were happy with the best ice cream in the galaxy!");
        dialogueQueue.Enqueue("Capybara: “We’re coming back here for sure!");

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