using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver = false;
    public bool isCoop = false;

    [SerializeField] private GameObject _mMenuPanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            if(!isCoop){
            SceneManager.LoadScene(1);
            } else {
            SceneManager.LoadScene(2);
            }
            _isGameOver = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.P)){
            _mMenuPanel.SetActive(true);
            _mMenuPanel.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
            _mMenuPanel.GetComponent<Animator>().SetBool("play_Anim",true);

            Time.timeScale = 0;
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

}
