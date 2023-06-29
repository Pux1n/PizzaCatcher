using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        PauseActive.pause = 0;
        ItemSpawn.gameOver = false;
    }

    public void Shop()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void MyCoupons()
    {
        SceneManager.LoadScene(3);
    }
}
