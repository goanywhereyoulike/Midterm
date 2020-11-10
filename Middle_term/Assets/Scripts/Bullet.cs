using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameManager gm;
    [SerializeField]
    private float bulletDamage = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(bulletDamage);
        }
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Enemy"))
        {
            DestructibleObject enemyhealth = other.gameObject.GetComponent<DestructibleObject>();
            if (enemyhealth.CurrentHealth == 0)
            {

                ServiceLocator.Get<GameManager>().UpdateScore(10);
            }
        }
    }
    //private void OnTriggleEnter(Collision collision)
    //{
    //    var damageable = collision.gameObject.GetComponent<IDamageable>();
    //    if (damageable != null)
    //    {
    //        damageable.TakeDamage(bulletDamage);
    //    }

    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        DestructibleObject enemyhealth = collision.gameObject.GetComponent<DestructibleObject>();
    //        if (enemyhealth.CurrentHealth == 0)
    //        {

    //            ServiceLocator.Get<GameManager>().UpdateScore(10);
    //        }
    //    }




    //}
}
