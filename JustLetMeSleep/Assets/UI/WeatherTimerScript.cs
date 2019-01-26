using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherTimerScript : MonoBehaviour
{
    public ParticleSystem rain;
    int rainChance = 2;
    int pickrand;
    void Update()
    {
        InvokeRepeating("pickWeather", 5, 20);
    }
    void PickWeather()
    {
         pickrand = Random.Range(0, 10);
        if (pickrand == rainChance)
        {
            rain.Play();
            rain.enableEmission = true;
        }
        else
        {
            rain.Stop();
            rain.enableEmission = false;
        }
    }
}