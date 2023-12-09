using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{

    public void GotToMenu() {
        SceneManager.LoadScene(0);
    }
    public void GoToPrototype1() {
        SceneManager.LoadScene(2);
    }

    public void GoToPrototype2()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToPrototype3()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ExitGame();
        }
    }
}
