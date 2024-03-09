using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] private GameObject _popup;

    private void Start()
    {
        _popup.SetActive(false);
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
