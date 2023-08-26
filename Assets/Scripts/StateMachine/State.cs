public abstract class State
{
    // Name
    public readonly string name;

    // Constructor
    protected State(string name)
    {
        this.name = name;
    }

    // Enter
    public virtual void Enter() { }

    // Exit
    public virtual void Exit() { }

    // Update
    public virtual void Update() { }

    // LateUpdate
    public virtual void LateUpdate() { }

    // FixedUpdate
    public virtual void FixedUpdate() { }
}