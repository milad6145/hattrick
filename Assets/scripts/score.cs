using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour
{

	public Text scoreText;
	public int ballValue=2;
	private int Score;
//-------------------------------------------------------------
	void Start ()
	{
		Score = 0;
		updateScore ();
	}
//-------------------------------------------------------------
	public void OnTriggerEnter2D ()
	{
		Score += ballValue;
		LevelControl.setScore(Score);
		updateScore ();
	}
//-------------------------------------------------------------
	public void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Bomb") {
			Score -= ballValue * 2;
			LevelControl.setScore(Score);
			updateScore ();
		}
	}
//-------------------------------------------------------------
	void updateScore ()
	{
		scoreText.text = " ﺯﺎﯿﺘﻣﺍ\n" + Score;
	}
//-------------------------------------------------------------
}
