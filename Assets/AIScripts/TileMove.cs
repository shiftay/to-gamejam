using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMove : MonoBehaviour {

	public Transform target;
	public GameObject player;
	// public ScriptType aiScript;

	// void Start() {
	// 	 aiScript = GameObject.Find("AiController").GetComponent<ScriptType>();
	// }

	void OnMouseDown()
	{
		player.transform.position = Vector3.MoveTowards(transform.position, target.position, 1f * Time.deltaTime);

		// aiScript.isSelected = true;
	}
}
