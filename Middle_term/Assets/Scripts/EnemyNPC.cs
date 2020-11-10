using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyNPC : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    public Transform target;
    public GameObject gunObject;
    public float attackRange = 8.0f;

    private NavMeshAgent _agent = null;
    private EnemyGuns _gun = null;

    //Get gun script later

    // Start is called before the first frame update
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _gun = gunObject.GetComponent<EnemyGuns>();
        healthBar.maxValue = this.GetComponent<DestructibleObject>().MaxHealth;
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        if (Vector3.SqrMagnitude(_agent.transform.position - target.position) < attackRange * attackRange)
        {
            _agent.isStopped = true;
            _agent.transform.LookAt(target);

            _gun.Shoot();

            //SHOOT!
        }
        else
        {
            _agent.isStopped = false;
            _agent.SetDestination(target.position);
        }

    }
    public void UpdateHealthBar(float health)
    {
        healthBar.value = health;

    }
}
