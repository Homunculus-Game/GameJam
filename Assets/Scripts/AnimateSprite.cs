using UnityEngine;

public class AnimateSprite : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator.speed = 0.0f;
    }

    private void OnMouseDown()
    {
        animator.SetTrigger("attack");
    }

    private void OnMouseOver()
    {
        //animator.SetBool("stir", true);
        animator.speed = 2f;
    }

    private void OnMouseExit()
    {
        //animator.SetBool("stir", false);
        animator.speed = 0f;
    }
}
