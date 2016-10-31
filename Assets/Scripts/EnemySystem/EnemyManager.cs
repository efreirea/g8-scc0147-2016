using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : ManagerBase
{
    public enum EnemyType
    {
        Asteroid = 0,
        EnemySpaceship =1
    }

    private static EnemyManager kInstance;
    private Dictionary<EnemyType, EnemyData> kAllEnemyData = new Dictionary<EnemyType, EnemyData>();

    public EnemyManager()
    {
        EnemyManager.kInstance = this;
        //kAllEnemyData.Add(EnemyType.Asteroid,
           //new EnemyData(EnemyType.Asteroid, "AsteroidPrefab", 6f, RoutingComponent.RouteStyle.Line, WeaponSystem.WeaponType.None, 0f, 0f));
        kAllEnemyData.Add(EnemyType.EnemySpaceship,
            new EnemyData(EnemyType.EnemySpaceship, "EnemySpaceshipPrefab",6f, RoutingComponent.RouteStyle.Line, WeaponSystem.WeaponType.Missile, 4f,5f));
    }

    public static EnemyManager Instance
    {
        get
        {
            if (EnemyManager.kInstance == null)
                new EnemyManager();
            return EnemyManager.kInstance;
        }
    }

    public List<EnemyData> AllEnemyDataList
    {
        get
        {
            return new List<EnemyData>(this.kAllEnemyData.Values);
        }
    }

    public Dictionary<EnemyType, EnemyData> AllEnemyData
    {
        get
        {
            return this.kAllEnemyData;
        }
    }

    public EnemyData GetEnemyData(EnemyType type)
    {
        EnemyData data = null;
        this.kAllEnemyData.TryGetValue(type, out data);
        return data;
    }

    public GameObject Spawn(EnemyType type)
    {
        EnemyData data = this.GetEnemyData(type);
        GameObject enemy = InstantiateEnemy(data);
        Enemy enemyComp = enemy.GetComponent<Enemy>();
        enemyComp.EnemyData = data;
        return enemy;
    }

    private GameObject InstantiateEnemy(EnemyData data)
    {
        GameObject projectile = Resources.Load<GameObject>("Prefabs/" + data.kPrefabName);
        return GameObject.Instantiate(projectile, SpawnPosition(), Quaternion.identity) as GameObject;
    }

    private Vector3 SpawnPosition()
    {
        return new Vector3(Random.Range(10f, 30f), Random.Range(-4f, 4f), 0f);
    }
}
