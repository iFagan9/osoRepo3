using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    EnemyBaseState currentState;
    public EnemyRoamState roamState = new EnemyRoamState();
    public EnemyChaseState chaseState = new EnemyChaseState();
    public EnemyAttackState attackState = new EnemyAttackState();

    public Rigidbody rb;
    private Renderer enemyRenderer;

    public float health;
    public float maxHealth;
    public float knockBackStrength;
    public Color hitColor;

    public float detectionRadius;
    public float attackRadius;
    public float repelRadius;
    public float attackDamage;
    public GameObject playerObject;
    public PlayerHealth playerHealth;
    public Vector3 pDir;
    public float speed;

    public bool canShoot;
    [SerializeField] private GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyRenderer = GetComponentInChildren<MeshRenderer>();
        playerObject = FindFirstObjectByType<PlayerLook>().gameObject;
        playerHealth = playerObject.GetComponent<PlayerHealth>();
        currentState = roamState;
        if (canShoot)
        {
            attackRadius = detectionRadius * .9f;
            gun.SetActive(true);
        }

        currentState.EnterState(this);
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        currentState.UpdateState(this);
        
        if (health <= 0)
        {
            Die();
        }

    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, pDir * 3);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, repelRadius);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        rb.AddForce(-transform.forward * knockBackStrength, ForceMode.Impulse);
        StartCoroutine(flashColor());
    }

    private void Die()
    {
        SwitchState(roamState);
        Destroy(gameObject);
    }

    IEnumerator flashColor()
    {
        Color prevColor;
        prevColor = enemyRenderer.material.color;
        enemyRenderer.material.color = hitColor;
        yield return new WaitForSeconds(.5f);
        enemyRenderer.material.color = prevColor;
    }
}
