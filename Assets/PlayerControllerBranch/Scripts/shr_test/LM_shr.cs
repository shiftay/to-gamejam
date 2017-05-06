﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LM_shr : MonoBehaviour {
	[System.SerializableAttribute]
	public class tileTypes {
		public int type;
		public GameObject tilePrefab;
	}

	public struct currentSelectedUnit {
		public int x;
		public int y;
		public GameObject fighter;
		public int uniqueID;	
	}
	const int PLAYERID = 300;
	const int ENEMYID = 560;

	public List<Fighter> curr_hero = new List<Fighter>();
	public Fighter[] heroes;

	public Fighter[] enemies;
	bool playersTurn = true;
	public bool PlayersTurn() { return playersTurn; }

	public int width = 10;
	public int height = 10;

	public tileTypes[] list;
	public GameObject moveRange;
	GameObject holder;
	public GameObject atkRange;
	public int[,]  grid;
	public currentSelectedUnit curr_Unit; // can be made private.

	// Use this for initialization
	void Start () {
		// instance = this;
		holder = new GameObject();
		holder.name = "Grid";
		moveRange = new GameObject();
		moveRange.name = "MoveRange";
		atkRange = new GameObject();
		atkRange.name = "atkRange";
		// Instantiate(holder);
		GenerateGrid();
		CreateGrid();
		FillFighters();
		//TODO: populate heroes.
		//TODO: populate enemies.
		// InputControl?
	}
	

	public void setCurrUnit(int x, int y, GameObject fighter, int UID) {
		curr_Unit.x = x;
		curr_Unit.y = y;
		curr_Unit.fighter = fighter;
		curr_Unit.uniqueID = UID;
	}
	void FillFighters() {
		//TODO: fill from current_mission on gm; rather than through inspector

		PlaceFighters();
	}

	void PlaceFighters() {
		for(int i = 0; i < heroes.Length; i++){
			int x = Random.Range(0,5);
			int y = Random.Range(0,5);
			curr_hero.Add(Instantiate(heroes[i], new Vector3(x, y, -2), Quaternion.identity));
			curr_hero[i].setOwnership("player", PLAYERID + i, this, x, y);
			grid[x,y] = PLAYERID + i;
		}
		for(int j = 0; j < enemies.Length; j++){
			int x = Random.Range(0,5);
			int y = Random.Range(0,5);
			// change to hero setup.
			Instantiate(enemies[j], new Vector3(x, y, -2), Quaternion.identity).setOwnership("enemy", ENEMYID + j, this, x, y);
			grid[x,y] = ENEMYID + j;
		}
	}

	void SetParent(GameObject parent, GameObject child) {
		child.transform.parent = parent.transform;
	}

	void GenerateGrid() {
		grid = new int[width, height];

		for(int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++) {
				grid[i,j] = 0;
			}
		}
	} 

	void CreateGrid() {
		for(int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++) {
				GameObject go = Instantiate(list[grid[i,j]].tilePrefab, new Vector2(i, j), Quaternion.identity);
				go.GetComponent<GridTile>().init(i, j, this, "grid");
				SetParent(holder, go);
			}
		}
	}


	public void GatherMovement(int UID, int range) {
		int x = width;
		int y = height;

		for(int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++) {
				if(grid[i,j] == UID){
					x = i;
					y = j;
				}
			}
		}

		for(int m = 1; m < range+1; m++) {
			CreateBlock(x+m,y,1,"move");
			CreateBlock(x-m,y,1,"move");
			CreateBlock(x,y+m,1,"move");
			CreateBlock(x,y-m,1,"move");
		}

		for (int n = 1; n <= range; n++) {	
			for(int z = -range+n; z < range-n; z++) {
				CreateBlock(x+n,y+z,1,"move");
				CreateBlock(x-n,y-z,1,"move");
				CreateBlock(x-z,y+n,1,"move");
				CreateBlock(x+z,y-n,1,"move");
			}
		}
	
	}


	public void GatherATKRange(int UID, int range) {
		int x = width;
		int y = height;

		for(int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++) {
				if(grid[i,j] == UID){
					x = i;
					y = j;
				}
			}
		}

		for(int m = 1; m < range+1; m++) {
			CreateBlock(x+m,y,2,"atk");
			CreateBlock(x-m,y,2,"atk");
			CreateBlock(x,y+m,2,"atk");
			CreateBlock(x,y-m,2,"atk");
		}

		for (int n = 1; n <= range; n++) {	
			for(int z = -range+n; z < range-n; z++) {
				CreateBlock(x+n,y+z,2,"atk");
				CreateBlock(x-n,y-z,2,"atk");
				CreateBlock(x-z,y+n,2,"atk");
				CreateBlock(x+z,y-n,2,"atk");
			}
		}
	}



	// already checked if valid movement
	public bool MoveUnit(int x, int y) {
		int selectedUnit = 0;
		for(int i = 0; i < curr_hero.Count; i++) {
			if(curr_hero[i].UID() == curr_Unit.uniqueID){
				selectedUnit = i;
				break;
			}
		}
		if(curr_hero[selectedUnit].isExhausted()) {
			return false;
		}


		// int test = curr_Unit.fighter.GetComponent<Fighter>().Curr_pos().x;
		// int test_2 = curr_hero[selectedUnit].Curr_pos().x;
		grid[curr_hero[selectedUnit].Curr_pos().x, curr_hero[selectedUnit].Curr_pos().y] = 0;
		grid[x,y] = curr_hero[selectedUnit].UID();
		curr_hero[selectedUnit].setExhausted(true);
		// curr_hero[selectedUnit].setSelected(false);
		curr_Unit.fighter.transform.position = new Vector3(x, y, -1);
		DeleteMovement();
		DeleteATK();
		GatherATKRange(curr_hero[selectedUnit].UID(), curr_hero[selectedUnit].getStats().atkrange); // change to range through fighter.
		return true;
	}


	public bool CheckValid(int x, int y) {
		if(grid[x,y] > 0){
			return false;
		} else {
			return true;
		}
	}

	void CreateBlock(int x, int y, int type, string tileType) {
		if(x > width || x < 0 || y < 0 || y > height){
			return;
		}
		
		int tile = 0;
		if(tileType == "atk"){
			tile = -1;
		}


		GameObject go = Instantiate(list[type].tilePrefab, new Vector3(x, y, tile), Quaternion.identity);
		go.GetComponent<GridTile>().init(x, y, this, tileType);
		if(tileType == "move") {
			SetParent(moveRange, go);
		} else {
			SetParent(atkRange, go);
		}
	}

	public void DeleteMovement() {
		List<GameObject> children = new List<GameObject>();
		foreach(Transform child in moveRange.transform) {
			children.Add(child.gameObject);
		}
		children.ForEach(child => Destroy(child));
	}

	public void DeleteATK() {
		List<GameObject> children = new List<GameObject>();
		foreach(Transform child in atkRange.transform) {
			children.Add(child.gameObject);
		}
		children.ForEach(child => Destroy(child));
	}

	// Update is called once per frame
	void Update () {

		if(playersTurn) {
			int amountExhausted = 0;
			for(int i = 0; i < curr_hero.Count; i++) {
				if(curr_hero[i].isExhausted() && curr_hero[i].hasAttacked()) {
					amountExhausted++;
				}
			}

			if(amountExhausted == curr_hero.Count) {
				Debug.Log("playersTurn is over");
				playersTurn = false;
			}
		}
		// END TURN BUTTON WILL SET ALL UNITS TO EXHAUSTED
		// check if game over.
	}
}
