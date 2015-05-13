using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {
    public Animator anim;
    public Vector3 goPosition;
    public Transform Arrow;
    public float speed;
    private Vector3 velocity = new Vector3(0.5f, 0.5f, 0.5f);
    private float smoothTime = 0.5f;
    public bool moving = false;
    public bool canMove, ableMove = true;
    private Quaternion targetRotation;
    private Vector3 stayPosition;
	// Use this for initialization
	void Start () {
        velocity = new Vector3(speed,0,speed);
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
                DestroyArrows();
                Transform arrowClone = Instantiate(Arrow, new Vector3(goPosition.x, 2.73f, goPosition.z), Quaternion.Euler(0, 0, 0)) as Transform;
                anim.SetFloat("posX", (goPosition.x - transform.position.x) );
                anim.SetFloat("posY", (goPosition.z - transform.position.z) );
            }
        }

        if (moving)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(goPosition.x, 0.70f, goPosition.z), ref velocity, smoothTime, 4);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }       
    }

    void DestroyArrows()
    {
        Destroy(GameObject.FindWithTag("Arrow"));
    }

    void PlayerStop()
    {
       // moving = false;
        anim.SetFloat("posX", 0);
        anim.SetFloat("posY", 0);
    }

   void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Arrow")
        {
            DestroyArrows();
            PlayerStop();
        }
    }

   void OnCollisionEnter(Collision other)
   {
       PlayerStop();
   }

}
