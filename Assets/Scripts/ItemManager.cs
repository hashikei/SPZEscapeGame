using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public static readonly Dictionary<ITEM, string> ITEM_PATH_DIC = new Dictionary<ITEM, string>() {
		{ ITEM.BALL, "Textures/Ball" },
	};

	private static ItemManager _instance;
	public static ItemManager instance { get { return _instance; } }

	private List<PossessionItem> possessionItemList;

	public ITEM selectItem { get; private set; }

	void Awake() {
		_instance = this;

		selectItem = ITEM.NONE;
	}

	void Start() {
		var possessionItems = GetComponentsInChildren<PossessionItem> ();
		possessionItemList = new List<PossessionItem> (possessionItems.Length);

		int index = 0;
		foreach (var possessionItem in possessionItems) {
			possessionItemList.Add (possessionItem);
			possessionItem.SetIndex (index);
			++index;
		}
	}

	public void SetItem(ITEM item) {
		PossessionItem remainPossessionItem = null;
		foreach (var possessionItem in possessionItemList) {
			if (possessionItem.item == item) {
				Debug.LogError ("すでにアイテムを所持しています。 - " + item.ToString ());
				return;
			}

			if (remainPossessionItem == null && possessionItem.item == ITEM.NONE) {
				remainPossessionItem = possessionItem;
			}
		}

		if (remainPossessionItem == null) {
			Debug.LogError ("所持上限に達しています。");
			return;
		}

		remainPossessionItem.SetItem(item);
	}

	public void SelectItem(ITEM item, int index) {
		selectItem = item;
		foreach(var possessionItem in possessionItemList) {
			possessionItem.DisableCursor ();
		}
	}
}
