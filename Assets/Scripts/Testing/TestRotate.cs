using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotate : MonoBehaviour
{

    [SerializeField]
    int RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Rotate on the Z Axis fowards
            Debug.Log("Up");
            transform.Rotate(Vector3.forward * RotationSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Rotate on the Z Axis backwards
            Debug.Log("Backwards");
            transform.Rotate(Vector3.back * RotationSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate on the X Axis right
            Debug.Log("Right");
            transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate on the X Axis left
            Debug.Log("Left"); 
            transform.Rotate(Vector3.left * RotationSpeed * Time.deltaTime);
        }
    }
}
