using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float jumpForce;
    public float moveForce;
    public float sphereRadius;
    public LayerMask graund;
    public Transform checkPoint;
   public Rigidbody PlayerRB;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.Space)&&Check())
		{
            PlayerRB.velocity = new Vector3(0, jumpForce, 0);
           
        }
		else if(!Check())
		{
            float moveUD = Input.GetAxis("Vertical") * Time.deltaTime * moveForce;
            transform.Translate(0, moveUD, 0);
        }
        float moveRL= Input.GetAxis("Horizontal")*Time.deltaTime*moveForce;
      
          transform.Translate(moveRL, 0, 0);
    }
    bool Check()
	{
       return Physics.CheckSphere(checkPoint.position, sphereRadius,graund);
	}
}
