using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRootAttribute("UnitRoster")]
public class UnitRoster {
	[XmlArrayAttribute("Units")]
	[XmlArrayItemAttribute("Unit")]
	public List<Unit> units = new List<Unit>();

	const string path = "roster";

	public static UnitRoster Load(){
		TextAsset xml = Resources.Load<TextAsset>(path);

		XmlSerializer serializer = new XmlSerializer(typeof(UnitRoster));

		StringReader reader = new StringReader(xml.text);

		UnitRoster units = serializer.Deserialize(reader) as UnitRoster;

		reader.Close();

		return units;
	}

	public static UnitRoster Load(string path){
		TextAsset xml = Resources.Load<TextAsset>(path);

		XmlSerializer serializer = new XmlSerializer(typeof(UnitRoster));

		StringReader reader = new StringReader(xml.text);

		UnitRoster units = serializer.Deserialize(reader) as UnitRoster;

		reader.Close();

		return units;
	}
}
