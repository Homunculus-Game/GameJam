using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static bool overThis = false;

    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        overThis = true;
        Debug.Log("over");
    }

    private void OnMouseExit()
    {
        overThis = false;
        Debug.Log("exit");
    }
}
