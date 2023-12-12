using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string sceneName;
    // Add this method to be called when the button is clicked
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}