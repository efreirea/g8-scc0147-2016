using UnityEngine;

public class MainMenuGameState : GameStateBase
{
    public MainMenuGameState()
    {
        Debug.Log("MainMenuGameState");
    }

    public override void Startup()
    {
        GameManager.Instance.RequestState(GameManager.GameStateType.Simulation);
    }
}