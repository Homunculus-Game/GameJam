using TMPro;
using UnityEngine;

public class InitPotion : MonoBehaviour
{
    [SerializeField] private Potion potion;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        spriteRenderer.sprite = potion.sprite;
        text.text = potion.count.ToString();
    }

    private void Update()
    {
        text.text = potion.count.ToString();
    }
}
