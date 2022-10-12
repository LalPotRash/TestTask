using UnityEngine;

public class Cube
{
    public GameObject cubePrefab { get; private set; }

    public Cube()
    {
        cubePrefab = (GameObject)Resources.Load("Prefabs/MovableObject", typeof(GameObject));
    }
}
