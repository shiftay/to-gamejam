using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


	public struct option_hldr {
		public float sfx_volume;
		public float music_volume;
		public bool isAnimated;
	}

	private static GameManager instance;
	public static GameManager Instance() { return instance; }
	public bool DEBUGGING;
	public bool firstRun = true;
	private Current_Mission current_mission;
	private Account_Info acct_info;
	private UnitRoster roster;
	private OptionContainer options;
	public Current_Mission current() { return current_mission; }
	public option_hldr CURR_options;
	
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
			current_mission = GetComponent<Current_Mission>();
			acct_info = GetComponent<Account_Info>();



			// Can be used to save the entire roster of dudes.
			roster = UnitRoster.Load();
			options = OptionContainer.Load();
			ReadOptions();
			// foreach(Unit unit in ur.units) {
			// 	print(unit.name);
			// }

			//acct_info.initInfo();
			//TODO: Load in any XML files for options / anything.

			firstRun = false;
		}
	}
	
	void ReadOptions() {
		CURR_options.isAnimated = options.options[0].GetAnim();
		CURR_options.sfx_volume = options.options[0].GetSFX();
		CURR_options.music_volume = options.options[0].GetMUSIC();
	}

	void ReadAccount() {
		// read acct information
	}

	

	//TODO: before quitting run a write to xml;
	public void SaveInfo() {
		// saves all information to xml
		OptionContainer.Write(options);
	}


}
