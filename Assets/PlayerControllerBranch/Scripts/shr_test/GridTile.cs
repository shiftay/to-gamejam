using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour {
	public int x;
	public int y;
	LM_shr lm;
	public string type;
	int clicked;

	public void init(int x, int y, LM_shr lm, string type) {
		this.x = x;
		this.y = y;
		this.lm = lm;
		this.type = type;
		clicked = 0;
	}

	// Update is called once per frame
	void Update () {
		// if(x > lm.width || x < 0 || y < 0 || y > lm.height){
		// 	Destroy(this.gameObject);
		// }
	}

	void OnMouseDown()
	{
		if(type != "move"){
			return;
		}

		clicked++;

		if(clicked > 1) {
			if(lm.CheckValid(x,y)){
				Debug.Log("Valid move!");
				lm.MoveUnit(x,y);
			} else {
				//	ATTACK?
			}
		}
		//TODO: check valid move / attack
		//		update grid if is
		//		move unit
	}
}
