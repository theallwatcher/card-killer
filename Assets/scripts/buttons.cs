using UnityEngine;

public class buttons : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] player player;
   

    public void AtackTemp() { 

        player.AtackEnemy(10);
    }
    public void HealTemp() { 
        
        player.DoHeal(10);
    }
    public void blockTemp() { 
        
        player.AddDefense(5);
    }

    public void EndTurn() { 
    
        gameManager.PlayerTurnEnd();
    }
}
