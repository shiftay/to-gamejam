using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour {

	private int max_healthPoints;
	private int current_healthPoints;
	private int max_magicPoints;
	private int current_magicPoints;
	private int speed;
	private bool alreadyMoved;
	public int setMaxHealth(int value){
		max_healthPoints = value;
		return max_healthPoints;
	}

	public int getMaxHealth(){
		return max_healthPoints;
	}

	public int getCurrentHealth(){
		return current_healthPoints;
	}

	public int setMaxMagic(int value){
		max_magicPoints = value;
		return max_magicPoints;
	}

	public int getMaxMagic(){
		return max_magicPoints;
	}

	public int getCurrentMagic(){
		return current_magicPoints;
	}

	public int setSpeed(int value){
		speed = value;
		return speed;
	}

	public int getSpeed(){
		return speed;
	}

	public bool setdoneMoving(bool value){
		alreadyMoved = value;
		return alreadyMoved;
	}

	public bool doneMoving(){
		return alreadyMoved;
	}




	

}
