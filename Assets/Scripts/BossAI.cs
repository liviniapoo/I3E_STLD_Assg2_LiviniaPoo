/*
 * Author: Livinia Poo
 * Date: 28/06/2024
 * Description: 
 * Script to create Boss detection, attacks and loot drop
 */

using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    float bossHealth = 100f;

    [Header("Combat")]
    [SerializeField]
    float attackCool = 1.5f;
    [SerializeField]
    float attackRange = 3f;
    [SerializeField]
    float aggroRange = 4f;

    GameObject player;
    NavMeshAgent agent;
    Animator animator;
    float timeBtwnAttack;
    float newDestCool = 0.5f;

    [SerializeField]
    GameObject LootDropped;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);

        if (timeBtwnAttack >= attackCool)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                animator.SetTrigger("attack");
                timeBtwnAttack = 0;
            }
        }
        timeBtwnAttack += Time.deltaTime;

        if (newDestCool <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
        {
            newDestCool = 0.5f;
            agent.SetDestination(player.transform.position);
        }
        newDestCool -= Time.deltaTime;
        transform.LookAt(player.transform);
    }

    public void TakeDamage(float amt)
    {
        bossHealth -= amt;
        if (bossHealth <= 0f)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        DropLoot();
    }

    void DropLoot()
    {
        Instantiate(LootDropped, transform.position, LootDropped.transform.rotation);
    }

    public void StartDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
    }

    public void EndDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
