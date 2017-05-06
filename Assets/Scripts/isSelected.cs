using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isSelected : MonoBehaviour {
    public Transform tiles;
    public GameObject Tile;
    public Material whenSelected;
    public bool selected = false; 
    private Transform target;
    Vector2 getPosition;

	// Use this for initialization
	void Start () {
        getPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		
	}
	
	// Update is called once per frame
	void Update () {
        if(getPosition.x == gameObject.transform.position.x ||
            getPosition.y == gameObject.transform.position.y)
        {
            if (Input.GetMouseButtonDown(0))
            {
                getSelected(tiles);
                selected = true;
                gameObject.GetComponent<Renderer>().material = whenSelected;

            }
        }
        
		
	}
    
    public Transform getSelected(Transform self)
    {
        Transform transformRecieved = self;
        return transformRecieved;
    }

}
