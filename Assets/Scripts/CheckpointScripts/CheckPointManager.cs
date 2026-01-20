using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager instance;

    [SerializeField] private GameObject checkpointPosition;
    private List<InfoStructure> saveables = new List<InfoStructure>();
    [HideInInspector] public GameObject currentCheckpointPosition; 

    private void Awake()
    {
        instance = this;
    }

    public void Register(InfoStructure obj)
    {
        if (!saveables.Contains(obj))
            saveables.Add(obj);
    }

    public void SetCheckpoint(Vector3 newPosition)
    {
        foreach (InfoStructure s in saveables)
        {
            s.SaveState();
        }
    }

    public void Respawn(GameObject player)
    {
        player.transform.position = currentCheckpointPosition.transform.position;

        foreach (InfoStructure s in saveables)
        {
            s.LoadState();
        }
    }
}
