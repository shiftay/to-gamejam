using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {
	//holder for information pertaining to the options of the game
	private bool isAnimated = true;
	private int sfx_volume;
	private int music_volume;

	public void setAnimated(bool value) { isAnimated = value; }
	public void setSFX(int value) { sfx_volume = value; }
	public void setMUSIC(int value) { music_volume = value; }
}
