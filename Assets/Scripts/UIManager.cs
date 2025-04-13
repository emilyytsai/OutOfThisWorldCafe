using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI Manager Script//
    public static UIManager Instance { get; private set; } //singleton pattern implementation

    //things that will be active when the customer enters/leaves
    public GameObject request_text;
    [SerializeField]
	private Button serve_button = null;

    //hide after serve
    public GameObject pink_cup = null;
    public GameObject blue_cup = null;
    public GameObject green_cup = null;
    public GameObject purple_cup = null;
    public GameObject rainbow = null;
    public GameObject white = null;
    public GameObject candies = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else //destroy duplicate instance if found
        {
            Destroy(gameObject);
        }

        serve_button.interactable = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        serve_button.interactable = false;
        request_text.SetActive(false);
    }
    
    public void show_text()
    {
        request_text.SetActive(true);
        serve_button.interactable = true;
    }

    public void hide_text()
    {
        request_text.SetActive(false);
    }

    public void hide_scoop()
    {
        if (pink_cup != null) pink_cup.SetActive(false);
        if (blue_cup != null) blue_cup.SetActive(false);
        if (green_cup != null) green_cup.SetActive(false);
        if (purple_cup != null) purple_cup.SetActive(false);
        if (rainbow != null) rainbow.SetActive(false);
        if (white != null) white.SetActive(false);
        if (candies != null) candies.SetActive(false);

        serve_button.interactable = false;
    }
}
