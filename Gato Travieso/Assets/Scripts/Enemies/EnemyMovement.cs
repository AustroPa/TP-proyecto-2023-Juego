using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    private float dazedTime;
    public float startDazedTime;
    public float health;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void OnDisable()
    {
        anim.SetBool("isRunning", false);
    }

    private void Update()
    {
        if (health > 0 )
        {
            if (dazedTime <= 0)
            {
                if (movingLeft)
                {
                    if (enemy.position.x >= leftEdge.position.x)
                        MoveInDirection(-1);
                    else
                        DirectionChange();
                }
                else
                {
                    if (enemy.position.x <= rightEdge.position.x)
                        MoveInDirection(1);
                    else
                        DirectionChange();
                }
            }
            else { 
            dazedTime -=Time.deltaTime; 
            }

        }
        else {
            dazedTime = Mathf.Infinity;
            //dead
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("isRunning", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("isRunning", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }


private void OnDrawGizmos(){
		Gizmos.DrawWireSphere(leftEdge.transform.position,0.5f);
		Gizmos.DrawWireSphere(rightEdge.transform.position,0.5f);
		Gizmos.DrawLine(leftEdge.transform.position, rightEdge.transform.position);
	}
    
	public void TakeDamage(int damage) {
        anim.SetBool("isRunning", false);
		anim.SetBool("isAttacked", true);
        dazedTime = startDazedTime;
			health -= damage;
		Debug.Log("Damage taken!");
	}
   
}

