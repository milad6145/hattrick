using UnityEngine;
using System.Collections;

public static class LevelControl  {
	public static Object[] balls=new GameObject[6];
	public static Object ball=null,bomb=null;
	public static int hatSpeed=22;
	public static int score=0;
	public enum showMenu{startGame,pause,loseLevel,nextLevel,finishGame};

	public static void init()
	{
		ball=Resources.Load( "ball" );
		bomb=Resources.Load( "BombSpark" ) ;
	}
	// Use this for initialization
	public static int loadLevelGame () {
		SaveLoadPlayerData.Load();
		return SaveLoadPlayerData.playerLevel;	
	}
	public static void setRequierLevel()
	{
		init();
		switch(loadLevelGame())
		{
		case 0:
			balls[0]=ball;
			balls[1]=bomb;
			balls[2]=ball;
			balls[3]=ball;
			balls[4]=bomb;
			balls[5]=ball;
			setHatSpeed(22);
			break;
		case 1:
			balls[0]=ball;
			balls[1]=bomb;
			balls[2]=ball;
			balls[3]=ball;
			balls[4]=bomb;
			balls[5]=ball;
			setHatSpeed(22);
			break;
		case 2:
			balls[0]=ball;
			balls[1]=bomb;
			balls[2]=ball;
			balls[3]=bomb;
			balls[4]=bomb;
			balls[5]=ball;
			setHatSpeed(21);
			break;
		case 3:
			balls[0]=ball;
			balls[1]=bomb;
			balls[2]=bomb;
			balls[3]=ball;
			balls[4]=bomb;
			balls[5]=ball;
			setHatSpeed(20);
			break;
		}
	}

	public static void nextLevel()
	{

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
