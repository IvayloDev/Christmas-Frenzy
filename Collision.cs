using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	public Animator ScoreAnimation;
	public AudioClip[] audioClip;


	public void PlaySound(int clip){
		
		GetComponent<AudioSource>().clip = audioClip[clip];
		GetComponent<AudioSource>().Play();
	}

	//BAG Collision
	void OnTriggerEnter2D (Collider2D collider) {
	if(!Lives.isDead){
		if(collider.tag == "Present"){
			ScoreAnimation.SetTrigger("Score");
			ScoreScript.Score++;
				PlaySound(0);
			Destroy(collider.gameObject,0f);
		}
	}
	if(!Lives.isDead){
		if(collider.tag == "BadPresent"){
			Lives.LivesCount--;
			Destroy(collider.gameObject,0f);
		}
	}
	if(!Lives.isDead){
		if(collider.tag == "Star"){
			Lives.LivesCount++;
				PlaySound(1);
			Destroy(collider.gameObject,0f);
			}
		}
	}
}
