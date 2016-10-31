using UnityEngine;
using System.Collections;

public class Projectile : Destroyable
{
    public delegate void ProjectileCollisionCallback(GameObject projectile, GameObject target);
    private bool kFromPlayer = true;
    private ProjectileCollisionCallback kProjectileCollisionCallBack;
    private GameObject kLastTarget = null;
    private WeaponSystem.WeaponData kWeaponData;

    public void SetProjectileCollisionCallBack(ProjectileCollisionCallback kProjectileCollisionCallBack)
    {
        this.kProjectileCollisionCallBack = kProjectileCollisionCallBack;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //if (this.kProjectileCollisionCallBack != null)
        //{
            GameObject target = col.gameObject;
            if (target.tag.Equals("Spaceship"))
            {
                if (FromPlayer)
                {
                    return;
                }
            }
            else
            {
                Projectile projectile2 = target.GetComponent<Projectile>();
                if (projectile2 != null)
                {
                    if (projectile2.FromPlayer == this.FromPlayer)
                        return;
                }
                else
                {
                    if (!this.FromPlayer)
                        return;
                }
            }
            // BUG CONHECIDO DO UNITY, OnTriggerEnter2D PODE SER CHAMADO MULTIPLAS VEZES PARA O MESMO TARGET. DÁ STACKOVERFLOW SE NÃO FOR TRATADO.
            if (kLastTarget != target)
            {
                kLastTarget = target;
                DamageTarget(target);
                ///this.kProjectileCollisionCallBack(base.gameObject, target.gameObject);
            }
       // }
    }

    private void DamageTarget(GameObject target)
    {
        AttributesComponent targetAttrComp = target.GetComponent<AttributesComponent>();
        if (targetAttrComp != null)
        {
            targetAttrComp.ApplyDamage(this.kWeaponData.kDamage);
        }
        Projectile projectile = target.GetComponent<Projectile>();
        if (projectile != null && projectile.CanBeDamaged)
        {
            projectile.Explode();
        }
        this.Explode();
    }

    public WeaponSystem.WeaponData WeaponData
    {
        get
        {
            return this.kWeaponData;
        }
        set
        {
            this.kWeaponData = value;
            this.ApplyData();
        }
    }

    private void ApplyData()
    {
        RoutingComponent.RouteOrientation orientation = FromPlayer? RoutingComponent.RouteOrientation.Right : RoutingComponent.RouteOrientation.Left;
        RoutingComponent.RoutingOptions options = new RoutingComponent.RoutingOptions(this.kWeaponData.kSpeed, orientation, this.kWeaponData.kRouteStyle);
        base.GetComponent<RoutingComponent>().CurrentRoutingOptions = options;
    }

    // Por favor, ajuste o from Player antes do WeaponData
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

    public void Explode()
    {
        GameObject.Destroy(base.gameObject);
    }
}
