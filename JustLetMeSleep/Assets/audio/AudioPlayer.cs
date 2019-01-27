using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip bg1;
    public AudioClip bg2;
    public AudioSource musicSource;
    int bgChance = 2;
    int pickrand;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = bg1;
        Picksong();
        musicSource.Play();
    }

    // Update is called once per frame
   /* void Update()
    {
        musicSource.Play();
    }*/
    void Picksong()
    {
        pickrand = Random.Range(0, 3);
        Debug.Log(pickrand);
        if (pickrand == bgChance)
        {
            musicSource.clip = bg2;
        }
        else
        {
            musicSource.clip = bg1;
        }
    }
}
