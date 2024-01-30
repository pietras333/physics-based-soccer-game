using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [Header("Ball Control")]
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Movement movement;
    [Space]
    [Header("Detection")]
    [SerializeField] float detectionVerticalOffset = 0.75f; 
    [SerializeField] float ballDetectionRange = 0.5f;
    [SerializeField] LayerMask ballLayer;
    void debugBallControlRange(){
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(this.transform.position - new Vector3(0, detectionVerticalOffset, 0), ballDetectionRange);
    }
    void OnDrawGizmosSelected(){
        debugBallControlRange();
    }

    void Update(){
        Collider[] colliders = Physics.OverlapSphere(this.transform.position - new Vector3(0, detectionVerticalOffset, 0), ballDetectionRange, ballLayer);
        for(int i = 0; i < colliders.Length; i++){
            Rigidbody ball = colliders[i].transform.gameObject.GetComponent<Rigidbody>();
            ball.velocity = rigidbody.velocity + this.transform.forward + movement.direction;
            ball.velocity = Vector3.ClampMagnitude(ball.velocity, rigidbody.velocity.magnitude);
        }
    }

}
