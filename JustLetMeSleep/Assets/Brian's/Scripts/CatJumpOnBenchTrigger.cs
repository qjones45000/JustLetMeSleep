using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatJumpOnBenchTrigger : MonoBehaviour
{
	public GameObject playerRef;

	public GameObject legSpawn;
	public GameObject occupiesLeg;
	public GameObject armSpawn;
	public GameObject occupiesArm;
	public int myInt;

	public bool isActive;
	public bool activating;
	public bool playerLookingAway;
	public bool isFront;
	public bool isBack;
	public GameObject otherSide;
	public bool isFilled;


	public float jumpMax;

	public GameObject catOrbit;
    // Start is called before the first frame update
    void Start()
    {
		jumpMax = 10;
    }

    // Update is called once per frame
    void Update()
    {
		if (jumpMax >= 1){
			jumpMax -= 0.000001f;
		}

		myInt = Random.Range(1,3);
       
            if (playerRef.GetComponent<PlayerScript>().lookingFront)
            {
                if (isFront == true)
                {
                    playerLookingAway = false;
                }
                if (isBack == true)
                {
                    playerLookingAway = true;
                }
            }
            if (playerRef.GetComponent<PlayerScript>().lookingBack == true)
            {
                if (isBack == true)
                {
                    playerLookingAway = false;
                }
                if (isFront == true)
                {
                    playerLookingAway = true;
                }
            }
        

		if (isActive == false && activating == false){
			activating = true;
			StartCoroutine(MakeActive());
		}
		if (occupiesArm != null || occupiesLeg != null)
		{
			isFilled = true;
		}
		else
		{
			isFilled = false;
		}


    }

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "CatTag" && playerLookingAway == true && isActive == true && playerRef.GetComponent<PlayerScript>().hasFarted == false)
        {
			
			GameObject newCat;
			newCat = other.gameObject;



			if (occupiesLeg == null && myInt == 1 && otherSide.GetComponent<CatJumpOnBenchTrigger>().isFilled == false){
				Destroy(newCat);
				GameObject legCat = Instantiate (newCat, legSpawn.transform.position, legSpawn.transform.rotation);
				occupiesLeg = legCat;
				isActive = false;

			}
			if (occupiesArm == null && myInt == 2 && otherSide.GetComponent<CatJumpOnBenchTrigger>().isFilled == false){
				Destroy(newCat);
				GameObject armCat = Instantiate (newCat, armSpawn.transform.position, armSpawn.transform.rotation);
				occupiesArm = armCat;
				isActive = false;

			}
		}
	}

	public IEnumerator MakeActive(){
		yield return new WaitForSeconds(Random.Range(0.5f,3));
			isActive = true;
			activating = false;
	}
}
