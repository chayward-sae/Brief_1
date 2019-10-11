﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the dance stats of a character.
/// 
/// TODO:
///     Nothing, but this class may be a good place to put some helper fuctions when dealing with xp to level conversion and the like.
/// </summary>
public class Stats : MonoBehaviour
{
    /// <summary>
    /// Our current level.
    /// </summary>
    public int level;

    /// <summary>
    /// The current amount of xp we have accumulated.
    /// </summary>
    public int currentXp;

    /// <summary>
    /// The amount of xp required to level up.
    /// </summary>
    public int xpThreshold = 10;
    
    /// <summary>
    /// Our variables used to determine our fighting power.
    /// </summary>
    public int style;
    public int luck; 
    public int rhythm;

    /// <summary>
    /// The Amount of skill points that can distributed amoungst our starting values.
    /// </summary>
    public int availableStartingSkillPoints = 10;
    
    /// <summary>
    /// Called on the very first frame of the game
    /// </summary>
    private void Start()
    {
        // We probably want to call our InitialStats function here.
        InitialStats(availableStartingSkillPoints);
    }

    /// <summary>
    /// A function used to handle setting the intial stats of our game at the begining of the game.
    /// </summary>
    private void InitialStats(Stats.availableStartingSkillPoints)
    {
        Debug.LogWarning("Initial stats has been called");
        // We probably want to set out default level and some default random stats 
        // for our luck, style and rythmn.
        float startingSkillPoints = 
        level = 1;
        style = Random.Range(0f, startingSkillPoints);
        startingSkillPoints -= style;
        float luck = Random.Range(0f, startingSkillPoints);
        startingSkillPoints -= luck;
        float rhythm = startingSkillPoints;


    }

    /// <summary>
    /// A function called when the battle is completed and some xp is to be awarded.
    /// Takes in and store in BattleOutcome from the BattleHandler script which is how much the player has won by.
    /// By Default it is set to 100% victory.
    /// </summary>
    public void CalculateXP(float BattleOutcome)
    {
        Debug.LogWarning("This character needs some xp to be given, the outcome of the fight was: " + BattleOutcome);
        // The result of the battle is coming in which is stored in BattleOutcome .... we probably want to do something with it to calculate XP.

        //Called when we want to display how much xp we won, by default it is 0
        GameEvents.PlayerXPGain(0);

        // We probably also want to check to see if the player can level up and if so do something....
    }

    /// <summary>
    /// A function used to handle actions associated with levelling up.
    /// </summary>
    private void LevelUp()
    {

        //We probably want to increase the player level, the xp threshold and increase our current skill points based on our level.
        GameEvents.PlayerLevelUp(level);
        Debug.LogWarning("Level up has been called");
    }
    
    /// <summary>
    /// A function used to assign a random amount of points ot each of our skills.
    /// </summary>
    public void AssignSkillPointsOnLevelUp(int PointsToAssign)
    {
        Debug.LogWarning("AssignSkillPointsOnLevelUp has been called " + PointsToAssign);

        // We are taking an amount of points to assign in, and we want to assign it to our luck, style and rhythm, we 
        // want some random amount of points added to our current values.
    }

    /// <summary>
    /// Used to generate a number of battle points that is used in combat.
    /// </summary>
    /// <returns></returns>
    public int ReturnBattlePoints()
    {
        // We want to design some algorithm that will generate a number of points based off of our luck,style and rythm, we probably want to add some randomness in our calculation too
        // to ensure that there is not always a draw, by default it just returns 0. 
        // If you right click this function and find all references you can see where it is called.
        Debug.LogWarning("ReturnBattlePoints has been called we probably want to create some battle points based on our stats");
        return 0;
    }

}
