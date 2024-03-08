using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "HomunculusGame/Ingredient")]
public class Ingredient : ScriptableObject
{
    public new string name;
    public Sprite sprite;

    public int count;
}
