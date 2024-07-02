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
    /// <summary>
    /// Variable for Boss' max starting health
    /// </summary>
    public float bossHealth = 100f;

    [SerializeField]
    GameObject teleMesh;

    /// <summary>
    /// Variables to determine Boss' combat statistics
    /// </summary>
    [Header("Combat")]
    [SerializeField]
    float attackCool = 1.5f;
    [SerializeField]
    float attackRange = 3f;
    [SerializeField]
    float aggroRange = 4f;

    /// <summary>
    /// Variables for Boss' AI
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
    /// Variable to attach asset mesh for loot dropped
    /// </summary>
    [SerializeField]
    GameObject LootDropped;

    /// <summary>
    /// Attaching/Referencing respective components and gameobjects on start
    /// </summary>
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        enemyHealthSlider.SetMaxHealth(bossHealth);
        teleMesh.SetActive(false);
    }

    /// <summary>
    /// Updating Boss' movement and detection every update
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

        enemyHealthSlider.SetHealth(bossHealth);
    }

    /// <summary>
    /// Deducts health from Boss based on damage dealt by player and kills when 0
    /// </summary>
    /// <param name="amt"></param>
    public void TakeDamage(float amt)
    {
        bossHealth -= amt;
        if (bossHealth <= 0f)
        {
            Die();
        }
    }

    /// <summary>
    /// Removes the Boss from the scene upon death and spawns respective loot asset
    /// </summary>
    public virtual void Die()
    {
        Destroy(gameObject);
        DropLoot();
        teleMesh.SetActive(true);
    }

    /// <summary>
    /// Spawns the gameobject attached where the Boss is killed
    /// </summary>
    void DropLoot()
    {
        GameObject lootInstance = Instantiate(LootDropped, transform.position, LootDropped.transform.rotation);
    }

    /// <summary>
    /// Start and end range for Boss' attack animation to determine when the player is hurt by the Boss
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
    /// Highlights the Boss' detection range for when aggro-ed or attack
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
