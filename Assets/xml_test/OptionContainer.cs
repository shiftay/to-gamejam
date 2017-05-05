using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRootAttribute("OptionsContainer")]
public class OptionContainer {
	[XmlArrayAttribute("Options")]
	[XmlArrayItemAttribute("Option")]
	public List<Options> options = new List<Options>();
	const string path = "options";

	public static OptionContainer Load(){
		TextAsset xml = Resources.Load<TextAsset>(path);

		XmlSerializer serializer = new XmlSerializer(typeof(OptionContainer));

		StringReader reader = new StringReader(xml.text);

		OptionContainer options = serializer.Deserialize(reader) as OptionContainer;

		reader.Close();

		return options;
	}

	public static void Write(OptionContainer holder) {
		XmlSerializer serializer = new XmlSerializer(typeof(OptionContainer));

		FileStream stream = new FileStream(path, FileMode.Create);
		
		serializer.Serialize(stream, holder);
		
		stream.Close();
	}
}
