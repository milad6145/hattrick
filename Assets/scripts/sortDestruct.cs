﻿using UnityEngine;
using System.Collections;

public class sortDestruct : MonoBehaviour {
	public float lifeTime;
	// Use this for initialization
	void Start () {
		Destroy(gameObject,lifeTime);
	}
	

}
