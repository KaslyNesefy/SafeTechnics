using UnityEngine;

public class StateMenu_Help : State
{
    private Player _player;
    private GameObject _helpMenu;
    private GameObject _playerCamera;
    public StateMenu_Help(Player player, GameObject helpMenu, GameObject playerCamera)
    {
        _player = player;
        _helpMenu = helpMenu;
        _playerCamera = playerCamera;
    }
    public override void Enter()
    {
        base.Enter();

        _helpMenu.SetActive(true);
        _playerCamera.SetActive(false);
    }
    public override void Exit()
    {
        base.Exit();

        _helpMenu.SetActive(false);
        _playerCamera.SetActive(true);
    }
}
