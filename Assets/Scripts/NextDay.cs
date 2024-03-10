using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextDay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    [SerializeField] private Animator _animator;

    [SerializeField] private Canvas _canvas;

    private void Start()
    {
        _canvas.sortingOrder = -10;

        // ResourceManager.mushrooms = 6;
        // ResourceManager.olive = 6;
        // ResourceManager.onix = 0;
        // ResourceManager.flower = 5;
        // ResourceManager.salt = 6;
    }

    void Update()
    {
        _text.text = "day " + ResourceManager.currentDay.ToString();
    }

    public void GoNextDay()
    {
        _canvas.sortingOrder = 110;
        StartCoroutine(FadeToBlack());

        // ResourceManager.currentDay++;
        // 
        // ResourceManager.mushrooms += Random.Range(1, 3);
        // ResourceManager.olive += Random.Range(1, 3);
        // ResourceManager.onix += Random.Range(0, 2);
        // ResourceManager.flower += Random.Range(1, 3);
        // ResourceManager.salt += Random.Range(1, 3);

    }

    private IEnumerator FadeToBlack()
    {
        _animator.SetBool("EndDay", true);
        yield return new WaitForSeconds(1);

        ResourceManager.currentDay++;

        ResourceManager.mushrooms += Random.Range(1, 3);
        ResourceManager.olive += Random.Range(1, 3);
        ResourceManager.onix += Random.Range(0, 2);
        ResourceManager.flower += Random.Range(1, 3);
        ResourceManager.salt += Random.Range(1, 3);

        yield return new WaitForSeconds(1);
        _animator.SetBool("EndDay", false);
        _canvas.sortingOrder -= 10;
    }
}
