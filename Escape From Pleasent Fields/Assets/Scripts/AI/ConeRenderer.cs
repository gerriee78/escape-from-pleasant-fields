using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ConeRenderer : MonoBehaviour
{
    private Mesh mesh;
    private float fov;
    [SerializeField] private Transform zero;
    [SerializeField] private Transform ConeOrigin;
    [SerializeField] private Vision NurseSettings;

    [SerializeField] private Vector3 rotation;

    private float startingAngle;
    private void Start()
    {
        fov = NurseSettings.visionAngle * 2;

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }




    [SerializeField]
    private LayerMask Collisionmask;

    // Start is called before the first frame update
    private void Update()
    {
        //meshstuff
        transform.position = Vector3.zero;
        

        Vector3 origin = ConeOrigin.transform.position;

        Vector3 direction = NurseSettings.transform.forward;
        fov = NurseSettings.visionAngle*2;
        startingAngle = GetAngleFromVectorFloat(new Vector3(direction.x, direction.z, direction.y)) - fov/2f + fov;
        int rayCount = 30;
        

        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = NurseSettings.seeDistance;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount*3];

        vertices[0] = origin;
        
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            
            Physics.Raycast(origin, GetVectorFromAngle(angle),out RaycastHit raycastHit2d,viewDistance,Collisionmask);
            Debug.DrawRay(origin,GetVectorFromAngle(angle) + rotation,Color.blue);
            if (raycastHit2d.collider == null)
            {
                //no hit 
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
                
                
            }
            else
            {
                vertex = raycastHit2d.point;
                Debug.DrawLine(origin, raycastHit2d.point);
            }
            vertices[vertexIndex] = vertex;
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
            
        }




        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();
    }

    


    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad),0, Mathf.Sin(angleRad));
    }

    

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) - fov/2f;
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}
