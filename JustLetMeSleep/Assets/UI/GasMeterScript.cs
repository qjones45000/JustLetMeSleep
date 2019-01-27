using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasMeterScript : MonoBehaviour
{
    public CameraShake shake;
    public PlayerScript playerRef;
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
        shake = FindObjectOfType<CameraShake>();
        myPlayer = FindObjectOfType<PlayerScript>();
        gasMeter.value = startingGas;
    }
    void Update()
    {
        if(gasMeter.value < maxGas)
        {
            gasMeter.value += 1 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.X) && gasMeter.value >= 40 && playerRef.dead == false)
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
        if (Input.GetKeyDown(KeyCode.Z) && gasMeter.value >= 10 && playerRef.dead == false)
        {
            gasMeter.value -= 10;
            shake.shakecamera();
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
            shake.shaketrue = false;
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
