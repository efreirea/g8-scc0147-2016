using UnityEngine;
using System.Collections;

public abstract class Enemy : Destroyable
{
    private float kDelay = 0;
    private EnemyData kEnemyData;

    void Start()
    {
    }

    public abstract EnemyManager.EnemyType EnemyType
    {
        get;
    }

    public virtual void Explode()
    {
        Destroy();
    }


    public override void FixedUpdate()
    {
        if(EnemyData == null)
        {
            return;
        }

        if (EnemyData.HasWeapon)
        {
            if (kDelay < 0f)
            {
                WeaponSystem weapon = base.GetComponent<WeaponSystem>();
                if (weapon != null)
                {
                    weapon.Fire(WeaponSystem.WeaponType.Missile);
                }
                kDelay = Random.Range(EnemyData.kWeaponMinWaitFire, EnemyData.kWeaponMaxWaitFire);
            }
            kDelay -= Time.fixedDeltaTime;
        }
        base.FixedUpdate();
    }

    public EnemyData EnemyData
    {
        get {
            return this.kEnemyData;
        }
        set
        {
            this.kEnemyData = value;
            this.ApplyData();
        }
    }

    private void ApplyData()
    {
        RoutingComponent routing = base.GetComponent<RoutingComponent>();
        routing.CurrentRoutingOptions = new RoutingComponent.RoutingOptions(this.kEnemyData.kSpeed, RoutingComponent.RouteOrientation.Left, this.kEnemyData.kRouteStyle);
    }
}
