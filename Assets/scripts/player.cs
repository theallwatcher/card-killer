using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class player : MonoBehaviour
{
    [Header("player stats")]
    public int health = 100;
    public int maxHealth = 100;
    public int defense = 0;
    bool isdead = false;

    [Header("ui")]
    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthText;
    

    Enemy enemy;

    public void GetEnemy()
    {

        enemy = FindFirstObjectByType<Enemy>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetEnemy();
        healthText.text = health + "/" + maxHealth;
    }

    // Update is called once per frame
    void Update(){

        if (health <= 0&&isdead == false) {
            
            health = 0;
            isdead = true;
            Debug.Log("ded");
        }
        if (defense < 0) { 
        
            defense = 0;
        }
    }

    public void AtackEnemy(int damage) {

        Debug.Log("attack");
        enemy.GetHit(damage);
    }

    public void GetHit(int damage){

        if (defense > 0){

            int trueDamage = damage - defense;
            defense = defense - damage;
            if (trueDamage < 0) {

                trueDamage = 0;
            }
            health = health - trueDamage;
            Debug.Log("clunk");
        }
        else { 
        
            health = health - damage;
            Debug.Log("au");
        }

        float newWidth = (float)health/maxHealth;
        healthBar.fillAmount = newWidth;
        healthText.text = health + "/" + maxHealth;
    }

    public void DoHeal(int amount){

        if (health + amount > maxHealth){

            health = maxHealth;
            Debug.Log("hp max heal");
        }
        else { 
            health = health + amount;
            Debug.Log("aaaa");
        }

        float newWidth = (float)health / maxHealth;
        healthBar.fillAmount = newWidth;
        healthText.text = health + "/" + maxHealth;
    }

    public void AddDefense(int amount){ 
    
        defense += amount;
        Debug.Log("gard up");
    }

}
