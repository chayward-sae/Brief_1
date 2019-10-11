using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class with method (function) to determine the outcome of a dance battle based on the player and NPC that are 
///     dancing off against each other.
///     
/// TODO:
///     Battle needs to use stats and random to determine the winner of the dance off
///       - outcome value to be a float value between 1 and negative 1. 1 being the biggest possible player win over NPC, 
///         through to -1 being the most decimating defeat of the player possible.
/// </summary>
public static class BattleHandler
{
    public static int playerPoints;
    public static int npcPoints;
    /// <summary>
    /// If is -1 npc has won, if retuns 0 battle is draw, if return 1 player has won
    /// </summary>
    public static float battleOutcome;

    public static void Battle(BattleEventData data)
    {

        playerPoints = data.player.ReturnBattlePoints();
        npcPoints = data.npc.ReturnBattlePoints();
        
        if(playerPoints <= 0 || npcPoints <=0)
        {
            Debug.LogWarning("Player or NPC battle points is 0, most likely the logic has not be setup for this yet");
        }

        if(playerPoints > npcPoints)
        {
            Debug.Log("Player has won with" + playerPoints + "points!");
            battleOutcome = 1 - ((float)npcPoints / (float)playerPoints);
            data.player.CalculateXP(battleOutcome);
            battleOutcome = 1;
        }
        else if(npcPoints > playerPoints)
        {
            Debug.Log("NPC has won with" + npcPoints + "points!");
            battleOutcome = 1 - ((float)playerPoints / (float)npcPoints);
            data.npc.CalculateXP(battleOutcome);
            battleOutcome = -1;
        }
        else if(npcPoints == playerPoints)
        {
            Debug.Log("It's a draw!");
            battleOutcome = 0.1f;
            data.player.CalculateXP(battleOutcome);
            data.npc.CalculateXP(battleOutcome);
            battleOutcome = 0;
        }
        else
        {
            Debug.LogWarning("Player or NPC battle points is 0, most likely something has gone wrong with the logic");
        }

        // if the player wins then the battle outcome is 1
        // we probably want to do some sort of check here to see if the player has won...rather than assigning xp everytime.
        // if so set points.    
        // If we wanted to we could also work out if the npc has won or if there is a draw!

        var results = new BattleResultEventData(data.player, data.npc, battleOutcome);
        GameEvents.FinishedBattle(results);
    }
}
