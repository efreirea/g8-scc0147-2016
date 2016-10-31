using System;
using System.Collections.Generic;
using UnityEngine;

public class AttributesComponent : MonoBehaviour
{
    public enum AttributeType
    {
        Health,
        Speed,
        Damage,
        Defense
    }
    public class Attribute
    {
        private AttributeType kType;
        private float kValue;
        private string kName;
        private float kMax;
        private float kMin;

        public Attribute(AttributeType kType, string kName, float kValue, float kMin, float kMax)
        {
            this.kType = kType;
            this.kName = kName;
            this.kMin = kMin;
            this.kMax = kMax;
            this.Value = kValue;
        }

        public float Value
        {
            get { return this.kValue; }
            set { this.kValue = Math.Max(this.kMin,Math.Min(this.kMax,value)); }
        }

        public void Delta(float value)
        {
            this.Value += value;
        }

        public float Percent
        {
            get { return this.kValue / this.kMax; }
        }

        public float Percent2
        {
            get { return 1f - this.kValue / this.kMax; }
        }

        public bool IsZero
        {
            get { return this.kValue <= 0f; }
        }
    }

    private Dictionary<AttributeType, Attribute> kAllAtributes = new Dictionary<AttributeType, Attribute>();
    public AttributesComponent()
    {

    }

    void Start()
    {
        this.kAllAtributes.Add(AttributeType.Health, new Attribute(AttributeType.Health, "Health", 100f, 0f, 100f));
        this.kAllAtributes.Add(AttributeType.Damage, new Attribute(AttributeType.Damage, "Damage", 1f, 0f, 2f));
        this.kAllAtributes.Add(AttributeType.Defense, new Attribute(AttributeType.Defense, "Defense", 0f, 0f, 1f));
        this.kAllAtributes.Add(AttributeType.Speed, new Attribute(AttributeType.Speed, "Speed", 1f, 1f, 2f));
    }

    public float GetValue(AttributeType type)
    {
        return this.GetAttribute(type).Value;
    }

    public Attribute GetAttribute(AttributeType type)
    {
        Attribute att = null;
        kAllAtributes.TryGetValue(type, out att);
        return att;
    }

    public void ApplyDamage(float amount)
    {
        Enemy enemy = base.GetComponent<Enemy>();
        if (enemy != null && !enemy.CanBeDamaged)
            return;

        Attribute health = this.GetAttribute(AttributeType.Health);
        Attribute defense = this.GetAttribute(AttributeType.Defense);
        health.Delta(-defense.Percent2 * amount);
        if (health.IsZero)
        {
            this.Explode();
        }
    }

    public float CalculateDamage(float amount)
    {
        return this.GetValue(AttributeType.Damage) * amount;
    }

    public float GetSpeedMultiply()
    {
        return this.GetValue(AttributeType.Speed);
    }

    private void Explode()
    {
        Enemy enemy = base.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.Explode();
        }
        Spaceship spaceship = base.GetComponent<Spaceship>();
        if (spaceship != null)
        {
            spaceship.Explode();
        }
    }
}