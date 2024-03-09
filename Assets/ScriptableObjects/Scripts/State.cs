using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "HomunculusGame/State")]
public class State : ScriptableObject
{
    public new string name;
    public int ID;
    public int stage;
    public Vector3 scale;
    public GameObject gameObject;
}
