using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingList : MonoBehaviour {
	public static ShoppingList Instance;

		public Transform container;
		public Transform itemTemplate;
		public float templateHeight = 25f;
		public List<ShoppingItem> shoppingList;

		private List<Item> itemList;
		private List<Transform> itemTransformList;

		private Animator animator;

		public bool ReadyToCheckout {get; set;}
		public bool ReadyToLeave {get; set;}

	void Start(){
		if (Instance == null){
			Instance = this;
		}

		animator = GetComponent<Animator>();

		itemTemplate.gameObject.SetActive(false);
		itemTransformList = new List<Transform>();

		ReadyToCheckout = false;
		ReadyToLeave = false;

		itemList = new List<Item>();
		foreach (ShoppingItem shoppingItem in shoppingList){
			itemList.Add(new Item { name = shoppingItem.name, collected = false });
		}

		foreach(Item item in itemList){
			CreateShoppingListEntry(item, container, itemTransformList);
		}
	}

	private void CreateShoppingListEntry(Item entry, Transform container, List<Transform> transformList){
		Transform entryTransform = Instantiate(itemTemplate, container);
		RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
		entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
		entryTransform.gameObject.SetActive(true);

		entryTransform.GetComponent<Text>().text = "[]   " + entry.name;
		transformList.Add(entryTransform);
	}

	public void UpdateShoppingList(string itemName){
		int itemCount = 0;
		foreach (Item item in itemList){
			if (item.name == itemName && !item.collected){
				item.collected = true;
				StartCoroutine(ScratchThat(itemTransformList[itemCount].GetComponentInChildren<Image>()));
				break;
			}
			itemCount ++;
		}

		int itemsRemainingCount = shoppingList.Count;
		foreach (Item item in itemList){
			if (item.collected){
				itemsRemainingCount --;
			}
		}
		if (itemsRemainingCount <= 0){
			ReadyToCheckout = true;
			animator.SetTrigger("hide");
			Dialog.Instance.UpdateDialog("Get to the Checkout!!");
		}
	}

	private IEnumerator ScratchThat(Image image){
		image.fillAmount = 0;
		while (image.fillAmount < 1){
			image.fillAmount = Mathf.Lerp(image.fillAmount, 1, Time.deltaTime);
			yield return null;
		}
	}

	public void ShowList(){
		animator.SetTrigger("show");
	}

	private class Item {
		public string name;
		public bool collected;
	}
}
