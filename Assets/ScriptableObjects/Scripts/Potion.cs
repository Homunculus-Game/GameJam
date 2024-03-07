using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "HomunculusGame/Potion")]
public class Potion : ScriptableObject
{
    public new string name;
    public Sprite sprite;

    public int count;
}
