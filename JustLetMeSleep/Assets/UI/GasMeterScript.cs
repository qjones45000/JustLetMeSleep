using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasMeterScript : MonoBehaviour
{
    float startingGas = 0;
    float maxGas = 100;
    public Slider gasMeter;
    void Start()
    {
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
        }
        if (Input.GetKeyDown(KeyCode.D) && gasMeter.value >= 10)
        {
            gasMeter.value -= 10;
        }
    }
}
