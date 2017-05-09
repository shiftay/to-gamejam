using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {
	[System.SerializableAttribute]
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
	public bool isSelected() { return selected; }
	//TODO: ADD STATS FROM UNITROSTER BASED OFF OF NAME OR W/E
	int amtClicked = 0;
	public void setAmtClicked(int value) { amtClicked = value; }

	void Start()
	{
		transform.rotation = Quaternion.Euler(0,90,90);
		if(ownership == "enemy"){
			this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
		}
	}

	// Update is called once per frame
	void Update () {
		if(alive){
			if(m_stats.health <= 0) {
				m_stats.health = 0;
				alive = false;
			}
		} else {
			//need bool so doesnt run over and over again bogging shit down.
			gameObject.SetActive(false);
		}
	}

	void OnMouseDown()	{	
		if(exhausted && attacked){
			return;
		}

		if(holder.curr_Unit.go_sel && ownership == "enemy") {
			amtClicked++;
		}
		
		if(ownership != "player"){
			if(amtClicked >= 2) {
				if(holder.ValidAttack(curr_pos.x, curr_pos.y)) {
					holder.ProcessAttack(this);
				}
			}
			return;
		}

		selected = !selected;

		holder.setCurrUnit(this, this.gameObject);
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
}
