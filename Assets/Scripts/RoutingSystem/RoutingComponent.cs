using UnityEngine;
using System.Collections;
using System;

public class RoutingComponent : MonoBehaviour
{
    public class RoutingOptions
    {
        public RoutingOptions(float kSpeed, RouteOrientation kOrientation, RouteStyle kRouteStyle)
        {
            this.kSpeed = kSpeed;
            this.kOrientation = kOrientation;
            this.kRouteStyle = kRouteStyle;
        }
        public float kSpeed;
        public RouteOrientation kOrientation;
        public RouteStyle kRouteStyle;
    }

    public enum RouteStyle
    {
        Line
    }
    public enum RouteOrientation
    {
        Left,
        Right
    }
    
    private RoutingComponent.RoutingOptions kRoutingOptions = new RoutingOptions(1f, RouteOrientation.Right, RouteStyle.Line);


    void Start ()
    {
    }

    public RoutingComponent.RoutingOptions CurrentRoutingOptions
    {
        get
        {
            return this.kRoutingOptions;
        }
        set
        {
            this.kRoutingOptions = value;
            this.ApplyConfig();
        }
    }

    private void ApplyConfig()
    {
        Vector3 rotation = this.kRoutingOptions.kOrientation == RouteOrientation.Right ? new Vector3(0f, 0f, -90f) : new Vector3(0f, 0f, 90f);
        transform.Rotate(rotation);
    }

    void Update()
    {
        float delta = Time.deltaTime;
        Vector3 speed = Vector3.zero;
        if (this.kRoutingOptions.kRouteStyle == RouteStyle.Line)
        {
           speed += new Vector3(delta * this.kRoutingOptions.kSpeed, 0f, 0f);
        }
        if (this.kRoutingOptions.kOrientation == RouteOrientation.Left)
        {
            speed = -speed;
        }
        speed.z = 0f;
        base.transform.position += speed;
    }

    public void RotateSprite(float x, float y, float z)
    {
        base.transform.Rotate(x, y, z);
    }
}
