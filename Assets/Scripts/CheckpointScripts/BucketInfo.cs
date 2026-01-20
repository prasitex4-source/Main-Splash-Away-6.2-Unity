using UnityEngine;

public class BucketInfo : InfoStructure
{
    private BucketController bucket;
    private bool savedHasFallen;
    private bool savedWaterActive;
    private Vector3 savedPosition;
    private bool savedCanFall;

    protected override void Start()
    {
        base.Start();
        bucket = GetComponent<BucketController>();
    }

    public override void SaveState()
    {
        savedHasFallen = bucket.hasFallen;
        savedWaterActive = bucket.waterActive;
        savedPosition = bucket.initialPosition;
        savedCanFall = bucket.canFall;
    }

    public override void LoadState()
    {
        bucket.RestartBucket();
    }
}
