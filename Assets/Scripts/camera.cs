using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public float speed;
    public Transform target;
    public float speedV = 1.0f;

    void LateUpdate () {

        if (target != null) {

            Vector3 v3 = transform.position;
            v3.y = Mathf.Lerp (v3.y, target.position.y, Time.deltaTime * speed);
            transform.position = v3;
        }

        transform.Translate (Vector3.right * speed * Time.deltaTime);

    }

}