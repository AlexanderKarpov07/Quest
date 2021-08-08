
using System;
using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {
    private Animator m_Animator;
    private bool m_TriggerEnter;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (m_TriggerEnter == false && other.CompareTag("Player"))
        {
            m_TriggerEnter = true;
            m_Animator.SetBool("Open", true);
        }
    }
    
    
}


    