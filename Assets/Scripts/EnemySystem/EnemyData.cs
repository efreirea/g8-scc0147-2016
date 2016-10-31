using UnityEngine;
using System.Collections;

public class EnemyData
{
    public float kSpeed;
    public string kPrefabName;
    public EnemyManager.EnemyType kEnemyType;
    public WeaponSystem.WeaponType kWeaponType;
    public float kWeaponMinWaitFire;
    public float kWeaponMaxWaitFire;
    public RoutingComponent.RouteStyle kRouteStyle;

    public EnemyData(EnemyManager.EnemyType kEnemyType, string kPrefabName,  float kSpeed, RoutingComponent.RouteStyle kRouteStyle, WeaponSystem.WeaponType kWeaponType, float kWeaponMinWaitFire, float kWeaponMaxWaitFire)
    {
        this.kEnemyType = kEnemyType;
        this.kPrefabName = kPrefabName;
        this.kSpeed = kSpeed;
        this.kWeaponType = kWeaponType;
        this.kRouteStyle = kRouteStyle;
        this.kWeaponMinWaitFire = kWeaponMinWaitFire;
        this.kWeaponMaxWaitFire = kWeaponMaxWaitFire;
    }

    public bool HasWeapon
    {
        get
        {
            return this.kWeaponType != WeaponSystem.WeaponType.None;
        }
    }
}
