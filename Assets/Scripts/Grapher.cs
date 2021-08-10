using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapher : MonoBehaviour
{
    [SerializeField]
    GameObject points;

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
    PCModeEnum selectedMode;

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
        selectedMode = GlobalVar.selectedMode;
        selectedFunction = GlobalVar.selectedFunction;


        if (selectedMode == PCModeEnum.TOASTER)
            Camera.main.clearFlags = CameraClearFlags.Nothing;
        if (selectedMode == PCModeEnum.POWERHOUSE)
            Camera.main.clearFlags = CameraClearFlags.Skybox;

        if (selectedMode==PCModeEnum.TOASTER)
        {
            for (float i = 0.005f; i < 5; i += 0.005f)
            {
                GameObject tempObject = Instantiate<GameObject>(points, transform);
                if (inputOne == -1)
                {
                    tempObject.transform.position = new Vector3(i,
                    FunctionSelector(i, inputTwo), 0);
                }
                else if (inputTwo == -1)
                {
                    tempObject.transform.position = new Vector3(i,
                    FunctionSelector(i, i), 0);
                }
                else if (inputOne == -1&&inputTwo==-1)
                {
                    tempObject.transform.position = new Vector3(i,
                    FunctionSelector(i, i), 0);
                }
                else
                {
                        tempObject.transform.position = new Vector3(i,
                        FunctionSelector(inputOne, inputTwo), 0);
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVar.selectedMode == PCModeEnum.TOASTER)
        {
                transform.RotateAround(new Vector3(x, z, y), 
                new Vector3(xAxis,yAxis,zAxis), 100 * Time.deltaTime);
                totalRotation++;
        }
        else
        {
            if (totalRotation < 150)
            {
                for (float i = 0.005f; i < 5; i += 0.005f)
                {
                    GameObject tempObject = Instantiate<GameObject>(points, transform);
                    if (inputOne == -1)
                    {
                        tempObject.transform.position = new Vector3(i,
                        FunctionSelector(i, inputTwo), 0);
                    }
                    else if (inputTwo == -1)
                    {
                        tempObject.transform.position = new Vector3(i,
                        FunctionSelector(i, i), 0);
                    }
                    else if (inputOne == -1 && inputTwo == -1)
                    {
                        tempObject.transform.position = new Vector3(i,
                        FunctionSelector(i, i), 0);
                    }
                    else
                    {
                        tempObject.transform.position = new Vector3(i,
                        FunctionSelector(inputOne, inputTwo), 0);
                    }
                }

                transform.RotateAround(new Vector3(x, z, y),
                new Vector3(xAxis, yAxis, zAxis), 10 * Time.deltaTime);
                totalRotation++;
            }
        }
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
