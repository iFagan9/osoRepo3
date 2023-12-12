using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public PlayerHealth PH;
    public int menuIndex;

    public void Respawn()
    {
        Time.timeScale = 1;
        PH.Respawn(PH.respawnPoint.transform.position);
        this.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        int currentSceneID = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneID);
        this.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(menuIndex);
    }

    public void setPlayerHealth(PlayerHealth ph)
    {
        PH = ph;
    }
}
