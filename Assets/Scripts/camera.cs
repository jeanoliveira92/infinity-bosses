using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private bool startRun = false;
    public float speed;
    public Transform target;
    public float speedV = 1.0f;
    void Start(){
        StartCoroutine("WaitStartRun");
    }
    void LateUpdate()
    {
        if (startRun == true)
        {
            if (target != null)
            {
                Vector3 v3 = transform.position;
                v3.y = Mathf.Lerp(v3.y, target.position.y+0.9f, Time.deltaTime * speed);
                transform.position = v3;

                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
    IEnumerator WaitStartRun()
    {
        yield return new WaitForSeconds(1.0f);
        startRun = true;

    }
    void stop (){
        startRun = false;
    }

    void go (){
        startRun = true;
    }
}