using UnityEngine;
using System.Collections;

public class bariereArriereScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		float anciennePositionX = collider.gameObject.transform.position.x;
		float anciennePositionY = collider.gameObject.transform.position.y;
		float anciennePositionZ = collider.gameObject.transform.position.z;
		collider.gameObject.transform.position = new Vector3 (anciennePositionX, anciennePositionY + 50, anciennePositionZ);

	}
}
