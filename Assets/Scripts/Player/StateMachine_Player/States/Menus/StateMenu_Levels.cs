using UnityEngine;

public class StateMenu_Levels : State
{
    private Player _player;
    private GameObject _tableTablet;
    private GameObject _playerTablet;
    private GameObject _startMenu;


    public StateMenu_Levels(Player player, GameObject tableTablet, GameObject playerTablet, GameObject startMenu)
    {
        _player = player;
        _tableTablet = tableTablet;
        _playerTablet = playerTablet;
        _startMenu = startMenu;
    }

    public override void Enter()
    {
        base.Enter();

        _tableTablet.SetActive(false);
        _playerTablet.SetActive(true);
        _startMenu.SetActive(false);
    }
    public override void Exit()
    {
        base.Exit();

    }
    public override void Update()
    {
        base.Update();
        //if (Input.GetKeyDown(KeyCode.Alpha1) { _player. }
        //playerMode = Input.GetKeyDown() ? 1 : playerMode;
        //playerMode = Input.GetKeyDown(KeyCode.Alpha2) ? 2 : playerMode;
        //playerMode = Input.GetKeyDown(KeyCode.Alpha3) ? 3 : playerMode;
        //playerMode = Input.GetKeyDown(KeyCode.Alpha4) ? 4 : playerMode;
        //playerMode = Input.GetKeyDown(KeyCode.Alpha5) ? 5 : playerMode;
    }

}
