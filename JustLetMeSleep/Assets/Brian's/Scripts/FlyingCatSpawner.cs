using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCatSpawner : MonoBehaviour
{

	public GameObject frontLeftCatRef;
	public GameObject frontLeftSpawn;

	public GameObject frontRightCatRef;
	public GameObject frontRightSpawn;

	public GameObject backLeftCatRef;
	public GameObject backLeftSpawn;

	public GameObject backRightCatRef;
	public GameObject backRightSpawn;

	public void Update(){
		if (Input.GetKeyDown(KeyCode.Space)){
			SpawnBackLeft();
		}
	}

	public void SpawnFrontLeft(){
		GameObject newCat = Instantiate (frontLeftCatRef, frontLeftSpawn.transform.position, frontLeftSpawn.transform.rotation);

	}
	public void SpawnFrontRight(){
		if (frontRightSpawn != null){
		GameObject newCat = Instantiate (frontRightCatRef, frontRightSpawn.transform.position, frontRightSpawn.transform.rotation);
		}
	}
	public void SpawnBackRight(){
		if (backRightSpawn != null){
			GameObject newCat = Instantiate (backRightCatRef, backRightSpawn.transform.position, backRightSpawn.transform.rotation);
		}
	}
	public void SpawnBackLeft(){
		if (backLeftSpawn != null){
			GameObject newCat = Instantiate (backLeftCatRef, backLeftSpawn.transform.position, backLeftSpawn.transform.rotation);
		}
	}
}
