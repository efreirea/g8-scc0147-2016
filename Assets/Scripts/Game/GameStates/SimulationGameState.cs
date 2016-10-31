using UnityEngine;

public class SimulationGameState : GameStateBase
{
    private GameManager.GameFlow kGameFlow = GameManager.GameFlow.Running;

    public SimulationGameState()
    {
        Debug.Log("SimulationGameState");
    }

    public override void Startup()
    {
        LevelManager levelm = LevelManager.Instance;
        if (levelm.CurrentLevel == null)
        {
            levelm.Switch(new Level(levelm, new LevelData()));
        }
    }

    public override void Update()
    {
        if (kGameFlow == GameManager.GameFlow.Running)
        {
            PlayerManager.Instance.Update();
            EnemyManager.Instance.Update();
            LevelManager.Instance.Update();
        }
    }

    public override void FixedUpdate()
    {
        if (kGameFlow == GameManager.GameFlow.Running)
        {
            PlayerManager.Instance.FixedUpdate();
            EnemyManager.Instance.FixedUpdate();
            LevelManager.Instance.FixedUpdate();
        }
    }
}