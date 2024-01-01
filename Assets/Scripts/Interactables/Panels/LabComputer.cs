using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabComputer : PanelInteractable
{
    [SerializeField]
    private string computerName;

    [SerializeField]
    private string ownerName;

    [SerializeField]
    private List<ButtonInfo> buttonInfoList;

    protected override void Interact()
    {
        if (panelManager.isPlaying)
        {
            panelManager.ExitPanel();
        }
        else
        {
            panelManager.EnterComputerPanel(computerName, "Welcome " + ownerName, buttonInfoList);
        }
    }
}
