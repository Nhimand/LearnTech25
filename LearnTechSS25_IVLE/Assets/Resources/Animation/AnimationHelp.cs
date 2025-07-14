using UnityEngine;
using System.Collections;

public class AnimationHelper : MonoBehaviour
{
    public GameObject andObject;

    private void DisableAll()
    {
        andObject.SetActive(false);
    }

    public void PlayAnd()
    {
        StopAllCoroutines(); 
        DisableAll();
        andObject.SetActive(true);
        Animator anim = andObject.GetComponent<Animator>();
        anim.Play("and", 0, 0f);
        StartCoroutine(AutoDisable(andObject, 5f));
    }

    private IEnumerator AutoDisable(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }
}
