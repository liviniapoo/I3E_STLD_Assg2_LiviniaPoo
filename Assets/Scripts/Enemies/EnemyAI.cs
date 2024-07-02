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

    /// <summary>
    /// Attaching/Referencing respective components and gameobjects on start
    /// </summary>
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        enemyHealthSlider.SetMaxHealth(enemyHealth);
    }

    /// <summary>
    /// Updating enemy's movement and detection every update, updating enemy healthbar
    /// </summary>
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

    /// <summary>
    /// Deducts health from enemy based on damage dealt by player and kills when 0
    /// </summary>
    /// <param name="amt"></param>
    public void TakeDamage(float amt)
    {
        enemyHealth -= amt;
        if (enemyHealth <= 0f )
        {
            Die();
        }
    }

    /// <summary>
    /// Removes the enemy from the scene upon death
    /// </summary>
    public virtual void Die()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Start and end range for enemy's attack animation to determine when the player is hurt by the enemy
    /// </summary>
    public void StartDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
    }
    public void EndDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
    }

    ///<summary>
    /// Highlights the enemy's detection range for when aggro-ed or attack
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

}
