using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Gun : MonoBehaviour
{
  
    public Transform muzzleTransform;
    private float nextTimeToFire = 0.0f;
    public float firerate = 10.0f;
    private float dividedFireRate = 0.0f;
    public float damage = 10.0f;
    public float range = 100.0f;
    public float ImpactForce = 100.0f;
    public Camera fpsCamera;
    public VisualEffect muzzleFlash;

    public GameObject impacteffect;
    // Update is called once per frame

    private void Start()
    {
        muzzleFlash.Stop();
        dividedFireRate = 1 / firerate;
    }
    private void Update()
    {
        Fire();
    }


    private void Fire()
    {
        if (Input.GetButton("Fire1") && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + dividedFireRate;
            muzzleFlash.Play();
            PlayerShoot();

        }


    }

    public void PlayerShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);


            IDamageable target = hit.transform.GetComponent<IDamageable>();
            DestructibleObject enemy = hit.transform.GetComponent<DestructibleObject>();
            EnemyNPC Enemy = hit.transform.GetComponent<EnemyNPC>();
            if (target != null&& Enemy != null)
            {
                target.TakeDamage(damage);
                Enemy.UpdateHealthBar(enemy.CurrentHealth);
                
               
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }

            GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2.0f);
            
            if (enemy != null && enemy.CurrentHealth == 0)
            {
                ServiceLocator.Get<GameManager>().UpdateScore(10);
            }

        }
    }

}
