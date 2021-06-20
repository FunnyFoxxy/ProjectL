using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    public Vector3 offset;
    public bool miniMap;
    // Update is called once per frame
    void FixedUpdate() //Flow for player
    {
        if (player != null)
        {
            if (miniMap)
            {
                Vector3 newPosition = Vector2.Lerp(transform.position, player.transform.position + offset, smoothing);
                newPosition.z = -50;
                transform.position = newPosition;
            }
            else
            {
            Vector3 newPosition = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
            newPosition.z = -10;
            transform.position = newPosition;
            }
            

        }
    }
}
