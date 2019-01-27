using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    public SpriteRenderer myRenderer;
    public Color furColor;
    public int randomInt;

    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    // Start is called before the first frame update
    void Start()
    {
        randomInt = Random.Range(1, 6);

        if (randomInt == 1)
        {
            furColor = color1;
        }
        if (randomInt == 2)
        {
            furColor = color2;
        }
        if (randomInt == 3)
        {
            furColor = color3;
        }
        if (randomInt == 4)
        {
            furColor = color4;
        }
        if (randomInt == 5)
        {
            furColor = color5;
        }
        myRenderer.color = furColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
