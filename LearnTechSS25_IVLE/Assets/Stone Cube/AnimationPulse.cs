using UnityEngine;

public class AnimationPulse : MonoBehaviour
{
    public Color baseColor = Color.yellow;
    public float pulseSpeed = 1f;
    public float intensity = 2f;
    public float minPulse = 0.2f; // Minimum brightness (10%)

    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        // Pulse between minPulse * intensity and full intensity
        float emission = Mathf.PingPong(Time.time * pulseSpeed, (1f - minPulse) * intensity) + (minPulse * intensity);
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", finalColor);
    }
}
