using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientsList : MonoBehaviour
{
    public static IngredientsList Instance;

    public Transform container;
    public Transform itemTemplate;
    public float templateHeight = 25f;
    public List<IngredientItem> ingredientList;

    private List<Item> itemList;
    private List<Transform> itemTransformList;

    public AudioSource audioSource;

    private Animator animator;

    public bool ReadyToCook { get; set; }

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        animator = GetComponent<Animator>();

        itemTemplate.gameObject.SetActive(false);
        itemTransformList = new List<Transform>();

        ReadyToCook = false;

        itemList = new List<Item>();
        foreach (IngredientItem ingredient in ingredientList)
        {
            itemList.Add(new Item { name = ingredient.name, collected = false });
        }

        foreach (Item item in itemList)
        {
            CreateListEntry(item, container, itemTransformList);
        }
    }

    private void CreateListEntry(Item entry, Transform container, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(itemTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        entryTransform.GetComponent<Text>().text = "[]   " + entry.name;
        transformList.Add(entryTransform);
    }

    public void UpdateList(string itemName)
    {
        int itemCount = 0;
        foreach (Item item in itemList)
        {
            if (item.name == itemName && !item.collected)
            {
                item.collected = true;
                StartCoroutine(ScratchThat(itemTransformList[itemCount].GetComponentInChildren<Image>()));
                break;
            }
            itemCount++;
        }

        int itemsRemainingCount = ingredientList.Count;
        foreach (Item item in itemList)
        {
            if (item.collected)
            {
                itemsRemainingCount--;
            }
        }
        if (itemsRemainingCount <= 0)
        {
            ReadyToCook = true;
            animator.SetTrigger("hide");
            Dialog.Instance.UpdateDialog("Time to bake this cake!");
        }
    }

    private IEnumerator ScratchThat(Image image)
    {
        audioSource.Play();
        image.fillAmount = 0;
        while (image.fillAmount < 1)
        {
            image.fillAmount = Mathf.Lerp(image.fillAmount, 1, Time.deltaTime);
            yield return null;
        }
    }

    public void ShowList()
    {
        animator.SetTrigger("show");
    }

    private class Item
    {
        public string name;
        public bool collected;
    }
}
