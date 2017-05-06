using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization

	private CharStats stats;
	public GameObject Knight;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

			if(hit.collider.tag == "Friendlies"){
				Knight.GetComponent<Knight>().Picked();
				Debug.Log("Knight");
			} else if(hit.collider.tag == "Enemies"){
				Debug.Log("Enemies");
			} else if(hit.collider.tag == "Tiles"){
				Debug.Log("Tiles");
			}

		}
    }
		
}
	




