using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static bool overThis = false;

    private void OnMouseOver()
    {
        overThis = true;
    }

    private void OnMouseExit()
    {
        overThis = false;
    }
}
