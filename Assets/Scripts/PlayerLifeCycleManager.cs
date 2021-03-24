﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeCycleManager : MonoBehaviour
{
    public Animator Animator;
    public string DeathAnimationTriggerName;

    public List<Behaviour> ComponentsToDisableWhenSpawningOrDespawning;

    void Start ()
    {
        setComponentState(false);
    }

    public void Die ()
    {
        setComponentState(false);
        Animator.SetTrigger(DeathAnimationTriggerName);
    }

#pragma warning disable IDE0051 // Remove unused private members - these will be called by the animation, don't want to unnecessarily expose it publically 
    void disappearAnimationEvent_destroy ()
    {
        Destroy(gameObject);
    }

    void appearAnimationEvent_enable ()
    {
        setComponentState(true);
    }
#pragma warning restore IDE0051 // Remove unused private members

    void setComponentState (bool value)
    {
        ComponentsToDisableWhenSpawningOrDespawning.ForEach(c => c.enabled = value);
    }
}
