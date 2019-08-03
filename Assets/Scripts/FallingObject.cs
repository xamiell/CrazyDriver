using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, -1f, 0f) * GameManager.speedFallingObjects * Time.deltaTime);
    }
}
