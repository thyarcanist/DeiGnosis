using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string sNextScene;
    private string sThisScene; // if next scene


    public void Start()
    {
        sThisScene = SceneManager.GetActiveScene().name;
    }


    public void GoToNextScene()
    {
        
    }

    public void GoToThisScene()
    {

    }
}
