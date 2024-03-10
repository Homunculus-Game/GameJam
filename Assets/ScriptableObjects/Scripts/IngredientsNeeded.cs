using TMPro;
using UnityEngine;

public class IngredientsNeeded : MonoBehaviour
{
    [SerializeField] private Potion _potion;

    [SerializeField] private TMP_Text _text1;
    [SerializeField] private TMP_Text _text2;
    [SerializeField] private TMP_Text _text3;

    void Start()
    {
        switch (_potion.id)
        {
            case 0:
                {
                    _text1.text = ResourceManager.salt.ToString() + "/2";
                    _text2.text = ResourceManager.olive.ToString() + "/2";
                    _text3 = null;
                    break;
                }
            case 1:
                {
                    // ResourceManager.failedCount++;
                    break;
                }
            case 2:
                {
                    _text1.text = ResourceManager.flower.ToString() + "/2";
                    _text2.text = ResourceManager.mushrooms.ToString() + "/2";
                    _text3.text = ResourceManager.onix.ToString() + "/2";
                    break;
                }
            case 3:
                {
                    _text1.text = ResourceManager.salt.ToString() + "/2";
                    _text2.text = ResourceManager.mushrooms.ToString() + "/2";
                    _text3 = null;
                    break;
                }
        }
    }

    void Update()
    {
        switch (_potion.id)
        {
            case 0:
                {
                    _text1.text = ResourceManager.salt.ToString() + "/2";
                    _text2.text = ResourceManager.olive.ToString() + "/2";
                    _text3 = null;
                    break;
                }
            case 1:
                {
                    // ResourceManager.failedCount++;
                    break;
                }
            case 2:
                {
                    _text1.text = ResourceManager.salt.ToString() + "/2";
                    _text2.text = ResourceManager.mushrooms.ToString() + "/2";
                    _text3.text = ResourceManager.onix.ToString() + "/2";
                    break;
                }
            case 3:
                {
                    _text1.text = ResourceManager.flower.ToString() + "/2";
                    _text2.text = ResourceManager.mushrooms.ToString() + "/2";
                    _text3 = null;
                    break;
                }
        }
    }
}
