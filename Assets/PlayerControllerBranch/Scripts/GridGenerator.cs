using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

	private int rows = 8;
	private int columns = 25;
	private Vector3 Gameboard;
	public GameObject tiles;
	public GameObject knight;

	// Use this for initialization
	void Start () {

		Gameboard = new Vector3(-12.19f,-3.56f,0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)){
			GenerateGrid();
		}
		if(Input.GetKeyDown(KeyCode.B)){
			SpawnUnits();
		}
	}

	void GenerateGrid(){
		for(float i = 0; i < rows; i += 1.28f ){
			for(float j = 0; j < columns; j += 1.28f){
				GameObject tileHolders = Instantiate(tiles,Gameboard + new Vector3(j,i,0),Quaternion.identity);
				tileHolders.transform.parent = GameObject.Find("Board Holder").transform;
			}
		}
	}
	void SpawnUnits(){
		Instantiate(knight,GameObject.Find("Board Holder").transform.GetChild(0).gameObject.transform.position,Quaternion.identity);
	}
}
