using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account_Info : MonoBehaviour {
	// Holder class for information.
	private int currency;
	private string acct_name;
	//TODO: roster holder, array of some sort.

	public void initInfo(int currency, string acct_name) {
		this.currency = currency;
		this.acct_name = acct_name;
		//TODO: init the rest of the information
	}

	
}
