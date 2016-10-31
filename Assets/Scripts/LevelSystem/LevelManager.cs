using UnityEngine;
using System.Collections;

public class LevelManager : ManagerBase
{
    private static LevelManager kInstance;
    private Level kCurrentLevel;
    private Spawner kSpaceshipSpawner;

    public LevelManager()
    {
        LevelManager.kInstance = this;
        this.kSpaceshipSpawner = new Spawner("SpaceshipPrefab");
    }

    public static LevelManager Instance
    {
        get
        {
            if (LevelManager.kInstance == null)
                new LevelManager();
            return LevelManager.kInstance;
        }
    }

    public override void Start()
    {
    }

    public Level CurrentLevel
    {
        get
        {
            return this.kCurrentLevel;
        }
    }

    public void Switch(Level newLevel)
    {
        if(kCurrentLevel != null)
        {
            kCurrentLevel.CleanUp();
        }
        kCurrentLevel = newLevel;
        if (kCurrentLevel != null)
        {
            kCurrentLevel.Build();
            PlaceSpaceship();
            kCurrentLevel.Start();
        }
    }

    void PlaceSpaceship()
    {
        kSpaceshipSpawner.Spawn(Vector2.zero, Quaternion.Euler(0f,0f,-90f));
    }

    public override void Update()
    {
        if(kCurrentLevel != null)
        {
            kCurrentLevel.Update();
        }
    }

    public override void FixedUpdate()
    {
        if (kCurrentLevel != null)
        {
            kCurrentLevel.FixedUpdate();
        }
	}
}
