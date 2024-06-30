/*
 * Author: Livinia Poo
 * Date: 26/06/2024
 * Description: 
 * Script to create enemy detection and attacks
 */

using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    /// <summary>
    /// Variable for enemy's max starting health
    /// </summary>
    [SerializeField]
    public float enemyHealth = 50f;

    /// <summary>
    /// Variables to determine the combat statistics of the enemy
    /// </summary>
    [Header("Combat")]
    [SerializeField]
    float attackCool = 1.5f;
    [SerializeField]
    float attackRange = 3f;
    [SerializeField]
    float aggroRange = 4f;

    /// <summary>
    /// Variables for enemy's AI
    /// </summary>
    GameObject player;
    NavMeshAgent agent;
    Animator animator;
    float timeBtwnAttack;
    float newDestCool = 0.5f;

    /// <summary>
    /// Referencing to Enemy Health Bar script to apply healthbar on enemy
    /// </summary>
    public EnemyHealthBar enemyHealthSlider;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        enemyHealthSlider.SetMaxHealth(enemyHealth);
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

        enemyHealthSlider.SetHealth(enemyHealth);
    }

    public void TakeDamage(float amt)
    {
        enemyHealth -= amt;
        if (enemyHealth <= 0f )
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
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
