using System.Collections;
using UnityEngine;

public class NextDayButton : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private Animator _fadeToBlack;

    [SerializeField] private Canvas _canvas;

    private bool canUse = true;

    private void OnMouseEnter()
    {
        _animator.SetBool("hover", true);
    }
    
    private void OnMouseExit()
    {
        _animator.SetBool("hover", false);
    }

    private void OnMouseDown()
    {
        if (canUse == false)
            return;

        _canvas.sortingOrder = 110;
        canUse = false;
        StartCoroutine(FadeToBlack());
    }

    private IEnumerator FadeToBlack()
    {
        _fadeToBlack.SetBool("EndDay", true);
        yield return new WaitForSeconds(1);

        ResourceManager.currentDay++;

        if (ResourceManager.currentDay % 5 == 0)
        {
            ResourceManager.failedCount++;
        }    

        ResourceManager.mushrooms += Random.Range(1, 3);
        ResourceManager.olive += Random.Range(1, 3);
        ResourceManager.onix += Random.Range(0, 2);
        ResourceManager.flower += Random.Range(1, 3);
        ResourceManager.salt += Random.Range(1, 3);

        yield return new WaitForSeconds(1);
        _fadeToBlack.SetBool("EndDay", false);
        _canvas.sortingOrder -= 10;
        canUse = true;
    }
}
