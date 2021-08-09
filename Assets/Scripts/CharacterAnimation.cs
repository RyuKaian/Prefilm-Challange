using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Idle()
    {
        animator.SetTrigger("Idle Trigger");
    }

    public void Laughing()
    {
        animator.SetTrigger("Laughing Trigger");
    }
}
