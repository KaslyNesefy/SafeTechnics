public class State_Idle : State
{
    private Player _player;
    public State_Idle(Player player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        //_player.playerTablet.SetActive(false);

        //_player.GetComponent<Level1Logic>().enabled = false;
        //_player.GetComponent<Level2Logic>().enabled = false;
        //_player.GetComponent<Level3Logic>().enabled = false;
        //_player.GetComponent<Level4Logic>().enabled = false;
        //_player.GetComponent<Level5Logic>().enabled = false;
    }
    public override void Exit() 
    { 
        base.Exit(); 

    }
}
