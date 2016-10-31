using UnityEngine;
using System.Collections;
using System;

public class Asteroid : Enemy
{
    public override EnemyManager.EnemyType EnemyType
    {
        get
        {
            return EnemyManager.EnemyType.Asteroid;
        }
    }
}
