using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

public class Account_Info : MonoBehaviour {
	// Holder class for information.
	private int currency;
	private string acct_name;
	private UnitRoster acct_roster;

	const string path_1 = "acctInfo";
	const string path_2 = "acctRoster";
	//TODO: roster holder, array of some sort.

	public void initInfo(int currency, string acct_name, UnitRoster curr_rost) {
		this.currency = currency;
		this.acct_name = acct_name;
		acct_roster = curr_rost;
	}

	public void LoadInfo() {
		TextAsset input = Resources.Load<TextAsset>(path_1);
		StringReader xml = new StringReader(input.text);


		XmlTextReader reader = new XmlTextReader(xml);

		while(reader.Read()) {
			if(reader.NodeType == XmlNodeType.Element) {
				switch(reader.Name) {
					case "account_name":
						acct_name = reader.ReadInnerXml();
						break;
					case "currency":
						int.TryParse(reader.ReadInnerXml(), out currency);
						break;
				}
			}
		}

		reader.Close();

		acct_roster = UnitRoster.Load(path_2);
	}

	public void LoadRoster(){

	}



	public void Write() {
		//Save information to xml
	}
}
