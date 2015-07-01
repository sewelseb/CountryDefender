using UnityEngine;
using System.Collections;

public class guiScript : MonoBehaviour {

	public static bool perdu=false;
	public static bool gagne=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (perdu)
		{

			const int buttonWidth = 200;
			const int buttonHeight = 60;
			
			
			GUI.Label(
				new Rect(
				Screen.width / 2 - (buttonWidth / 2),
				( Screen.height / 3) - (buttonHeight / 2),
				buttonWidth,
				buttonHeight
				),
				"Game Over!"
				);
			

			
			if (
				GUI.Button(
				new Rect(
				Screen.width / 2 - (buttonWidth / 2),
				(2 * Screen.height / 3) - (buttonHeight / 2),
				buttonWidth,
				buttonHeight
				)
				,
				"Return to menu"
				)
				)
			{
				// Sur le clic, on démarre le premier niveau
				// "Stage1" est le nom de la première scène que nous avons créés.
				perdu=false;
				gagne=false;
				Application.LoadLevel("Menu");
			}
		}


		if (gagne)
		{
			
			const int buttonWidth = 200;
			const int buttonHeight = 60;
			
			
			GUI.Label(
				new Rect(
				Screen.width / 2 - (buttonWidth / 2),
				( Screen.height / 3) - (buttonHeight / 2),
				buttonWidth,
				buttonHeight
				),
				"You Won!"
				);
			
			
			
			if (
				GUI.Button(
				new Rect(
				Screen.width / 2 - (buttonWidth / 2),
				(2 * Screen.height / 3) - (buttonHeight / 2),
				buttonWidth,
				buttonHeight
				)
				,
				"Return to menu"
				)
				)
			{
				// Sur le clic, on démarre le premier niveau
				// "Stage1" est le nom de la première scène que nous avons créés.
				gagne=false;
				perdu=false;
				Application.LoadLevel("Menu");
			}
		}

	}

}
