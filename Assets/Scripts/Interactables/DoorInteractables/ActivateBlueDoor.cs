using UnityEngine;

public class ActivateBlueDoor : Interactable
{
    private DoorInfo doorInfo;

    private CountdownTimer countdownTimer;

    public GameObject door;

    void Start(){
        doorInfo = GetComponentInParent<DoorInfo>();
        countdownTimer = CountdownTimer.Instance;
    }

    protected override void Interact(){
        doorInfo.isOpen = !doorInfo.isOpen;
        if (doorInfo.isOpen){
            countdownTimer.DecreaseByTwoMinutes();
        }
        else{
            countdownTimer.IncreaseByTwoMinutes();
        }
        door.GetComponent<Animator>().SetBool("isOpen", doorInfo.isOpen);
    }
}
