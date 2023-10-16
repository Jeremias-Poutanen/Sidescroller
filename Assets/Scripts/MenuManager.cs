using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public static void Play()
    {
        SceneManager.LoadScene("Level");
    }

    public static void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
