using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapher : MonoBehaviour
{
    [SerializeField]
    GameObject points;
    GameObject currentObject;

    int totalRotation = 0;

      float inputOne;
      float inputTwo;

      float x;
      float y;
      float z;

      float xAxis;
      float yAxis;
      float zAxis;
      FunctionsEnum selectedFunction;

    // Start is called before the first frame update
    void Start()
    {

         inputOne=GlobalVar.inputOne;
         inputTwo=GlobalVar.inputTwo;

         x=GlobalVar.x;
         y=GlobalVar.y;
         z=GlobalVar.z;

         xAxis=GlobalVar.xAxis;
         yAxis=GlobalVar.yAxis;
         zAxis=GlobalVar.zAxis;
        selectedFunction = GlobalVar.selectedFunction;

    }

    // Update is called once per frame
    void Update()
    {
        if (totalRotation < 360)
        {
            Vector2[] vertices = new Vector2[10];

            currentObject = new GameObject();


            for (int i = 0; i < 10; i++)
            {

                if (inputOne == -1)
                {
                    vertices[i] = new Vector2(i, FunctionSelector(i, inputTwo));
                }
                else if (inputTwo == -1)
                {
                    vertices[i] = new Vector2(i, FunctionSelector(i, i));
                }
                else if (inputOne == -1 && inputTwo == -1)
                {
                    vertices[i] = new Vector2(i, FunctionSelector(i, i));
                }
                else
                {
                    vertices[i] = new Vector2(i, FunctionSelector(inputOne, inputTwo));
                }
            }
            PolygonCreator(vertices);

            currentObject.transform.RotateAround(new Vector3(x, z, y),
            new Vector3(xAxis, yAxis, zAxis), 100000*Time.deltaTime);

            totalRotation++;
        }
    }

    void PolygonCreator(Vector2[] vertices2D)
    {

        var vertices3D = System.Array.ConvertAll<Vector2, Vector3>(vertices2D, v => v);

        // Use the triangulator to get indices for creating triangles
        var triangulator = new Triangulator(vertices2D);
        var indices = triangulator.Triangulate();

        // Create the mesh
        var mesh = new Mesh
        {
            vertices = vertices3D,
            triangles = indices,
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        // Set up game object with mesh;
        var meshRenderer = currentObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material((Material)Resources.Load("Blue"));

        var filter = currentObject.AddComponent<MeshFilter>();
        filter.mesh = mesh;
    }

    float FunctionSelector(float input, float input2)
    {
        switch (selectedFunction)
        {
            case FunctionsEnum.SIN:
                return Mathf.Sin(input);
            case FunctionsEnum.COS:
                return Mathf.Cos(input);
            case FunctionsEnum.TAN:
                return Mathf.Tan(input / input2);
            case FunctionsEnum.ARCSIN:
                return Mathf.Asin(input);
            case FunctionsEnum.ARCCOS:
                return Mathf.Acos(input);
            case FunctionsEnum.ARCTAN:
                return Mathf.Atan(input / input2);
            case FunctionsEnum.LOG:
                return Mathf.Log(input, input2);
            case FunctionsEnum.POWER:
                return Mathf.Pow(input, input2);
            case FunctionsEnum.SQRROOT:
                return Mathf.Sqrt(input);
            case FunctionsEnum.ABS:
                return Mathf.Abs(input);
        }
        return input;
    }
}
