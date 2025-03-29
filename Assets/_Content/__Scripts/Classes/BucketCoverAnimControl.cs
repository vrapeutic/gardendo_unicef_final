using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketCoverAnimControl : MonoBehaviour
{
    [SerializeField]
    Animator coverAnimator;

    private void Start()
    {
        if (!coverAnimator) coverAnimator = this.GetComponent<Animator>();
    }
    public void OpenTheCover()
    {
        OpenTheCoverRPC();
    }

    public void OpenTheCoverRPC()
    {
        coverAnimator.SetBool("OpenTheCover", true);
    }

    public void CloseTheCover()
    {
        CloseTheCoverRPC();
    }

    public void CloseTheCoverRPC()
    {
        coverAnimator.SetBool("ColseTheCover", true);
    }
}
