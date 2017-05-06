using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

	public struct current_position {
		public int x;
		public int y;
	}
	bool doneMovement;
	bool selected = false;
	bool showingMovement = false;
	string ownership;
	
	int uniqueID;
	public int UID() { return uniqueID; }
	LM_shr holder;
	current_position curr_pos;
	public current_position Curr_pos() { return curr_pos; }

	//TODO: ADD STATS FROM UNITROSTER BASED OFF OF NAME OR W/E
	
	// Update is called once per frame
	void Update () {
		if(!holder.PlayersTurn() && selected) {
			selected = false;
			return;
		}

		if(holder.PlayersTurn() && ownership == "player") {
			if(selected && !showingMovement) {
				//TODO: show possible movements;
				holder.curr_Unit.x = curr_pos.x;
				holder.curr_Unit.y = curr_pos.y;
				holder.curr_Unit.fighter = this.gameObject;
				holder.GatherMovement(holder.grid, uniqueID, 3);
				showingMovement = true;
			}
		}
	}


	void OnMouseDown()	{	
		selected = !selected;
		//TODO: add UI stuff.
		if(showingMovement) {
			holder.DeleteMovement();
			showingMovement = !showingMovement;
		}
	}
	public void setOwnership(string value, int id, LM_shr lm, int x, int y) {
		ownership = value;
		uniqueID = id;
		holder = lm; 
		curr_pos.x = x;
		curr_pos.y = y;
	}
	// void OnMouseUp() {	selected = false;	}
}
