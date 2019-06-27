using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Suite{
	CLUB,
	SPADE,
	DIAMOND,
	HEART
}

public class Card{

	private int cardId;

	public int CardId {
		get {
			return cardId;
		}
	}


	//TODO: enum?
	private int cardNumber;

	public int CardNumber {
		get {
			return cardNumber;
		}
	}

	private Suite cardSuite;

	public Suite CardSuite {
		get {
			return cardSuite;
		}
	}

	private string cardName;

	public string CardName {
		get {
			return cardName;
		}
	}

	public Card (Card copy){
		cardId = copy.cardId;
		cardSuite = copy.cardSuite;
		cardNumber = copy.cardNumber;
		cardName = copy.cardName;
	}

	public Card(int id, int number, Suite suite, string name){
		cardId = id;
		cardSuite = suite;
		cardNumber = number;
		cardName = name;
	}
		


}
