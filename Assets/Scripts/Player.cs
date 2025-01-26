using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Player : Entity
{
    [Header("Player Stats")]
    [SerializeField] private int defense = 1;      // Base defense
    [SerializeField] private int agility = 2;      // Base agility
    [SerializeField] private int stamina = 100;    // Player's current stamina
    [SerializeField] private int maxStamina = 100; // Maximum stamina
    [SerializeField] private float staminaRegenRate = 5f; // Stamina points regenerated per second

    [Header("Weapons")]
    [SerializeField] public GameObject weaponOne; // Prima arma
    [SerializeField] public GameObject weaponTwo; // Seconda arma

    private GameObject currentWeapon; // Arma attualmente 
    private Animator animator;

    private List<Item> inventory = new List<Item>(); // Lista di oggetti raccolti

    protected override void Start()
    {
        base.Start();
        
        EquipWeapon(weaponOne); // Equipaggia la prima arma di default

        Camera.main.GetComponent<CameraScript>().player = transform;
        animator = GetComponent<Animator>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        RegenerateStamina();
        GameManager.CurrentPlayerPosition = transform.position;
    }

    protected override void Update()
    {
        base.Update();

        // Gestisci il cambio di arma
        HandleWeaponSwitch();

        // Sprint logic (consume stamina)
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift) && movement != Vector3.zero && stamina > 0)
        {
            if (ConsumeStamina(10 * Time.deltaTime)) // Sprinting costs stamina
            {
                Move(movement * agility); // Velocità aumentata per lo sprint
            }
        }
        else
        {
            Move(movement); // Movimento normale
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentWeapon != null)
            {
                var weaponComponent = currentWeapon.GetComponent<Weapon>();
                weaponComponent.TryAttack(this);
            }
        }

        var horAxis = Input.GetAxisRaw("Horizontal");
        var vertAxis = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horAxis",horAxis);
        animator.SetFloat("vertAxis",vertAxis);
    }

    // Metodo per equipaggiare un'arma specifica
    private void EquipWeapon(GameObject weaponToEquip)
    {
        if (weaponToEquip == currentWeapon) return; // Se è già equipaggiata, non fare nulla

        currentWeapon = Instantiate(weaponToEquip);

        // Disattiva l'arma attuale (se esiste)
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        // Attiva la nuova arma
        currentWeapon = weaponToEquip;
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
            Debug.Log($"Arma equipaggiata: {currentWeapon.name}");
        }
    }

    // Metodo per gestire il cambio di arma
    private void HandleWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(weaponOne);
                Debug.Log($"Gesemo arama UNO: {currentWeapon.name}");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(weaponTwo);
            Debug.Log($"Gesemo arama DUE: {currentWeapon.name}");
        }
    }

    // Consuma stamina per le azioni
    public bool ConsumeStamina(float amount)
    {
        if (stamina >= amount)
        {
            stamina -= Mathf.RoundToInt(amount);
            return true;
        }
        else
        {
            return false;
        }
    }

    // Rigenera stamina nel tempo
    private void RegenerateStamina()
    {
        if (stamina < maxStamina)
        {
            stamina += Mathf.RoundToInt(staminaRegenRate * Time.deltaTime);
            stamina = Mathf.Min(stamina, maxStamina); // Clamp alla stamina massima
        }
    }

    // Ritorna il valore dell'attacco
    public int GetAttackPower()
    {
        return baseDamage;
    }

    // Calcola i bonus degli oggetti
    public void CalculateStats()
    {
        int totalAttackBonus = 0;
        int totalDefenseBonus = 0;
        int totalAgilityBonus = 0;
        int totalStaminaMaxBonus = 0;

        foreach (Item item in inventory)
        {
            totalAttackBonus += item.AttackBonusItem;
            totalDefenseBonus += item.DefenseBonusItem;
            totalAgilityBonus += item.AgilityBonusItem;
            totalStaminaMaxBonus += item.StaminaBonusItem;
        }
    }

    // Aggiunge un oggetto all'inventario e ricalcola le statistiche
    public void AddItemToInventory(Item item)
    {
        inventory.Add(item);
        Debug.Log($"Oggetto raccolto: {item.itemName}");
        CalculateStats();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Debug.Log("1: " + GameManager.HealthText.name);
        var txt = GameManager.HealthText.GetComponent<TextMeshProUGUI>();

        Debug.Log(txt == null);
        txt.SetText(health.ToString());
    }

    public override void Heal(int amount)
    {
        base.Heal(amount);

        var txt = GameManager.HealthText.GetComponent<Text>();
        txt.text = health.ToString();
    }
    public int GetattackPower (){
        return baseDamage;
    }
}
