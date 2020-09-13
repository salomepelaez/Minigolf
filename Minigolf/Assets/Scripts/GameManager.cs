using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartFirstLevel()
    {
        SceneManager.LoadScene("PrimerNivel");
    }

    public void StartSecondLevel()
    {
        SceneManager.LoadScene("SegundoNivel");
    }

    public void StartThirdLevel()
    {
        SceneManager.LoadScene("TercerNivel");
    }

    public void StartForthLevel()
    {
        SceneManager.LoadScene("CuartoNivel");
    }

    public void StartFifthLevel()
    {
        SceneManager.LoadScene("QuintoNivel");
    }

    public void StartSixthLevel()
    {
        SceneManager.LoadScene("SextoNivel");
    }
    
}
