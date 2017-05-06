using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour {
    public GameObject TilePrefab;
    public Transform StartingPoint;
    public int mapSize = 10;


	// Use this for initialization
	void Start () {
		for(int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                
                Instantiate<GameObject>(TilePrefab, new Vector3(i, j, 0), Quaternion.identity);
                
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
