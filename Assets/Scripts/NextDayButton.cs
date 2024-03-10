using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class NextDayButton : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private Animator _fadeToBlack;

    [SerializeField] private Canvas _canvas;

    public event Action<string> FakePotion;

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

        // if (ResourceManager.currentDay % 2 == 0 && ChangeState._potionsUsed == 0)
        // {
        //     FakePotion?.Invoke("Albedo");
        // }

        if (ChangeState._potionsUsed == 0)
        {
            ChangeState.daysWithNoPotion++;
        }

        if (ChangeState.daysWithNoPotion >= 2)
        {
            ChangeState.daysWithNoPotion = 0;
            FakePotion?.Invoke("Albedo");
        }

        _canvas.sortingOrder = 110;
        canUse = false;

        StartCoroutine(FadeToBlack());
    }

    private IEnumerator FadeToBlack()
    {
        _fadeToBlack.SetBool("EndDay", true);
        yield return new WaitForSeconds(1.4f);

        ResourceManager.currentDay++;
        ChangeState._potionsUsed = 0;

        if (ResourceManager.currentDay % 3 == 0)
        {
            ResourceManager.failedCount++;
        }

        //if (ResourceManager.currentDay % 2 == 0 && ChangeState._potionsUsed == 0)
        //{

        //}

        ResourceManager.mushrooms += UnityEngine.Random.Range(1, 3);
        ResourceManager.olive += UnityEngine.Random.Range(1, 3);
        ResourceManager.onix += UnityEngine.Random.Range(0, 2);
        ResourceManager.flower += UnityEngine.Random.Range(1, 3);
        ResourceManager.salt += UnityEngine.Random.Range(1, 3);

        // yield return new WaitForSeconds(1);
        // _fadeToBlack.SetBool("EndDay", false);
        // _canvas.sortingOrder -= 10;
    }


    public void ExitStatsScreen()
    {
        _fadeToBlack.SetBool("EndDay", false);
        _canvas.sortingOrder -= 10;
        canUse = true;
    }
}
