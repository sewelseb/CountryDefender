using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public static class savingData{

	public static victoriousCountry votoriousCountryInst;



	public static void Save() {

		listePaysSerialisable liste = new listePaysSerialisable();
		liste.addDictionaire();

		BinaryFormatter bf = new BinaryFormatter();
		Debug.Log ("chemin d'enregistrement: " + Application.persistentDataPath);
		FileStream file = File.Create (Application.persistentDataPath + "/victoriousCountry.gd");
		bf.Serialize(file,liste);
		file.Close();
	}

	public static void Load() {
		if (File.Exists (Application.persistentDataPath + "/victoriousCountry.gd")) {
			listePaysSerialisable liste = new listePaysSerialisable();
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/victoriousCountry.gd", FileMode.Open);

			liste = (listePaysSerialisable)bf.Deserialize (file);
			liste.createDictionaire();
			file.Close ();
		} else {
			votoriousCountryInst = new victoriousCountry();
		}
		variablesGlobales.votoriousCountryInst = votoriousCountryInst;
	}
}
