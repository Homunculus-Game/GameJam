using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<GameObject> _uiElements = new();

    private int i;

    void Start()
    {
        _uiElements[0].SetActive(true);
        i = 0;
    }

    public void NextHint()
    {
        if (i < _uiElements.Count - 1)
        {
            _uiElements[i].SetActive(false);
            _uiElements[i + 1].SetActive(true);
        }
        else if (i < _uiElements.Count)
        {
            _uiElements[i].SetActive(false);
        }
        i++;
    }
}
