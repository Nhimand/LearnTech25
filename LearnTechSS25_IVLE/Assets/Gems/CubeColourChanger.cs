using UnityEngine;

public class CubeColourChanger : MonoBehaviour
{
    private Renderer cubeRenderer;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();

        // initial (RGB: 1, 0.5, 0)
        cubeRenderer.material.color = new Color(1f, 0.5f, 0f);
    }

    public void RiddleSolved()
    {
        //green
        cubeRenderer.material.color = Color.green;
    }

    public void RiddleNotSolved()
    {
        //red
        cubeRenderer.material.color = Color.red;
    }
}
