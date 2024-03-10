using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public Transform arrow;
    public Transform redRectangle;
    public Transform progressBar;
    public Transform cauldron;

    public float arrowSpeed = 3f;
    public float progressSpeed = 0.5f;

    private bool isArrowMovingUp;
    private bool isProgressBarFilling;

    private void OnMouseDown()
    {
        if (!isArrowMovingUp)
        {
            isArrowMovingUp = true;
        }
    }

    private void OnMouseUp()
    {
        if (isArrowMovingUp)
        {
            isArrowMovingUp = false;
        }
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
