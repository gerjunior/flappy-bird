using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : MonoBehaviour
{
    private Button playBtn;
    private Button quitBtn;
    private Button infoBtn;

    private void Awake()
    {
        playBtn = transform.Find("playBtn").GetComponent<Button>();
        playBtn.onClick.AddListener(HandlePlayButtonClick);

        quitBtn = transform.Find("quitBtn").GetComponent<Button>();
        quitBtn.onClick.AddListener(HandleQuitButtonClick);

        infoBtn = transform.Find("infoBtn").GetComponent<Button>();
        infoBtn.onClick.AddListener(HandleInfoButtonClick);

    }

    private void HandlePlayButtonClick()
    {
        Loader.Load(Loader.Scene.GameScene);
    }

    private void HandleQuitButtonClick()
    {
        Application.Quit();
    }
    private void HandleInfoButtonClick()
    {
        Application.OpenURL("http://github.com/Gerjunior/flappy-bird");
    }

}
