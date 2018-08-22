using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PossessionItem : MonoBehaviour {

	[SerializeField] private GameObject cursorObj;

	private int index;
	private Image image;
	private Button button;
	public ITEM item { get; private set; }

	void Awake() {
		image = GetComponent<Image> ();
		button = GetComponent<Button> ();
		item = ITEM.NONE;
	}

	// Use this for initialization
	void Start () {
		button.onClick.AddListener (SelectItem);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetIndex(int inIndex) {
		index = inIndex;
	}

	public void SetItem(ITEM inItem) {
		item = inItem;
		image.sprite = Resources.Load<Sprite> (ItemManager.ITEM_PATH_DIC [item]);
	}

	void SelectItem() {
		if (item == ITEM.NONE) {
			return;
		}

		bool isSelected = cursorObj.activeSelf;
		ItemManager.instance.SelectItem (item, index);
		if (!isSelected) {
			cursorObj.SetActive (true);
		}
	}

	public void EnableCursor() {
		cursorObj.SetActive (true);
	}

	public void DisableCursor() {
		cursorObj.SetActive (false);
	}
}
