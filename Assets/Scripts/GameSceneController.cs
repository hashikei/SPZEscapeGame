using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour {

	[SerializeField] private GameObject leftViewObj;
	[SerializeField] private GameObject centerViewObj;
	[SerializeField] private GameObject rightViewObj;

	[SerializeField] private Button leftArrowButton;
	[SerializeField] private Button rightArrowButton;

	private static List<FLG> flgList = new List<FLG>();
	private VIEW currentView;

	void Awake() {
		currentView = VIEW.CENTER;
	}

	// Use this for initialization
	void Start () {
		leftArrowButton.onClick.AddListener (OnSelectLeftArrow);
		rightArrowButton.onClick.AddListener (OnSelectRightArrow);
	}

	public static void GameClear() {
		Debug.Log ("Clear!!");
		SceneManager.LoadScene ("Result");
	}

	public static void SetFlg(FLG flg) {
		if (flgList.Contains(flg)) {
			Debug.LogError ("すでにフラグが立っています。 - " + flg.ToString ());
			return;
		}

		flgList.Add (flg);
		Debug.Log ("flgが立った");
	}

	void OnSelectLeftArrow() {
		switch (currentView) {
			case VIEW.CENTER:
				leftViewObj.SetActive (true);
				centerViewObj.SetActive (false);
				currentView = VIEW.LEFT;
				leftArrowButton.gameObject.SetActive (false);
				break;
			case VIEW.RIGHT:
				rightViewObj.SetActive (false);
				centerViewObj.SetActive (true);
				currentView = VIEW.CENTER;
				rightArrowButton.gameObject.SetActive (true);
				break;
		}
	}

	void OnSelectRightArrow() {
		switch (currentView) {
			case VIEW.LEFT:
				leftViewObj.SetActive (false);
				centerViewObj.SetActive (true);
				currentView = VIEW.CENTER;
				leftArrowButton.gameObject.SetActive (true);
				break;
			case VIEW.CENTER:
				centerViewObj.SetActive (false);
				rightViewObj.SetActive (true);
				currentView = VIEW.RIGHT;
				rightArrowButton.gameObject.SetActive (false);
				break;
		}
	}
}
