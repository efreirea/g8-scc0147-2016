using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player
{
    private string kName = string.Empty;
    private int kScore = 0;
    private int kBestScore = 0;
    private int kLevel = 1;

    public Player(string kName)
    {
        this.kName = kName;
    }

    public string Name
    {
        get
        {
            return this.kName;
        }
    }

    public int Score
    {
        get
        {
            return this.kScore;
        }
        set
        {
            if (value > this.kBestScore)
                this.kBestScore = value;
            this.kScore = value;
        }
    }

    public int BestScore
    {
        get
        {
            return this.kBestScore;
        }
    }

    public int Level
    {
        get
        {
            return this.kLevel;
        }
        set
        {
            this.kLevel = value;
        }
    }
}