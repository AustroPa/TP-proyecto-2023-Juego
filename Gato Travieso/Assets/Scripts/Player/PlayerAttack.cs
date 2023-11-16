using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] private float attackCooldown;
	private Animator anim;
	private PlayerMovement playerMovement;
	private float cooldownTimer = Mathf.Infinity;

	public Transform attackPos;
	public LayerMask whatIsEnemies;
	public float attackRange;

	public int damage;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		playerMovement = GetComponent<PlayerMovement>();
	}


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()) {
            Attack();

			Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
			for (int i = 0; i < enemiesToDamage.Length; i++) {
				enemiesToDamage[i].GetComponent<EnemyMovement>().TakeDamage(damage);
			}

		}

        cooldownTimer += Time.deltaTime;


	}

	void OnDrawGizmosSelected() { 
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPos.position,attackRange);
	}


	public void Attack()
	{
		anim.SetTrigger("attack");
		cooldownTimer = 0;
	}

}