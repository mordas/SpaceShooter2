using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SingleGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene(2);
    }

}
