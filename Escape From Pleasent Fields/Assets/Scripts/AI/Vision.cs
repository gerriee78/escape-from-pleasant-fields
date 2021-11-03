using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField]
    public LayerMask interactable;
    [SerializeField]
    [Tooltip("How far can it see")]
    public float seeDistance;
    public float visionAngle;
    [HideInInspector]
    public bool LOS;

    [SerializeField]
    GameObject visionCone;
    Material coneMat;
    Transform player;
    [SerializeField]
    LayerMask visionblocker;


    

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        Renderer coneRender = visionCone.GetComponent<Renderer>();
        coneMat = coneRender.material;
        
        //meshstuff
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[3];
        Vector2[] uv = new Vector2[3];
        int[] triangles = new int[3];

        vertices[0] = Vector3.zero;
        vertices[1] = new Vector3(50, 0);
        vertices[2] = new Vector3(0,-50);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;


    }

    // Update is called once per frame
    void Update()
    {
        //Linecast to the player to check if the player is within vision 
        Debug.DrawRay(transform.position, transform.forward * 1, Color.magenta);
        RaycastHit lineinfo;
        Physics.Linecast(transform.position, player.transform.position, out lineinfo, interactable);

        //Update vision cone shader to match set angle and distance.
        coneMat.SetFloat("Angle", Mathf.Lerp(-50, 0, Mathf.InverseLerp(0, 180, visionAngle)));
        visionCone.transform.localScale = new Vector3(12.5f * seeDistance, 12.5f * seeDistance, visionCone.transform.localScale.z);


        
        //Calculate distance without y axis. 
        Vector3 distance = transform.position - new Vector3(player.position.x, transform.position.y, player.position.z);
        float Distance = distance.magnitude;
        //Debug.Log(Distance);
        
        //Calculate angle without y axis.
        float angle = Vector3.Angle(transform.forward, -distance);
        //Debug.Log(angle);

        //if the player is seen
        if (Distance < seeDistance && lineinfo.collider.tag == "Player" && angle < visionAngle)
        {
            Debug.DrawLine(transform.position, player.position, Color.blue);
            LOS = true;
        }
        else
        {
            LOS = false;
            Debug.DrawLine(transform.position, player.position, Color.red);
        }
    }

   

}
