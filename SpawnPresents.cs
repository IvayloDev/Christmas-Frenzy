using UnityEngine;
using System.Collections;

public class SpawnPresents : MonoBehaviour {

	Vector2 PresentPos;
	public float IncreasingSeconds;
	public float PresentsTimer;
	public Animator InfoAnim, SoundAnim, ShopAnim,ShopAnimation;
	public GameObject Click2Start;
	void Start(){

		InfoAnim.SetBool("StartAnim",true);
		SoundAnim.SetBool("StartAnim",true);
		ShopAnim.SetBool("StartAnim",true);
		Click2Start.SetActive(true);
		ButtonScript.Click2StartBool = false;

		IncreasingSeconds = 1f;

		if(!Lives.NotPressed){
		StartCoroutine(PresentSpawning());
		}
	}


	IEnumerator  PresentSpawning () {

		if(!Lives.isDead){

		float RandomX = Random.Range(-5f,5f);
		int CoalRandom = Random.Range(1,5);
		int RandomStarPickUp = Random.Range(1,9);
		int RandomPresent = Random.Range(1, 8);

		PresentPos = new Vector2(RandomX, 14f);

		switch (RandomPresent) {
		case 1:
			GameObject Present1 = Instantiate(Resources.Load("Present1"),PresentPos, Quaternion.identity) as GameObject;
			Present1.GetComponent<Rigidbody2D>().gravityScale = 1.6f;
			break;
		case 2:
			GameObject Present2 = Instantiate(Resources.Load("Present2"),PresentPos, Quaternion.identity) as GameObject;
			Present2.GetComponent<Rigidbody2D>().gravityScale = 1.4f;
			break;
		case 3:
			GameObject Present3 = Instantiate(Resources.Load("Present3"),PresentPos, Quaternion.identity) as GameObject;
			Present3.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
			break;
		case 4:
			GameObject Present4 = Instantiate(Resources.Load("Present4"),PresentPos, Quaternion.identity) as GameObject;
			Present4.GetComponent<Rigidbody2D>().gravityScale = 1.7f;
			break;
		case 5:
			GameObject Present5 = Instantiate(Resources.Load("Present5"),PresentPos, Quaternion.identity) as GameObject;
			Present5.GetComponent<Rigidbody2D>().gravityScale = 1.8f;
			break;
		case 6:
			if(CoalRandom == 1){
			GameObject Present6 = Instantiate(Resources.Load("Present6"),PresentPos, Quaternion.identity) as GameObject;
			Present6.GetComponent<Rigidbody2D>().gravityScale = 1.9f;
				}else if(CoalRandom == 2){
				GameObject Present7 = Instantiate(Resources.Load("Present7"),PresentPos, Quaternion.identity) as GameObject;
			Present7.GetComponent<Rigidbody2D>().gravityScale = 1.7f;
				}
			else{
				Present1 = Instantiate(Resources.Load("Present1"),PresentPos, Quaternion.identity) as GameObject;
				Present1.GetComponent<Rigidbody2D>().gravityScale = 2f;
			}
			break;
		case 7:
			if(RandomStarPickUp == 3){
				GameObject StarPickUp = Instantiate(Resources.Load("StarPickUp"),PresentPos, Quaternion.identity) as GameObject;
			}
			else{
				Present3 = Instantiate(Resources.Load("Present3"),PresentPos, Quaternion.identity) as GameObject;
			}
			break;
		default:
			Debug.Log("Nothing");
			break;
		}
	
		//seconds get less



		yield return new WaitForSeconds(IncreasingSeconds);

		StartCoroutine(PresentSpawning());

		}
	}

	// Update is called once per frame
	void Update () {

		if(Lives.NotPressed && ButtonScript.Click2StartBool){

			InfoAnim.SetBool("StartAnimFadeOut",true);
			SoundAnim.SetBool("StartAnimFadeOut",true);
			ShopAnim.SetBool("StartAnimFadeOut",true);
			ShopAnimation.SetBool("ShopBack",true);
			ShopAnimation.SetBool("ShopTrue",false);
			Click2Start.SetActive(false);
			ButtonScript.ShowHighScore = false;


			Lives.NotPressed = false;
			StartCoroutine(PresentSpawning());

		}

		if(ScoreScript.Score >= 5) {
			if(ScoreScript.Score <= 10){
			IncreasingSeconds = Random.Range(0.7f,1.2f);
			}
		}
		if(ScoreScript.Score >= 10){
				if(ScoreScript.Score <= 20){
			IncreasingSeconds = Random.Range(0.8f,1.1f);
			}
		}
		if(ScoreScript.Score >= 20){
			if(ScoreScript.Score <=50){
			IncreasingSeconds = Random.Range(0.3f,0.5f);
		 	}
		}
		if(ScoreScript.Score >= 50){
			if(ScoreScript.Score <= 100){
			IncreasingSeconds = Random.Range(0.2f,0.5f);
			}
		}
		if(ScoreScript.Score >= 100){
			if(ScoreScript.Score <= 200){
			IncreasingSeconds = Random.Range(0.1f,0.5f);
			}
		}
		if(ScoreScript.Score > 200){
			IncreasingSeconds = Random.Range(0.1f,0.3f);
		}
			
	}
}
