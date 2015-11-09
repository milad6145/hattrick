using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class LevelControl  {
	public static Object[] balls=new GameObject[6];
	public static Object ball=null,bomb=null;
	public static int hatSpeed=22;
	public static int score=0;

	public static GameObject splashScreen;
	public static GameObject gameOverText;
	public static GameObject gameCompleteText;
	public static Button restartButton;
	public static Button startButton;
	public static Button exitButton;
	public static Button resumeButton;

	public static hatController hat_controller;
	public static GameController game_controller;
	public enum showMenu{startGame,pauseGame,loseLevelGame,nextLevelGame,finishGame};

	public static void init()
	{
		ball=Resources.Load( "ball" );
		bomb=Resources.Load( "BombSpark" ) ;
		gameOverText=GameObject.Find("game_over_text");
		gameCompleteText=GameObject.Find("game_complete_text");
		splashScreen=GameObject.Find("splash_screen");
		startButton=GameObject.Find("start_button").GetComponent<Button>();
		exitButton=GameObject.Find("exit_Button").GetComponent<Button>();
		resumeButton=GameObject.Find("resume_button").GetComponent<Button>();
		restartButton=GameObject.Find("restart_Button").GetComponent<Button>();

		hat_controller=GameObject.Find("HatBackSprite").GetComponent<hatController> ();
		game_controller=GameObject.Find("GameController").GetComponent<GameController>();
	}
	public static int loadLevelGame ()
	{
		SaveLoadPlayerData.Load();
		return SaveLoadPlayerData.playerLevel;	
	}
	public static void setRequierLevel()
	{
		//set ball and bomb refrence for create instance
		init();
		// load player data class from bin file for get level 
		switch(loadLevelGame())
		{
		case 0:
			// set percent ball and percent bomb for this level 
			balls[0]=ball;
			balls[1]=bomb;
			balls[2]=ball;
			balls[3]=ball;
			balls[4]=bomb;
			balls[5]=ball;
			//set speed movement for hat in this level game 
			setHatSpeed(22);
			break;
		case 1:
			// set percent ball and percent bomb for this level 
			balls[0]=ball;
			balls[1]=bomb;
			balls[2]=ball;
			balls[3]=ball;
			balls[4]=bomb;
			balls[5]=ball;
			//set speed movement for hat in this level game 
			setHatSpeed(22);
			break;
		case 2:
			// set percent ball and percent bomb for this level 
			balls[0]=ball;
			balls[1]=bomb;
			balls[2]=ball;
			balls[3]=bomb;
			balls[4]=bomb;
			balls[5]=ball;
			//set speed movement for hat in this level game 
			setHatSpeed(21);
			break;
		case 3:
			// set percent ball and percent bomb for this level 
			balls[0]=ball;
			balls[1]=bomb;
			balls[2]=bomb;
			balls[3]=ball;
			balls[4]=bomb;
			balls[5]=ball;
			//set speed movement for hat in this level game 
			setHatSpeed(20);
			break;
		}
	}

	public static void nextLevel()
	{

	}
	//-------------------------------------------------------------
	///  set situation for show menu in start level game
	public static void startLevelGameSituation()
	{
		LevelControl.splashScreen.SetActive(true);
		LevelControl.startButton.gameObject.SetActive(true);
		LevelControl.exitButton.gameObject.SetActive(true);
		LevelControl.resumeButton.gameObject.SetActive(false);
		LevelControl.restartButton.gameObject.SetActive(true);
		LevelControl.restartButton.image.color=new Color(255,255,255,100);
	}
	//-------------------------------------------------------------
	///  set situation for show menu in pause game
	public static void pauseGameSituation()
	{
		LevelControl.splashScreen.SetActive(true);
		LevelControl.startButton.gameObject.SetActive(false);
		LevelControl.exitButton.gameObject.SetActive(true);
		LevelControl.restartButton.gameObject.SetActive(true);
		LevelControl.resumeButton.gameObject.SetActive(true);
	}
	//-------------------------------------------------------------
	///  set situation for show menu in lose game
	public static void loseGameSituation()
	{
		LevelControl.splashScreen.SetActive(true);
		LevelControl.startButton.gameObject.SetActive(false);
		LevelControl.exitButton.gameObject.SetActive(true);
		LevelControl.restartButton.gameObject.SetActive(true);
		LevelControl.resumeButton.gameObject.SetActive(true);
		LevelControl.resumeButton.image.color=new Color(255,255,255,100);

	}
	//-------------------------------------------------------------
	///  set situation for show menu in finish game
	public static void finishsGameSituation()
	{
		LevelControl.splashScreen.SetActive(true);
		LevelControl.startButton.gameObject.SetActive(false);
		LevelControl.exitButton.gameObject.SetActive(false);
		LevelControl.resumeButton.gameObject.SetActive(false);
		LevelControl.restartButton.gameObject.SetActive(false);
	}
	//-------------------------------------------------------------
	///  set and get for public static variable 
	public static void setHatSpeed(int hatSpeed_)
	{
		LevelControl.hatSpeed=hatSpeed_;
	}
	public static int getHatSpeed()
	{
		return LevelControl.hatSpeed;
	}
	public static void setScore(int Score_)
	{
		LevelControl.score=Score_;
	}
	public static int getScore()
	{
		return LevelControl.score;
	}

}
