using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour {

	private CharStats stats;
	private bool isPicked;
	

	void Start(){
		stats = GetComponent<CharStats>();
		stats.setMaxHealth(100);
		stats.setMaxMagic(30);
		stats.setSpeed(1);
		stats.setdoneMoving(false);
		isPicked = false;
		
		
	}
	
	void Update () {
		if(isPicked){		
			isSelected();
		} else {
			notSelected();
		}
	}
	void OnMouseDown(){
		// for(int i = 0; i < 1; i++){
		// 	otherUnits[0].GetComponent<Archer>().currentUnit = false;
		// }
		// currentUnit = true;
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

	public bool Picked(bool change){
		isPicked = change;
		return isPicked;
	}
}
