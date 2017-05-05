using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private GameManager instance;
	public GameManager Instance() { return instance; }

	public bool DEBUGGING;
	public bool firstRun = true;
	private Options options;
	private Current_Mission current_mission;
	private Account_Info acct_info;

	public Current_Mission current() { return current_mission; }

	// Use this for initialization
	void Start () {
		if (instance == null)
        	instance = this;
        else if (instance != this)
            Destroy(gameObject);
    	DontDestroyOnLoad(gameObject);

		if(DEBUGGING) {
			// TODO: clear any saved keys
			// Used for setting up tutorial at some point
		}

		if(firstRun) {
			options = GetComponent<Options>();
			current_mission = GetComponent<Current_Mission>();
			acct_info = GetComponent<Account_Info>();



			//acct_info.initInfo();
			//TODO: Load in any XML files for options / anything.

			firstRun = false;
		}
	}
	
	void ReadOptions() {
		// read options info
	}

	void ReadAccount() {
		// read acct info
	}

	//TODO: before quitting run a write to xml;
	public void SaveInfo() {
		// saves all information to xml
	}


}
