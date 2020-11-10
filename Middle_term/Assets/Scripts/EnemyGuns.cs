using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuns : MonoBehaviour
{
    public Transform muzzleTransform;
    public GameObject bulletPrefab;
    public float bulletVelocity = 100.0f;
    private float shootrate = 0.1f;
    private float shoottime = 0;
    // Update is called once per frame

    public void Shoot()
    {
        shoottime += Time.deltaTime;
        if (shoottime > shootrate)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzleTransform.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(muzzleTransform.up * bulletVelocity, ForceMode.Force);
            shoottime = 0;
        }

    }

}
