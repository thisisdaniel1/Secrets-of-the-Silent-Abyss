using UnityEngine;

// template for other interactable scripts
public abstract class Interactable : MonoBehaviour
{
    // message displayed to player when looking at an interactable
    public string promptMessage;

    // called from player script, template method pattern
    public void BaseInteract(){
        Interact();
    }

    protected virtual void Interact(){
        // will be overwritten by subclasses
    }
}
