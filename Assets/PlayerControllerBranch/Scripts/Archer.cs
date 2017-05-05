using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {
	public int hitPoints;
	public int magicPoints;
	public int speed;
	public bool currentUnit;
	public GameObject[]otherUnits;
	
	void Awake(){
		hitPoints = 80;
		magicPoints = 50;
		speed = 1;
		currentUnit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentUnit){		
			isSelected();
		} else {
			notSelected();
		}
	}
	void OnMouseDown(){

		for(int i = 0; i < 1; i++){
			otherUnits[0].GetComponent<Knight>().currentUnit = false;
		}
		currentUnit = true;
	}

	void isSelected(){
			transform.GetChild (0).gameObject.SetActive(true);
			transform.GetChild (1).gameObject.SetActive(true);
			transform.GetChild (2).gameObject.SetActive(true);
			transform.GetChild (3).gameObject.SetActive(true);
	}
	void notSelected(){
			transform.GetChild (0).gameObject.SetActive(false);
			transform.GetChild (1).gameObject.SetActive(false);
			transform.GetChild (2).gameObject.SetActive(false);
			transform.GetChild (3).gameObject.SetActive(false);
	}
}
