using UnityEngine;
using System.Collections;

public class BagController : MonoBehaviour {

	public Camera cam;
	public GameObject Bag;
	public RaycastHit rhInfo;

	void Update(){

		if(!ButtonScript.Paused){

		if(Input.GetMouseButton(0)){
			RaycastHit hit;
			var ray = cam.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit)){

			if(hit.transform.name == "Bag"){

					Vector3 point = cam.ScreenToWorldPoint(Input.mousePosition);
					point.z = Bag.transform.position.z;
					point.y = Bag.transform.position.y;

					if(point.x >= 4.9f){
						point.x = 4.9f;
					}else if(point.x <= -4.9f){
						point.x = -4.9f;
					}
					
					
					Bag.transform.position = point;

						}
					}
				}
 			}
		}
	}
