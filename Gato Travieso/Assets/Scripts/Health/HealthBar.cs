using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField] private Health playerHealth;
    [SerializeField] private Image currenthealthBar;
    




    // Update is called once per frame
    void Update() {

        if (playerHealth.currentHealth == 4)
        {
            currenthealthBar.fillAmount = 1f;
        }
        else if (playerHealth.currentHealth == 3)
        {
            currenthealthBar.fillAmount = 0.7f;
        }
        else if (playerHealth.currentHealth == 2)
        {
            currenthealthBar.fillAmount = 0.5f;
        }
        else if (playerHealth.currentHealth == 1)
        {
            currenthealthBar.fillAmount = 0.2f;
        }
        else if (playerHealth.currentHealth == 0)
        {
            currenthealthBar.fillAmount = 0f;
        }

    }
}
