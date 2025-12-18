using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private player player;
    GameManager gameManager;

    [Header("enemy stats")]
    public int health = 60;
    public int maxHealth = 60;
    public int defense = 0;
    public int attack = 10;
    bool isdead = false;
    bool canDicide = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        player = FindFirstObjectByType<player>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update() {

        if (health <= 0 && isdead == false) {

            health = 0;
            isdead = true;
            gameManager.curentTurn = GameManager.turn.eDead;
            Destroy(gameObject);
            Debug.Log("ded E");
        }
        if (defense < 0) {

            defense = 0;
        }
    }

    public void DecideMove() {

        if (canDicide == true){
            canDicide = false;
            int rMove = Random.Range(0, 2);
            StartCoroutine(DoMove(rMove));
            

        }
    }

    IEnumerator DoMove(int rMove) {

        yield return new WaitForSeconds(2);
        if (rMove == 0){

            AtackPlayer(attack);
        }
        else{

            AddDefense(5);
        }

        gameManager.curentTurn = GameManager.turn.player;
        canDicide = true;
    }

    public void AtackPlayer(int damage) {

        Debug.Log("atack E");
        player.GetHit(damage);
    }

    public void GetHit(int damage){

        if (defense > 0){

            int trueDamage = damage - defense;
            defense = defense - damage;
            if (trueDamage < 0){

                trueDamage = 0;
            }
            health = health - trueDamage;
            Debug.Log("clunk E");
        }
        else{

            health = health - damage;
            Debug.Log("au E");
        }
    }

   /* public void DoHeal(int amount){

        if (health + amount > maxHealth){

            health = maxHealth;
            Debug.Log("hp max heal");
        }
        else{
            health = health + amount;
            Debug.Log("aaaa");
        }
    }
   */

    public void AddDefense(int amount){

        defense += amount;
        Debug.Log("gard up E");
    }
}
