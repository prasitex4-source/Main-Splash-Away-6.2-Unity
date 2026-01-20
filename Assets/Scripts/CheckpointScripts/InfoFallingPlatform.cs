using UnityEngine;

public class InfoFallingPlatform : InfoStructure
{
    private EstanteriaScript estanteria;
    private int savedCount;
    private Vector3 savedInitialPosition;

    protected override void Start()
    {
        base.Start();
        estanteria = GetComponent<EstanteriaScript>();
    }

    public override void SaveState()
    {
        savedCount = estanteria.Count;
        savedInitialPosition = estanteria.initialPosition;
    }

    public override void LoadState()
    {
        estanteria.Restart();
    }
}
