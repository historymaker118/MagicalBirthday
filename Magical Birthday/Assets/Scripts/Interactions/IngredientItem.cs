using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientItem : MonoBehaviour, ICollectable
{
    public string name;
    public int score;

    public void DoTheThing(GameObject player)
    {
        IngredientsList.Instance.UpdateList(name);
        Destroy(this.gameObject);
    }
}
