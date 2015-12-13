using UnityEngine;
using System.Collections;

public class CollisionWithGround : MonoBehaviour {

	public Animator ScoreAnimation;

	
	void OnTriggerEnter2D (Collider2D collider) {
	if(!Lives.isDead){
		if(collider.tag == "Present"){
			Lives.LivesCount--;
			}
		}
	}
}
