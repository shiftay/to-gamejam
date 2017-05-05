using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour 
{
	public GameObject Options;
	public GameObject Shop;
	public GameObject Roster;
	public Image Popup;
	public GameObject Back;
	public GameObject AnimText;
	public GameObject AnimToggle;
	public GameObject MusicText;
	public Slider MusicSlider;
	public GameObject SoundText;
	public Slider SoundSlider;
	public GameObject Exit;
	public GameObject ShopText;
	public Image[] Rosters;
	private GameManager gm;

	void Start () 
	{
		gm = GameManager.Instance();

		//Pass the options value to GameManager 
		gm.CURR_options.music_volume = (int)MusicSlider.value;
		gm.CURR_options.sfx_volume = (int)SoundSlider.value;
		gm.CURR_options.isAnimated = AnimToggle.gameObject.GetComponent<Toggle>().isOn;

		//Set popup background for menu to semi-transparent
		Popup.color = new Color(Popup.color.r, Popup.color.g, Popup.color.b, 0.75f);

		//Start by setting  things invisible
		Popup.enabled = false;
		Back.SetActive(false);
		AnimText.SetActive(false);
		AnimToggle.SetActive(false);
		MusicText.SetActive(false);
		MusicSlider.enabled = false;
		SoundText.SetActive(false);
		SoundSlider.enabled = false;
		Exit.SetActive(false);
		ShopText.SetActive(false);
		// Rosters[0].enabled = false;
		// Rosters[1].enabled = false;
		// Rosters[2].enabled = false;
		// Rosters[3].enabled = false;
		// Rosters[4].enabled = false;
		// Rosters[5].enabled = false;
	}

	public void onRoster()
	{
		//While this is active, hide other buttons
		Shop.SetActive(false);
		Options.SetActive(false);

		//When pressed activate roster stuff
		Popup.enabled = true;
		Back.SetActive(true);
		Rosters[0].enabled = true;
		Rosters[1].enabled = true;
		Rosters[2].enabled = true;
		Rosters[3].enabled = true;
		Rosters[4].enabled = true;
		Rosters[5].enabled = true;
	}

	public void onShop()
	{
		//While this is active, hide other buttons
		Roster.SetActive(false);
		Options.SetActive(false);

		//When pressed activate shop stuff
		Popup.enabled = true;
		Back.SetActive(true);
		ShopText.SetActive(true);
	}

	public void onOptions()
	{	
		//While this is active, hide other buttons
		Roster.SetActive(false);
		Shop.SetActive(false);

		//When pressed activate options stuff
		Popup.enabled = true;
		Back.SetActive(true);
		AnimText.SetActive(true);
		AnimToggle.SetActive(true);
		MusicText.SetActive(true);
		MusicSlider.enabled = false;
		SoundText.SetActive(true);
		SoundSlider.enabled = false;
		Exit.SetActive(true);
	}	

	public void onBack()
	{
		Back.SetActive(false);
		Popup.enabled = false;

		//ROSTER STUFF
		Rosters[0].enabled = false;
		Rosters[1].enabled = false;
		Rosters[2].enabled = false;
		Rosters[3].enabled = false;
		Rosters[4].enabled = false;
		Rosters[5].enabled = false;
		Shop.SetActive(true);
		Options.SetActive(true);

		//SHOP STUFF
		ShopText.SetActive(false);
		Roster.SetActive(true);
		Options.SetActive(true);

		//OPTIONS STUFF
		AnimText.SetActive(false);
		AnimToggle.SetActive(false);
		MusicText.SetActive(false);
		MusicSlider.enabled = false;
		SoundText.SetActive(false);
		SoundSlider.enabled = false;
		Exit.SetActive(false);
	}
}