using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    private GameManager gm;
    [SerializeField]
    private float bulletDamage = 10.0f;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            var damageable = other.gameObject.GetComponent<IDamageable>();
            var player = other.gameObject.GetComponent<DestructibleObject>();
            if (damageable != null)
            {
                damageable.TakeDamage(bulletDamage);
                ServiceLocator.Get<GameManager>().UpdateHealthBar(player.CurrentHealth);
            }
            Destroy(gameObject);

            DestructibleObject enemyhealth = other.gameObject.GetComponent<DestructibleObject>();
            if (enemyhealth.CurrentHealth == 0)
            {
                ServiceLocator.Get<GameManager>().UpdateScore(10);
            }
        }

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        var damageable = collision.gameObject.GetComponent<IDamageable>();
    //        if (damageable != null)
    //        {
    //            damageable.TakeDamage(bulletDamage);
    //        }


    //        DestructibleObject enemyhealth = collision.gameObject.GetComponent<DestructibleObject>();
    //        if (enemyhealth.CurrentHealth == 0)
    //        {
    //            ServiceLocator.Get<GameManager>().UpdateScore(10);
    //        }
    //    }




    //}
}
