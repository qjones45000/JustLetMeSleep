using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherTimerScript : MonoBehaviour
{
    //insert rain effect here
    public ParticleSystem rain;
    int rainChance = 2;
    int pickrand;
    void Start()
    {
        
    }
    void Update()
    {
        InvokeRepeating("pickWeather", 5, 20);
    }
    void PickWeather()
    {
         pickrand = Random.Range(0, 10);
        if (pickrand == rainChance)
        {
            // put rain effect activation here
            rain.enableEmission = true;
        }
    }
}
