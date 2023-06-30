using UnityEngine;

public class HandleTyreGrip : MonoBehaviour
{
    private float unstableTime = 0f;
    private float airTime;
    private int tiresOnGround;
    private float xVel;
    public float tireGrip = 1000f;
    public float downforce = 55000f;
    [HideInInspector]
    public float zVel;

    // Use this for initialization
    private void Start()
    {
        xVel = 0f;
        zVel = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        //track how many tires are touching the ground//
        tiresOnGround = 0;
        if (GetComponent<RCC_CarControllerV3>().groundedRL)
        {
            tiresOnGround++;
            airTime = 0f;
        }
        if (GetComponent<RCC_CarControllerV3>().groundedFL)
        {
            tiresOnGround++;
            airTime = 0f;
        }
        if (GetComponent<RCC_CarControllerV3>().groundedRR)
        {
            tiresOnGround++;
            airTime = 0f;
        }
        if (GetComponent<RCC_CarControllerV3>().groundedFR)
        {
            tiresOnGround++;
            airTime = 0f;
        }

        if (tiresOnGround <= 0)
        {
            airTime += Time.deltaTime;
        }

        if (tiresOnGround >= 4)
        {
            unstableTime = 0f;
        }
        else
        {
            unstableTime += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        //track velocity//
        xVel = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).x;
        zVel = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z;
        if (tiresOnGround > 0 || airTime < 0.3f)
        {
            //stop sliding sideways//
            GetComponent<Rigidbody>().AddForce(transform.right * xVel * -(tireGrip * 140f) * Time.deltaTime);

            //downforce//
            GetComponent<Rigidbody>().AddForce(transform.up * (Mathf.Abs(zVel) * -downforce) * Time.deltaTime);
        }
        else
        {
            if (airTime > 0.3f)
            {
                //increase gravity//
                GetComponent<Rigidbody>().AddForce((Physics.gravity * GetComponent<Rigidbody>().mass) * 2f);
            }
        }
    }
}
