using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IPlayer
{

    //[SerializeField] private GameObject playerTablet;
    [SerializeField] private Camera cameraPlayer;
    [SerializeField] private Transform fireExtinguisherPlaceInHands;
    [SerializeField] private Transform tabletPlaceInHands;
    [SerializeField] private Image cursor;

    public const float PlayerHandsRange = 1.8f;

    private StateMachine_Player _playerStateMachine;

    private void Start()
    {
        _playerStateMachine = new StateMachine_Player();
        _playerStateMachine.Initialize(new State_Idle(this));
        HideInteractiveCursor();
    }

    private void Update() { }
    public void ShowInteractiveCursor() => cursor.enabled = true;
    public void HideInteractiveCursor() => cursor.enabled = false;
    public State GetCurrentState() => _playerStateMachine.CurrentState;
    public void SetNewState(State newState) => _playerStateMachine.SetNewState(newState);
}
