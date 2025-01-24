using UnityEngine;

public class Enemy : Entity
{
    [Header("Enemy Stats")]
    [SerializeField] private int livello = 1; // Livello del nemico
    [SerializeField] private int dannoBase = 1; // Danno base del nemico

    public int Livello => livello;

    // Metodo per infliggere danni al giocatore
    public void AttaccaGiocatore(Entity giocatore)
    {
        if (!isAlive) return;

        int dannoInflitto = CalcolaDanno();
        giocatore.TakeDamage(dannoInflitto);
        Debug.Log($"Il nemico {gameObject.name} ha inflitto {dannoInflitto} danni al giocatore.");
    }

    // Calcola il danno basato sul livello del nemico
    private int CalcolaDanno()
    {
        return dannoBase + livello; // Aggiunge il livello al danno base
    }

    // Logica specifica della morte del nemico
    protected override void Die()
    {
        base.Die();
        Debug.Log($"{gameObject.name} (Livello {livello}) è stato sconfitto.");
    }
}
