using UnityEngine;

public class StateMenu_Start : State
{
    private Player _player;
    private GameObject _doorText2;
    private GameObject _helpMenu;
    private GameObject _startMenu;
    public StateMenu_Start(Player player, GameObject doorText2, GameObject helpMenu, GameObject startMenu)
    {
        _player = player;
        _doorText2 = doorText2;
        _helpMenu = helpMenu;
        _startMenu = startMenu;
    }
    public override void Enter()
    {
        base.Enter();

        _doorText2.SetActive(false);
        _helpMenu.SetActive(false);
        //_startMenu.SetActive();

        _startMenu.SetActive(true);
    }
    public override void Exit()
    {
        base.Exit();

        _startMenu.SetActive(false);
    }
}
