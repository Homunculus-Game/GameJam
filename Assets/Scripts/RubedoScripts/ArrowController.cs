using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ArrowController : MonoBehaviour
{
    public Transform redRectangle;
    public Transform progressBar;


    public float arrowSpeed = 3f;
    public float progressSpeed = 0.5f;

    private bool isArrowMovingUp;
    private bool isProgressBarFilling;
    private float currentProgress;
    private Rigidbody2D arrowRigidbody;
    private Vector3 originalArrowPosition;
    public float fallSpeedMultiplier = 0.5f; // Adjust this value to control the falling speed



    void Start()
    {
        // Get the Rigidbody2D component of the arrow
        arrowRigidbody = GetComponent<Rigidbody2D>();

        // Set the arrow's gravity scale to zero initially
        arrowRigidbody.gravityScale = 0f;

        // Store the original position of the arrow
        originalArrowPosition = transform.localPosition;

        // Get the Button component attached to the CauldronBtn GameObject
        Button cauldronButton = GameObject.Find("CauldronBtn").GetComponent<Button>();

        if (cauldronButton == null)
        {
            Debug.LogError("CauldronBtn button not found.");
            return;
        }

        // Add listeners to the button click events
        cauldronButton.onClick.AddListener(OnCauldronButtonDown);
        cauldronButton.onClick.AddListener(OnCauldronButtonUp);
    }


    public void OnCauldronButtonDown()
    {
        isArrowMovingUp = true;
        // Set the arrow's velocity to move upwards when the button is clicked
        arrowRigidbody.velocity = new Vector2(0, arrowSpeed);
        // Enable gravity when the button is clicked
        arrowRigidbody.gravityScale = 1f;
    }

    public void OnCauldronButtonUp()
    {
        // Indicate that the arrow should stop moving up
        isArrowMovingUp = false;

        // Set the arrow's velocity to zero to stop its upward movement
        arrowRigidbody.velocity = Vector2.zero;
        arrowRigidbody.gravityScale = 85f;
    }

    void Update()
    {
        if (isArrowMovingUp)
        {
            MoveArrow();
        }

        if (isProgressBarFilling)
        {
            FillProgressBar();
        }
        else
        {
            DecreaseProgressBar();
        }
    }

    void MoveArrow()
    {
        // Get the current position of the arrow
    Vector3 arrowPosition = transform.position;

    // Calculate the new position based on arrow speed and time
    arrowPosition.y += arrowSpeed * Time.deltaTime;

    // Check if the arrow and the red rectangle are intersecting
    bool isIntersecting = arrowPosition.y >= redRectangle.position.y;

    // Update the progress bar filling status
    isProgressBarFilling = isIntersecting;

    // Update the position of the arrow
    transform.position = arrowPosition;
    }


    void FillProgressBar()
    {
        // Get the maximum height of the progress bar
        float maxProgressY = progressBar.GetComponent<RectTransform>().rect.height;

        // Increase progress gradually
        currentProgress += progressSpeed * Time.deltaTime;
        currentProgress = Mathf.Clamp(currentProgress, 0f, maxProgressY);

        // Update the scale of the progress bar
        progressBar.localScale = new Vector3(progressBar.localScale.x, currentProgress, progressBar.localScale.z);

        if (currentProgress >= maxProgressY)
        {
            Debug.Log("You win!");
            // Implement win condition
        }
    }

    void DecreaseProgressBar()
    {
        // Decrease progress gradually
        currentProgress -= progressSpeed * Time.deltaTime;
        currentProgress = Mathf.Clamp(currentProgress, 0f, float.MaxValue);

        // Update the scale of the progress bar
        progressBar.localScale = new Vector3(progressBar.localScale.x, currentProgress, progressBar.localScale.z);
    }

    // Implement the logic to start arrow movement
    public void StartArrowMovement()
    {
        isArrowMovingUp = true;
    }

    // Implement the logic to stop arrow movement
    public void StopArrowMovement()
    {
        isArrowMovingUp = false;
    }
}