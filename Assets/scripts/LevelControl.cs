using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class LevelControl
{
	public static GameObject[] balls = new GameObject[6];
	public static GameObject ball = null, bomb = null;
	public static int hatSpeed = 22;
	public static int thresholdLevel = 7;
	public static int levelGame = 0;
	public static int score = 0;
	public static int timer = 0;
	////////////////////////////////////////////////////////////////////////////
	public static Image splashScreen;
	public static SpriteRenderer skySprite;
	public static GameObject night;
	////////////////////////////////////////////////////////////////////////////
	public static Text gameOverText;
	public static Text gameCompleteText;
	public static Text masal_text;
	public static Button menu;
	public static Button restart_Button;
	public static Button start_Button;
	public static Button exit_Button;
	public static Button resume_Button;
	////////////////////////////////////////////////////////////////////////////
	public static hatController hat_controller;
	public static GameController game_controller;

	////////////////////////////////////////////////////////////////////////////
	public static void init ()
	{
		splashScreen = GameObject.Find ("splash_screen").GetComponent<Image> ();
		skySprite = GameObject.Find ("SkySprite").GetComponent<SpriteRenderer> ();
		night = GameObject.Find ("night");
		//////////////////////////////////////////////////////////////
		gameOverText = GameObject.Find ("game_over_text").GetComponent<Text> ();
		gameCompleteText = GameObject.Find ("game_complete_text").GetComponent<Text> ();
		masal_text = GameObject.Find ("masal_text").GetComponent<Text> ();
		//////////////////////////////////////////////////////////////
		menu = GameObject.Find ("menu").GetComponent<Button> ();
		start_Button = GameObject.Find ("start_Button").GetComponent<Button> ();
		exit_Button = GameObject.Find ("exit_Button").GetComponent<Button> ();
		resume_Button = GameObject.Find ("resume_Button").GetComponent<Button> ();
		restart_Button = GameObject.Find ("restart_Button").GetComponent<Button> ();
		//////////////////////////////////////////////////////////////
		hat_controller = GameObject.Find ("HatBackSprite").GetComponent<hatController> ();
		game_controller = GameObject.Find ("GameController").GetComponent<GameController> ();
	}

	public static int loadLevelGame ()
	{

		SaveLoadPlayerData.Load ();
		return SaveLoadPlayerData.playerLevel;	
	}

	public static void saveLevelGame ()
	{
		if ((levelGame + 1) < 4 && LevelControl.getScore () >= LevelControl.thresholdLevel) {
			SaveLoadPlayerData.playerLevel = levelGame + 1;
			SaveLoadPlayerData.Save ();
		}
	}

	public static void setRequierLevel (GameObject ball_, GameObject bomb_,GameObject sky_)
	{
		ball = ball_;
		bomb = bomb_;
		skySprite=sky_.GetComponent<SpriteRenderer> ();
		levelGame = loadLevelGame ();
		//set ball and bomb refrence for create instance
		// load player data class from bin file for get level 
		switch (levelGame) {
		case 0:
			// set percent ball and percent bomb for this level 
			balls [0] = ball;
			balls [1] = bomb;
			balls [2] = ball;
			balls [3] = ball;
			balls [4] = bomb;
			balls [5] = ball;
			//set speed movement for hat in this level game 
			setHatSpeed (22);
			LevelControl.skySprite.color = new Color (255, 255, 255, 255);
			LevelControl.night.SetActive (false);
			thresholdLevel = 7;
			break;
		case 1:
			// set percent ball and percent bomb for this level 
			balls [0] = ball;
			balls [1] = bomb;
			balls [2] = ball;
			balls [3] = ball;
			balls [4] = bomb;
			balls [5] = ball;
			//set speed movement for hat in this level game 
			setHatSpeed (22);
			LevelControl.skySprite.color = new Color (60, 60, 60, 255);
			LevelControl.night.SetActive (true);
			thresholdLevel = 8;
			break;
		case 2:
			// set percent ball and percent bomb for this level 
			balls [0] = ball;
			balls [1] = bomb;
			balls [2] = ball;
			balls [3] = bomb;
			balls [4] = bomb;
			balls [5] = ball;
			//set speed movement for hat in this level game 
			setHatSpeed (21);
			LevelControl.skySprite.color = new Color (255, 255, 255, 255);
			LevelControl.night.SetActive (false);
			thresholdLevel = 8;
			break;
		case 3:
			// set percent ball and percent bomb for this level 
			balls [0] = ball;
			balls [1] = bomb;
			balls [2] = bomb;
			balls [3] = ball;
			balls [4] = bomb;
			balls [5] = ball;
			//set speed movement for hat in this level game 
			setHatSpeed (20);
			LevelControl.skySprite.color = new Color (60, 60, 60, 255);
			LevelControl.night.SetActive (true);
			thresholdLevel = 9;
			break;
		}
	}

	//-------------------------------------------------------------
	///  set situation for show menu in start level game
	public static void loadLevelGameSituation ()
	{
		////////////////////////////////////////////////////////////////////////////
		LevelControl.restart_Button.interactable = false;
		LevelControl.start_Button.interactable = true;
		////////////////////////////////////////////////////////////////////////////
		LevelControl.gameCompleteText.gameObject.SetActive (false);
		LevelControl.gameOverText.gameObject.SetActive (false);
		LevelControl.masal_text.gameObject.SetActive (false);
		LevelControl.menu.gameObject.SetActive (false);
		////////////////////////////////////////////////////////////////////////////
		LevelControl.splashScreen.gameObject.SetActive (true);
		LevelControl.start_Button.gameObject.SetActive (true);
		LevelControl.exit_Button.gameObject.SetActive (true);
		LevelControl.resume_Button.gameObject.SetActive (false);
		LevelControl.restart_Button.gameObject.SetActive (true);
		////////////////////////////////////////////////////////////////////////////

	}
	//-------------------------------------------------------------
	///  set situation for show menu in pause game
	public static void pauseGameSituation ()
	{
		////////////////////////////////////////////////////////////////////////////
		LevelControl.resume_Button.interactable = true;
		LevelControl.restart_Button.interactable = true;
		LevelControl.start_Button.interactable = true;
		////////////////////////////////////////////////////////////////////////////
		LevelControl.gameOverText.gameObject.SetActive (false);
		LevelControl.gameCompleteText.gameObject.SetActive (false);
		LevelControl.masal_text.gameObject.SetActive (false);
		LevelControl.menu.gameObject.SetActive (false);
		////////////////////////////////////////////////////////////////////////////
		LevelControl.splashScreen.gameObject.SetActive (true);
		LevelControl.start_Button.gameObject.SetActive (false);
		LevelControl.exit_Button.gameObject.SetActive (true);
		LevelControl.restart_Button.gameObject.SetActive (true);
		LevelControl.resume_Button.gameObject.SetActive (true);
		////////////////////////////////////////////////////////////////////////////


	}
	//-------------------------------------------------------------
	///  set situation for show menu in lose game
	public static void loseGameSituation ()
	{
		////////////////////////////////////////////////////////////////////////////
		LevelControl.start_Button.interactable = false;
		LevelControl.restart_Button.interactable = true;
		////////////////////////////////////////////////////////////////////////////
		LevelControl.gameCompleteText.gameObject.SetActive (false);
		LevelControl.masal_text.gameObject.SetActive (false);
		LevelControl.gameOverText.gameObject.SetActive (false);
		LevelControl.menu.gameObject.SetActive (false);
		////////////////////////////////////////////////////////////////////////////
		LevelControl.splashScreen.gameObject.SetActive (true);
		LevelControl.start_Button.gameObject.SetActive (true);
		LevelControl.exit_Button.gameObject.SetActive (true);
		LevelControl.restart_Button.gameObject.SetActive (true);
		LevelControl.resume_Button.gameObject.SetActive (false);
		////////////////////////////////////////////////////////////////////////////

	}
	//-------------------------------------------------------------
	///  set situation for show menu in finish game
	public static void finishsGameSituation ()
	{
		////////////////////////////////////////////////////////////////////////////
		LevelControl.restart_Button.interactable = true;
		LevelControl.start_Button.interactable = true;
		////////////////////////////////////////////////////////////////////////////
		LevelControl.gameCompleteText.gameObject.SetActive (false);
		LevelControl.masal_text.gameObject.SetActive (false);
		LevelControl.menu.gameObject.SetActive (false);
		////////////////////////////////////////////////////////////////////////////
		LevelControl.splashScreen.gameObject.SetActive (true);
		LevelControl.start_Button.gameObject.SetActive (true);
		LevelControl.exit_Button.gameObject.SetActive (true);
		LevelControl.resume_Button.gameObject.SetActive (false);
		LevelControl.restart_Button.gameObject.SetActive (true);
		////////////////////////////////////////////////////////////////////////////
	}
	//-------------------------------------------------------------
	///  set situation for play game
	public static void playGameSituation ()
	{
		LevelControl.gameOverText.gameObject.SetActive (false);
		LevelControl.gameCompleteText.gameObject.SetActive (false);
		LevelControl.masal_text.gameObject.SetActive (false);
		LevelControl.menu.gameObject.SetActive (true);
		////////////////////////////////////////////////////////////////////////////
		LevelControl.splashScreen.gameObject.SetActive (false);
		LevelControl.start_Button.gameObject.SetActive (false);
		LevelControl.exit_Button.gameObject.SetActive (false);
		LevelControl.resume_Button.gameObject.SetActive (false);
		LevelControl.restart_Button.gameObject.SetActive (false);
	}

	///  for show message in end of game
	public static void showMessageInEndOfGame ()
	{
		LevelControl.menu.gameObject.SetActive (false);
		if (LevelControl.getScore () >= LevelControl.thresholdLevel) {
			LevelControl.gameCompleteText.gameObject.SetActive (true);
			LevelControl.masal_text.gameObject.SetActive (false);
			LevelControl.gameOverText.gameObject.SetActive (false);
		} else {
			LevelControl.gameOverText.gameObject.SetActive (true);
			LevelControl.gameCompleteText.gameObject.SetActive (false);
			LevelControl.masal_text.gameObject.SetActive (false);
		}
	}
	///  for show masal in end of game
	public static void showMasalInEndOfGame ()
	{
		LevelControl.menu.gameObject.SetActive (false);
		if (LevelControl.getScore () >= LevelControl.thresholdLevel) {
			string masalString = masal.loadMasalLevel (LevelControl.levelGame);
			LevelControl.masal_text.gameObject.SetActive (true);
			LevelControl.gameOverText.gameObject.SetActive (false);
			LevelControl.masal_text.text = masalString;
		}
	}
	//-------------------------------------------------------------
	///  for show menu in end of game
	public static void showMenuInEndOfGame ()
	{
		if (LevelControl.getScore () >= LevelControl.thresholdLevel) {
			LevelControl.finishsGameSituation ();
		} else {
			LevelControl.loseGameSituation ();
		}
	}
	//-------------------------------------------------------------
	///  set and get for public static variable 
	public static void setHatSpeed (int hatSpeed_)
	{
		LevelControl.hatSpeed = hatSpeed_;
	}

	public static int getHatSpeed ()
	{
		return LevelControl.hatSpeed;
	}

	public static void setScore (int Score_)
	{
		LevelControl.score = Score_;
	}

	public static int getScore ()
	{
		return LevelControl.score;
	}

	public static void setTimer (int timer_)
	{
		LevelControl.timer = timer_;
	}

	public static int getTimer ()
	{
		return LevelControl.timer;
	}
}
