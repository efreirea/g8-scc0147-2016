using UnityEngine;
using System.Collections;
using System;

public class EnemySpaceship : Enemy
{
    public override EnemyManager.EnemyType EnemyType
    {
        get
        {
            return EnemyManager.EnemyType.EnemySpaceship;
        }
    }
}
