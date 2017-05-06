using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnSystem : MonoBehaviour {
    GameObject Level;
    GameObject[] playerUnit;
    GameObject[] enemyUnits;
    public Transform[] selectableTiles;

    public int turnCount = 0;
    bool isWon = false;
    bool isSelected;
    int whosFirst;
    public enum battleState {
        start, player,
        enemy, lose, win, end
    }
    public enum turnState
    {
        move, attack, end
    }

    public battleState currentBattleState;
    public turnState currentTurnState;

	// Use this for initialization
	void Start () {
        currentBattleState = battleState.start;
	}
	
	// Update is called once per frame
	void Update () {
        switch(currentBattleState)    {
            case (battleState.start):
                // Start of the battle
                // Where the counting of turns happen
                break;
            case (battleState.player):
                // Player input registers
                break;
            case (battleState.enemy):
                // Enemy AI here
                break;
            case (battleState.lose):
                break;
            case (battleState.win):
                break;
            case (battleState.end):
                break;
        }
	}

    public void intiate()
    {
        Level.SetActive(true);
        if (!isWon)
        {
            whosFirst = Random.Range(1, 2);
            if(whosFirst == 1)
            {
                // PlayerTurn goes Here
                currentBattleState = battleState.player;
            }
            else
            {
                // EnemyTurn goes Here
                currentBattleState = battleState.enemy;
            }
        }
    }
    public void playerTurn()
    {
        if(currentBattleState == battleState.player)
        {
            // Player move here
        }
        
    }

    //public void playerMove()
    //{
    //    if (isSelected)
    //    {
    //        switch(currentTurnState)
    //        {
    //            case (turnState.move):
    //                // Move() here
    //                Move();
    //                break;
    //            case (turnState.attack):
    //                // Attack() here
    //                break;
    //            case (turnState.end):
    //                // moved = true 
    //                break;
    //        }
    //    }
    //}

    //  public void Move()
    //  {
    //      if(currentTurnState == turnState.move)
    //      {
    //          // Selected Player Unit gains the Transform of the Selected Tile
    //          OnMouseOver();
    //    }
    //}

    //public void OnMouseOver()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        // Select the object
    //    }
    //}

}
