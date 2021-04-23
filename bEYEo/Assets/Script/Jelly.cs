using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public float Intensity = 1;
    public float Mass = 1.5f;
    public float stiffness = 0.54f;
    public float damping = 0.3f;
    private Mesh OrginalMesh, MeshClone;
    private MeshRenderer rendererr;
    private JellyVertex[] jellyVertex;
    private Vector3[] vertexArray;

    // Start is called before the first frame update
    void Start()
    {
        OrginalMesh = GetComponent<MeshFilter>().sharedMesh;
        MeshClone = Instantiate(OrginalMesh);
        GetComponent<MeshFilter>().sharedMesh = MeshClone;
        rendererr = GetComponent<MeshRenderer>();
        jellyVertex = new JellyVertex[MeshClone.vertices.Length];
        for (int i = 0; i < MeshClone.vertices.Length; i++)
        {
            jellyVertex[i] = new JellyVertex(i, transform.TransformPoint(MeshClone.vertices[i]));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vertexArray = OrginalMesh.vertices;
        for (int i = 0; i < jellyVertex.Length; i++)
        {
            Vector3 target = transform.TransformPoint(vertexArray[jellyVertex[i].ID]);
            float intensity = (1 - (rendererr.bounds.max.y - target.y) / rendererr.bounds.size.y) * Intensity;
            jellyVertex[i].Shake(target, Mass, stiffness, damping);
            target = transform.InverseTransformPoint(jellyVertex[i].Position);
            vertexArray[jellyVertex[i].ID] = Vector3.Lerp(vertexArray[jellyVertex[i].ID], target, intensity);
        }
        MeshClone.vertices = vertexArray;

    }
    public class JellyVertex{
        public int ID;
        public Vector3 Position;
        public Vector3 velocity, Force;
        public JellyVertex(int id, Vector3 pos) {
            ID = id;
            Position = pos;
        }

        public void Shake(Vector3 target, float m , float s, float d)
        {
            Force = (target - Position) * s;
            velocity = (velocity + Force / m) * d;
            Position += velocity;
            if ((velocity+Force+Force/m).magnitude<0.001f)
            {
                Position = target;
            }
        }
    }
}
