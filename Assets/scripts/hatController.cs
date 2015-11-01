using UnityEngine;	
using System.Collections;

public class hatController : MonoBehaviour
{
	public Camera camera;
	public Renderer rend;
	//public Vector3 touchPosition=Vector3.zero;
	public Vector3 rawPosition = Vector3.zero;
	private Rigidbody2D body2d;
	private float maxWidth;
	private bool canControl;
	//public Vector3 rawPosition;
	void Awake ()
	{
		body2d = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start ()
	{
		canControl = false;
		if (camera == null)
			camera = Camera.main;
		rend = GetComponent<Renderer> ();
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = camera.ScreenToWorldPoint (upperCorner);
		float hatWidth = rend.bounds.extents.x;
		maxWidth = targetWidth.x - hatWidth;
	}

	void Update ()
	{


	

	}
	// Update is called once per frame
	void FixedUpdate ()
	{

		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			if (touch.phase == TouchPhase.Moved || 
			    touch.phase == TouchPhase.Stationary) 
			{
				rawPosition.x = touch.position.x;
				rawPosition.y = touch.position.y;
				rawPosition.z = 0.0f;
				
				if (canControl) {
					rawPosition=camera.ScreenToWorldPoint(rawPosition);
					Vector3 targetPosition = new Vector3 (rawPosition.x, transform.position.y, 0.0f);
					float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
					targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
					//body2d.MovePosition (targetPosition);
					transform.position = Vector3.MoveTowards(transform.position
					        	, targetPosition, Time.deltaTime * 18);
				}
			}
			else if(touch.phase == TouchPhase.Ended)
			{

			}
		}
	}

	public void toggleControl (bool toggle)
	{
		canControl = toggle;
	}
}
