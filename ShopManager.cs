using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {
		
	public GameObject Bag1,Bag2,Bag3,Locked2,Locked3,BagObj;
	public Animator ShopAnim;
	public Sprite Bag1Sprite,Bag2Sprite,Bag3Sprite;
	public BoxCollider2D BagBoxColl;

	int BagInt;
	float CollXValue;


	// Use this for initialization
	void Start () {
	
		BagInt = PlayerPrefs.GetInt("BagInt",1);
		Locked2.SetActive(true);
		Locked3.SetActive(true);
		
	}

	public void onBag1Click(){
		ShopAnim.SetBool("ShopBack",true);
		ShopAnim.SetBool("ShopTrue",false);
		ButtonScript.ShowHighScore = false;
		BagInt = 1;
	}
	
	public void onBag2Click(){
		ShopAnim.SetBool("ShopTrue",false);
		ShopAnim.SetBool("ShopBack",true);
		ButtonScript.ShowHighScore = false;
		BagInt = 2;
	}
	public void onBag3Click(){
		ShopAnim.SetBool("ShopTrue",false);
		ShopAnim.SetBool("ShopBack",true);
		ButtonScript.ShowHighScore = false;
		BagInt = 3;
	}


	// Update is called once per frame
	void Update () {

		BagBoxColl.size = new Vector2(CollXValue,1f);

		switch(BagInt){
		case 1:
			BagObj.GetComponent<SpriteRenderer>().sprite = Bag1Sprite;
			CollXValue = 2f;
			break;
		case 2: 
			BagObj.GetComponent<SpriteRenderer>().sprite = Bag2Sprite;
			CollXValue = 2.7f;
			break;

		case 3:
			BagObj.GetComponent<SpriteRenderer>().sprite = Bag3Sprite;
			CollXValue = 3.5f;
			break;
		
		}
	
		if(HighScoreScript.HighScore >= 100){
			Locked2.SetActive(false);
		}
		if(HighScoreScript.HighScore >= 300){
			Locked3.SetActive(false);
		}
	}

	void OnDestroy(){
		PlayerPrefs.SetInt("BagInt",BagInt);
	}

}
