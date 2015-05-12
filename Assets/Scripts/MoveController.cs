using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {
    public Vector3 goPosition;
    private Vector3 velocity = new Vector3(0.5f, 0.5f, 0.5f);
    private float smoothTime = 0.5f;
    private bool moving = false;
    public bool canMove, ableMove = true;
    private Quaternion targetRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            MoveFunction();
        }
	}

    public void MoveFunction()
    {
        if (Input.GetMouseButtonDown(0) && ableMove)
        {
            moving = true;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                goPosition = hit.point;
                targetRotation = Quaternion.LookRotation(goPosition - transform.position);
                targetRotation.x = 0;
                targetRotation.z = 0;
            }
        }

        if (moving)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(goPosition.x, 0.50f, goPosition.z), ref velocity, smoothTime, 4);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, .05f);

            ableMove = true; 
        }
    }
}
