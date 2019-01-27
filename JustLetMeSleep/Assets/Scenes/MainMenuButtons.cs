using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject helppanel;
    public GameObject creditspanel;
    bool helpon;
    bool credon;
    public void playgame()
    {
        SceneManager.LoadScene(1);
    }
    public void help()
    {
        helpon = true;
        helppanel.SetActive(true);
    }
    public void credits()
    {
        credon = true;
        creditspanel.SetActive(true);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            helpon = false;
            credon = false;
        }
        if (helpon == true)
        {
            helppanel.SetActive(true);
        }
        else if (helpon == false)
        {
            helppanel.SetActive(false);
        }
        if (credon == true)
        {
            creditspanel.SetActive(true);
        }
        else if (credon == false)
        {
            creditspanel.SetActive(false);
        }
    }
}
