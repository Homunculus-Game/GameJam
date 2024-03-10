using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AlbedoMinigame : MonoBehaviour
{
    public RectTransform arrow;
    public RectTransform bar;
    public RectTransform[] coloredRectangles;
    public Button button;
    public float movementSpeed = 1000.0f;

    private bool isMoving = true;
    private bool firstRectangleClicked = false;
    private bool secondRectangleClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(StopArrow);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            // Calculate the target position (end of the bar)
            float targetX = (bar.sizeDelta.x / 2 - arrow.sizeDelta.x / 2) * 1.35f; // Multiply by 2 to move farther
            Vector3 targetPosition = new Vector3(targetX, arrow.position.y, arrow.position.z);

            // Calculate the direction and distance to move the arrow
            Vector3 direction = (targetPosition - arrow.position).normalized;
            float distanceToMove = movementSpeed * Time.deltaTime;

            // Move the arrow
            arrow.position += direction * distanceToMove;

            // Check if the arrow has reached the end of the bar
            if (Mathf.Abs(arrow.position.x - targetPosition.x) < 0.1f)
            {
                isMoving = false;
                arrow.position = targetPosition; // Ensure the arrow stops exactly at the end of the bar
                Debug.Log("Arrow reached the end of the bar!");
            }
        }
    }

    void StopArrow()
    {
        isMoving = false;

        // Check if arrow is within the bounds of colored rectangles
        foreach (RectTransform rect in coloredRectangles)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(rect, arrow.position))
            {
                Debug.Log("Arrow stopped on colored rectangle!");

                if (!firstRectangleClicked)
                {
                    firstRectangleClicked = true;
                    isMoving = true; // Continue moving if only the first rectangle is clicked
                }
                else if (!secondRectangleClicked)
                {
                    secondRectangleClicked = true;
                }

                if (secondRectangleClicked)
                {
                    Debug.Log("Player succeeded!");
                }

                return;
            }
        }

        Debug.Log("Player failed!");
    }

    public void OnExitButtonClick()
    {
        // Load the MainScene
        SceneManager.LoadScene("MainScene");
    }
}
