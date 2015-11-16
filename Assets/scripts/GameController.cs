using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

	public Camera cameraInstance;
	 GameObject[] balls;
	public GameObject ballInit,bombInit;
	public float timeLeft;
	public Text timerText;
	public GameObject gameOverText;
	public GameObject gameCompleteText;
	public GameObject restartButton;
	public GameObject spalshScreen;
	public GameObject startButton;
	public GameObject exitButton;
	////////////////////////////////////////////////////////////////////////////////
	public hatController hat_controller_Class;
	public score score_Class;
//-------------------------------------------------------------
	private Rigidbody2D body2d;
	private float maxWidth;
	private bool playing;
//-------------------------------------------------------------
	void Awake ()
	{
		hat_controller_Class=GameObject.Find("HatBackSprite").GetComponent<hatController> ();
		score_Class=GameObject.Find("HatBackSprite").GetComponent<score> ();
	}
//-------------------------------------------------------------
	// Use this for initialization
	void Start ()
	{
		LevelControl.init();
		LevelControl.loadLevelGameSituation();
		playing = false;
		balls=new GameObject[6];
		//ballInit = GameObject.Instantiate( UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/prefab/ball.prefab", typeof(GameObject)) )as GameObject;
		//bombInit = GameObject.Instantiate( UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/prefab/BombSpark.prefab", typeof(GameObject)) )as GameObject;
		///////////////////////////////////////////////////////////////////////////////////////
		// LevelControl class
		LevelControl.setRequierLevel (ballInit,bombInit);
		for (int i=0; i<6; i++)
		{
			balls [i] = LevelControl.balls [i];
		}
		///////////////////////////////////////////////////////////////////////////////////////
		if (cameraInstance == null)
			cameraInstance = Camera.main;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cameraInstance.ScreenToWorldPoint (upperCorner);
		float ballWidth = balls [0].GetComponent<Renderer> ().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;

	}
//-------------------------------------------------------------	
	void FixedUpdate ()
	{
		if (playing)
		{
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
			updateText ();
		}
	}
//-------------------------------------------------------------	
	public void playGame ()
	{
		//for set unvisible buttons
		LevelControl.playGameSituation();
		playing=true;
		hat_controller_Class.toggleControl (true);
		StartCoroutine (Spawn ());

	}
	//-------------------------------------------------------------	
	public void pauseGame ()
	{
		LevelControl.pauseGameSituation();
		StopCoroutine(Spawn ());
		playing=false;
		hat_controller_Class.toggleControl (false);
		LevelControl.setTimer(Mathf.RoundToInt(timeLeft));
		LevelControl.setScore(score_Class.Score);

	}
	//-------------------------------------------------------------	
	public void resumeGame ()
	{
		//for set unvisible buttons
		LevelControl.playGameSituation();
		score_Class.Score=LevelControl.score;
		score_Class.updateScore();

		this.timeLeft=LevelControl.timer;
		this.updateText();

		playing=true;
		hat_controller_Class.toggleControl (true);
		StartCoroutine (Spawn ());

	}
	//-------------------------------------------------------------	
	public void restartGame ()
	{
		//for set unvisible buttons
		LevelControl.playGameSituation();
		StopCoroutine(Spawn ());
		playing=false;
		hat_controller_Class.toggleControl (false);
		Application.LoadLevel(Application.loadedLevel);

	}
	//-------------------------------------------------------------	
	public void exitGame ()
	{
		//for set unvisible buttons
		LevelControl.playGameSituation();
		StopCoroutine(Spawn ());
		playing=false;
		hat_controller_Class.toggleControl (false);
		Application.Quit();
		
	}
//-------------------------------------------------------------	
	IEnumerator Spawn ()
	{
		yield return new WaitForSeconds (1.0f);
		playing = true;
		while (timeLeft>0) {
			GameObject ball = balls [Random.Range (0, balls.Length)];
			Vector3 spawnPosition = new Vector3 (
				Random.Range (-maxWidth, maxWidth), transform.position.y, 0.0f);
			Quaternion spawnRotaion = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotaion);
			yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
		}
		yield return new WaitForSeconds (2.0f);
		gameOverText.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		restartButton.SetActive (true);
	}
//-------------------------------------------------------------
	public void updateText ()
	{
		timerText.text = "ﻩﺪﻧﺎﻣ ﯽﻗﺎﺑ ﻥﺎﻣﺯ  \n" + Mathf.RoundToInt (timeLeft);
	}
}
