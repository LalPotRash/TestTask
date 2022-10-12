using UnityEngine;

public class Ground
{
    public GameObject groundPrefab { get; private set; }

    public Ground()
    {
        groundPrefab = (GameObject)Resources.Load("Prefabs/Ground", typeof(GameObject));
    }
}
