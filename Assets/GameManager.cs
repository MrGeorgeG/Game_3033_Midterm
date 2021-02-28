using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] Text ScoreText;
    public int Score = 0;
    public GameObject PauseUI;
    public GameObject Gredits;
    public GameObject MainMenu;
    public GameObject HitUI;

    public void UpdateUI()
    {
        ScoreText.text = Score.ToString();
    }

    public void AddScore(int score)
    {
        Score += score;
        UpdateUI();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenCredit()
    {
        if (Gredits && MainMenu)
        {
            Gredits.SetActive(true);
            MainMenu.SetActive(false);
        }
    }
    public void CloseCredit()
    {
        if (Gredits && MainMenu)
        {
            Gredits.SetActive(false);
            MainMenu.SetActive(true);
        }
    }

    public void OpenHItUI()
    {
        HitUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HItUI()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        HitUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMeun()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }

    public void End()
    {
        SceneManager.LoadScene("EndScene");
    }

}
