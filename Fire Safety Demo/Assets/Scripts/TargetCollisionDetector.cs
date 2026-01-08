using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollisionDetector : MonoBehaviour
{
    public UXManager uXManager;

    private float lastCollisionTime;
    private bool isColliding = false;
    public float collisionTimeout = 0.1f; // Time in seconds to wait before declaring collision "stopped"

    void Update()
    {
        // Check if the time since the last collision exceeds the timeout threshold
        if (isColliding && Time.time - lastCollisionTime > collisionTimeout)
        {
            isColliding = false;
            uXManager.targetHit = false;
            Debug.Log("Particle collision has stopped.");
            // Add your custom logic here (e.g., stop a sound effect, disable an effect)
        }
    }
    void OnParticleCollision(GameObject other)
    {
        // 'other' is the GameObject that has the Particle System component
      //  Debug.Log("Particle system from " + other.name + " hit the target!");

        // Optional: Check if the 'other' object (the particle system source) has a specific tag
        if (other.name == "FX_DryPowder")//CompareTag("ProjectileParticle"))
        {
            lastCollisionTime = Time.time;
            if (!isColliding)
            {
                isColliding = true;
                uXManager.targetHit = true;
                Debug.Log("Particle collision started/continued.");
                // Add logic for when collision starts
            }
           
          //  Debug.Log("Specific target hit by the correct particle type!");
            // Add your custom logic here (e.g., reduce health, play sound, etc.)
        }
    }

    
}
