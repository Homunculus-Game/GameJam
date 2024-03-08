using UnityEngine;

public class StirAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private Transform spoonTransform;

    [SerializeField] private string _trigger;

    [SerializeField] private Potion _potion;

    [SerializeField] private Ingredient _ingredient1;
    [SerializeField] private Ingredient _ingredient2;
    [SerializeField] private Ingredient _ingredient3;
    [SerializeField] private Ingredient _ingredient4;
    [SerializeField] private Ingredient _ingredient5;

    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = spoonTransform.position;
    }

    void Update()
    {
        if (animator.speed == 0.0f)
        {
            spoonTransform.position = Vector3.Lerp(spoonTransform.position, _initialPosition, 2.0f * Time.deltaTime);
            Debug.Log("no stir");
        }
    }

    private void OnMouseDown()
    {
        // if (_ingredient1.count == 2 && _ingredient2.count == 2 && _ingredient3.count == 1)
        // {
        //     _potion.count++;
        // }
        // Function(_ingredient1, _ingredient2, _ingredient3, _ingredient4, _ingredient5);
        _potion.count++;
        Debug.Log("Enter minigame 2, change scene!");
    }

    private void OnMouseOver()
    {
        animator.SetBool(_trigger, true);
        animator.speed = 1f;
    }

    private void OnMouseExit()
    {
        animator.SetBool("stir", false);
        animator.speed = 0f;
    }

    private void Function(Ingredient ingredient1, 
                          Ingredient ingredient2, 
                          Ingredient ingredient3, 
                          Ingredient ingredient4 = null, 
                          Ingredient ingredient5 = null)
    {
        if (ingredient4 == null && ingredient5 == null)
        {
            if (ingredient1.count == 2 && ingredient2.count == 2 && ingredient3.count == 1)
            {
                _potion.count++;
            }
        }
        else if (ingredient4 != null && ingredient5 != null)
        {
            if (ingredient1.count == 2 && ingredient2.count == 2 && ingredient3.count == 1 && ingredient4.count == 1 && ingredient5.count == 1)
            {
                _potion.count++;
            }
        }
    }
}
