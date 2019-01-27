using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatOrbit : MonoBehaviour
{

    public PlayerScript playerRef;

	public GameObject catRef;

	public GameObject spawnPoint;


	public List<GameObject> myCats = new List<GameObject>();
	public float catCount;

	public bool maxCatCountReached;

	public float rotSpeed;

	public float spawnMin;
	public float spawnMax;

    public float baseMin;
    public float baseMax;

    public float rainMin;
    public float rainMax;


    public WeatherTimerScript weatherRef;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = FindObjectOfType<PlayerScript>();
        weatherRef = FindObjectOfType<WeatherTimerScript>();
		StartCoroutine(CatSpawnProcess());
		rotSpeed = 1f;
		baseMin = 2;
		baseMax = 5;
    }

    // Update is called once per frame
    void Update()
    {


        if (weatherRef.raining == true)
        {
            spawnMin = rainMin;
            spawnMax = rainMax;
        }
        if (weatherRef.raining == false)
        {
            spawnMin = baseMin;
            spawnMax = baseMax;
        }
        if (playerRef.dead == false)
        {
            rotSpeed += 0.0001f;
        }
		if (baseMin >= 0){
			baseMin -= 0.01f;
		}
		if (baseMax >= 1){
			baseMax -= 0.0001f;
		}
        rainMin = baseMin * 2;
        rainMax = baseMax * 2;
		transform.Rotate(0,rotSpeed,0);
//		if (Input.GetKeyDown(KeyCode.Space)){
//			var myNewCat = Instantiate (catRef, spawnPoint.transform.position, spawnPoint.transform.rotation);
//			myNewCat.transform.parent = gameObject.transform;
//
//		}
//		
		if (catCount == 10){
			maxCatCountReached = true;
		}

		if (catCount < 10 && maxCatCountReached == true){
			maxCatCountReached = false;
			StartCoroutine(CatSpawnProcess());
		}
    }

	public IEnumerator CatSpawnProcess(){
		yield return new WaitForSeconds(Random.Range(spawnMin,spawnMax));
		var myNewCat = Instantiate (catRef, spawnPoint.transform.position, spawnPoint.transform.rotation);
		myNewCat.transform.parent = gameObject.transform;

		catCount += 1;
		myCats.Add(myNewCat);
		if (catCount < 10){
		StartCoroutine(CatSpawnProcess());
		}

	}
}
