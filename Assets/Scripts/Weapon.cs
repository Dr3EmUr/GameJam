using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private int attackDamage = 10; // Base attack damage
    [SerializeField] private float range = 5f;      // Weapon range
    [SerializeField] private float cooldown = 5f;   // Cooldown time (in seconds)
    Player player;

    
    private float lastAttackTime = -Mathf.Infinity; // Tracks when the weapon was last used

   


    // Method to attempt an attack
    public bool TryAttack()
    {
         //imposto il danno dal player
        attackDamage += player.GetattackPower();
        if (Time.time >= lastAttackTime + cooldown)
        {
            PerformAttack();
            lastAttackTime = Time.time; // Update the last attack time
            return true;
        }
        else
        {
            Debug.Log("Weapon is on cooldown!");
            return false;
        }
    }

    // Perform the actual attack logic (placeholder)
    private void PerformAttack()
    {
        // cra proiettile
    }

    public int GetDameage(){
        return attackDamage;
    }
}


