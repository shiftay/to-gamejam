using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour {
	public int x;
	public int y;
	LM_shr lm;
	public string type;

	public void init(int x, int y, LM_shr lm, string type) {
		this.x = x;
		this.y = y;
		this.lm = lm;
		this.type = type;
	}

	// Update is called once per frame
	void Update () {
		// if(x > lm.width || x < 0 || y < 0 || y > lm.height){
		// 	Destroy(this.gameObject);
		// }
	}
}
