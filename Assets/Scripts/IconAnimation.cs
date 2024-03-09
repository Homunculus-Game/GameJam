using UnityEngine;

public class IconAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private string _trigger;

    private void OnMouseOver()
    {
        animator.SetBool(_trigger, true);
        animator.speed = 1f;
    }

    private void OnMouseExit()
    {
        animator.SetBool(_trigger, false);
        animator.speed = 0f;
    }
}
