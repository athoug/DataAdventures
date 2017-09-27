﻿using System;
using UnityEngine;
public class InventoryItemManager : MonoBehaviour
{
	public string Name;
	public string Description;

	public DescriptionManager DM;

	public void Pressed()
	{
		DM.SetDescription(Name, Description);
	}

}
