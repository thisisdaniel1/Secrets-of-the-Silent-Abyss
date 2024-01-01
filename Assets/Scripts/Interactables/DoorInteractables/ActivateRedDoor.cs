using UnityEngine;

public class ActivateRedDoor : Interactable
{
    // each doorpanel script has its own doorinfo related to whichever door it is attached to
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
            countdownTimer.DecreaseByOneMinute();
        }
        else{
            countdownTimer.IncreaseByOneMinute();
        }

        door.GetComponent<Animator>().SetBool("isOpen", doorInfo.isOpen);
    }
}