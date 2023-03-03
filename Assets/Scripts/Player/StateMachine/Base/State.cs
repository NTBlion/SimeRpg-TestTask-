using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private Transition[] _transitions;

    protected PlayerMove PlayerMove {get; private set;}

    protected Animator Animator { get; private set; }

    public void Enter(PlayerMove playerMove, Animator animator)
    {
        if (enabled == false)
        {
            PlayerMove = playerMove;
            Animator = animator;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public void Exit()
    {
        if(enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
