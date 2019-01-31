using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    bool isMute;

    public void PlayGame()
    {
        PlayerPrefs.SetInt("scoreNew", ScoreManager.scoreCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MuteGame()
    {
        //Muten
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayGameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ScoreManager.scoreCount = 0;
        PlayerPrefs.SetInt("scoreNew", 0);
    }
}