using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _leftPosition;
    [SerializeField] private Transform _rightPosition;

    [SerializeField] private Transform _rightRotation;

    [SerializeField] private GameObject _canvas1;
    [SerializeField] private GameObject _canvas2;
    [SerializeField] private GameObject _canvas3;

    [SerializeField] private float speed = 5.0f;

    private Transform _camera;
    private Transform _targetPosition;
    private Transform _targetRotation;

    private void Start()
    {
        _camera = Camera.main.transform;
        _targetPosition = _rightPosition;
        _targetRotation = _rightPosition;

        _canvas2.SetActive(false);
        _canvas3.SetActive(false);

        // Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseClickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(mouseClickRay, out hit))
            {
                // Debug.Log(hit.transform.name);
            }
        }
    }

    private void LateUpdate()
    {
        _camera.position = Vector3.Lerp(_camera.position, _targetPosition.position, speed * Time.deltaTime);
        _camera.rotation = Quaternion.Slerp(_camera.rotation, _targetRotation.rotation, speed * Time.deltaTime);
    }

    public void MoveCameraLeft()
    {
        _targetPosition = _leftPosition;

        _canvas1.SetActive(false);
        _canvas2.SetActive(true);
    }

    public void MoveCameraRight()
    {
        _targetPosition = _rightPosition;

        _canvas1.SetActive(true);
        _canvas2.SetActive(false);
    }

    public void RotateCameraLeft()
    {
        _targetRotation = _rightPosition;

        _canvas1.SetActive(true);
        _canvas3.SetActive(false);
    }

    public void RotateCameraRight()
    {
        _targetRotation = _rightRotation;

        _canvas3.SetActive(true);
        _canvas1.SetActive(false);
    }
}

