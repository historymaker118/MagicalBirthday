using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingItem : MonoBehaviour, ICollectable {

	public string name;
	public int score;

	public void DoTheThing(GameObject player){
		ShoppingList.Instance.UpdateShoppingList(name);
		Scorekeeper.Instance.UpdateScore(score);
		Destroy(this.gameObject);
	}
}
