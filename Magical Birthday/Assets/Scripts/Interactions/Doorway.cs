using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour, ICheckpoint
{
    public Animator ingredientsListAnimator;

    private bool triggered = false;

    public void DoTheThing(bool thing)
    {
        if (!triggered)
        {
            ingredientsListAnimator.SetTrigger("show");
        }
        triggered = true;
    }
}
