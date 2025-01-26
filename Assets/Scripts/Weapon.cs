using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] public int attackDamage = 10; // Base attack damage
    [SerializeField] public float range = 5f;      // Weapon range
    [SerializeField] public float cooldown = 5f;   // Cooldown time (in seconds)
    private float lastAttackTime = -0f; // Tracks when the weapon was last used

    // Method to attempt an attack
    public bool TryAttack(Player player)
    {
         //imposto il danno dal player
        attackDamage += player.GetattackPower();

        Debug.Log(Time.time);
        Debug.Log(lastAttackTime);
        if (Time.time >= lastAttackTime + cooldown)
        {
            PerformAttack(player);
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
    private void PerformAttack(Player player)
    {
        Debug.Log("Perform attack!");
        GameObject go = Instantiate(BulletModel);
        var bullet = go.GetComponent<Bullet>();
        bullet.weapon = this;

        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(v3);

        var playerPos = player.transform.position;
        bullet.transform.position = playerPos;
        bullet.currentDirection = new Vector2(mousePos.x - playerPos.x, mousePos.y - playerPos.y).normalized;
    }

    public int GetDamage(){
        return attackDamage;
    }
}


