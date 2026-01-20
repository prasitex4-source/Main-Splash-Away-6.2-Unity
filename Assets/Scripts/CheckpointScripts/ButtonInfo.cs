using UnityEngine;

public class ButtonInfo : InfoStructure
{
    private ButtonController button;
    private bool savedIsOn;
    private bool savedActivate;
    private bool savedDesactivate;

    protected override void Start()
    {
        base.Start();
        button = GetComponent<ButtonController>();
    }

    public override void SaveState()
    {
        savedIsOn = button.isOn;
        savedActivate = button.isDoorActivated;
        savedDesactivate = button.isdoorDeactivated;
    }

    public override void LoadState()
    {
        button.RestartButton();
    }
}
