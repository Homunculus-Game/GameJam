using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArrowController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform arrow;
    public Transform redRectangle;
    public Transform progressBar;
    public Button cauldronButton;

    public float arrowSpeed = 3f;
    public float progressSpeed = 0.5f;

    private bool isArrowMovingUp;
    private bool isProgressBarFilling;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Button Pressed");
        if (!isArrowMovingUp)
        {
            isArrowMovingUp = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Button Released");
        // Stop arrow movement when the button is released
        isArrowMovingUp = false;
    }

    private void Update()
    {
        if (isArrowMovingUp)
        {
            MoveArrow();
        }

        if (isProgressBarFilling)
        {
            FillProgressBar();
        }
    }

    private void MoveArrow()
    {
        Vector3 arrowPosition = arrow.localPosition;

        arrowPosition.y += arrowSpeed * Time.deltaTime;

        if (arrowPosition.y >= redRectangle.localPosition.y)
        {
            isProgressBarFilling = true;
        }
        else if (arrowPosition.y <= -2f) // Original position of the arrow
        {
            isProgressBarFilling = false;
        }

        arrow.localPosition = arrowPosition;
    }

    private void FillProgressBar()
    {
        Vector3 progressScale = progressBar.localScale;
        progressScale.y += progressSpeed * Time.deltaTime;

        float maxProgressY = progressBar.GetComponent<SpriteRenderer>().bounds.size.y / 2f;
        float progressY = Mathf.Clamp(progressScale.y, 0f, maxProgressY);

        progressBar.localScale = new Vector3(progressBar.localScale.x, progressY, progressBar.localScale.z);

        if (progressY >= maxProgressY)
        {
            Debug.Log("You win!");
            // Implement win condition
        }
    }
}
