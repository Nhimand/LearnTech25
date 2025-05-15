using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputDebugger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        Vector2 delta = Mouse.current.delta.ReadValue();

        // Right mouse button states
        bool rightHeld = Mouse.current.rightButton.isPressed;
        bool rightDown = Mouse.current.rightButton.wasPressedThisFrame;
        bool rightUp = Mouse.current.rightButton.wasReleasedThisFrame;

        Debug.Log($"Mouse Delta: X={delta.x}, Y={delta.y} | RMB Held={rightHeld}, Down={rightDown}, Up={rightUp}");
    }
}
