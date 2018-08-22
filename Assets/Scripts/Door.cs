using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

	private Button button;

	void Awake() {
		button = GetComponent<Button> ();
	}

	// Use this for initialization
	void Start () {
		button.onClick.AddListener (OnTapButton);
	}

	void OnTapButton() {
		Debug.Log (ItemManager.instance.selectItem.ToString ());
		if (ItemManager.instance.selectItem != ITEM.BALL) {
			return;
		}

		GameSceneController.GameClear ();
	}
}
