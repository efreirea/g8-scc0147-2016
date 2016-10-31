using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour
{
    private float kSpeed = 7f;
    

	void Start ()
    {
        base.transform.position = new Vector2(0f, 0f);
    }

    void Update()
    {
        float delta = Time.deltaTime;
        float speed = delta * kSpeed;
        Vector2 pos = base.transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed;
        }

        base.transform.position = pos;
    }


    void FixedUpdate()
    {
        WeaponSystem weapon = base.GetComponent<WeaponSystem>();
        if (Input.GetKeyUp(KeyCode.Space))
        {
            weapon.Fire(WeaponSystem.WeaponType.Missile);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
