using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    public float rotationSpeed = 90f; // Degrees per second
    private bool isRotating = false;  // Flag to check if rotation is happening
    private Quaternion targetRotation; // The target rotation after each trigger
    private int rotationCount = 0;    // Keeps track of the number of 90-degree rotations

    // Call this method to trigger the rotation
    public void RiddleSolved()
    {
        // If it's not already rotating, set up the next target rotation
        if (!isRotating)
        {
            rotationCount++; // Increase the rotation count
            targetRotation = Quaternion.Euler(0, 0, 90f * rotationCount); // Set the target rotation for Z-axis
            isRotating = true; // Indicate that rotation has started
        }
    }

    void Update()
    {
        // If rotation is in progress, perform the smooth rotation
        if (isRotating)
        {
            // Gradually rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Check if the rotation is close enough to the target, then stop rotating
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation; // Ensure it exactly matches the target rotation
                isRotating = false; // Stop rotating
            }
        }
    }
}
