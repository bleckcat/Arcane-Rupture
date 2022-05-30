using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float MANA_PER_SEC = 0.1f;
    public int maxHealth = 100;
    public int maxMana = 100;
    public int currentHealth;
    public float currentMana;
    public HealthBar healthBar;
    public ManaBar manaBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        manaBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            UseSkill(33);
        }
    }
    void FixedUpdate()
    {
        print(manaBar.slider.value);
        print(manaBar.slider.maxValue);
        if (currentMana <= maxMana)
        {
            currentMana += MANA_PER_SEC;
            manaBar.slider.value += MANA_PER_SEC;
        }
    }

    void UseSkill(int mana)
    {
        currentMana -= mana;
        manaBar.SetMana(currentMana);
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
