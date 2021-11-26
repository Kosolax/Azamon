using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScriptedMovement : MonoBehaviour
{
    public List<Transform> Transforms;

    public int index;

    public float Speed;

    private Transform positionToGoTo;

    public Transform ResetTransform;

    public void FixedUpdate()
    {
        if (this.index >= this.Transforms.Count)
        {
            this.transform.position = this.ResetTransform.position;
            this.index = 0;
        }
        else
        {
            this.positionToGoTo = this.Transforms[index];
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.positionToGoTo.position, this.Speed * Time.deltaTime);

            if (Vector3.Distance(this.transform.position, this.positionToGoTo.position) < 0.0001f)
            {
                this.index++;
            }
        }
    }
}
