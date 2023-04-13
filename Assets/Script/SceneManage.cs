using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void changeToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void changeToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
