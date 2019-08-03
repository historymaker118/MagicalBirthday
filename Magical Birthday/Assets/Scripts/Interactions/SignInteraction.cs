using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInteraction : MonoBehaviour, IInteractable {

	public GameObject prompt;
    public string[] text;

    private int dialogCount;
    public AudioSource audioSource;

	void Start(){
		prompt.SetActive(false);
        dialogCount = 0;
	}

	public void ShowPrompt(bool showing){
		prompt.SetActive(showing);
	}

	public void DoTheThing(GameObject player){
        audioSource.Play();
        Dialog.Instance.UpdateDialog(text[dialogCount]);
        if (dialogCount++ >= text.Length -1)
        {
            dialogCount = text.Length -1;
        }
            
    }
}
