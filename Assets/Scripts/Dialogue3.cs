    using UnityEngine;
    using TMPro;
    using System.Collections.Generic;

    public class Dialogue3 : MonoBehaviour
    {
        public TMP_Text dialogueText;

        private Queue<string> dialogueQueue;
        private bool dialogueStarted = false;

        void Start()
        {
            dialogueQueue = new Queue<string>();

            dialogueQueue.Enqueue("Dog: Hurruff! you served the pidges!");
            dialogueQueue.Enqueue("Rat: Ratatata!");
            dialogueQueue.Enqueue("Dog: Woof, time to go home! Thanks for helping us Ice Creamer!");

            DisplayNextLine();
            dialogueStarted = true;
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
                dialogueText.text = "";
                dialogueStarted = false;
            }
        }
    }