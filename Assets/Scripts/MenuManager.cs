using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public Canvas HTP = null;
    public Canvas mainCanvas = null;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void HowToPlay()
    {
        mainCanvas.gameObject.SetActive(false);
        HTP.gameObject.SetActive(true);
    }

    public void Back()
    {
        mainCanvas.gameObject.SetActive(true);
        HTP.gameObject.SetActive(false);
    }

}
