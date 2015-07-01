using UnityEngine;
using System.Collections;

public class movingUfoScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	
	
	public Vector2 direction = new Vector2(0, -1);
	
	private Vector2 movement;

	private int vie=2;
	//ParticleSystem particle;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
		
	}
	void OnTriggerEnter2D(Collider2D collider)
	{


		//Debug.Log( "collide (tag) : " + collider.gameObject.tag );

		if (collider.gameObject.tag == "missile")
		{
			//Debug.Log( "collision avec missile" );
			vie--;
			if (vie <= 0) {
				Destroy (gameObject);

			}
			//particle.Play;
			Destroy(collider.gameObject);
		}

		
		
	}
	void FixedUpdate()
	{
		// 5 - Déplacement
		GetComponent<Rigidbody2D>().velocity = movement;
		
		//myRigidBody.velocity = movement;
		//rigidbody2D.velocity = movement;
	}
}
