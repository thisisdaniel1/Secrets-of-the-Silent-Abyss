using UnityEngine;

public class Chest : Interactable
{
    [SerializeField]
    private GameObject cube;

    private bool isPlaying;
    protected override void Interact(){
        isPlaying = !isPlaying;
        Debug.Log("chest opened");
        // chest.GetComponent<Animator>().SetBool("isOpen", chestOpen);
    }
}
