using System.Xml;
using System.Xml.Serialization;

public class Unit {
	[XmlAttribute("name")]
	public string name;
	[XmlElement("Damage")]
	public int damage;
	[XmlElement("Health")]
	public int health;
	[XmlElement("Movement")]
	public int movement;
	[XmlElement("Rarity")]
	public string rarity;
}
