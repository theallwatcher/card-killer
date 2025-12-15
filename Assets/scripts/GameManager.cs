using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum turn{
        player,
        enemy,
        eDead

    }
    
    public turn curentTurn = turn.player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

    }

    public void EnemyTurn() { 


    }

    public void EDeadTurn() { 
    

    }
}
