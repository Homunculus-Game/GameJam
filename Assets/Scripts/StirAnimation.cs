using UnityEngine;

public class StirAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private Transform spoonTransform;

    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = spoonTransform.position;
    }

    void Update()
    {
        // if (animator.GetBool("stir") == false)
        // {
        //     spoonTransform.position = Vector3.Lerp(spoonTransform.position, _initialPosition, 2.0f * Time.deltaTime);
        //     Debug.Log("no stir");
        // }
    }

    private void OnMouseDown()
    {
        Debug.Log("Enter minigame 2, change scene!");
    }

    private void OnMouseOver()
    {
        animator.SetBool("stir", true);
        animator.speed = 1f;
    }

    private void OnMouseExit()
    {
        animator.SetBool("stir", false);
        animator.speed = 0f;
    }
}
