using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	private Button button;

	void Awake () {
		button = GetComponent<Button> ();
	}

	// Use this for initialization
	void Start () {
		button.onClick.AddListener (OnTapButton);
	}

	void OnTapButton() {
		ItemManager.instance.SetItem (ITEM.BALL);
		gameObject.SetActive (false);
	}
}
