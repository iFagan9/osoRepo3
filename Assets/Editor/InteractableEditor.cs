using System.Runtime;
using UnityEditor;

[CustomEditor(typeof(InteractableEditor), true)] 


public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
            if(interactable.useEvents)
        {
            if (interactable.GetComponent<InteractionEvent>() == null)
            {
                interactable.gameObject.AddComponent<InteractionEvent>();

            }
        }
        else
        {
            if(interactable.GetComponent<InteractionEvent>() != null)
            {
                DestroyImmediate(interactable.GetComponent<InteractionEvent>());
            }
        }
    }
}
