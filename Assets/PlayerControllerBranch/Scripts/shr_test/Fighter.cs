using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

	bool doneMovement;
	bool selected = false;
	bool showingMovement = false;
	string ownership;
	public void setOwnership(string value, int id, LM_shr lm) { ownership = value; uniqueID = id; holder = lm; }
	int uniqueID;
	public int UID() { return uniqueID; }
	LM_shr holder;

	//TODO: ADD STATS FROM UNITROSTER BASED OFF OF NAME OR W/E
	
	// Update is called once per frame
	void Update () {
		// if(holder.PlayersTurn() && selected) {
		// 	selected = false;
		// 	return;
		// }

	
		if(selected && !showingMovement) {
			//TODO: show possible movements;
			holder.GatherMovement(holder.grid, uniqueID, 3);
			showingMovement = true;
		}
	}


	void OnMouseDown()	{	
		selected = !selected;
		if(showingMovement) {
			List<GameObject> children = new List<GameObject>();
			foreach(Transform child in holder.moveRange.transform) {
				children.Add(child.gameObject);
			}
			children.ForEach(child => Destroy(child));
			showingMovement = !showingMovement;
		}


	}
	// void OnMouseUp() {	selected = false;	}
}
