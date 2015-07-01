using UnityEngine;
using System.Collections;


[System.Serializable]
public class countrys  {

	public string[] countryList;

	public countrys() {
		countryList = new string[5]{
		//possibilité les autres pays plus tard
		"Belgium",
		"Canada",
		"France",
		"Germany",
		"Spain"
		};
	}
}
