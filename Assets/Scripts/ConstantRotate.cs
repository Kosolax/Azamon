using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotate : MonoBehaviour
{
    public int XSpeed = 0;
    public int YSpeed = 1;
    public int ZSpeed = 0;
    public int GlobalSpeed = 20;

    private void FixeUpdate()
    {
        transform.Rotate(this.GlobalSpeed * this.XSpeed * Time.deltaTime, this.GlobalSpeed * this.YSpeed * Time.deltaTime, this.GlobalSpeed * this.ZSpeed * Time.deltaTime);
    }
}
