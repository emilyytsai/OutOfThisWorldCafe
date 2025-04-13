    using UnityEngine;
    using TMPro;
    using System.Collections.Generic;

    public class Dialogue3 : MonoBehaviour
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

            dialogueQueue.Enqueue("Dog: Hurruff! you served the pidges!");
            dialogueQueue.Enqueue("Rat: Ratatata!");
            dialogueQueue.Enqueue("Dog: Woof, time to go home! Thanks for helping us Ice Creamer!");
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