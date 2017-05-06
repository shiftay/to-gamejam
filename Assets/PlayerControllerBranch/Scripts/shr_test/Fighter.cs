using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

	public struct current_position {
		public int x;
		public int y;
	}
	[System.SerializableAttribute]
	public struct stats {
		public int health;
		public int damage;
		public int movespeed;
		public int atkrange;
	}
	bool selected = false;
	bool showingMovement = false;
	bool showingAttack = false;
	string ownership;
	

	int uniqueID;
	public int UID() { return uniqueID; }
	LM_shr holder;
	current_position curr_pos;
	public current_position Curr_pos() { return curr_pos; }
	stats m_stats;
	public stats getStats() { return m_stats; }
	bool exhausted = false;
	bool attacked = false;
	bool alive = true;
	public bool isAlive() { return alive; }
	public bool isExhausted() { return exhausted; }
	public void setExhausted(bool value) { exhausted = value; }
	public bool hasAttacked() { return attacked; }
	public void setAttacked(bool value) { attacked = value; }
	public void setSelected(bool value) { selected = value; }
	//TODO: ADD STATS FROM UNITROSTER BASED OFF OF NAME OR W/E
	
	// Update is called once per frame
	void Update () {
	
		if(alive){
			if(!holder.PlayersTurn() && selected) {
				selected = false;
				return;
			}

			if(holder.PlayersTurn() && ownership == "player") {
				if(!exhausted) {
					if(selected && !showingMovement) {
						//TODO: show possible movements;
						// holder.curr_Unit.x = curr_pos.x;
						// holder.curr_Unit.y = curr_pos.y;
						// holder.curr_Unit.fighter = this.gameObject;
						holder.setCurrUnit(curr_pos.x, curr_pos.y, this.gameObject, uniqueID);
						holder.GatherMovement(uniqueID, m_stats.movespeed);
						holder.GatherATKRange(uniqueID, m_stats.atkrange);
						showingMovement = true;
						showingAttack = true;
					}
				} else if (!attacked) {
					if(selected && !showingAttack) {
						holder.setCurrUnit(curr_pos.x, curr_pos.y, this.gameObject, uniqueID);
						holder.GatherATKRange(uniqueID, m_stats.atkrange);
						showingAttack = true;
					}
				}
			}
			// DIE
			if(m_stats.health <= 0) {
				m_stats.health = 0;
				alive = false;
			}


		} else {
			//TODO IF DEAD TURN OFF, DO NOT DELETE.
			gameObject.SetActive(false);
		}
	}


	void OnMouseDown()	{	
		if(exhausted && attacked){
			return;
		}
	
		//TODO: add UI stuff.
		if(showingAttack) {
			holder.DeleteATK();
			showingAttack = !showingAttack;
		}
		if(showingMovement) {
			holder.DeleteMovement();
			showingMovement = !showingMovement;
		}

		selected = !selected;
	}
	public void setOwnership(string value, int id, LM_shr lm, int x, int y) {
		ownership = value;
		uniqueID = id;
		holder = lm; 
		curr_pos.x = x;
		curr_pos.y = y;
		if(id < 500) {
			m_stats.health = 20;
			m_stats.damage = 10;
			m_stats.atkrange = 2;
			m_stats.movespeed = 3;
		} else {
			m_stats.health = 10;
			m_stats.damage = 5;
			m_stats.atkrange = 2;
			m_stats.movespeed = 3;
		}
	}
	
	public void TakeDamage(int damage) {
		m_stats.health -= damage;
	}
	// void OnMouseUp() {	selected = false;	}
}
