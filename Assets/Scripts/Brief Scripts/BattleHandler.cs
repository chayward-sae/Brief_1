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

        // if the player wins then the battle outcome is 1
        // if the npc has won, then the battle outcome is -1
        // otherwise the outcome is 0 and its a draw;
        battleOutcome = 1;

        // we probably want to do some sort of check here to see if the player has won...rather than assigning xp everytime.
        // if so set points.
        data.player.CalculateXP(battleOutcome);
        battleOutcome = 1;         
        // If we wanted to we could also work out if the npc has won or if there is a draw!

        var results = new BattleResultEventData(data.player, data.npc, battleOutcome);
        GameEvents.FinishedBattle(results);
    }
}
