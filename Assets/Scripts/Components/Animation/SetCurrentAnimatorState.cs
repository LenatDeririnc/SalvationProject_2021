using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurrentAnimatorState : MonoBehaviour
{
    private Animator m_animator;
    [SerializeField] private string stateOnStart;
    private string currentState;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        
        m_animator.Play(newState);

        currentState = newState;
    }

    private void Start()
    {
        m_animator.Play(stateOnStart);

        currentState = stateOnStart;
    }
}
