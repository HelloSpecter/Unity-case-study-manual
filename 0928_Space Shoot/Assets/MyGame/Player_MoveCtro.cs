using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MoveCtro : MonoBehaviour
{
    public float Ctro_speed = 0.5f;
    private Vector3 oldVec;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //GetComponent<Rigidbody>().velocity
        

        transform.rotation = Quaternion.Euler(90,0,0);
        if (Input.GetAxis("Horizontal")!=0|| Input.GetAxis("Vertical") != 0)
        {

            if (Input.GetAxis("Horizontal")<0)
            {
                transform.rotation = Quaternion.Euler(120, -90, -90);
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.rotation = Quaternion.Euler(120, 90, 90);
            }
            if ((transform.localPosition.x>=-2.52f)&& (transform.localPosition.x <= 2.52f)&& (transform.localPosition.z>=-8.5f)&&(transform.localPosition.z <= 2.55f))
            {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Ctro_speed * Time.deltaTime,Space.World);

            }
            //考虑用mathf.Clamp函数简化下面的代码
            else if (transform.localPosition.x < -2.52f)
            {
                oldVec = transform.localPosition;
                oldVec.x = -2.52f;
                transform.localPosition = oldVec;
            }
            else if (transform.localPosition.x > 2.52f)
            {
                oldVec = transform.localPosition;
                oldVec.x = 2.52f;
                transform.localPosition = oldVec;
            }
            else if (transform.localPosition.z < -8.5f)
            {
                oldVec = transform.localPosition;
                oldVec.z = -8.5f;
                transform.localPosition = oldVec;
            }
            else if (transform.localPosition.z > 2.55f)
            {
                oldVec = transform.localPosition;
                oldVec.z =2.55f;
                transform.localPosition = oldVec;
            }
        }
    }
}
