using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    [SerializeField]
    public string promptMessage;
  

    public virtual string OnLook()
    { 
        return promptMessage; 
    }

    //THIS IS THE SUPERCLASS, MEANT TO BE OVERIDDEN
    public void BaseInteract()
    {
        if(useEvents)
        {
            //should never be null
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }
        Interact();
    }

    protected virtual void Interact()
    {

    }
}
