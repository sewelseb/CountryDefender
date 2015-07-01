using UnityEngine;
using System.Collections;
using System;
using System.Xml;
using System.IO;

public class menuScript : MonoBehaviour {


	public string playerPrefsKey = "Country";
	public string codeDuPay;
	public string nomDuPay;
	public bool VCInstancié = false;


	void Start () {
		this.getGeographicalCoordinates ();
		//this.getGeographicalCoordinatesCoroutine ();
		if (!VCInstancié)
		{

			victoriousCountry vic = new victoriousCountry();
				VCInstancié=true;
		}

	}

	void OnGUI()
	{


		const int buttonWidth = 100;
		const int buttonHeight = 60;
		//GUIStyle labelStyle;
		//labelStyle.fontSize = 20;

		GUI.Label (new Rect(10, 10, 200, 40), "You are defending " + nomDuPay);

		if (
			GUI.Button(
				
					new Rect(
						Screen.width / 2 - (buttonWidth / 2),
						(2 * Screen.height / 3) - (buttonHeight / 2),
						buttonWidth,
						buttonHeight
					),
				"Start!"
				)
			)
		{
			// Sur le clic, on démarre le premier niveau
			// "Stage1" est le nom de la première scène que nous avons créés.
			Application.LoadLevel("scene_de_combat");
		}

		if (
			GUI.Button(
				
				new Rect(
				Screen.width / 2 - (buttonWidth / 2),
				( Screen.height / 3) - (buttonHeight / 2),
				buttonWidth,
				buttonHeight
				),
				"List of country"
				)
			)
		{
			// Sur le clic, on démarre le premier niveau
			// "Stage1" est le nom de la première scène que nous avons créés.
			Application.LoadLevel("liste_de_pays");
		}



	}
	public void getGeographicalCoordinates()
	{
		//Debug.Log ("test2");
		StartCoroutine (getGeographicalCoordinatesCoroutine ());
		if (Input.location.isEnabledByUser) {

		}
	}
	private IEnumerator getGeographicalCoordinatesCoroutine()
	{

		Input.location.Start();
		int maximumWait = 20;
		while(Input.location.status == LocationServiceStatus.Initializing && maximumWait > 0)
		{

			yield return new WaitForSeconds(1);
			maximumWait--;
		}
		//if(maximumWait < 1 || Input.location.status == LocationServiceStatus.Failed)
		if (maximumWait < 1 && Input.location.status == LocationServiceStatus.Failed) {
			Debug.Log ("test");
			Input.location.Stop ();
			yield break;
		} else {
			Debug.Log (" une des conditions suivantes est mauvaise: maximumWait < 1 && Input.location.status == LocationServiceStatus.Failed");
		}
		float latitude = Input.location.lastData.latitude;
		float longitude = Input.location.lastData.longitude;



		//pour le bien de la démo, si je n'ai pas un device avec GPS, je prend celui de supinfo
		if (latitude == 0 && longitude == 0) {
			latitude=50.844918f;
			longitude=4.366399f;

		}

		Debug.Log ("latitude: "+latitude);
		Debug.Log ("longitude: "+longitude);
		Input.location.Stop();
		WWW www = new WWW("https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=true");
		yield return www;
		if(www.error != null) yield break;
		XmlDocument reverseGeocodeResult = new XmlDocument();
		reverseGeocodeResult.LoadXml(www.text);
		if(reverseGeocodeResult.GetElementsByTagName("status").Item(0).ChildNodes.Item(0).Value != "OK") yield break;
		string countryCode = null;
		string countryName = null;
		bool countryFound = false;
		foreach(XmlNode eachAdressComponent in reverseGeocodeResult.GetElementsByTagName("result").Item(0).ChildNodes)
		{
			if(eachAdressComponent.Name == "address_component")
			{
				foreach(XmlNode eachAddressAttribute in eachAdressComponent.ChildNodes)
				{
					if(eachAddressAttribute.Name == "short_name")
					{
						countryCode = eachAddressAttribute.FirstChild.Value;
					}
					if(eachAddressAttribute.Name == "long_name")
					{
						countryName = eachAddressAttribute.FirstChild.Value;
					}
					if(eachAddressAttribute.Name == "type" && eachAddressAttribute.FirstChild.Value == "country")
					{

						countryFound = true;
					}
				}
				if(countryFound) break;
			}
		}
		if(countryFound && countryCode != null)
			PlayerPrefs.SetString(playerPrefsKey,countryCode);
		codeDuPay = countryCode.ToString();
		nomDuPay = countryName.ToString ();
		variablesGlobales.paysActuel = countryName.ToString (); 

	}
}
