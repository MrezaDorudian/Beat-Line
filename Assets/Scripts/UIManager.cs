using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{

    public PlayerController player;
    public AudioSource audioSource;




    public void startFirstLevel()
    {
        // set active scene to FirstScene
        //UnityEngine.SceneManagement.SceneManager.LoadScene("FirstScene");
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("FirstScene"));
        if (SceneManager.GetActiveScene().name == "SecondScene")
        {
            SceneManager.LoadScene("FirstScene");
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("FirstScene"));
        player.gameStarted = true;
        audioSource.Play();
    }

    public void startSecondLevel()
    {
        // set active scene to SecondScene
        //UnityEngine.SceneManagement.SceneManager.LoadScene("SecondScene");
        if (SceneManager.GetActiveScene().name == "FirstScene")
        {
            SceneManager.LoadScene("SecondScene");
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("SecondScene"));
        player.gameStarted = true;
        audioSource.Play();
    }
}
