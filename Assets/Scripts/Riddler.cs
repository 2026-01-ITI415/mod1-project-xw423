using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Riddler : MonoBehaviour
{
	public Text narrator;
	public Text strikes;
	public int strikesLeft = 3;
	public bool gameOver = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		narrator.text = "Welcome, to Simply Riddle Me!";
		strikes.text = "Strikes: " + strikesLeft;
		Win();
	}

	// intro
	void Intro()
	{
		narrator.text = "Are you ready to be riddled?";
		// yes
		// no
	}
	// riddles
	void Riddle1()
	{}
	void Riddle2()
	{}
	void Riddle3()
	{}
	// end game screens
	void Win()
	{
		narrator.text = "Congratulations! You've solved all riddles with " + strikesLeft + " strikes left.";
	}
	void GameOver()
	{
		narrator.text = "Looks like you need to brush up on your riddles.\nBetter luck next time!";
	}

	void But1()
	{}
	void But2()
	{}

	// Update is called once per frame
	void Update()
	{
			
	}
}
