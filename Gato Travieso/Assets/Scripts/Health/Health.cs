using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField] private float startingHealth;
	public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

	private void Awake() {
		currentHealth = startingHealth;
        anim = GetComponent<Animator>();
	}

	
	// Update is called once per frame


	public void TakeDamage(float _damage) {

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

		if (currentHealth > 0)
		{

            anim.SetTrigger("hurt");
		}
		else {
            if (!dead) { 
            anim.SetTrigger("died");
            GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
	}

    public void AddHealth(float _value) {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(-1);

        }

    }

}
