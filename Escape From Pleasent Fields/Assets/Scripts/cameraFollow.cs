using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour
{
	public Transform target;
	public float smoothing = 5f;
    [SerializeField] private Vector3 TargetOffset;
    Vector3 offset;

	// Use this for initialization
	void Start()
	{
		offset = transform.position - target.position;
	}

	// Update is called once per frame
	void LateUpdate()
	{
        
        Vector3 targetCamPos = target.position + offset+TargetOffset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}