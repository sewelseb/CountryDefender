using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class victoriousCountry{

	public countrys country = new countrys();


	public static Dictionary <string, string> victoryList = new Dictionary <string, string> ();


	public victoriousCountry(){
		//victoryList = new Dictionary <string, string> ();

		updateVictoryWithCountry ();

	}

	//pour créer ou updater la liste de pays (en cas de mise à jour et d'ajout de pays)
	public void updateVictoryWithCountry(){
		country = new countrys();

		foreach(string countryInst in country.countryList)
		{

			if(!victoryList.ContainsKey(countryInst))
			{
				//Debug.Log ("test");
				victoryList.Add(countryInst, "Not defended yet");


			}

		}

	}



	
}
