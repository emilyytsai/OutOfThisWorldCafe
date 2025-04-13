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

    [SerializeField]
    private GameObject ice_cream1 = null;
    [SerializeField]
    private GameObject ice_cream2 = null;
    [SerializeField]
    private GameObject dog = null;
    [SerializeField]
    private GameObject bear = null;

    void Start()
    {
        dialogueQueue = new Queue<string>();

        dialogueQueue.Enqueue("Dog: Bear is jumping for joy! You've really left a mark on these animals.");
        dialogueQueue.Enqueue("You’ve unlocked: Galactic Grape Ice Cream and Earth & Sun Candies!");
        dialogueQueue.Enqueue("Dog: Woof, we're not done just yet. I'm bringing back all my animal friends for one more round of ice cream.");

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
            if (line.Contains("unlocked"))
            {
                ice_cream1.SetActive(true);
                ice_cream2.SetActive(true);
                dog.SetActive(false);
                bear.SetActive(false);
            }
            else
            {
                ice_cream1.SetActive(false);
                ice_cream2.SetActive(false);
            }
        }
        else
        {
            continue_button.SetActive(true);
            continue_text.SetActive(false);
            dialogueStarted = false;
            ice_cream1.SetActive(false);
            ice_cream2.SetActive(false);
            dog.SetActive(true);
            bear.SetActive(true);
        }
    }
}