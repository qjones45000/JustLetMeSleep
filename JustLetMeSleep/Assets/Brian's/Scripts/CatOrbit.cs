using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatOrbit : MonoBehaviour
{

	public GameObject catRef;

	public GameObject spawnPoint;


	public List<GameObject> myCats = new List<GameObject>();
	public float catCount;

	public bool maxCatCountReached;

	public float rotSpeed;

	public float spawnMin;
	public float spawnMax;
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(CatSpawnProcess());
		rotSpeed = 1f;
		spawnMin = 2;
		spawnMax = 5;
    }

    // Update is called once per frame
    void Update()
    {
		rotSpeed += 0.001f;
		if (spawnMin >= 0){
			spawnMin -= 0.01f;
		}
		if (spawnMax >= 1){
			spawnMax -= 0.0001f;
		}
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
