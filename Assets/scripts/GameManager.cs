using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum turn{
       
        player,
        enemy,
        eDead
    }
    
    public turn curentTurn = turn.player;
    [SerializeField] List<GameObject> buttons;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemySpawnpoin;
    Enemy enemy;
    player player;

    bool canEDead = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        enemy = FindFirstObjectByType<Enemy>();
        player = FindFirstObjectByType<player>();
    }

    // Update is called once per frame
    void Update(){

        switch (curentTurn) { 
            case turn.player:
                PlayerTurn();
            break;
            case turn.enemy:
                EnemyTurn();
            break;
            case turn.eDead:
                EDeadTurn();
            break;
        }
    }

    public void PlayerTurn() {
        //get cards
        for (int i = 0; i < buttons.Count; i++){

            buttons[i].SetActive(true);
        }
    }

    public void PlayerTurnEnd() {

        for (int i = 0; i < buttons.Count; i++){

            buttons[i].SetActive(false);

        }

        curentTurn = turn.enemy;
    }

    public void EnemyTurn() { 

        enemy.DecideMove();
    }

    public void EDeadTurn() {

        if (canEDead == true) {

            canEDead = false;
            StartCoroutine(EDead());
        }
      

    }

    IEnumerator EDead() {

        yield return new WaitForSeconds(2);

        //new cards?

        Instantiate(enemyPrefab,enemySpawnpoin.transform.position,enemySpawnpoin.transform.rotation);
        //respawn enemy
        player.GetEnemy();
        enemy = FindFirstObjectByType<Enemy>();

        curentTurn = turn.player;
        canEDead = true;
    }
}
