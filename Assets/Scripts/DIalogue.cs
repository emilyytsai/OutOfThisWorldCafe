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
    
    //ice cream sprites appear on screen according to dialogue line
    [SerializeField]
    private GameObject ice_cream1 = null;
    [SerializeField]
    private GameObject ice_cream2 = null;
    [SerializeField]
    private GameObject ice_cream3 = null;

    [SerializeField]
    private GameObject dog = null;
    [SerializeField]
    private GameObject human = null;

    void Start()
    {
        dialogueQueue = new Queue<string>();

        dialogueQueue.Enqueue("Dog: Woof! Hey there human!");
        dialogueQueue.Enqueue("Dog: Me and my animal friends have been stuck in space for quite some time now. We really miss the taste of ice cream and could use a nice owner.");
        dialogueQueue.Enqueue("Dog: Wait it looks like you just opened an ice cream cafe here in space?!");
        dialogueQueue.Enqueue("Dog: Woof, we’re so hungry. Help us get some treats, and maybe we will go home with you!");
        dialogueQueue.Enqueue("Serve some treats to the ice cream deprived animals. \n\n\n\n\n\n\n\n");
        dialogueQueue.Enqueue("HOW TO PLAY: \n\nWhen you get to the cafe, click on the flavor, then click on the cup to add the ice cream scoop. \n\nNOTE: these animals aren't picky about their toppings. Have fun!\n\n\n");

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
            if (line.Contains("on the flavor"))
            {
                ice_cream1.SetActive(true);
                ice_cream2.SetActive(true);
                dog.SetActive(false);
                human.SetActive(false);
                continue_button.SetActive(true);
                continue_text.SetActive(false);
                ice_cream3.SetActive(false);
            }

            else if (line.Contains("ice cream deprived animals"))
            {
                ice_cream3.SetActive(true);
                dog.SetActive(false);
                human.SetActive(false);
            }
        }
        else
        {
            continue_button.SetActive(true);
            continue_text.SetActive(false);
            dialogueStarted = false;
            ice_cream1.SetActive(true);
            ice_cream2.SetActive(true);
            ice_cream3.SetActive(false);
            dog.SetActive(false);
            human.SetActive(false);
        }
    }
}