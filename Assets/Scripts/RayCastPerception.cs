using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RayCastPerception : AIPerception
{
    [SerializeField][Range(2, 50)] int numRaycast = 2;
    public override GameObject[] GetGameObjects()
    {
        List<GameObject> result = new List<GameObject>();

        Vector3[] directions = Utilities.GetDirectionsInCircle(numRaycast, maxAngle);
        foreach (Vector3 direction in directions)
        {
            Ray ray = new Ray(transform.position, transform.rotation * direction);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, distance))
            {
                Debug.DrawRay(ray.origin, ray.direction * raycastHit.distance, Color.red);
                if (raycastHit.collider == gameObject) continue;
                if ((tagName == "") || raycastHit.collider.CompareTag((tagName)))
                {
                    result.Add(raycastHit.collider.gameObject);
                }


            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
            }

        }
        result = result.Distinct().ToList();

        return result.ToArray();
    }
}