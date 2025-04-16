using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Dialogue1 : MonoBehaviour
{
    public TMP_Text dialogueText;

    private Queue<string> dialogueQueue;
    private bool dialogueStarted = false;

    [SerializeField]
    private GameObject continue_button = null;

    [SerializeField]
    private GameObject continue_text = null;

    [SerializeField]
    private GameObject ice_cream1 = null;
    [SerializeField]
    private GameObject ice_cream2 = null;

    [SerializeField]
    private GameObject dog = null;
    [SerializeField]
    private GameObject human = null;

    void Start()
    {
        dialogueQueue = new Queue<string>();

        // Add dialogue lines
        dialogueQueue.Enqueue("Dog: Nice job! Cat and Rat enjoyed visiting your ice cream cafe.");
        dialogueQueue.Enqueue("<b>You’ve unlocked:</b>  <color=#beddff>Blue Giant Blueberry Ice Cream</color=#beddff> and <u>White Star Sprinkles</u>!");
        dialogueQueue.Enqueue("Me: Wait I hear more animals coming in…");
        dialogueQueue.Enqueue("Dog: My turn to get some ice cream! Woof.");

        DisplayNextLine();
        dialogueStarted = true;
        continue_button.SetActive(false);
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
            if (line.Contains("unlocked"))
            {
                ice_cream1.SetActive(true);
                ice_cream2.SetActive(true);
                human.SetActive(false);
                dog.SetActive(false);
            }
            else if (line.Contains("Dog:"))
            {
                ice_cream1.SetActive(false);
                ice_cream2.SetActive(false);
                human.SetActive(false);
                dog.SetActive(true);
            }
            else if (line.Contains("Me:"))
            {
                ice_cream1.SetActive(false);
                ice_cream2.SetActive(false);
                dog.SetActive(false);
                human.SetActive(true);
            }
        }
        else
        {
            continue_button.SetActive(true);
            continue_text.SetActive(false);
            dialogueStarted = false;
            ice_cream1.SetActive(false);
            ice_cream2.SetActive(false);
            human.SetActive(false);
            dog.SetActive(true);
        }
    }
}