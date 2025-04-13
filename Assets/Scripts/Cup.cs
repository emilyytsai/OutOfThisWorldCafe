using UnityEngine;

public class Cup : MonoBehaviour
{
    public enum Flavor
    {
        None,
        stardust_strawberry,    
        blue_giant_blueberry,   
        meteoric_mint,        
        galactic_grape        
    }

    private Flavor current_flavor = Flavor.None;

    public void SetFlavor(string scoop_name)
    {
        switch (scoop_name)
        {
            case "Pink":
                current_flavor = Flavor.stardust_strawberry;
                break;
            case "Blue":
                current_flavor = Flavor.blue_giant_blueberry;
                break;
            case "Green":
                current_flavor = Flavor.meteoric_mint;
                break;
            case "Purple":
                current_flavor = Flavor.galactic_grape;
                break;
            default:
                break;
        }
    }

    public bool has_scoop()
    {
        return current_flavor != Flavor.None;
    }

    public Flavor get_flavor()
    {
        return current_flavor;
    }

    public void reset_flavor()
    {
        current_flavor = Flavor.None;
    }
}
