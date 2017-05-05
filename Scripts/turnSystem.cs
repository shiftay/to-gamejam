using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnSystem : MonoBehaviour {
    GameObject Level;
    GameObject[] playerUnit;
    GameObject[] enemyUnits;

    public int turnCount = 0;
    bool isWon = false;
    int whosFirst;
    public enum battleState {
        start, player,
        enemy, lose, win, end
    }

    public battleState currentState;

	// Use this for initialization
	void Start () {
        currentState = battleState.start;
	}
	
	// Update is called once per frame
	void Update () {
        switch(currentState)    {
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
                currentState = battleState.player;
            }
            else
            {
                // EnemyTurn goes Here
                currentState = battleState.enemy;
            }
        }
    }
    public void playerTurn()
    {
        if(currentState == battleState.player)
        {
            if()
        }
    }
}
