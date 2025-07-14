using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
    public GameObject andObject;

    private void DisableAll()
    {
        andObject.SetActive(false);
    }

    public void PlayAnd()
    {
        DisableAll();
        andObject.SetActive(true);
        Animator anim = andObject.GetComponent<Animator>();
        anim.Play("and", 0, 0f);
    }

}
