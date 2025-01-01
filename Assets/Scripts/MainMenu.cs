using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyUI.Popup;

public class MainScene : MonoBehaviour
{
    [TextArea(5,30)] public string longText;
    //Load scene
    public void Play()
    {
        SceneManager.LoadScene("WeWillRockYou");
    }
    //Quit scene
    public void Quit()
    {
        Application.Quit();
        Debug.Log("user quit");
    }
    //Intructive pop-up
    public void Intructive()
    {
        Popup.Show("Instructivo", longText);
    }
}
