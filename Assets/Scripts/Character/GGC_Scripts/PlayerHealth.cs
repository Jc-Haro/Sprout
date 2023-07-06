using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        //This is compleatly unnecesary btw, necesitamos una animacion de game over
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (healthBar.fillAmount >= 0.60)
        {
            healthBar.color = Color.green;
        }
        else if (healthBar.fillAmount >= 0.4)
        {
            healthBar.color = new Color(1, 0.4f, 0.07f, 1); //105 255
        }
        else
        {
            healthBar.color = Color.red;
        }
    }

}
