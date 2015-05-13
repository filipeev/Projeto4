using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {
    public Animator anim;
    public Vector3 goPosition;
    public float speed;
    private Vector3 velocity = new Vector3(0.5f, 0.5f, 0.5f);
    private float smoothTime = 0.5f;
    private bool moving = false;
    public bool canMove, ableMove = true;
    private Quaternion targetRotation;
    private Vector3 stayPosition;
	// Use this for initialization
	void Start () {
        velocity = new Vector3(speed,speed,speed);
        GetPosition();
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
               // targetRotation = Quaternion.LookRotation(goPosition - transform.position);
                targetRotation.x = 0;
                targetRotation.z = 0;
                Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                anim.SetFloat("posX", (goPosition.x - transform.position.x) );
                anim.SetFloat("posY", (goPosition.z - transform.position.z) );
            }
        }

        if (moving)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(goPosition.x, 0.50f, goPosition.z), ref velocity, smoothTime, 4);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }       
    }

    void GetPosition()
    {
        stayPosition = transform.position;
        Invoke("VerifyIddle", .02f);
    }

    void VerifyIddle()
    {

        if (stayPosition.x + .5f >= transform.position.x)
        {
            anim.SetFloat("posX", 0f);
            anim.SetFloat("posY", 0f);
          //  moving = false;

        }
        stayPosition = transform.position;
        Invoke("VerifyIddle", .5f);
        //GetPosition();
    }
}
