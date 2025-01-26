using UnityEngine;

public class Entity : MonoBehaviour
{
    // Parametri base per tutte le entità
    [Header("Entity Stats")]
    public int baseDamage = 1;
    public int speed = 2;
    public int health = 5;
    public int maxHealth = 5;

    [Header("State")]
    protected bool isAlive = true;

    // Metodo per applicare danno all'entità
    public virtual void TakeDamage(int damage)
    {
        if (!isAlive) return;

        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    // Metodo per curare l'entità
    public virtual void Heal(int amount)
    {
        if (!isAlive) return;

        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    // Metodo per gestire la morte dell'entità
    protected virtual void Die()
    {
        isAlive = false;
        // Aggiungere logica specifica per la morte (ad esempio, animazioni o distruzione)
        Debug.Log($"{gameObject.name} è morto.");
    }

    // Metodo per spostare l'entità
    public virtual void Move(Vector3 direction)
    {
        if (!isAlive) return;

        transform.Translate( direction * speed * Time.deltaTime);
    }

    // Start viene chiamato una volta prima dell'esecuzione di Update
    protected virtual void Start()
    {

    }

    // Update viene chiamato una volta per frame
    protected virtual void Update()
    {
        // Logica generale per tutte le entità
    }

    protected virtual void FixedUpdate()
    {
        // Logica generale per tutte le entità
    }
}
