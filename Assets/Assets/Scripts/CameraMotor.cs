using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform look_At;
    public float bound_X = 0.15f;
    public float bound_Y = 0.05f;

    private void LateUpdate() 
    {
        Vector3 delta = Vector3.zero;

        float delta_X= look_At.position.x - transform.position.x;
        if(delta_X > bound_X || delta_X < - bound_X)
        {
            if(transform.position.x < look_At.position.x)
            {
                delta.x = delta_X - bound_X;
            }
            else
            {
                delta.x = delta_X + bound_X;
            }
        }    
        float delta_Y= look_At.position.y - transform.position.y;
        if(delta_Y > bound_Y || delta_Y < - bound_Y)
        {
            if(transform.position.y < look_At.position.y)
            {
                delta.y = delta_Y - bound_Y;
            }
            else
            {
                delta.y = delta_Y + bound_Y;
            }
        }     

        transform.position += new Vector3(delta.x , delta.y, 0);
    }
}
