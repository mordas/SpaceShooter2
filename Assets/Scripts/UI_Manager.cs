using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _liveImage;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Text _restartText;
    void Start()
    {
        _scoreText.text = "Score: " + "0";
    }
    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
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

    
}
