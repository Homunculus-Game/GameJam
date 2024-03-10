using TMPro;
using UnityEngine;

public class ShowPotionsCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _albedoText;
    [SerializeField] private TMP_Text _rubedoText;
    [SerializeField] private TMP_Text _nigredoText;
    [SerializeField] private TMP_Text _failedText;

    void Update()
    {
        _albedoText.text = ResourceManager.albedoCount.ToString();
        _rubedoText.text = ResourceManager.rubedoCount.ToString();
        _nigredoText.text = ResourceManager.nigredoCount.ToString();
        _failedText.text = ResourceManager.failedCount.ToString();
    }
}
