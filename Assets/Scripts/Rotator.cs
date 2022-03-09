using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
   //We are changing the default fixed rotation props of the 3D object, cube in our case

    // Update is called once per frame
    void Update()
    {
     transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);//delta time tells differenece between two frames and thus the smoothness it provides

    }
}
