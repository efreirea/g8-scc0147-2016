using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : ManagerBase
{
    private static PlayerManager kInstance;
    private Player kActivePlayer;

    public PlayerManager()
    {
        PlayerManager.kInstance = this;
    }

    public static PlayerManager Instance
    {
        get
        {
            if (PlayerManager.kInstance == null)
                new PlayerManager();
            return PlayerManager.kInstance;
        }
    }

    public Player ActivePlayer
    {
        get
        {
            return this.kActivePlayer;
        }
    }

    public Player NewPlayer(string name)
    {
        this.kActivePlayer = new Player(name);
        return this.kActivePlayer;
    }
}