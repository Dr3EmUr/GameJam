using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] public int attackDamage = 10; // Base attack damage
    [SerializeField] public float range = 5f;      // Weapon range
    [SerializeField] public float cooldown = 5f;   // Cooldown time (in seconds)
    public Player player;

    
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
    public GameObject BulletModel;
    private void PerformAttack()
    {
        GameObject go = Instantiate(BulletModel);
        var bullet = go.GetComponent<Bullet>();
    }

    public int GetDameage(){
        return attackDamage;
    }
}


