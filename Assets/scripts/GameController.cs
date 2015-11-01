using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Camera camera;
	public GameObject[] balls;
	public float timeLeft;
	public Text timerText;
	public GameObject gameOverText;
	public GameObject restartButton;
	public GameObject spalshScreen;
	public GameObject startButton;
	public hatController hat_controller;
//-------------------------------------------------------------

	private Rigidbody2D body2d;
	private float maxWidth;
	private bool playing;
//-------------------------------------------------------------
	// Use this for initialization
	void Start () {
		playing=false;
		if(camera==null)
			camera=Camera.main;
		Vector3 upperCorner=new Vector3(Screen.width,Screen.height,0.0f);
		Vector3 targetWidth=camera.ScreenToWorldPoint(upperCorner);
		float ballWidth = balls[0].GetComponent<Renderer>().bounds.extents.x;
		
		maxWidth=targetWidth.x-ballWidth;
	}
//-------------------------------------------------------------	
	void FixedUpdate()
	{
		if(playing)
		{
			timeLeft -= Time.deltaTime;
			if(timeLeft<0)
			{
				timeLeft=0;
			}
			updateText();
		}
	}
//-------------------------------------------------------------	
public void startGame()
	{
		spalshScreen.SetActive(false);
		startButton.SetActive(false);
		hat_controller.toggleControl(true);
		StartCoroutine (Spawn());

	}
//-------------------------------------------------------------	
	IEnumerator Spawn()
	{
		yield return new WaitForSeconds (1.0f);
		playing=true;
		while (timeLeft>0) 
		{
			GameObject ball=balls[Random.Range(0,balls.Length)];
			Vector3 spawnPosition = new Vector3 (
				Random.Range (-maxWidth, maxWidth),transform.position.y,0.0f);
			Quaternion spawnRotaion = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotaion);
			yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
		}
		yield return new WaitForSeconds (2.0f);
		gameOverText.SetActive(true);
		yield return new WaitForSeconds (2.0f);
		restartButton.SetActive(true);
	}
//-------------------------------------------------------------
	public void updateText()
	{
		timerText.text="ﻩﺪﻧﺎﻣ ﯽﻗﺎﺑ ﻥﺎﻣﺯ  \n"+Mathf.RoundToInt(timeLeft);
	}
}
