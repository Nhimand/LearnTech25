using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorPullUp : MonoBehaviour
{
    public GameObject door;
    public float moveAmount = 3f;
    public float speed = 1f;

    public Button active;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool shouldMove = false;
    private bool hasPlayedSound = false;
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
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    public void OnButtonClick()
    {
        active.interactable = false;
        StartCoroutine(DelayedOpen(2f));
    }

    private IEnumerator DelayedOpen(float delay)
    {
        yield return new WaitForSeconds(delay);

        shouldMove = true;

        if (audioSource != null && !hasPlayedSound)
        {
            audioSource.Play();
            hasPlayedSound = true;
        }
    }
}
