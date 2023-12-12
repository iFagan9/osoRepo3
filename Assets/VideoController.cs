using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Start()
    {
        // Subscribe to the loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Unsubscribe from the event to avoid multiple calls
        vp.loopPointReached -= OnVideoEnd;

        // Add your code here to transition to the next scene
        SceneManager.LoadScene("Forest Level");
    }
}