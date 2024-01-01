using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPad : PanelInteractable
{    
    public DoorInfo doorInfo;
    public GameObject door;

    public int password;

    public AudioManager audioManager;

    protected override void Interact(){

        if (panelManager.isPlaying){
            panelManager.ExitNumPad();
        }
        else{
            panelManager.EnterNumPad();
        }

        doorInfo.isOpen = !doorInfo.isOpen;
    }

    public void CheckingPassword(){
        bool passwordMatch = panelManager.CheckPassword(password);
        if (passwordMatch){
            door.GetComponent<Animator>().SetBool("isOpen", doorInfo.isOpen);

            audioManager.Play(Resources.Load<AudioClip>("win"));
        }
    }
}
