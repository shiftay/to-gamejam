using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour {

	public Transform posMove;
	public GameObject player;
	

    void Start(){
		
	}

    void OnMouseDown()
    {


        // gameObject.transform.parent.position = Vector3.MoveTowards(transform.position, posMove.position, 1f * Time.deltaTime);
        // aiScript.isSelected = true;
		if(!transform.parent.gameObject.GetComponentInParent<Archer>().turnDone){
			player.transform.position = Vector3.MoveTowards(transform.position, posMove.position, 1f * Time.deltaTime);
			player.GetComponent<Archer>().turnDone = true;
		}

		transform.parent.gameObject.GetComponent<Archer>().turnDone = true;

    }
}
