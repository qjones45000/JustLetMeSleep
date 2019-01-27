using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherTimerScript : MonoBehaviour
{
    public GameObject rain;
    int rainChance = 2;
    int pickrand;
    public bool raining;
    void Start()
    {
        raining = false;
        InvokeRepeating("PickWeather", 1, 10);
    }
    void Update()
    {
        
    }
    void PickWeather()
    {
        pickrand = Random.Range(0, 3);
        Debug.Log(pickrand);
        if (pickrand == rainChance)
        {
            if (raining == true)
            {
                rain.SetActive(false);
                Debug.Log("not raining!");
                raining = false;
            }
            else if (raining == false)
            {
                rain.SetActive(true);
                Debug.Log("raining!");
                raining = true;
            }
        }
    }
}