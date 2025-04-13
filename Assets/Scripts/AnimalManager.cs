using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimalManager : MonoBehaviour
{
    public Animator animator;
    public GameObject animal;
    public SpriteRenderer animal_sprite;

    public Sprite[] animal_sprites;

    //counter
    private int current_animal = -1;
    //track if lthey left
    private bool is_leaving = false;

    public Button serve_button = null;

    public string Name; //scene name

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = animal.GetComponent<Animator>();
        serve_button.onClick.AddListener(animal_served);
        next_animal();
    }


    public void next_animal()
    {
        if (current_animal + 1 < animal_sprites.Length)
        {
            current_animal++;
            animal_sprite.sprite = animal_sprites[current_animal];

            reset_animator();

            //animal enters//
            StartCoroutine(enter_animation());
        }
        else
        {
            SceneManager.LoadScene(Name); //load dialogue
        }
    }

    private void reset_animator()
    {
        animator.Rebind();
        animator.Update(0);
    }

    public void animal_served()
    {
        if (!is_leaving)
        {
            is_leaving = true;
            StartCoroutine(leave_animation());
        }
    }

    public IEnumerator enter_animation()
    {
        animator.ResetTrigger("IdleTrigger");
        animator.ResetTrigger("LeaveTrigger");
        animator.SetTrigger("EnterTrigger");
        yield return new WaitForSeconds(2.2f);
        animator.ResetTrigger("EnterTrigger");
        animator.SetTrigger("IdleTrigger");
    }

    public IEnumerator leave_animation()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetTrigger("LeaveTrigger");

        yield return new WaitForSeconds(3f);
        is_leaving = false;

        next_animal();
    }
}
