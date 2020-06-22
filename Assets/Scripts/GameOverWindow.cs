using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    private static Button retryBtn;
    private static Button mainMenuBtn;


    private Text scoreText;
    private Text highScoreText;

    private void Awake()
    {
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        highScoreText = transform.Find("highScoreText").GetComponent<Text>();

        retryBtn = transform.Find("retryBtn").GetComponent<Button>();
        retryBtn.onClick.AddListener(HandleClickRetryButton);
        retryBtn.AddButtonSounds();

        mainMenuBtn = transform.Find("mainMenuBtn").GetComponent<Button>();
        mainMenuBtn.onClick.AddListener(HandleClickMainMenuButton);


    }

    private void HandleClickRetryButton()
    {
        Loader.Load(Loader.Scene.GameScene);
    }

    private void HandleClickMainMenuButton()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }

    private void Start()
    {
        Bird.GetInstance().OnDied += Bird_OnDied;
        Hide();
    }


    private void Bird_OnDied(object sender, EventArgs e)
    {
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();

        int score = Convert.ToInt32(scoreText.text);
        int highscore = PlayerPrefs.GetInt("highscore");

        if (score > highscore)
        {
            SetHighScore(score);
        } 
        else
        {
            SetHighScore(highscore);
        }


        Show();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("highscore", score);
        highScoreText.text = score.ToString();

    }
}
