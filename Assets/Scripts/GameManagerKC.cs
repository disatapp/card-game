using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;

public class GameManagerKC : MonoBehaviour
{
	//TODO: change to top down manager
	private GameManager GM;
	private DeckManager Deck;
	private CardAnimator Animator;

	[SerializeField] private GameObject CardObject;
	[SerializeField] private GameObject InformationPanel;

	//This could be in gameManager
	[SerializeField] private GameObject MenuPanel;

	[SerializeField] private Sprite BackSideSprite;
	[SerializeField] private Sprite NextCardSprite;


	//Game data
	private Dictionary<int, string> KCRules;
	private Queue<Card> RandomKCDeck;
	private int CardCount;
	private int KingCount;
	private bool isActive;
	private Card CurrentCard;
	private DrawState state;



	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (isActive) {
			switch (state) {
			case DrawState.HIDE:
				if (TouchManager.IsSwipingLeft () || TouchManager.IsSwipingRight ()) {

					DrawCard ();
				} 
				break;
			case DrawState.REVEAL:
				if (TouchManager.IsTapping () || TouchManager.IsSwipingLeft () || TouchManager.IsSwipingRight ()) {
					NextCard ();
				}
				break;
			case DrawState.GAMEOVER:
				
				if (TouchManager.IsTapping ()) {
					ShowGameover ();
					isActive = false;
				}
				break;

			}
		}

	}



	//==================================================================


	public void InitializeKC ()
	{
		if (Deck == null) {
			Deck = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<DeckManager> ();
		}

		if (Animator == null) {
			Animator = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<CardAnimator> ();
		}

		if (CardObject == null) {
			CardObject = GameObject.FindGameObjectWithTag ("Card");
		}
		if (!CardObject.activeInHierarchy) {
			CardObject.SetActive (true);
		}

		if (InformationPanel == null) {
			InformationPanel = GameObject.FindGameObjectWithTag ("InfoPanel");
		}
		if (InformationPanel.activeInHierarchy) {
			InformationPanel.SetActive (false);
		}

		if (MenuPanel == null) {
			MenuPanel = GameObject.FindGameObjectWithTag ("MenuPanel");
		}
		if (MenuPanel.activeInHierarchy) {
			MenuPanel.SetActive (false);
		}

		CardCount = 0;
		KingCount = 0;
		CurrentCard = null;
		RandomKCDeck = null;

		if (KCRules == null) {
			InitializeKCRules ();
		}

		InitializeRandomKCDeck ();
		NextCard ();
		isActive = true;
	}

	private void InitializeKCRules ()
	{
		KCRules = new Dictionary<int, string> ();

		//2
		KCRules.Add (1, "You:\nThe Person who drew this card gets to pick who drinks.");

		//3
		KCRules.Add (2, "Me:\nThe person who drew this card drinks.");

		//4
		KCRules.Add (3, "Women:\nA.k.a. Classy ladies All the women playing this game drinks");

		//5
		KCRules.Add (4, "Play Drive:\n" +
		"1)Start with the person who drew the card.\n" +
		"2)Every player should put both their hands up,\n" +
		"acting as they are holding an invisible steering wheel.\n" +
		"3)The player will then act out a turning motion (turning left or right)\n" +
		"4)While turning the player had to make a......");

		//6
		KCRules.Add (5, "Men:\nAll the men in the game has to drink.");

		//7
		KCRules.Add (6, "Point A Heaven:\nThe last player to point up into the air has to drink.");

		//8
		KCRules.Add (7, "Pick a Mate:\nPick a friend to drink with." +
		" everytime you are punished and have to drink you mate has to drink as well.");

		//9
		KCRules.Add (8, "Ryme:\nThe person who drew this card picks a word" +
		", the follow players take turns ryming with that word clock-wise." +
		" continue playing until a player fails to ryme in a timely manner.");

		//10
		KCRules.Add (9, "Categories:\nThe person who drew that card picks a category" +
		", the follow players take turns name one word that fits into that category." +
		" Continue playing until a player fails to name a word within that category" +
		" in a timely manner.");

		//Jack
		KCRules.Add (10, "Rules:\nMake a rule any rule. Anyone who violates the rule has to drink.");

		//Queen
		KCRules.Add (11, "Questions:\nThe person who drew this card starts" +
		"by asking someone in the circle the question." +
		"the next person (the person asked the question) must not anwser the question," +
		"instead they have to ask another person a new question, the continues until one person accidently anwsers" +
		"a question or fails to ask a qusetion within a reasonable time.");

		//King
		KCRules.Add (12, "King:\npour any amount of drink into the kings cup, the person who draws the last king will have to drink from the kings cup.");

		//Ace
		KCRules.Add (13, "Water Fall:\n Everyone drinks.");

		//LAST KING
		KCRules.Add (0, "LAST KING:\nYou loose. Now drink from the kings cup! HAHAHA!");
	
	}


	//TODO: this might need to be changed
	private void InitializeRandomKCDeck ()
	{
		List<Card> newDeck = new List<Card> (Deck.Deck);

		for (var i = 0; i < Deck.GetDeckSize () - 1; ++i) {
			int range = Random.Range (i, Deck.GetDeckSize ());
			Card temp = newDeck [range];
			newDeck [range] = newDeck [i];
			newDeck [i] = temp;
			CardCount++;
		}
		RandomKCDeck = new Queue<Card> (newDeck);

	}


	private void SetInfoText (int faceIndex)
	{
		InformationPanel.GetComponentInChildren<Text> ().text = KCRules [faceIndex];

	}

	private enum DrawState
	{
		REVEAL,
		HIDE,
		GAMEOVER
	}

	/// <summary>
	/// Draws the card.
	/// </summary>
	public void DrawCard ()
	{
		//1) show the card
		Animator.RotateCard (NextCardSprite);

		state = DrawState.REVEAL;
		if (!InformationPanel.activeInHierarchy) {
			InformationPanel.SetActive (true);
		}
		CardCount--;

		//2) handle event
		DrawHandler (CurrentCard.CardNumber);
	}

	/// <summary>
	/// Nexts the card.
	/// </summary>
	public void NextCard ()
	{

		//1) spin to hide function (animation) & hide text
		Animator.RotateCard (BackSideSprite);

		state = DrawState.HIDE;
		if (InformationPanel.activeInHierarchy) {
			InformationPanel.SetActive (false);
		}

		//2) get new card
		CurrentCard = null;
		if (RandomKCDeck.Count > 0) {
			CurrentCard = RandomKCDeck.Dequeue ();
			NextCardSprite = Deck.GetSprite (CurrentCard.CardId);
		} else {
			state = DrawState.GAMEOVER;
		}
	}

	private void DrawHandler (int faceIndex)
	{
		Debug.Log (faceIndex);

		//TODO: need to look into this
		if (faceIndex == 12) {
			KingCount++;
			if (KingCount == 4) {
				state = DrawState.GAMEOVER;
				SetInfoText (0);
			} else {
				SetInfoText (faceIndex);
			}
		} else if (faceIndex == 13 || faceIndex < 12 && faceIndex > 0) {
			SetInfoText (faceIndex);
		}
	}


	private void ShowGameover ()
	{
		InformationPanel.SetActive (false);
		MenuPanel.SetActive (true);
		//Prompt a would you like to start over button

	}
	//=====================================================================

	/// <summary>
	/// Restart this KC.
	/// </summary>
	public void Restart ()
	{
		InitializeKC ();
		HideKC ();
	}


	/// <summary>
	/// Go back to main menu.
	/// </summary>
	public void Quit ()
	{
		GM.BackToMain ();

		HideKC ();
		if (CardObject.activeInHierarchy) {
			CardObject.transform.parent.gameObject.SetActive (false);
		}
			
		if (CardObject.activeInHierarchy) {
			CardObject.SetActive (false);
		}

		RandomKCDeck = null;
		CurrentCard = null;



	}

	/// <summary>
	/// Hides the GameObjects
	/// </summary>
	private void HideKC ()
	{
		if (MenuPanel.activeInHierarchy) {
			MenuPanel.SetActive (false);
		}

		if (InformationPanel.activeInHierarchy) {
			InformationPanel.SetActive (false);
		}

	}
	//=====================================================================
		

}
