using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    public bool gameStarted;
    public bool gameOver;
    public static StartGameController instance;

    [SerializeField] GameObject gameOverBtn;
    [SerializeField] GameObject startBtn;
    [SerializeField] GameObject fade;
    [SerializeField] GameObject startImage;
    [SerializeField] TextMeshProUGUI pointsText;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        gameOver = false;
        instance = this;
    }

    public void StartGame()
    {
        gameStarted = true;
        fade.SetActive(false);
        startBtn.SetActive(false);
        startImage.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
