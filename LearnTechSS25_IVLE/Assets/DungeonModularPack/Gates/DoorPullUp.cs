using UnityEngine;
using UnityEngine.UI;

public class DoorPullUp : MonoBehaviour
{
    public GameObject door;
    public float moveAmount = 3f;
    public float speed = 2f;

    public Button active;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool shouldMove = false;
    private bool hasPlayedSound = false; // Prevent multiple plays

    private AudioSource audioSource;

    void Start()
    {
        if (door != null)
        {
            startPos = door.transform.position;
            targetPos = startPos + Vector3.up * moveAmount;
        }

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (shouldMove && door != null)
        {
            if (!hasPlayedSound && audioSource != null)
            {
                audioSource.Play();
                hasPlayedSound = true;
            }

            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    public void OnButtonClick()
    {
        active.interactable = false;
        shouldMove = true;
    }
}
