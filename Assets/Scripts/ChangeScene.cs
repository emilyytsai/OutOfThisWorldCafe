using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private string Name; //scene name
    [SerializeField]
    private AudioManager audio_manager;
    [SerializeField] RectTransform fader;

    //to stop the star glow particle effect during the salad transition
    //hide the salad sprite as well
    public GameObject star_glow_effect;
    public GameObject galaxy_glow_effect;
    public GameObject title_glow_effect;

    // Left & Right Curtain Transition
    public RectTransform left_curtain;
    public RectTransform right_curtain;
    public float slide_distance = 1920f;
    public float slide_duration = 1.0f;


    private void Start()
    {
        // Find the AudioManager in the scene.
        audio_manager = FindAnyObjectByType<AudioManager>();
    }

    // public void change_scene()
    // {
    //     click_sound();
    //     SceneManager.LoadScene(Name);
    // }

    public void click_sound()
    {
        audio_manager.Play("Button Click");
    }

    public void quit_game() 
    {
        Application.Quit();
        Debug.Log("game quit");
    }

    // ADDED
    public void change_scene()
    {
        // This is the function you'll attach to your button OnClick.
        StartCoroutine(WaitAndChangeScene());

        //stop the moon/sun glow effect
        StartCoroutine(stop_star_glow());
        StartCoroutine(stop_galaxy_glow());
        StartCoroutine(stop_title_glow());
    }

    public void OpenScene()
    {
        // Activate the fader so it's visible
        fader.gameObject.SetActive(true);
        // Instantly set the scale to zero (hidden)
        LeanTween.scale(fader, Vector3.zero, 0f);
        // Scale the fader to (1,1,1) over 1 second with an ease in/out quad effect.
        LeanTween.scale(fader, new Vector3(1, 1, 1), 1.0f)
                 .setEase(LeanTweenType.easeInOutQuad)
                 .setOnComplete(() => {
                     // After scaling, wait another second before changing the scene.
                     Invoke("DelayedChangeScene", 1.0f);
                 });
    }

    void InitializeCurtainsOpen() {
        left_curtain.localPosition = new Vector3(-slide_distance, left_curtain.localPosition.y, left_curtain.localPosition.z);
        right_curtain.localPosition = new Vector3(slide_distance, right_curtain.localPosition.y, right_curtain.localPosition.z);
    }

    public void CloseCurtains()
    {
        // Make sure the left and right curtains are active
        left_curtain.gameObject.SetActive(true);
        right_curtain.gameObject.SetActive(true);

        // Animate the left curtain to move to the left
        LeanTween.moveLocalX(left_curtain.gameObject, -1, slide_duration)
                 .setEase(LeanTweenType.easeInOutQuad);

        // Animate the right curtain to move to the right
        LeanTween.moveLocalX(right_curtain.gameObject, 5, slide_duration)
                 .setEase(LeanTweenType.easeInOutQuad)
                 .setOnComplete(() =>
                 {
                    // After sliding, wait another second before changing the scene
                    Invoke("DelayedChangeScene", 1.0f);
                 });

    }

    //add a slight delay before the glow effect is stopped
    public IEnumerator stop_star_glow()
    {
        yield return new WaitForSeconds(0.4f);
        
        if (star_glow_effect != null)
        {
            star_glow_effect.SetActive(false);
        }
    }

    public IEnumerator stop_galaxy_glow()
    {
        yield return new WaitForSeconds(0.4f);
        
        if (galaxy_glow_effect != null)
        {
            star_glow_effect.SetActive(false);
        }
    }

        public IEnumerator stop_title_glow()
    {
        yield return new WaitForSeconds(0.4f);
        
        if (title_glow_effect != null)
        {
            star_glow_effect.SetActive(false);
        }
    }


    // public void click_sound()
    // {
    //     // This calls the AudioManager to play your "Button Click" sound.
    //     audio_manager.Play("Button Click");
    // }

    public IEnumerator WaitAndChangeScene()
    {
        click_sound(); // Play the sound effect
        yield return new WaitForSeconds(0.9f); // Wait 0.9 seconds
        SceneManager.LoadScene(Name); // Load the new scene after the delay
    }
}
