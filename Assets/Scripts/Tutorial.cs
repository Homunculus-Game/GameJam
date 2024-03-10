using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<GameObject> _uiElements = new();

    [SerializeField] private GameObject _arrow;
    [SerializeField] private GameObject _button;

    [SerializeField] private GameObject _nextButton1;
    [SerializeField] private GameObject _nextButton2;
    [SerializeField] private GameObject _nextButton3;
    [SerializeField] private GameObject _skipButton;

    [SerializeField] private GameObject _canvas1;
    [SerializeField] private GameObject _canvas2;

    private int i;

    void Start()
    {
        _uiElements[0].SetActive(true);
        _arrow.SetActive(false);
        _button.SetActive(false);
        i = 0;

        _nextButton1.SetActive(true);
        _nextButton2.SetActive(false);
        _nextButton3.SetActive(false);
    }

    public void NextHint()
    {
        i++;
        if (i < _uiElements.Count)
        {
            _uiElements[i - 1].SetActive(false);
            // if (i + 1 == 6 && ChangeState._potionsUsed < 6)
            // {
            //     return;
            // }

            if (i == 2 || i == 5)
            {
                _nextButton1.SetActive(false);
                _nextButton2.SetActive(true);
                _nextButton3.SetActive(false);
                _arrow.SetActive(false);
            }
            else if (i == 7 || i == 8)
            {
                _nextButton1.SetActive(false);
                _nextButton2.SetActive(false);
                _nextButton3.SetActive(true);
                _arrow.SetActive(false);
                _skipButton.SetActive(false);
            }
            else if (i == 6)
            {
                _nextButton1.SetActive(false);
                _nextButton2.SetActive(false);
                _nextButton3.SetActive(false);
                _arrow.SetActive(true);
            }
            else
            {
                _nextButton1.SetActive(true);
                _nextButton2.SetActive(false);
                _nextButton3.SetActive(false);
                _arrow.SetActive(false);
            }
            _uiElements[i].SetActive(true);
            return;
        }

        if (i == _uiElements.Count)
        {
            gameObject.SetActive(false);
            _button.SetActive(true);
            _canvas2.SetActive(true);
        }
    }

    public void SkipTutorial()
    {
        gameObject.SetActive(false);
        _button.SetActive(true);
    }
}
