using UnityEngine;
using System.Collections;

public class howToPlayGui : MonoBehaviour {


	public Vector2 scrollPosition = Vector2.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		
		if (
			GUI.Button(
			new Rect(Screen.width-200, 10, 200, 40)
			,
			"Return to menu"
			)
			)
		{
			// Sur le clic, on démarre le premier niveau
			// "Stage1" est le nom de la première scène que nous avons créés.
			Application.LoadLevel("Menu");
		}
		string texte = "";
		

		
		scrollPosition=GUI.BeginScrollView(new Rect(
			Screen.width / 2 ,
			(2 * Screen.height / 3) - (Screen.height/3),
			Screen.width / 2,
			Screen.height/3
			), scrollPosition, new Rect(0, 0, 220, 200));
		GUI.Label(new Rect(0, 0, Screen.width / 2, Screen.height/3), 
		          "Earth is attacked by evil alliens. jump into your plane to defend countrys of the planet. \n" +
		          "You must go with your phone in the different countrys in order to defend them. \n" +
		          "Hit the screen to shoot and move your phone to move your plane."
		          );
		
		
		
		GUI.EndScrollView();
	}
}
