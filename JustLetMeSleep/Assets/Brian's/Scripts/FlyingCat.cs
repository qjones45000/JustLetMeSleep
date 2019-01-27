using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCat : MonoBehaviour
{
    public CatScoreScript catscore;
	public float traXMax;
	public float traX;
	public float traXMin;

	public float traYMax;
	public float traY;
	public float traYMin;

	public float traZMax;
	public float traZ;
	public float traZMin;

	public float rotXMax;
	public float rotX;
	public float rotXMin;

	public float rotYMax;
	public float rotY;
	public float rotYMin;

	public float rotZMax;
	public float rotZ;
	public float rotZMin;

	public bool blowsUp;
	public GameObject boomFX;

	public float deathTime;
    // Start is called before the first frame update
    void Start()
    {

        traX = Random.Range(traXMin,traXMax);
		traY = Random.Range(traYMin,traYMax);
		traZ = Random.Range(traZMin,traZMax);

		rotX = Random.Range(rotXMin,rotXMax);
		rotY = Random.Range(rotYMin,rotYMax);
		rotZ = Random.Range(rotZMin,rotZMax);

		StartCoroutine(TimeToDestruction());
        catscore = FindObjectOfType<CatScoreScript>();
        catscore.AddScore(1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(traX,traY,traZ);
		transform.Rotate(rotX,rotY,rotZ);
    }

	public IEnumerator TimeToDestruction()
    {
		yield return new WaitForSeconds(deathTime);
		if (blowsUp == true)
        {
		    Instantiate (boomFX, gameObject.transform.position, gameObject.transform.rotation);
		}
        Destroy(gameObject);
	}
}
