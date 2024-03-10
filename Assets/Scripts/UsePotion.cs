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

    public event Action<Potion> OnPotionUsed;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (GetPotionID(_potion) <= 0)
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
        // _potion.count--;
        AddPotion(-1);
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
            // _potion.count++;
            AddPotion(1);
        }
        else
        {
            OnPotionUsed?.Invoke(_potion);
            // AddPotion(1);
            // _potion.number++;
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

    private void AddPotion(int nr)
    {
        switch (_potion.id)
        {
        case 0:
            {
                ResourceManager.albedoCount += nr;
                break;
            }
        case 1:
            {
                ResourceManager.failedCount += nr;
                break;
            }
        case 2:
            {
                ResourceManager.nigredoCount += nr;
                break;
            }
        case 3:
            {
                ResourceManager.rubedoCount += nr;
                break;
            }
        }
    }

    private int GetPotionID(Potion potion)
    {
        int thisPotion;

        switch (potion.id)
        {
            case 0:
                {
                    thisPotion = ResourceManager.albedoCount;
                    return thisPotion;
                }
            case 1:
                {
                    thisPotion = ResourceManager.failedCount;
                    return thisPotion;
                }
            case 2:
                {
                    thisPotion = ResourceManager.nigredoCount;
                    return thisPotion;
                }
            case 3:
                {
                    thisPotion = ResourceManager.rubedoCount;
                    return thisPotion;
                }
            default: return -1;
        }
    }
}
