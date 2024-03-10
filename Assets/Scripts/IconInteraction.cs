using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IconInteraction : MonoBehaviour
{
    [SerializeField] private GameObject _popup;

    [SerializeField] private Potion _potion;

    [SerializeField] private Ingredient _ingredient1;
    [SerializeField] private Ingredient _ingredient2;
    [SerializeField] private Ingredient _ingredient3;
    [SerializeField] private Ingredient _ingredient4;
    [SerializeField] private Ingredient _ingredient5;

    private Canvas _albedoCanvas;

    private int _thisPotion;

    private void Start()
    {
        // switch (_potion.name)
        // {
        //     case "Albedo": _thisPotion = ResourceManager.instance.albedoCount; break;
        //     case "Rubedo": _thisPotion = ResourceManager.instance.rubedoCount; break;
        //     case "Nigredo": _thisPotion = ResourceManager.instance.nigredoCount; break;
        //     case "Failed": _thisPotion = ResourceManager.instance.failedCount; break;
        // }
    }

    private void OnMouseDown()
    {
        // if (_ingredient1.count == 2 && _ingredient2.count == 2 && _ingredient3.count == 1)
        // {
        //     _potion.count++;
        // }
        // Function(_ingredient1, _ingredient2, _ingredient3, _ingredient4, _ingredient5);

      
        switch (_potion.number)
        {
            case 1: ResourceManager.albedoCount++; break;
            case 4: ResourceManager.rubedoCount++; break;
            case 3: ResourceManager.nigredoCount++; break;
            case 2: ResourceManager.failedCount++; break;
        }

        if (_potion.name == "Albedo")
        {
            SceneManager.LoadScene("AlbedoMinigame");
            Debug.Log("Enter Albedo");
        }

        if (_potion.name == "Rubedo")
        {
            SceneManager.LoadScene("RubedoMinigame");
            Debug.Log("Enter Rubedo");
        }

        _potion.count++;
        Debug.Log(_potion.name);
    }

    private void OnMouseOver()
    {
        _popup.SetActive(true);
    }

    private void OnMouseExit()
    {
        _popup.SetActive(false);
    }

    private void Function(Ingredient ingredient1,
                          Ingredient ingredient2,
                          Ingredient ingredient3,
                          Ingredient ingredient4 = null,
                          Ingredient ingredient5 = null)
    {
        //if (ingredient4 == null && ingredient5 == null)
        {
            if (ingredient1.count == 2 && ingredient2.count == 2 && ingredient3.count == 1)
            {
                _potion.count++;
            }
        }
        //else if (ingredient4 != null && ingredient5 != null)
        {
            // if (ingredient1.count == 2 && ingredient2.count == 2 && ingredient3.count == 1 && ingredient4.count == 1 && ingredient5.count == 1)
            // {
            //     _potion.count++;
            // }
        }
    }
}
