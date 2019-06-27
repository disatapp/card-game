using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimator : MonoBehaviour {

	[SerializeField] Transform CardTransform;
	[SerializeField] SpriteRenderer CardRenderer;
	[SerializeField] AnimationCurve TimeCurve;


	public float duration = 0.05f;

	void Awake(){
		InitializeCA ();
	}

	//==================================================================

	void InitializeCA(){
		if(CardTransform == null){
			CardTransform = GameObject.FindGameObjectWithTag ("Card").transform;
		}
		if(CardRenderer == null){
			CardRenderer = GameObject.FindGameObjectWithTag ("Card").GetComponent<SpriteRenderer>();
		}
	}

	//==================================================================


	public void RotateCard (Sprite NextCardSprite)
	{
		StopCoroutine (Flip (NextCardSprite));
		StartCoroutine (Flip (NextCardSprite));
	}

	IEnumerator Flip (Sprite NextCardSprite)
	{
		float i = 0.0f;

		while (i <= TimeCurveEndPoint() + 0.5f) {
			float scale = TimeCurve.Evaluate (i);
			i = i + Time.deltaTime / duration;

			Vector3 localScale = CardTransform.localScale;
			localScale.x = scale;
			CardTransform.localScale = localScale;
		

			if(i >= TimeCurveMidPoint()){
				if (CardRenderer.sprite != NextCardSprite) {
					CardRenderer.sprite = NextCardSprite;
				}
			}

			yield return new WaitForFixedUpdate ();
		}
	}

	public float TimeCurveMidPoint(){
		return TimeCurve.keys [1].time;
	}

	public float TimeCurveEndPoint(){
		return TimeCurve.keys [2].time;
	}
}
