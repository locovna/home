using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResources : MonoBehaviour
{
    public CharacterHealth characterHealth;
    public float healPoints = 20f;

    void OnCollisionEnter(Collision collisionInfo) 
    {
        if (collisionInfo.collider.tag == "Resource") 
        {
            Debug.Log(gameObject.name + " hits " + collisionInfo.collider.name);
            Destroy(collisionInfo.collider.gameObject);
        }
        else 
        {
            Debug.Log(gameObject.name + " hits " + collisionInfo.collider.name);
        }

        ConsumeResource();
    }

    void ConsumeResource()
    {
        characterHealth.Healing(healPoints);
    }
}
