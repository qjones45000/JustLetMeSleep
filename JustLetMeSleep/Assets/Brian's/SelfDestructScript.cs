using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructScript : MonoBehaviour
{

	public float destructionTime;
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(BeginCountdown());
    }

	IEnumerator BeginCountdown(){
		yield return new WaitForSeconds(destructionTime);
		Destroy(gameObject);
	}
}
