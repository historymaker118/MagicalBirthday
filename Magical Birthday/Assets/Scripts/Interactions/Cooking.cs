using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour, IInteractable
{
    public GameObject prompt;
    public GameObject cake;
    public string notReadyText;
    public string readyText;

    public AudioSource audioSource;

    public void Start()
    {
        cake.SetActive(false);
    }

    public void ShowPrompt(bool showing)
    {
        prompt.SetActive(showing);
    }

    public void DoTheThing(GameObject player)
    {
        if (IngredientsList.Instance.ReadyToCook)
        {
            audioSource.Play();
            Dialog.Instance.UpdateDialog(readyText);
            cake.SetActive(true);
            StartCoroutine(GameEnd());
        }
        else
        {
            Dialog.Instance.UpdateDialog(notReadyText);
        }
    }

    private IEnumerator GameEnd()
    {
        float timer = 0;
        while (timer < 5.0f)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        GameManager.Instance.TriggerGameOver();
    }
}
