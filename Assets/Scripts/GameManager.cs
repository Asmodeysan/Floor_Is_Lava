using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public int score;
    GameObject player;
    UIPlayground playgroundUI;
    public string playerName;
    public TMP_InputField iField;
    public TextMeshProUGUI yourScore;

    void Start()
    {
        isGameActive = true;
        player = GameObject.Find("PlayerArmature");
        playgroundUI = GameObject.Find("Canvas").GetComponent<UIPlayground>();
    }

    void Update()
    {
        if (player.transform.position.y < -1.28)
        {
            GameOver();
        }

        if (isGameActive)
        {
            score = GameObject.Find("PlayerArmature").GetComponent<JumpCounter>().jumpCounter;
        }

        if (!isGameActive)
        {
            yourScore.text = "Your Score - " + score;
            MainManager.Instance.score = score;
            MainManager.Instance.playerName = playerName;
        }
    }

    public void NameInput()
    {
        playerName = iField.text;
        iField.gameObject.SetActive(false);
    }

    public void Finish()
    {
        playgroundUI.Finish();
        isGameActive = false;
        player.SetActive(false);
    }

    public void GameOver()
    {
        isGameActive = false;
        playgroundUI.GameOver();
        player.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
