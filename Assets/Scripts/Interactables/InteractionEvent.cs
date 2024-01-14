using UnityEngine.Events;
using UnityEngine;
using System.CodeDom;

public class InteractionEvent : MonoBehaviour
{
    public UnityEvent OnInteract;

    public void stopEvents()
    {
        InteractionEvent scriptComponent = gameObject.GetComponent<InteractionEvent>();
        EventOnlyInteractable scriptComponent2 = gameObject.GetComponent<EventOnlyInteractable>();
        if (scriptComponent != null && scriptComponent2 != null)
        {
            Destroy(scriptComponent2);
            Destroy(scriptComponent);

        }
    }

}
