using UnityEngine;

public class UsePotion : MonoBehaviour
{
    [SerializeField] private Potion _potion;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _canvas;

    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _text;

    private GameObject _spawnedObject;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider _boxCollider;
    
    private int _nr;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (_potion.count <= 0)
        {
            ActivateObject(false);
        }
        else
        {
            ActivateObject(true);
        }
    }

    private void OnMouseDown()
    {
        _potion.count--;
        _spawnedObject = Instantiate(_prefab, Input.mousePosition, Quaternion.identity, _canvas.transform);
    }

    private void OnMouseDrag()
    {
        _spawnedObject.transform.position = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        if (Interaction.overThis == false)
        {
            _potion.count++;
        }
        else
        {
            _potion.number++;
        }
        Destroy(_spawnedObject);
    }

    private void ActivateObject(bool isActive)
    {
        _light.SetActive(isActive);
        _text.SetActive(isActive);

        _spriteRenderer.enabled = isActive;
        _boxCollider.enabled = isActive;
    }
}
