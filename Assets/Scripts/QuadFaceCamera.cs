using UnityEngine;

public class QuadFaceCamera : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.forward = -transform.forward;
    }
}
