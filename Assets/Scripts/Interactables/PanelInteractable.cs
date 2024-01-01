using UnityEngine;
using UnityEngine.UI;

public class PanelInteractable : Interactable
{
    protected PanelManager panelManager;

    void Start(){
        panelManager = PanelManager.Instance;
    }
}
