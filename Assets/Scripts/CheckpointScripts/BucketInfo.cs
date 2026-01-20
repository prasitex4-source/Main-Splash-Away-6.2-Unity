using UnityEngine;

public class BucketInfo : InfoStructure
{
    private BucketController bucket;
    private bool savedHasFallen;
    private bool savedWaterActive;

    protected override void Start()
    {
        base.Start();
        bucket = GetComponent<BucketController>();
    }

    public override void SaveState()
    {
        savedHasFallen = bucket.hasFallen;
        savedWaterActive = bucket.waterActive;
    }

    public override void LoadState()
    {
        bucket.RestartBucket();
    }
}
