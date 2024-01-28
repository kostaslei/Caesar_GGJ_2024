using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public static void EnterMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public static void CloseGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
