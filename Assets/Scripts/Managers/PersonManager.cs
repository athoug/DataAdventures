﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonManager : MonoBehaviour {
	public Person me;
	public GameObject Photo;
	public Text Name;
	public Button TalkButton;

	private DescriptionManager DM;
	private GameManager GM;
	void Start()
	{
		DM = GameObject.FindWithTag("UI Manager").GetComponent<DescriptionManager>();
	}
	public void SetUp(Person p)
	{
		GM = GameObject.FindWithTag("UI Manager").GetComponent<GameManager>();
		me = p;

		Name.text = me.name;

		// set up photo
		// seach for image
		Sprite myFace = GM.SearchPeopleSprites(me.image);


		Photo.GetComponentInChildren<Image>().overrideSprite = myFace;
	}

	public void DescriptionTrigger()
	{
		Debug.Log("HERE HERE");
		DM.SetDescription(me.name, me.description);


		DM.SetLocation(me, FileReader.TheGameFile.SearchBuildings(me.buildingid), FileReader.TheGameFile.SearchCities(FileReader.TheGameFile.SearchBuildings(me.buildingid).cityid));
		DM.SetFacts(me);
		DM.FactsDiscoveredCounter.gameObject.SetActive(false);
		//DM.SetArrestButton(me);
	}
}
