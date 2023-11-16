using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    public string promptMessage;
    public bool useEvents;

    //THIS IS THE SUPERCLASS, MEANT TO BE OVERIDDEN
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {

    }
}
