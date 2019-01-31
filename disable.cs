using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class disable : MonoBehaviour
{

    public Button Mute;
    public Sprite muteA;
    public Sprite muteA_disable;
    private int counter = 0;

    void Start()
    {
        Mute = GetComponent<Button>();
    }

    public void changeButton()
    {
        counter++;
        if (counter % 2 == 0)
        {
            Mute.image.overrideSprite = muteA;
        }
        else
        {
            Mute.image.overrideSprite = muteA_disable;

        }
    }
}