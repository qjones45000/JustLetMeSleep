using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasMeterScript : MonoBehaviour
{
    public PlayerScript myPlayer;
    float startingGas = 0;
    float maxGas = 100;
    public Slider gasMeter;
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerScript>();
        gasMeter.value = startingGas;
    }
    void Update()
    {
        if(gasMeter.value < maxGas)
        {
            gasMeter.value += 1 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.A) && gasMeter.value >= 40)
        {
            gasMeter.value -= 40;
            //myPlayer.GetComponent<PlayerScript>().Fart();
        }
        if (Input.GetKeyDown(KeyCode.D) && gasMeter.value >= 10)
        {
            gasMeter.value -= 10;
            myPlayer.GetComponent<PlayerScript>().Burp();
        }
    }
}
