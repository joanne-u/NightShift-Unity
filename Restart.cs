using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public GameObject MainMenu;

    public void Update()
    {
        //Restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Score resetten auf mainmenu value
            ScoreManager.scoreCount = PlayerPrefs.GetInt("scoreNew");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        //Menü
        else if (Input.GetKeyDown(KeyCode.M))
        {
            ScoreManager.scoreCount = PlayerPrefs.GetInt("scoreNew");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        //Quit
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
