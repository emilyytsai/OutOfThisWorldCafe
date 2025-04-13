using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private string Name; //scene name

    public void change_scene()
    {
        //click_sound(); //NOTE** uncomment this later
        SceneManager.LoadScene(Name);
    }

    public void quit_game() 
    {
        Application.Quit();
        Debug.Log("game quit");
    }
}
