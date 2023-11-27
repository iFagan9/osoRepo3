using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    public void CloseProgram()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}