using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	[SerializeField] private float attackCooldown;
	private Animator anim;
	private PlayerMovement playerMovement;
	private float cooldownTimer = Mathf.Infinity;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		playerMovement = GetComponent<PlayerMovement>();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)	&&	cooldownTime > attackCooldown	&&	playerMovement.canAttack())
			Attack();

		cooldownTimer += Time.deltaTime;

	public void Attack() {
			anim.SetTrigger("attack");
			cooldownTimer = 0;
	}
}
