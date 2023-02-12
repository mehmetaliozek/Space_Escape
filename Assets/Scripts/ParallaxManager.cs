using UnityEngine;
using System.Collections.Generic;

public class ParallaxManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public float AnimatorSpeed
    {
        get { return animator.speed; }
        set { animator.speed = value; }
    }
}