using UnityEngine;

public class DeactivateCollider : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    private BoxCollider _boxCollider;

    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (_canvas.activeSelf == false)
        {
            _boxCollider.enabled = false;
        }
        else
        {
            _boxCollider.enabled = true;
        }
    }
}
