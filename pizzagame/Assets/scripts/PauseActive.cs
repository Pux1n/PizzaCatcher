using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseActive : MonoBehaviour
{

    public static int pause = 0;

    public GameObject pausePanel;
    public GameObject startWarning;

    public void OpenPause()
    {
        pause++;

        if (pause == 0)
        {
            pausePanel.SetActive(false);
            startWarning.SetActive(true);
            Time.timeScale = 1f;
        }
        else if (pause == 1)
        {
            pausePanel.SetActive(true);
            startWarning.SetActive(false);
            Time.timeScale = 0f;
        }
        else if (pause > 1)
        {
            pause = 0;
            Time.timeScale = 1f;
            startWarning.SetActive(true);
            pausePanel.SetActive(false);
        }
    }
}
