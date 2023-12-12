using UnityEngine;
//using static System.Net.Mime.MediaTypeNames;

public class ExitGame : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void Exit()
    {
        // This line quits the application (works in standalone builds)
        // Note: This won't work in the Unity Editor, only in a built application
        Application.Quit();
    }
}