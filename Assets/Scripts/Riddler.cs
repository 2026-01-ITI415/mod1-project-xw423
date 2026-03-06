using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Riddler : MonoBehaviour
{
	public static Riddler R;
	public Text narrator;
	public Text strikes;
	public Text ButText1;
	public Text ButText2;
	public GameObject Button1;
	public GameObject Button2;
	public GameObject goPlayer;
	public GameObject goDoor;
	public int strikesLeft = 3;
	public bool gameOver = false;
	static public bool collidedWDoor = false;
	Vector3 ogPos = new Vector3(0, .78f, -3.1f);

	public enum gameStage {Intro = 0, Interim1, Riddle1, Interim2, Incorrect1, Riddle2, Interim3, Incorrect2, Riddle3, GameOver, Win, Bye};
	gameStage currentStage = gameStage.Intro;
	[Header("Dynamic")]
	public bool but1 = false;
	public bool but2 = false;

	void Awake()
	{
		R = this;
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		goPlayer = GameObject.Find("Player");
		goDoor = GameObject.Find("Door");
		goDoor.SetActive(false);
		narrator.text = "Welcome, to Simply Riddle Me!";
		strikes.text = "Strikes: " + strikesLeft;
	}

	// intro

	public void But1()
	{
		but1 = true;
		// return true;
	}
	public void But2()
	{
		but2 = true;
		// return true;
	}

	void FixedUpdate()
	{
		switch( currentStage )
		{
			case gameStage.Intro:
				narrator.text = "Welcome to Simply Riddle Me! Are you ready to be riddled?";
				ButText1.text = "Yes";
				ButText2.text = "No";
				if( but1 )
				{
					currentStage = gameStage.Interim1;
					but1 = false;
				}
				else if( but2 )
				{
					currentStage = gameStage.Bye;
					but2 = false;
				}
				break;
			case gameStage.Interim1:
				Button1.SetActive(false);
				Button2.SetActive(false);
				goDoor.SetActive(true);
				narrator.text = "Well then, walk through the white door to start the game!";
				if( collidedWDoor )
				{ 
					// move player back to the original position;
					goPlayer.transform.position = ogPos;
					// move onto the next riddle
					currentStage = gameStage.Riddle1;
					collidedWDoor = false;
					goDoor.SetActive(false);
				}
				break;
			case gameStage.Riddle1:
				Button1.SetActive(true);
				Button2.SetActive(true);
				narrator.text = "What stays in a corner and goes all over?";
				ButText1.text = "A postal stamp";
				ButText2.text = "A cell phone";
				if( but1 )
				{
					currentStage = gameStage.Interim2;
					but1 = false;
				}
				else if( but2 )
				{
					strikesLeft--;
					currentStage = gameStage.Incorrect1;
					but2 = false;
				}
				break;
			case gameStage.Interim2:
				Button1.SetActive(false);
				Button2.SetActive(false);
				goDoor.SetActive(true);
				narrator.text = "Correct! Walk through the white door for the next riddle!";
				if( collidedWDoor )
				{ 
					// move player back to the original position;
					goPlayer.transform.position = ogPos;
					// move onto the next riddle
					currentStage = gameStage.Riddle2;
					collidedWDoor = false;
					goDoor.SetActive(false);
				}
				break;
			case gameStage.Incorrect1:
				narrator.text = "Incorrect!";
				ButText1.text = "Next";
				Button2.SetActive(false);
				if( but1 )
				{
					currentStage = gameStage.Riddle2;
					but1 = false;
				}
				break;
			case gameStage.Riddle2:
				Button1.SetActive(true);
				Button2.SetActive(true);
				narrator.text = "What has a head and tail, but no body?";
				ButText1.text = "A coin";
				ButText2.text = "A snake";
				if( but1 )
				{
					currentStage = gameStage.Interim3;
					but1 = false;
				}
				else if( but2 )
				{
					strikesLeft--;
					currentStage = gameStage.Incorrect2;
					but2 = false;
				}
				break;
			case gameStage.Interim3:
				Button1.SetActive(false);
				Button2.SetActive(false);
				goDoor.SetActive(true);
				narrator.text = "Correct! Walk through the white door for the next riddle!";
				if( collidedWDoor )
				{ 
					// move player back to the original position;
					goPlayer.transform.position = ogPos;
					// move onto the next riddle
					currentStage = gameStage.Riddle3;
					collidedWDoor = false;
					goDoor.SetActive(false);
				}
				break;
			case gameStage.Incorrect2:
				narrator.text = "Incorrect!";
				ButText1.text = "Next";
				Button2.SetActive(false);
				if( but1 )
				{
					currentStage = gameStage.Riddle3;
					but1 = false;
				}
				break;
			case gameStage.Riddle3:
				Button1.SetActive(true);
				Button2.SetActive(true);
				narrator.text = "What goes up but never comes down?";
				ButText1.text = "Age";
				ButText2.text = "Height";
				if( but1 )
				{
					currentStage = gameStage.Win;
					but1 = false;
				}
				else if( but2 )
				{
					strikesLeft--;
					if( strikesLeft > 0 )
						currentStage = gameStage.Win;
					else if (strikesLeft == 0 )
						currentStage = gameStage.GameOver;
					but2 = false;
				}
				break;
			case gameStage.GameOver:
				narrator.text = "Too bad! Really need to brush up on your riddles next time!";
				ButText1.text = "Restart";
				Button2.SetActive(false);
				if( but1 )
				{
					SceneManager.LoadScene("SimplyRiddleMe");
					but1 = false;
				}
				break;
			case gameStage.Win:
				narrator.text = "Congratulations! You passed with " + strikesLeft + " left!";
				ButText1.text = "Restart";
				Button2.SetActive(false);
				if( but1 )
				{
					SceneManager.LoadScene("SimplyRiddleMe");
					but1 = false;
				}
				break;
			case gameStage.Bye:
				narrator.text = "Understandable! Good Bye!";
				ButText1.text = "Restart";
				Button2.SetActive(false);
				if( but1 )
				{
					SceneManager.LoadScene("SimplyRiddleMe");
					but1 = false;
				}
				break;
		}
	}
	// Update is called once per frame
	void Update()
	{
		strikes.text = "Strikes: " + strikesLeft;
	}
}
