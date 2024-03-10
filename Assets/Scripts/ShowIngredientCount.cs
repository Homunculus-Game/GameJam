using TMPro;
using UnityEngine;

public class ShowIngredientCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _musrhoomText;
    [SerializeField] private TMP_Text _oliveText;
    [SerializeField] private TMP_Text _onixText;
    [SerializeField] private TMP_Text _flowerText;
    [SerializeField] private TMP_Text _saltText;

    void Update()
    {
        _musrhoomText.text = ResourceManager.mushrooms.ToString();
        _oliveText.text = ResourceManager.olive.ToString();
        _onixText.text = ResourceManager.onix.ToString();
        _flowerText.text = ResourceManager.flower.ToString();
        _saltText.text = ResourceManager.salt.ToString();
    }
}
