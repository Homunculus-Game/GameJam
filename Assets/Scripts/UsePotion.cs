using System;
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

    private int _thisPotion;
    
    public Action<Potion> OnPotionUsed;

    public int potionCount;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider>();

        // switch (_potion.name)
        // {
        //     case "Albedo": _thisPotion = ResourceManager.instance.albedoCount; break;
        //     case "Rubedo": _thisPotion = ResourceManager.instance.rubedoCount; break;
        //     case "Nigredo": _thisPotion = ResourceManager.instance.nigredoCount; break;
        //     case "Failed": _thisPotion = ResourceManager.instance.failedCount; break;
        // }
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
            OnPotionUsed?.Invoke(_potion);
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
