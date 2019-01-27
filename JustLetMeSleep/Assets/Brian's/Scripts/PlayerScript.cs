using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

	public float pushedOffIn;
	public Slider timeBar;
	public bool dead;

	public GameObject catOrbit;

	public bool lookingBack;
	public bool lookingFront;

	public GameObject backSide;
	public GameObject frontSide;

	public GameObject flyingCatSpawner;


	public GameObject[] cats;
	public GameObject flyingCatRef;
	public GameObject spookedCat;

    public bool hasFarted;
    // Start is called before the first frame update
    void Start()
    {
		pushedOffIn = 100;

		lookingFront = true;
    }

	void Update(){
		timeBar.value = pushedOffIn;
		if (dead == false){
		if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z == 0 && frontSide.GetComponent<CatJumpOnBenchTrigger>().occupiesLeg == null && frontSide.GetComponent<CatJumpOnBenchTrigger>().occupiesArm == null){
			//transform.Rotate(0,180,0);
			//transform.Translate(0,0,-1);
			transform.position = new Vector3(0,1.1f,-1);
			transform.rotation = Quaternion.Euler(-90,0,90);
			lookingBack = false;
			lookingFront = true;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z == 0 && backSide.GetComponent<CatJumpOnBenchTrigger>().occupiesLeg == null && backSide.GetComponent<CatJumpOnBenchTrigger>().occupiesArm == null){
			//transform.Rotate(0,-180,0);
			//transform.Translate(0,0,1);
			transform.position = new Vector3(0,1.1f,1);
			transform.rotation = Quaternion.Euler(90,0,90);
			lookingFront = false;
			lookingBack = true;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z == 1){
			//transform.Rotate(0,180,0);
			//transform.Translate(0,0,-1);
			transform.position = new Vector3(0,1.1f,0);
			transform.rotation = Quaternion.Euler(-90,0,90);
			lookingBack = false;
			lookingFront = true;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z == -1){
			//transform.Rotate(0,-180,0);
			//transform.Translate(0,0,1);
			transform.position = new Vector3(0,1.1f,0);
			transform.rotation = Quaternion.Euler(90,0,90);
			lookingFront = false;
			lookingBack = true;
		}

			/*if (Input.GetKeyDown(KeyCode.A)){
				Burp();
			}*/
		if (lookingFront == true){
				
				if (Input.GetKeyDown(KeyCode.Z) && frontSide.GetComponent<CatJumpOnBenchTrigger>().occupiesArm != null){
					
				Destroy(frontSide.GetComponent<CatJumpOnBenchTrigger>().occupiesArm);
				catOrbit.GetComponent<CatOrbit>().catCount -= 1;
					flyingCatSpawner.GetComponent<FlyingCatSpawner>().SpawnFrontLeft();
			}
				if (Input.GetKeyDown(KeyCode.X) && backSide.GetComponent<CatJumpOnBenchTrigger>().occupiesLeg != null){
				
				Destroy(backSide.GetComponent<CatJumpOnBenchTrigger>().occupiesLeg);
				catOrbit.GetComponent<CatOrbit>().catCount -= 1;
					flyingCatSpawner.GetComponent<FlyingCatSpawner>().SpawnBackRight();
			}
		}
		if (lookingBack == true){
				if (Input.GetKeyDown(KeyCode.Z) && backSide.GetComponent<CatJumpOnBenchTrigger>().occupiesArm != null){
				Destroy(backSide.GetComponent<CatJumpOnBenchTrigger>().occupiesArm);
				catOrbit.GetComponent<CatOrbit>().catCount -= 1;
					flyingCatSpawner.GetComponent<FlyingCatSpawner>().SpawnBackLeft();
			}
				if (Input.GetKeyDown(KeyCode.X) && frontSide.GetComponent<CatJumpOnBenchTrigger>().occupiesLeg != null){
				
				Destroy(frontSide.GetComponent<CatJumpOnBenchTrigger>().occupiesLeg);
				catOrbit.GetComponent<CatOrbit>().catCount -= 1;
					flyingCatSpawner.GetComponent<FlyingCatSpawner>().SpawnFrontRight();
			}
		}

		if (backSide.GetComponent<CatJumpOnBenchTrigger>().isFilled == true || frontSide.GetComponent<CatJumpOnBenchTrigger>().isFilled == true)
		{
			pushedOffIn -= 1;
		}

		if (backSide.GetComponent<CatJumpOnBenchTrigger>().isFilled == false && frontSide.GetComponent<CatJumpOnBenchTrigger>().isFilled == false)
		{
			pushedOffIn = 100;
		}
		}

		if (pushedOffIn <= 0 && backSide.GetComponent<CatJumpOnBenchTrigger>().isFilled == true && dead == false){
			dead = true;
			pushedOffFront();
		}
		if (pushedOffIn <= 0 && frontSide.GetComponent<CatJumpOnBenchTrigger>().isFilled == true && dead == false){
			dead = true;
			pushedOffBack();
		}
	}
	public void Burp(){
	if(catOrbit.GetComponent<CatOrbit>().myCats.Count > 0 && catOrbit.GetComponent<CatOrbit>().myCats[0] == null){

		catOrbit.GetComponent<CatOrbit>().myCats.Remove (catOrbit.GetComponent<CatOrbit>().myCats [0]);
		Burp ();
	}
    
	if(catOrbit.GetComponent<CatOrbit>().myCats.Count > 0 && catOrbit.GetComponent<CatOrbit>().myCats[0] != null){
			Destroy(catOrbit.GetComponent<CatOrbit>().myCats[0]);
		GameObject scaredCat;
			scaredCat = Instantiate (spookedCat, catOrbit.GetComponent<CatOrbit>().myCats[0].transform.position, catOrbit.GetComponent<CatOrbit>().myCats[0].transform.rotation);
		scaredCat.transform.Rotate(0,90,0);

		catOrbit.GetComponent<CatOrbit>().myCats.Remove (catOrbit.GetComponent<CatOrbit>().myCats [0]);
		Burp ();
	}

	}
    public void AssBlast()
    {
        hasFarted = true;
        Debug.Log("Ass has blasted");
        StartCoroutine(FartEffectTime());
    }
    public IEnumerator FartEffectTime()
    {
        yield return new WaitForSeconds(8);
        hasFarted = false;
        Debug.Log("Blast of ass has dissipated");
    }


	public void pushedOffFront(){
		transform.position = new Vector3(0,-0.2f,-2.15f);
		transform.rotation = Quaternion.Euler(-90,0,90);
	}
	public void pushedOffBack(){
		transform.position = new Vector3(0,-0.2f,2.15f);
		transform.rotation = Quaternion.Euler(90,0,90);
	}




}
