using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject MainMenu;

	[SerializeField] private GameObject KCObject;
	// Use this for initialization
	void Start ()
	{
		Initialize ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void Initialize ()
	{
		if (MainMenu == null) {
			MainMenu = GameObject.FindGameObjectWithTag ("GameManager");
		}
		if (!MainMenu.activeInHierarchy) {

			MainMenu.SetActive (true);
		}

		if (KCObject == null) {
			KCObject = GameObject.FindGameObjectWithTag ("KC");
		}

		if (KCObject.activeInHierarchy) {
			KCObject.SetActive (false);
		}
	}

	public void StartKingsCup ()
	{
		GameManagerKC KC = KCObject.GetComponent<GameManagerKC> ();

		MainMenu.SetActive (false);
		KCObject.SetActive (true);
		KC.InitializeKC ();


	}

	public void BackToMain ()
	{
		KCObject.SetActive (false);
		MainMenu.SetActive (true);
	}
}
