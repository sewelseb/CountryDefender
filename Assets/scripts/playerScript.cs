using UnityEngine;
using System.Collections;


/// <summary>
/// Contrôleur du joueur
/// </summary>
public class playerScript : MonoBehaviour {

	/// <summary>
	/// 1 - La vitesse de déplacement
	/// </summary>
	public Vector2 speed = new Vector2(1, 1);

	public int vie = 10;

	// 2 - Stockage du mouvement
	private Vector2 movement;

	public Rigidbody2D rb;



	public bool victoireEnregistree = false;



	// Use this for initialization
	void Start () {
		//myRigidBody = GetComponent<Rigidbody2D>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		// 3 - Récupérer les informations du clavier/manette
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");


		
		// 4 - Calcul du mouvement
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		if (shoot)
		{
			createurMissileScript weapon = GetComponent<createurMissileScript>();
			if (weapon != null)
			{
				// false : le joueur n'est pas un ennemi
				weapon.Attack(false);
			}
		}
		// on gere les accélérometres
		if (SystemInfo.supportsAccelerometer)
		{
			movement = new Vector2(0,0);
			transform.Translate(Input.acceleration.x, Input.acceleration.y, 0);
		}


		var enemies = GameObject.FindWithTag ("ufo");
		Debug.Log (victoriousCountry.victoryList[variablesGlobales.paysActuel].ToString());
		if (enemies == null) {
			if (!victoireEnregistree)
			{
				victoireEnregistree=false;

				victoriousCountry.victoryList[variablesGlobales.paysActuel]="defended";
				savingData.votoriousCountryInst=variablesGlobales.votoriousCountryInst;
				savingData.Save();

			}

			guiScript.gagne=true;

		}
		else
		{
			//Debug.Log("partie en cours");
		}
		var dist = (transform.position - Camera.main.transform.position).z;
		var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;
		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1,dist)).y;
		
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp (transform.position.y, topBorder, bottomBorder),
			transform.position.z);


	}
	void FixedUpdate()
	{
		// 5 - Déplacement
		GetComponent<Rigidbody2D>().velocity = movement;

		//myRigidBody.velocity = movement;
		//rigidbody2D.velocity = movement;
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		

		//Debug.Log( "collide (tag) : " + collider.gameObject.tag );
		
		if (collider.gameObject.tag == "ufo")
		{
			//Debug.Log( "collision avec ufo" );
			vie--;
			if (vie <= 0) {
				Destroy (gameObject);


				
			}

		}
		
		
		
	}

	void OnDestroy(){


		guiScript.perdu = true;
		
	}

}
