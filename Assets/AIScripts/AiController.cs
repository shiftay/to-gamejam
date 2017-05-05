using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour {

	public bool isSelected;
    // public bool canMove;
    
    void Start(){
        isSelected = false;
        transform.GetChild (0).gameObject.SetActive(true);
        transform.GetChild (1).gameObject.SetActive(true);
        transform.GetChild (2).gameObject.SetActive(true);
        transform.GetChild (3).gameObject.SetActive(true);
    }
    
    void Update() {
       tileVisible();
    }

    void OnMouseDown() {
        isSelected = !isSelected;
    }

    void tileVisible() {
         if(isSelected){
            transform.GetChild (0).gameObject.SetActive(true);
            transform.GetChild (1).gameObject.SetActive(true);
            transform.GetChild (2).gameObject.SetActive(true);
            transform.GetChild (3).gameObject.SetActive(true);
        } else{
            transform.GetChild (0).gameObject.SetActive(false);
            transform.GetChild (1).gameObject.SetActive(false);
            transform.GetChild (2).gameObject.SetActive(false);
            transform.GetChild (3).gameObject.SetActive(false);
        }
    }
}
