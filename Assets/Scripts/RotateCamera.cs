using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotationSpeedScale = horizontalInput * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, rotationSpeedScale);
    }
}