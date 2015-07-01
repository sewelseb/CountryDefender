using UnityEngine;
using System.Collections;

public class tir : MonoBehaviour {

		public int damage = 1;

		public bool isMissile= true;
		
		
		public bool isEnemyShot = false;
		
		void Start()
		{
		this.gameObject.name = "missile";	
			Destroy(gameObject, 1); 
		}

	
		
		void Update () {
		
		}
		void OnTriggerEnter2D(Collider2D collider)
		{
			
		}
}
