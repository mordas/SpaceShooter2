using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _liveImage;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Text _restartText;
    [SerializeField] private GameObject _mMenuPanel;
    [SerializeField] private Text _bestScoreText;

    private int _bestScore = 0;
    void Start()
    {
        _scoreText.text = "Score: " + "0";
        _bestScore = PlayerPrefs.GetInt("score",0);
       _bestScoreText.text = "Best: " + _bestScore;
    }
    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void BestScore(int bestScore){
       if(bestScore > _bestScore){
       _bestScore = bestScore; 
       PlayerPrefs.SetInt("score",_bestScore);
       _bestScoreText.text = "Best: " + _bestScore;
       }
    }

    public void UpdateLives(int live)
    {
        _liveImage.sprite = _sprites[live];
    }

    public void ShowGameOverText()
    {
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(FlicrText());
    }

    IEnumerator FlicrText()
    {
        while (true)
        {
        _gameOverText.text = "GAME OVER";
        yield return new WaitForSeconds(0.5f);
        _gameOverText.text = "";
        yield return new WaitForSeconds(0.5f);
        }
    }
    public void LoadMainMenu(){
        SceneManager.LoadScene(0);
    }

    public void Resume(){
        _mMenuPanel.active = false;
        Time.timeScale = 1;
            _mMenuPanel.GetComponent<Animator>().SetBool("play_Anim",false);
    }

    
}
