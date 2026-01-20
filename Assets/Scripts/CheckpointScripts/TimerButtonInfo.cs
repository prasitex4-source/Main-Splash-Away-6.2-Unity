using UnityEngine;

public class TimerButtonInfo : InfoStructure
{
    private buttoncontroler2 timedButton;

    private bool savedIsPressed = false;
    private bool savedIsActiveDoor = false;
    private bool savedIsActiveTimer = false;

    protected override void Start()
    {
        base.Start();
        timedButton = GetComponent<buttoncontroler2>();
    }

    public override void SaveState()
    {
        savedIsPressed = timedButton.isPressed;
        savedIsActiveDoor = timedButton.isActiveDoor;
        savedIsActiveTimer = timedButton.isActiveTimer;
    }

    public override void LoadState()
    {
        timedButton.RestartTimerButton();
    }
}
