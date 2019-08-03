using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

	public static Dialog Instance;

	public float delay = 0.1f;

	private bool speaking;
	private Text dialogText;
	private string currentString;
	private string fullString;

	void Start () {
		if (Instance == null){
			Instance = this;
		}
		speaking = false;
		dialogText = GetComponent<Text>();
	}

	public void UpdateDialog(string message){
		if (speaking){
			StopCoroutine(ShowText());
		}
		fullString = message;
		currentString = "";
		StartCoroutine(ShowText());
	}

	private IEnumerator ShowText(){
		speaking = true;
		for (int i=0; i<fullString.Length; i++){
			currentString = fullString.Substring(0, i);
			dialogText.text = currentString;
			yield return new WaitForSeconds(delay);
		}
		dialogText.text = "";
		speaking = false;
	}

}
