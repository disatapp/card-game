using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour {

	private List<Card> deck;
	public List<Card> Deck { 
		get{
			return deck; 
		} 
	}

	private Sprite[] sprites;

	void Awake(){
		InitializeDeck ();
	}

	//==================================================================

	public int GetDeckSize(){
		return deck.Count;
	}

	public Sprite GetSprite(int id){
		if(id > sprites.Length){
			return null;
		}

		return sprites[id];
	}

	//==================================================================

	void InitializeDeck ()
	{
		if (deck == null) {
			deck = new List<Card> ();
			int i = 0;

			//2
			deck.Add (new Card (i, 1, Suite.CLUB, "2_Club"));
			i++;
			deck.Add (new Card (i, 1, Suite.DIAMOND, "2_Diamond"));
			i++;
			deck.Add (new Card (i, 1, Suite.HEART, "2_Heart"));
			i++;
			deck.Add (new Card (i, 1, Suite.SPADE, "2_Spade"));
			i++;

			//3
			deck.Add (new Card (i, 2, Suite.CLUB, "3_Club"));
			i++;
			deck.Add (new Card (i, 2, Suite.DIAMOND, "3_Diamond"));
			i++;
			deck.Add (new Card (i, 2, Suite.HEART, "3_Heart"));
			i++;
			deck.Add (new Card (i, 2, Suite.SPADE, "3_Spade"));
			i++;

			//4
			deck.Add (new Card (i, 3, Suite.CLUB, "4_Club"));
			i++;
			deck.Add (new Card (i, 3, Suite.DIAMOND, "4_Diamond"));
			i++;
			deck.Add (new Card (i, 3, Suite.HEART, "4_Heart"));
			i++;
			deck.Add (new Card (i, 3, Suite.SPADE, "4_Spade"));
			i++;

			//5
			deck.Add (new Card (i, 4, Suite.CLUB, "5_Club"));
			i++;
			deck.Add (new Card (i, 4, Suite.DIAMOND, "5_Diamond"));
			i++;
			deck.Add (new Card (i, 4, Suite.HEART, "5_Heart"));
			i++;
			deck.Add (new Card (i, 4, Suite.SPADE, "5_Spade"));
			i++;

			//6
			deck.Add (new Card (i, 5, Suite.CLUB, "6_Club"));
			i++;
			deck.Add (new Card (i, 5, Suite.DIAMOND, "6_Diamond"));
			i++;
			deck.Add (new Card (i, 5, Suite.HEART, "6_Heart"));
			i++;
			deck.Add (new Card (i, 5, Suite.SPADE, "6_Spade"));
			i++;

			//7
			deck.Add (new Card (i, 6, Suite.CLUB, "7_Club"));
			i++;
			deck.Add (new Card (i, 6, Suite.DIAMOND, "7_Diamond"));
			i++;
			deck.Add (new Card (i, 6, Suite.HEART, "7_Heart"));
			i++;
			deck.Add (new Card (i, 6, Suite.SPADE, "7_Spade"));
			i++;

			//8
			deck.Add (new Card (i, 7, Suite.CLUB, "8_Club"));
			i++;
			deck.Add (new Card (i, 7, Suite.DIAMOND, "8_Diamond"));
			i++;
			deck.Add (new Card (i, 7, Suite.HEART, "8_Heart"));
			i++;
			deck.Add (new Card (i, 7, Suite.SPADE, "8_Spade"));
			i++;

			//9
			deck.Add (new Card (i, 8, Suite.CLUB, "9_Club"));
			i++;
			deck.Add (new Card (i, 8, Suite.DIAMOND, "9_Diamond"));
			i++;
			deck.Add (new Card (i, 8, Suite.HEART, "9_Heart"));
			i++;
			deck.Add (new Card (i, 8, Suite.SPADE, "9_Spade"));
			i++;

			//10
			deck.Add (new Card (i, 9, Suite.CLUB, "10_Club"));
			i++;
			deck.Add (new Card (i, 9, Suite.DIAMOND, "10_Diamond"));
			i++;
			deck.Add (new Card (i, 9, Suite.HEART, "10_Heart"));
			i++;
			deck.Add (new Card (i, 9, Suite.SPADE, "10_Spade"));
			i++;

			//jack
			deck.Add (new Card (i, 10, Suite.CLUB, "Jack_Club"));
			i++;
			deck.Add (new Card (i, 10, Suite.DIAMOND, "Jack_Diamond"));
			i++;
			deck.Add (new Card (i, 10, Suite.HEART, "Jack_Heart"));
			i++;
			deck.Add (new Card (i, 10, Suite.SPADE, "Jack_Spade"));
			i++;

			//queen
			deck.Add (new Card (i, 11, Suite.CLUB, "Queen_Club"));
			i++;
			deck.Add (new Card (i, 11, Suite.DIAMOND, "Queen_Diamond"));
			i++;
			deck.Add (new Card (i, 11, Suite.HEART, "Queen_Heart"));
			i++;
			deck.Add (new Card (i, 11, Suite.SPADE, "Queen_Spade"));
			i++;

			//king
			deck.Add (new Card (i, 12, Suite.CLUB, "King_Club"));
			i++;
			deck.Add (new Card (i, 12, Suite.DIAMOND, "King_Diamond"));
			i++;
			deck.Add (new Card (i, 12, Suite.HEART, "King_Heart"));
			i++;
			deck.Add (new Card (i, 12, Suite.SPADE, "King_Spade"));
			i++;

			//Ace
			deck.Add (new Card (i, 13, Suite.CLUB, "Ace_Club"));
			i++;
			deck.Add (new Card (i, 13, Suite.DIAMOND, "Ace_Diamond"));
			i++;
			deck.Add (new Card (i, 13, Suite.HEART, "Ace_Heart"));
			i++;
			deck.Add (new Card (i, 13, Suite.SPADE, "Ace_Spade"));
			i++;

			LoadSpriteSet ();
		}
	}

	public void LoadSpriteSet(){
		sprites = Resources.LoadAll<Sprite> ("CardSet");
	}

}
