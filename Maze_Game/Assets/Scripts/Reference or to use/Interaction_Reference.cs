using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Reference : MonoBehaviour
{
    public float r_distance = 2.5f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Use") == true)
        {
            if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, r_distance) == true)
            {
                if(hit.transform.TryGetComponent(out R_IInteractable interaction) == true)
                {
                    Debug.DrawRay(transform.position, transform.forward * r_distance, Color.blue, 0.2f);
                    interaction.Activate();
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.forward * r_distance, Color.red, 0.2f);
                }
            }
        }
    }
}

public interface R_IInteractable
{
    void Activate();
}