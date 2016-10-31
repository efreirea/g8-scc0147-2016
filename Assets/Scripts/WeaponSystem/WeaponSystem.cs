using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSystem : MonoBehaviour
{
    public enum WeaponType
    {
        None,
        Missile
    }
    public class WeaponData
    {
        public string kPrefabName;
        public float kDamage;
        public float kSpeed;
        public RoutingComponent.RouteStyle kRouteStyle;
        public WeaponData(float kDamage, float kSpeed, RoutingComponent.RouteStyle kRouteStyle, string kPrefabName)
        {
            this.kDamage = kDamage;
            this.kSpeed = kSpeed;
            this.kRouteStyle = kRouteStyle;
            this.kPrefabName = kPrefabName;
        }
    }
    private bool kFromPlayer = true;
    private Dictionary<WeaponType,WeaponData> kAllWeaponData = new Dictionary<WeaponType, WeaponData>();

    public WeaponSystem()
    {
        this.LoadWeaponData();
    }

    void Start()
    {
        Enemy enemy = base.GetComponent<Enemy>();
        FromPlayer = enemy == null;
    }

    public bool FromPlayer
    {
        get
        {
            return this.kFromPlayer;
        }
        set
        {
            this.kFromPlayer = value;
        }
    }

    private void LoadWeaponData()
    {
        kAllWeaponData.Add(WeaponType.Missile, new WeaponData(34f, 8f, RoutingComponent.RouteStyle.Line, "MissilePrefab"));
    }

    public void Fire(WeaponType type)
    {
        if (type != WeaponType.None)
        {
            WeaponData data = this.GetWeaponData(type);
            GameObject projectile = InstantiateProjectile(data);
            Projectile projectileComp = projectile.GetComponent<Projectile>();
            projectileComp.SetProjectileCollisionCallBack(new Projectile.ProjectileCollisionCallback(CollisionCallback));
            projectileComp.FromPlayer = this.FromPlayer;
            projectileComp.WeaponData = data;
        }
    }

    public void CollisionCallback(GameObject projectile, GameObject target)
    {
        this.DamageTarget(target);
    }

    private void DamageTarget(GameObject target)
    {
    }

    public WeaponData GetWeaponData(WeaponType type)
    {
        WeaponData data = null;
        this.kAllWeaponData.TryGetValue(type, out data);
        return data;
    }

    private GameObject InstantiateProjectile(WeaponData data)
    {
        GameObject projectile = Resources.Load<GameObject>("Prefabs/" + data.kPrefabName);
        return GameObject.Instantiate(projectile, base.transform.position, Quaternion.identity) as GameObject;
    }
}
