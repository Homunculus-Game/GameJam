using TMPro;
using UnityEngine;

public class InitPotion : MonoBehaviour
{
    [SerializeField] private Potion _potion;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        // _potion.count = 0;
        // _potion.number = 0;
        _spriteRenderer.sprite = _potion.sprite;
        // _text.text = _potion.count.ToString();
    }

    private void Update()
    {
        // switch (_potion.id)
        // {
        // case 0:
        //     {
        //         _text.text = ResourceManager.albedoCount.ToString();
        //         break;
        //     }
        // case 1:
        //     {
        //         _text.text = ResourceManager.failedCount.ToString();
        //         break;
        //     }
        // case 2:
        //     {
        //         _text.text = ResourceManager.nigredoCount.ToString();
        //         break;
        //     }
        // case 3:
        //     {
        //         _text.text = ResourceManager.rubedoCount.ToString();
        //         break;
        //     }
        // }

        // _text.text = _potion.count.ToString();
    }
}
