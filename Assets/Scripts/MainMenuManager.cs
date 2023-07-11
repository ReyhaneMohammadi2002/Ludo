using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static int howManyPlayers;
   
    public void TwoPlayers()
    {
        //buttonAS.PlayOneShot(buttonAC);
        //SoundManager.buttonAusioSource.Play();
        howManyPlayers = 2;
        SceneManager.LoadScene("Ludo");


    }
    public void ThreePlayers()
    {
        // buttonAS.PlayOneShot(buttonAC);
        //SoundManager.buttonAusioSource.Play();
        howManyPlayers = 3;
        SceneManager.LoadScene("Ludo");


    }
    public void FourPlayers()
    {
        //buttonAS.PlayOneShot(buttonAC);
        //SoundManager.buttonAusioSource.Play();
        howManyPlayers = 4;
        SceneManager.LoadScene("Ludo");


    }

    public void Quit()
    {
        //buttonAS.PlayOneShot(buttonAC);
        //SoundManager.buttonAusioSource.Play();
        Application.Quit();


    }
}
