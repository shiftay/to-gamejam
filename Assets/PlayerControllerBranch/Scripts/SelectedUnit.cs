using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnit : MonoBehaviour {

	public bool isSelected;
	public bool currentUnit;

	public GameObject[]Units; 
	public Vector3[]moves;
	public GameObject Possiblemoves;
	

	
	void Start(){
		isSelected = false;
		currentUnit = false;
	}

	void Update(){
		if(isSelected && currentUnit){
			
			transform.GetChild (0).gameObject.SetActive(true);
			transform.GetChild (1).gameObject.SetActive(true);
			transform.GetChild (2).gameObject.SetActive(true);
			transform.GetChild (3).gameObject.SetActive(true);
			
			// for(int i = 0; i < 5; i++) {
			// 	Instantiate(Possiblemoves, moves[0], Quaternion.identity);
			// }

		} else{
			transform.GetChild (0).gameObject.SetActive(false);
			transform.GetChild (1).gameObject.SetActive(false);
			transform.GetChild (2).gameObject.SetActive(false);
			transform.GetChild (3).gameObject.SetActive(false);
		}

		if(isSelected && currentUnit){
			if(Input.GetMouseButtonDown(0)){
				Debug.Log("go Here");
			}
		}

		

	}
	void OnMouseDown(){
		isSelected = !isSelected;
		currentUnit = true;

		for(int i = 0; i < 1; i++){
			Units[i].GetComponent<SelectedUnit>().isSelected = false;
			Units[i].GetComponent<SelectedUnit>().currentUnit = false;
		}
	}
}
