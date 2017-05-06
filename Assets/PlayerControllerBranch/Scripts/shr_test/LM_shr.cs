using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LM_shr : MonoBehaviour {
	[System.SerializableAttribute]
	public class tileTypes {
		public int type;
		public GameObject tilePrefab;
	}
	const int PLAYERID = 300;
	const int ENEMYID = 560;

	public Fighter[] heroes;

	public Fighter[] enemies;

	bool playersTurn = true;
	public bool PlayersTurn() { return playersTurn; }

	public int width = 10;
	public int height = 10;

	public tileTypes[] list;
	public GameObject moveRange;
	GameObject holder;
	public int[,]  grid;

	// Use this for initialization
	void Start () {
		// instance = this;
		holder = new GameObject();
		holder.name = "Grid";
		moveRange = new GameObject();
		moveRange.name = "MoveRange";
		// Instantiate(holder);
		GenerateGrid();
		CreateGrid();
		FillFighters();
		bool hello = true;
		//TODO: populate heroes.
		//TODO: populate enemies.
		// InputControl?
	}
	

	void FillFighters() {
		//TODO: fill from current_mission on gm; rather than through inspector

		PlaceFighters();
	}

	void PlaceFighters() {
		for(int i = 0; i < heroes.Length; i++){
			int x = Random.Range(0,5);
			int y = Random.Range(0,5);
			Instantiate(heroes[i], new Vector3(x, y, -1), Quaternion.identity).setOwnership("player", PLAYERID + i, this);
			grid[x,y] = PLAYERID + i;
		}
		for(int j = 0; j < enemies.Length; j++){
			int x = Random.Range(0,5);
			int y = Random.Range(0,5);
			Instantiate(enemies[j], new Vector3(x, y, -1), Quaternion.identity).setOwnership("enemy", ENEMYID + j, this);
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
				go.GetComponent<GridTile>().init(i, j, this);
				SetParent(holder, go);
			}
		}
	}


	public void GatherMovement(int[,] grid, int UID, int range) {
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



		// for(int r=-range; r<=range; r++) {
		// 	for(int c=-range; c<=range;c++) {
		// 		if(Mathf.Abs(r)+Mathf.Abs(c) == range) {
		// 			//instantiate.
		// 		}
		// 	}
		// }



		// for(int k = 1; k < range; k++) {
		// 	for(int l = 1; l < range; l++) {
		// 		SetParent(moveRange, Instantiate(list[1].tilePrefab, new Vector2(x+l,y+k), Quaternion.identity));
		// 		SetParent(moveRange, Instantiate(list[1].tilePrefab, new Vector2(x-l,y-k), Quaternion.identity));
		// 		SetParent(moveRange, Instantiate(list[1].tilePrefab, new Vector2(x-l,y+k), Quaternion.identity));
		// 		SetParent(moveRange, Instantiate(list[1].tilePrefab, new Vector2(x+l,y-k), Quaternion.identity));
		// 	}
		// }


		// straight lines on x
		for(int m = 1; m < range+1; m++) {
			CreateMoveBlock(x+m,y);
			CreateMoveBlock(x-m,y);
			CreateMoveBlock(x,y+m);
			CreateMoveBlock(x,y-m);
			// SetParent(moveRange, Instantiate(list[1].tilePrefab, new Vector2(x+m,y), Quaternion.identity));
			// SetParent(moveRange, Instantiate(list[1].tilePrefab, new Vector2(x-m,y), Quaternion.identity));
			// SetParent(moveRange, Instantiate(list[1].tilePrefab, new Vector2(x,y+m), Quaternion.identity));
			// SetParent(moveRange, Instantiate(list[1].tilePrefab, new Vector2(x,y-m), Quaternion.identity));
		}

		for (int n = 1; n <= range; n++) {	
			for(int z = -range+n; z < range-n; z++) {
				CreateMoveBlock(x+n,y+z);
				CreateMoveBlock(x-n,y-z);
				CreateMoveBlock(x-z,y+n);
				CreateMoveBlock(x+z,y-n);
				// SetParent(moveRange, Instantiate(list[1].tilePrefab, new Vector2(x+n,y+z), Quaternion.identity));
				// SetParent(moveRange, Instantiate(list[1].tilePrefab, new Vector2(x-n,y-z), Quaternion.identity));
				// SetParent(moveRange, Instantiate(list[1].tilePrefab, new Vector2(x-z,y+n), Quaternion.identity));
				// SetParent(moveRange, Instantiate(list[1].tilePrefab, new Vector2(x+z,y-n), Quaternion.identity));
			}
		}
		




	}

	void CreateMoveBlock(int x, int y) {
		if(x > width || x < 0 || y < 0 || y > height){
			return;
		}

		GameObject go = Instantiate(list[1].tilePrefab, new Vector2(x, y), Quaternion.identity);
		go.GetComponent<GridTile>().init(x, y, this);
		SetParent(moveRange, go);
	}


	// Update is called once per frame
	void Update () {
		// check if game over.
	}
}
