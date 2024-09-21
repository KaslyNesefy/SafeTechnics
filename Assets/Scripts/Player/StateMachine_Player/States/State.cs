using UnityEngine;

public abstract class State
{
    public virtual void Enter() 
    {
        Debug.Log("State changed");
    }
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void OnTriggerStay() { }
}
