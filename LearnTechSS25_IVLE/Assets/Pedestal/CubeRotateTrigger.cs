using UnityEngine;

public class CubeRotateTrigger : MonoBehaviour
{
    public float rotationSpeed = 90f; // degrees per second

    private bool isRotating = false;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private float rotationProgress = 0f;

    // Trigger this from another script or event
    public void RiddleSolved()
    {
        if (isRotating) return;

        isRotating = true;
        rotationProgress = 0f;

        startRotation = transform.rotation; // Use world rotation as starting point
        // Rotate around the cube's own local Y axis
        targetRotation = startRotation * Quaternion.Euler(0f, 0f, 90f);
    }

    void Update()
    {
        if (isRotating)
        {
            rotationProgress += rotationSpeed * Time.deltaTime;
            float t = Mathf.Clamp01(rotationProgress / 90f); // from 0 to 1

            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);

            if (t >= 1f)
            {
                transform.rotation = targetRotation; // Snap to target to fix small errors
                isRotating = false;
            }
        }
    }
}
