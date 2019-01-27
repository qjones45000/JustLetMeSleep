using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasMeterScript : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip burpnoise;
    public AudioClip fartnoise;
    public GameObject fart;
    public GameObject burp;
    public PlayerScript myPlayer;
    float startingGas = 0;
    float maxGas = 100;
    public Slider gasMeter;
    bool burping;
    bool farting;
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
            myPlayer.GetComponent<PlayerScript>().AssBlast();
            Debug.Log("FFFFFFFFFFRRRRRRRRT!");
            fart.SetActive(true);
            farting = true;
            audio.clip = fartnoise;
            audio.Play();
            StartCoroutine(deactivate());
        }
        if (Input.GetKeyDown(KeyCode.D) && gasMeter.value >= 10)
        {
            gasMeter.value -= 10;
            myPlayer.GetComponent<PlayerScript>().Burp();
            burp.SetActive(true);
            burping = true;
            audio.clip = burpnoise;
            audio.Play();
            Debug.Log("BUUUEEEEEELLLCH!");
            StartCoroutine(deactivate());
        }
    }
    public IEnumerator deactivate()
    {
        if(burping == true)
        {
            yield return new WaitForSeconds(2);
            burp.SetActive(false);
            burping = false;
            Debug.Log("belch over");
        }
        else if (farting == true)
        {
            yield return new WaitForSeconds(8);
            fart.SetActive(false);
            farting = false;
            Debug.Log("fart over");
        }
    }
}
