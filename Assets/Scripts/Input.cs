using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    public GameObject last_selected;
    private Color initial_color;
    public GameObject cup;
    private GameObject scoop;

    //sprites for how the scoop looks when added to the cup
    public GameObject pink_cup = null;
    public GameObject blue_cup = null;
    public GameObject green_cup = null;
    public GameObject purple_cup = null;
    public GameObject rainbow = null;
    public GameObject white = null;
    public GameObject candies = null;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        GameObject selected_object = rayHit.collider.gameObject;
        Debug.Log(selected_object.name);

        if (selected_object.CompareTag("cup"))
        {
            if (last_selected != null)
            {
                AddscoopTocup(last_selected);
                Reset(); //visually deselect
                last_selected = null; //reset the last selected
            }
            return;
        }

        //scoop/topping selection
        if (selected_object.CompareTag("scoop"))
        {
            if (last_selected == selected_object)
            {
                Reset();
                last_selected = null; //deselecting the object
                return;
            }

            if (last_selected != null)
            {
                Reset();
            }
        }
        highlight(selected_object);

        last_selected = selected_object;
    }

    private void highlight(GameObject selected_object)
    {
        SpriteRenderer renderer = selected_object.GetComponent<SpriteRenderer>();

        if (renderer != null)
        {
            //store the initial color (color of the object)
            initial_color = renderer.color;

            //switch the color to white
            renderer.color = new Color(1f, 1f, 1f, 0.15f); //R,G,B,alpha 
        }
    }

    private void Reset()
    {
        if (last_selected != null)
        {
            SpriteRenderer renderer = last_selected.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.color = initial_color; //reset to the initial color (remove highlight)
            }
        }
    }

/////////////////////////////////////////////////
//adding scoops/toppings logic 

    public void AddscoopTocup(GameObject scoop)
    {
        if (scoop != null && cup != null) // If scoop and cup are assigned and contain references to GameObjects
        {
            string scoop_name = scoop.name; //get the name of the scoop
            Debug.Log($"Added {scoop.name} to the cup!");
            trigger_scoop_sprite(scoop_name); //add the sprite that looks like the scoops are actaully in the cup
            
            Cup cup_script = cup.GetComponent<Cup>();
            if (cup_script != null)
            {
                if (scoop_name == "Pink" || scoop_name == "Blue" || scoop_name == "Green" || scoop_name == "Purple")
                {
                    cup_script.SetFlavor(scoop_name);
                }
            }
        }
    }

    void trigger_scoop_sprite(string scoop_name)
    {
        switch (scoop_name)
        {
            case "Pink":
                enable_pink();
                break;

            case "Blue":
                enable_blue();
                break;
            
            case "Green":
                enable_green();
                break;

            case "Purple":
                enable_purple();
                break;

            case "Rainbow":
                enable_rainbow();
                break;

            case "White":
                enable_white();
                break;

            case "Candies":
                enable_candies();
                break;

            default:
                break;
        }
    }

    void enable_pink()
    {
        disable_scoop();
        if (pink_cup != null)
        {
            pink_cup.SetActive(true);
        }
    }

    void enable_blue()
    {
        disable_scoop();
        if (blue_cup != null)
        {
            blue_cup.SetActive(true);
        }
    }

    void enable_green()
    {
        disable_scoop();
        if (green_cup != null)
        {
            green_cup.SetActive(true);
        }
    }

    void enable_purple()
    {
        disable_scoop();
        if (purple_cup != null)
        {
            purple_cup.SetActive(true);
        }
    }

    void enable_rainbow()
    {
        if (rainbow != null)
        {
            rainbow.SetActive(true);
        }
    }

    void enable_white()
    {
        if (white != null)
        {
            white.SetActive(true);
        }
    }

    void enable_candies()
    {
        if (candies != null)
        {
            candies.SetActive(true);
        }
    }

    //only one scoop can appear at a time
    void disable_scoop()
    {
        if (pink_cup != null) pink_cup.SetActive(false);
        if (blue_cup != null) blue_cup.SetActive(false);
        if (green_cup != null) green_cup.SetActive(false);
        if (purple_cup != null) purple_cup.SetActive(false);
    }
}
