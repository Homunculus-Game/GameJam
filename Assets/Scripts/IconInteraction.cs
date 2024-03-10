using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IconInteraction : MonoBehaviour
{
    [SerializeField] private GameObject _popup;

    [SerializeField] private Potion _potion;

    private void OnMouseDown()
    {
        switch (_potion.id)
        {
            case 0:
            {
                if (ResourceManager.salt >= 2 && ResourceManager.olive >= 2)
                {
                    ResourceManager.salt -= 2;
                    ResourceManager.olive -= 2;
                    //ResourceManager.albedoCount++;
                    SceneManager.LoadScene("AlbedoMinigame", LoadSceneMode.Additive);
                }
                break;
            }
            case 1:
            {
                // ResourceManager.failedCount++;
                break;
            }
            case 2:
            {
                if (ResourceManager.salt >= 2 && ResourceManager.mushrooms >= 2 && ResourceManager.onix >=2)
                {
                    ResourceManager.salt -= 2;
                    ResourceManager.mushrooms -= 2;
                    ResourceManager.onix -= 2;
                    ResourceManager.nigredoCount++;
                }
                break;
            }
            case 3:
            {
                if (ResourceManager.flower >= 2 && ResourceManager.mushrooms >= 2)
                {
                    ResourceManager.flower -= 2;
                    ResourceManager.mushrooms -= 2;
                    ResourceManager.rubedoCount++;
                }
                break;
            }
        }

        // _potion.count++;
        // Debug.Log("Enter minigame 2, change scene!");
        // Debug.Log(_potion.name);
    }

    private void OnMouseOver()
    {
        _popup.SetActive(true);
    }

    private void OnMouseExit()
    {
        _popup.SetActive(false);
    }
}
