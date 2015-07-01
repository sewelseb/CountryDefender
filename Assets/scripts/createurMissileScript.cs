using UnityEngine;
using System.Collections;

public class createurMissileScript : MonoBehaviour {


	public Transform missile;
	public float shootingRate = 0.25f;
	private float shootCooldown;
	// Use this for initialization
	void Start () {
		shootCooldown = 0f;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	
	}
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			
			// Création d'un objet copie du prefab
			var shotTransform = Instantiate(missile) as Transform;
			
			// Position
			shotTransform.position = transform.position;
			
			// Propriétés du script
			tir shot = shotTransform.gameObject.GetComponent<tir>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			
			// On saisit la direction pour le mouvement
			moveMissileScript move = shotTransform.gameObject.GetComponent<moveMissileScript>();
			
			if (move != null)
			{
				move.direction = this.transform.up; // ici la droite sera le devant de notre objet
			}
		}
	}

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}
