using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // the animator
    //public Animator anim;
    public AudioSource audio;
    public AudioClip meow1;
    public AudioClip meow2;
    public AudioClip meow3;
    public AudioClip deadnoise;
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
        //
        //
        //
        //
        // get component of animator here
        //
        //
        //anim = gameObject.GetComponent<Animator>();
		pushedOffIn = 100;

		lookingFront = true;
    }

	void Update(){
		timeBar.value = pushedOffIn;
		if (dead == false){
		if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z == 0 && frontSide.GetComponent<CatJumpOnBenchTrigger>().occupiesLeg == null && frontSide.GetComponent<CatJumpOnBenchTrigger>().occupiesArm == null){
			//transform.Rotate(0,180,0);
			//transform.Translate(0,0,-1);
			transform.position = new Vector3(3.45f,1.0f,-1);
			transform.rotation = Quaternion.Euler(-180,0,0);
			lookingBack = false;
			lookingFront = true;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z == 0 && backSide.GetComponent<CatJumpOnBenchTrigger>().occupiesLeg == null && backSide.GetComponent<CatJumpOnBenchTrigger>().occupiesArm == null){
			//transform.Rotate(0,-180,0);
			//transform.Translate(0,0,1);
			transform.position = new Vector3(3.45f, 0.5f,1);
			transform.rotation = Quaternion.Euler(0,0,0);
			lookingFront = false;
			lookingBack = true;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z == 1){
			//transform.Rotate(0,180,0);
			//transform.Translate(0,0,-1);
			transform.position = new Vector3(3.45f, 1.0f, 0);
			transform.rotation = Quaternion.Euler(-180,0,0);
			lookingBack = false;
			lookingFront = true;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z == -1){
			//transform.Rotate(0,-180,0);
			//transform.Translate(0,0,1);
			transform.position = new Vector3(3.45f, 0.5f, 0);
			transform.rotation = Quaternion.Euler(0,0,0);
			lookingFront = false;
			lookingBack = true;
		}
		if (lookingFront == true){
				
				if (Input.GetKeyDown(KeyCode.Z) && frontSide.GetComponent<CatJumpOnBenchTrigger>().occupiesArm != null){
                    // call punch animation state from trigger here
                    //anim.SetTrigger("punch");
                    audio.clip = meow1;
                    audio.Play();
                    Destroy(frontSide.GetComponent<CatJumpOnBenchTrigger>().occupiesArm);
                    catOrbit.GetComponent<CatOrbit>().catCount -= 1;
					flyingCatSpawner.GetComponent<FlyingCatSpawner>().SpawnFrontLeft();
			}
				if (Input.GetKeyDown(KeyCode.X) && backSide.GetComponent<CatJumpOnBenchTrigger>().occupiesLeg != null){
                    // call kick animation state from trigger here
                    //anim.SetTrigger("kick");
                    audio.clip = meow2;
                    audio.Play();
                    Destroy(backSide.GetComponent<CatJumpOnBenchTrigger>().occupiesLeg);
                    catOrbit.GetComponent<CatOrbit>().catCount -= 1;
					flyingCatSpawner.GetComponent<FlyingCatSpawner>().SpawnBackRight();
			}
		}
		if (lookingBack == true){
				if (Input.GetKeyDown(KeyCode.Z) && backSide.GetComponent<CatJumpOnBenchTrigger>().occupiesArm != null)
                {
                    // call punch animation state from trigger here
                    //anim.SetTrigger("punch");
                    audio.clip = meow3;
                    audio.Play();
                    Destroy(backSide.GetComponent<CatJumpOnBenchTrigger>().occupiesArm);
                    catOrbit.GetComponent<CatOrbit>().catCount -= 1;
					flyingCatSpawner.GetComponent<FlyingCatSpawner>().SpawnBackLeft();
			    }
				if (Input.GetKeyDown(KeyCode.X) && frontSide.GetComponent<CatJumpOnBenchTrigger>().occupiesLeg != null){
                    // call kick animation state from trigger here
                    //anim.SetTrigger("kick");
                    audio.clip = meow1;
                    audio.Play();
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
            audio.clip = deadnoise;
            audio.Play();
		}
		if (pushedOffIn <= 0 && frontSide.GetComponent<CatJumpOnBenchTrigger>().isFilled == true && dead == false){
			dead = true;
			pushedOffBack();
            audio.clip = deadnoise;
            audio.Play();
        }
	}
	public void Burp(){
	if(catOrbit.GetComponent<CatOrbit>().myCats.Count > 0 && catOrbit.GetComponent<CatOrbit>().myCats[0] == null){

		catOrbit.GetComponent<CatOrbit>().myCats.Remove (catOrbit.GetComponent<CatOrbit>().myCats [0]);
		Burp ();
	}
    
	if(catOrbit.GetComponent<CatOrbit>().myCats.Count > 0 && catOrbit.GetComponent<CatOrbit>().myCats[0] != null){
			Destroy(catOrbit.GetComponent<CatOrbit>().myCats[0]);
            catOrbit.GetComponent<CatOrbit>().catCount -= 1;
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
		transform.position = new Vector3(0.5f,3.2f,-2.8f);
		transform.rotation = Quaternion.Euler(-180,-1.5f,-75);
	}
	public void pushedOffBack(){
		transform.position = new Vector3(0.8f,3.3f,2.6f);
		transform.rotation = Quaternion.Euler(-180,103,-85);
	}




}
