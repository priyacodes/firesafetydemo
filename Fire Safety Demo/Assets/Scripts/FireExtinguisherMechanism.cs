using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireExtinguisherMechanism : MonoBehaviour, IHandGrabUseDelegate
{
    [SerializeField]
    private UnityEvent StartSpray;

    [SerializeField]
    private UnityEvent StopSpray;

    public UXManager uxMgr;
    public void BeginUse()
    {
       
    }

    public float ComputeUseStrength(float strength)
    {
        if (strength > 0.5f)
        {
            if(uxMgr.canStartSpray)
                StartSpray.Invoke();
        }

        else
            StopSpray.Invoke();

        return strength;
    }

  
    public void EndUse()
    {
        
    }

    // Start is called before the first frame update
    void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
}
