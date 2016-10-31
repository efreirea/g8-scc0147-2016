using UnityEngine;
using System.Collections;

public class Spawner
{
    private string kPrefabName;

    public Spawner(string kPrefabName)
    {
        this.kPrefabName = kPrefabName;
    }

    public virtual GameObject Spawn(Vector2 position)
    {
        return GameObject.Instantiate(Instantiate(), position, Quaternion.identity) as GameObject;
    }

    public virtual GameObject Spawn(Vector2 position, Quaternion rotation)
    {
        return GameObject.Instantiate(Instantiate(), position, rotation) as GameObject;
    }

    public GameObject Instantiate()
    {
        return Resources.Load<GameObject>("Prefabs/" + this.kPrefabName);
    }
}
