using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public enum GameStateType
    {
        Startup,
        MainMenu,
        Simulation,
        Quit
    }
    public enum GameFlow
    {
        Pause,
        Running
    }

    private static GameManager kInstance;
    private GameStateType kGameStateType = GameStateType.Startup;
    private GameStateType kNextGameStateType = GameStateType.MainMenu;
    private GameStateBase kGameState = new GameStateBase();

    public GameManager()
    {
        GameManager.kInstance = this;
    }

    public static GameManager Instance
    {
        get
        {
            if (kInstance == null)
                new GameManager();
            return kInstance;
        }
    }
    
	void Start ()
    {
        PlayerManager.Instance.NewPlayer("Player");
	}
	
	void Update ()
    {
        this.kGameState.Update();
    }

    void FixedUpdate()
    {
        this.kGameState.FixedUpdate();
        if (this.kGameStateType != kNextGameStateType)
        {
            SwitchState();
        }
    }

    public void RequestState(GameStateType nextStateType)
    {
        this.kNextGameStateType = nextStateType;
    }

    private void SwitchState()
    {
        if (this.kGameStateType != kNextGameStateType)
        {
            kGameState.CleanUp();
            GameStateBase nextGameState = null;
            switch (kNextGameStateType)
            {
                case GameStateType.MainMenu:
                    {
                        nextGameState = new MainMenuGameState();
                        break;
                    }
                case GameStateType.Simulation:
                    {
                        nextGameState = new SimulationGameState();
                        break;
                    }
                case GameStateType.Quit:
                    {
                        nextGameState = new QuitGameState();
                        break;
                    }
            }
            this.kGameStateType = kNextGameStateType;
            this.kGameState = nextGameState;
            nextGameState.Startup();
        }
    }
    
}
