using UnityEngine;
using System.Collections;

public class Simulator : MonoBehaviour{

    private UI kUI;
    private Logic kLogic;
    private Map kMap;
    private Board kBoard;
    private static Simulator sSingleton;
    private bool kSleep;

    private Simulator()
    {
        kLogic = new Logic();
        kUI = new UI();
        kMap = new Map();
        kBoard = new Board();

        kLogic.Setup(kUI, kLogic, kMap, kBoard);
        kUI.Setup(kUI, kLogic, kMap, kBoard);
        kMap.Setup(kUI, kLogic, kMap, kBoard);
        kBoard.Setup(kUI, kLogic, kMap, kBoard);

        Simulator.sSingleton = this;
    }

    public Simulator Singleton
    {
        get
        {
            return Simulator.sSingleton;
        }
    }

	private void Start ()
    {
        kLogic.Start();
        kUI.Start();
        kMap.Start();
        kBoard.Start();
    }

    private void Update()
    {
        kLogic.Update();
        kMap.Update();
        kBoard.Update();
        kUI.Update();
    }

    private void FixedUpdate()
    {
        if (!Sleep)
        {
            kLogic.FixedUpdate();
            kMap.FixedUpdate();
            kBoard.FixedUpdate();
        }
        kUI.FixedUpdate();
    }

    public bool Sleep
    {
        get
        {
            return this.kSleep;
        }
        set
        {
            this.kSleep = value;
        }
    }
}
