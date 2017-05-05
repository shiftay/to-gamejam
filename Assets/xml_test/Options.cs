using System.Xml;
using System.Xml.Serialization;

public class Options {
	[XmlElementAttribute("Animations")]
	private bool isAnimated;
	[XmlElementAttribute("SFXVol")]
	private int sfx_volume;
	[XmlElementAttribute("MUSICVol")]
	private int music_volume;

	public bool GetAnim() { return isAnimated; }
	public int GetSFX() { return sfx_volume; }
	public int GetMUSIC() { return music_volume; }

	// Options(bool isAnimated, int sfx, int music) {
	// 	this.isAnimated = isAnimated;
	// 	sfx_volume = sfx;
	// 	music_volume = music;
	// }

}
