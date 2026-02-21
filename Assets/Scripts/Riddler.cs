using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Riddler : MonoBehaviour
{
	public Text narrator;
	public Text strikes;
	public int strikesLeft = 3;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		narrator.text = "Welcome, to Simply Riddle Me!";
		strikes.text = "Strikes: " + strikesLeft;
	}

	// Update is called once per frame
	void Update()
	{
			
	}
}
