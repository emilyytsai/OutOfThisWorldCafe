using UnityEngine;
using TMPro;

public class AnimalRequest : MonoBehaviour
{
    public enum Flavor
    {
        stardust_strawberry,
        blue_giant_blueberry,
        meteoric_mint,
        galactic_grape
    }

    public Flavor desired_flavor;

    public TextMeshProUGUI request_text;

    private bool has_received_ice_cream = false;

    void Start()
    {
        request_text.text = $"I'm really in the mood for some {desired_flavor.ToDisplayString()} ice cream.";
    }

    public void receive_ice_cream(bool has_flavor, Flavor given_flavor = Flavor.stardust_strawberry)
    {
        if (has_received_ice_cream) return;

        //if player tries to serve empty cup
        if (!has_flavor)
        {
            request_text.text = "You gave me... nothing?! How could you do this...";
        }
        //correct
        else if (given_flavor == desired_flavor)
        {
            request_text.text = "Wow! Thank you for this yummy treat!";
        }
        //incorrect
        else
        {
            request_text.text = "I didn't really want this. Thanks anyways.";
        }

        has_received_ice_cream = true;
    }
}

public static class FlavorExtensions
{
    public static string ToDisplayString(this AnimalRequest.Flavor flavor)
    {
        switch (flavor)
        {
            case AnimalRequest.Flavor.stardust_strawberry:
                return "Stardust Strawberry";
            case AnimalRequest.Flavor.blue_giant_blueberry:
                return "Blue Giant Blueberry";
            case AnimalRequest.Flavor.meteoric_mint:
                return "Meteoric Mint";
            case AnimalRequest.Flavor.galactic_grape:
                return "Galactic Grape";
            default:
                return flavor.ToString();
        }
    }
}
