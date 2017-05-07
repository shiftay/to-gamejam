using System.Collections;
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
		public GameObject go_sel;
		public Fighter fight_sel;
		public int uniqueID;	
	}
	const int PLAYERID = 300;
	const int ENEMYID = 560;

	public List<Fighter> curr_hero = new List<Fighter>();
	public List<Fighter> curr_enemy = new List<Fighter>();
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
	public bool showingMR = false;
	public bool showingAR = false;

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
	

	public void setCurrUnit(Fighter selectUnit, GameObject fighter) {
		if(curr_Unit.fight_sel){
			curr_Unit.fight_sel.setSelected(false);
		}
		
		curr_Unit.x = selectUnit.Curr_pos().x;
		curr_Unit.y = selectUnit.Curr_pos().y;
		curr_Unit.go_sel = fighter;
		curr_Unit.fight_sel = selectUnit;
		curr_Unit.uniqueID = selectUnit.UID();
		// delete current ranges if applicable. might cause error?
		DeleteATK();
		DeleteMovement();
		if(!selectUnit.isSelected()) {
			return;
		}



		if(!selectUnit.isExhausted()){
			GatherMovement(selectUnit.UID(), selectUnit.getStats().movespeed);
		}
		
		GatherATKRange(selectUnit.UID(), selectUnit.getStats().atkrange);
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
			curr_enemy.Add(Instantiate(enemies[j], new Vector3(x, y, -2), Quaternion.identity));
			curr_enemy[j].setOwnership("enemy", ENEMYID + j, this, x, y);
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
		// Find Origin / CenterPoint
		for(int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++) {
				if(grid[i,j] == UID){
					x = i;
					y = j;
				}
			}
		}

		// Makes the diamond
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
		curr_Unit.go_sel.transform.position = new Vector3(x, y, -2);
		DeleteMovement();
		DeleteATK();
		GatherATKRange(curr_hero[selectedUnit].UID(), curr_hero[selectedUnit].getStats().atkrange); // change to range through fighter.
		return true;
	}

	public void ProcessAttack(Fighter beingAtkd) {
		if(playersTurn) {


			if(curr_Unit.fight_sel.hasAttacked()){
				return;
			}

			Debug.Log("HEALTH:" + beingAtkd.getStats().health);
			beingAtkd.TakeDamage(curr_Unit.fight_sel.getStats().damage);
			Debug.Log("HEALTH:" + beingAtkd.getStats().health);
			
			//TODO Animations
			curr_Unit.fight_sel.setAttacked(true);
			DeleteATK();
			if(!curr_Unit.fight_sel.isExhausted()){
				DeleteMovement();
				curr_Unit.fight_sel.setExhausted(true);
			}
		}
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
	public bool ValidAttack(int x, int y) {
		bool canAttack = false;

		// TODO: This enemy is within range of currently selectedUnit
		List<GridTile> children = new List<GridTile>();
		foreach(Transform child in atkRange.transform) {
			children.Add(child.GetComponent<GridTile>());
		}

		for(int i = 0; i < children.Count; i++) {
			if(children[i].x == x && children[i].y == y) {
				canAttack = true;
				break;
			}
		}



		return canAttack;
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
		// SURRENDER ENDS GAME
		// END TURN BUTTON WILL SET ALL UNITS TO EXHAUSTED
		// check if game over.
		CheckGameOver();
	}

	void CheckGameOver() {
		int enemiesDead = 0;
		int heroesDead = 0;
		for(int i = 0; i < curr_enemy.Count; i++) {
			if(!curr_enemy[i].isAlive()){
				enemiesDead++;
			}
		}
		for(int j = 0; j < curr_hero.Count; j++) {
			if(!curr_hero[j].isAlive()){
				heroesDead++;
			}
		}
		
		
		//TODO turn on GameOver elements
		//	set bool, so game over only runs once.
		//  apply anything to game manager as needed.w
		if(enemiesDead == curr_enemy.Count){
			Debug.Log("Player wins!");
		}

		if(heroesDead == curr_hero.Count){
			Debug.Log("Enemy wins!");
		}

	}
}
