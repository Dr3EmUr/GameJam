using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    [Header("Item Stats")]
    public string itemName;
    public int AttackBonusItem = 0; // Bonus to attack power
    public int DefenseBonusItem = 0; // Bonus to defense
    public int AgilityBonusItem = 0; // Bonus to agility
    public int StaminaBonusItem = 0; // Bonus to max stamina

}
