using TMPro;
using UnityEngine;

public class InitPotion : MonoBehaviour
{
    [SerializeField] private Potion _potion;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _potion.count = 0;
        _potion.number = 0;
        _spriteRenderer.sprite = _potion.sprite;
        _text.text = _potion.count.ToString();
    }

    private void Update()
    {
        _text.text = _potion.count.ToString();
    }
}
