using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float startSpeed;
    public float speed;
    private Rigidbody2D rigidbody;
    private DistanceJoint2D joint;

	void Awake () {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(new Vector2(0f, startSpeed));

        joint = GetComponent<DistanceJoint2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);

        if (Input.GetMouseButtonUp(0))
        {
            DetachSwingAnchor();
        }

        print("velocity: " + rigidbody.velocity.magnitude);
	}

    void LateUpdate()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;
    }

    public void AttachToSwingAnchor(Rigidbody2D swingAnchor)
    {
        joint.connectedBody = swingAnchor;
        joint.distance = (transform.position - joint.connectedBody.transform.position).magnitude;

        joint.enabled = true;
    }

    void DetachSwingAnchor()
    {
        joint.enabled = false;
    }
}
