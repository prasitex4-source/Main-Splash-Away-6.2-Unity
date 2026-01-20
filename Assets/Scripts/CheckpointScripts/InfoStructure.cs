using UnityEngine;

public abstract class InfoStructure : MonoBehaviour
{
    protected virtual void Start()
    {
        CheckPointManager.instance.Register(this);
    }

    public abstract void SaveState();
    public abstract void LoadState();
}

