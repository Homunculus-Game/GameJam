using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] private float offset = 0.0f;

    private Vector3 newPosition;

    private Vector3 initialPos;
    private Vector3 targetPos;

    [SerializeField] private GameObject canvas;

    [SerializeField] private GameObject _descritpion;

    private void Awake()
    {
        initialPos = transform.position;
        targetPos = initialPos;
    }

    private void Start()
    {
        newPosition = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);

        _descritpion.SetActive(false);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, 5.0f * Time.deltaTime);
    }

    private void OnMouseOver()
    {
        // targetPos = newPosition;
        // transform.position = new Vector3(initialPos.x, initialPos.y + offset, initialPos.z);

        if (canvas.activeSelf == false)
            return;

        _descritpion.SetActive(true);

        targetPos = newPosition;

        // Debug.Log("pick up");
    }

    private void OnMouseExit()
    {
        if (canvas.activeSelf == false)
            return;

        _descritpion.SetActive(false);

        // transform.position = initialPos;
        targetPos = initialPos;
    }
}
