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

        [SerializeField]
        private GameObject dog = null;
        [SerializeField]
        private GameObject cat = null;

        [SerializeField]
        private GameObject heart1 = null;
        [SerializeField]
        private GameObject heart2 = null;
        [SerializeField]
        private GameObject polaroid = null;


        void Start()
        {
            dialogueQueue = new Queue<string>();

            dialogueQueue.Enqueue("Dog: Hurruff! You and your cafe are just what me and my animal friends were looking for.");
            dialogueQueue.Enqueue("Cat: Meow!");
            dialogueQueue.Enqueue("Dog: Woof, we have decided we are coming home with you. Thank you for serving us treats.");
            dialogueQueue.Enqueue("So the animals went home satisfied with their new owner, and they were happy with the best ice cream in the galaxy!");
            dialogueQueue.Enqueue("\n\nThis journey was <b><u><color=#A70002>Out of This World</color=#A70002></b></u> for sure!");

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
                if (line.Contains("Meow!"))
                {
                    cat.SetActive(true);
                }
                else if (line.Contains("for sure"))
                {
                    heart1.SetActive(true);
                }
            }
            else
            {
                continue_button.SetActive(true);
                continue_text.SetActive(false);
                dialogueStarted = false;
                dog.SetActive(true);
                cat.SetActive(true);
                heart2.SetActive(true);

                dialogueText.text = "";
                polaroid.SetActive(true);
            }
        }
    }