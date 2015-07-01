using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class listePaysSerialisable{

	public string listePays;
	public string listeDefandu;

	public listePaysSerialisable()
	{

	}

	public void addDictionaire()
	{
		foreach (var country in victoriousCountry.victoryList) {
			listePays+=country.Key.ToString()+":";
			listeDefandu+=country.Value.ToString()+":";
		}
	}
	public void createDictionaire()
	{
		Dictionary <string, string> victoryList = new Dictionary <string, string> ();


		string[] listePaysArray = new string[250];
		string[] listeDefanduArray = new string[250];
		int n = 0;

		foreach (char paysChar in listePays) {
			if (paysChar == ':')
			{
				Debug.Log(listePaysArray[n]);
				n++;
			}
			else
			{
				listePaysArray[n]+=paysChar;
			}



		}
		n = 0;
		foreach (char paysChar in listeDefandu) {
			if (paysChar == ':')
			{
				Debug.Log(listeDefanduArray[n]);
				n++;
			}
			else
			{

				listeDefanduArray[n]+=paysChar;
			}
			
			
			
		}
		int i = 0;
		foreach (string pays in listePaysArray) {
			if (pays != null)
			{

				if (!victoryList.ContainsKey(pays.ToString()))
				{

					victoryList.Add(pays.ToString(), listeDefanduArray[i].ToString());
				}
				else
				{
					victoryList[pays.ToString()]=listeDefanduArray[i].ToString();
				}
			}
			i++;
		}
		victoriousCountry.victoryList = victoryList;
	}
}
