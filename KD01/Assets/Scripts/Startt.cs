using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startt : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
