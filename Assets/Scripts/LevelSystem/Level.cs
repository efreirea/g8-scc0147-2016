using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level
{
    private float kDelay;
    private LevelData kLevelData;
    private LevelManager kLevelManager;

    public Level(LevelManager kLevelManager, LevelData kLevelData)
    {
        this.kLevelData = kLevelData;
        this.kLevelManager = kLevelManager;
    }

    public void Build()
    {

    }

    public void Start ()
    {
	    
	}
	
	public void Update ()
    {

    }

    public void FixedUpdate()
    {
        if (kDelay > 1f)
        {
            Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
            foreach (EnemyData data in EnemyManager.Instance.AllEnemyDataList)
            {
                int count = 0;
                foreach (Enemy enemy in enemies)
                {
                    if (enemy.EnemyType == data.kEnemyType)
                    {
                        count++;
                    }
                }
                if (count < kLevelData.kEnemyDensity)
                {
                    EnemyManager.Instance.Spawn(data.kEnemyType);
                }
            }
            kDelay = 0f;
        }
        kDelay += Time.fixedDeltaTime;
    }

    public void CleanUp()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.Destroy();
        }
    }
}
