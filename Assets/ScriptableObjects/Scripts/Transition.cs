using UnityEngine;

[CreateAssetMenu(fileName = "New Transition", menuName = "HomunculusGame/Transition")]
public class Transition : ScriptableObject
{
    public new string name;

    public State fromState;
    public State toState;

    public Potion potion;
}
