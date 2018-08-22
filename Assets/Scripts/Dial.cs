using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dial : MonoBehaviour {

	private static readonly int CORRECT = 123;

	[SerializeField] private Button[] buttons;
	[SerializeField] private Ball ball;

	private int[] nums;
	private Text[] texts;

	// Use this for initialization
	void Start () {
		nums = new int[buttons.Length];
		texts = new Text[buttons.Length];

		for (int i = 0; i < buttons.Length; ++i) {
			texts [i] = buttons [i].GetComponentInChildren<Text> ();

			int index = i;
			buttons [i].onClick.AddListener (() => OnTapButton(index));
		}
	}

	private void OnTapButton(int index) {
		++nums [index];
		if (nums[index] > 9) {
			nums [index] = 0;
		}

		texts [index].text = nums[index].ToString ();

		JudgeCorrect ();
	}

	private void JudgeCorrect() {
		int answer = 0;
		for (int i = 0; i < nums.Length; ++i) {
			answer += nums [i] * (int)Mathf.Pow (10, nums.Length - i - 1);
		}

		if (answer == CORRECT) {
			GameSceneController.SetFlg (FLG.DIAL);
			ball.gameObject.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
