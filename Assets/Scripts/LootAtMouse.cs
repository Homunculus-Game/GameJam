using UnityEngine;

public class LootAtMouse : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Input.mousePosition);
        // transform.forward = -transform.forward;
    }
}
