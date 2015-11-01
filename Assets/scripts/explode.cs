using UnityEngine;
using System.Collections;

public class explode : MonoBehaviour
{

	public GameObject explodeObjec;
	public ParticleSystem[] effects;

	void OnCollisionEnter2D (Collision2D collision)
	{
		if(collision.gameObject.tag=="HAT")
		{
			Instantiate(explodeObjec,transform.position,transform.rotation);
			foreach (var effect in effects) {
				effect.transform.parent=null;
				effect.Stop();
				Destroy(effect.gameObject,1.0f);
			}
			Destroy(gameObject);
		}
	}
}
