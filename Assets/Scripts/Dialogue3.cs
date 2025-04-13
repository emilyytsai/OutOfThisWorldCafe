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
        private GameObject heart = null;


        void Start()
        {
            dialogueQueue = new Queue<string>();

            dialogueQueue.Enqueue("Dog: Hurruff! You and your cafe are just what me and my animal friends were looking for.");
            dialogueQueue.Enqueue("Cat: Meow!");
            dialogueQueue.Enqueue("Dog: Woof, we have decided we are coming home with you");
            dialogueQueue.Enqueue("So the animals went home satisfied with their new owner, and they were happy with the best ice cream in the galaxy!");
            dialogueQueue.Enqueue("This journey was Out of This World for sure!");

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
            }
            else
            {
                continue_button.SetActive(true);
                continue_text.SetActive(false);
                dialogueStarted = false;
                dog.SetActive(true);
                cat.SetActive(true);
                heart.SetActive(true);
            }
        }
    }