using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphPicker : MonoBehaviour
{

    [SerializeField]
    TMP_InputField inputOne;
    [SerializeField]
    TMP_InputField inputTwo;

    public void Sin()
    {
        GlobalVar.selectedFunction = FunctionsEnum.SIN;
    }

    public void Cos()
    {
        GlobalVar.selectedFunction = FunctionsEnum.COS;
    }

    public void Tan()
    {
        GlobalVar.selectedFunction = FunctionsEnum.TAN;
    }

    public void ArcSin()
    {
        GlobalVar.selectedFunction = FunctionsEnum.ARCSIN;
    }

    public void ArcCos()
    {
        GlobalVar.selectedFunction = FunctionsEnum.ARCCOS;
    }

    public void ArcTan()
    {
        GlobalVar.selectedFunction = FunctionsEnum.ARCTAN;
    }

    public void Log()
    {
        GlobalVar.selectedFunction = FunctionsEnum.LOG;
    }

    public void Power()
    {
        GlobalVar.selectedFunction = FunctionsEnum.POWER;
    }

    public void SqrRoot()
    {
        GlobalVar.selectedFunction = FunctionsEnum.SQRROOT;
    }

    public void Abs()
    {
        GlobalVar.selectedFunction = FunctionsEnum.ABS;
    }

    public void Enter()
    {
         float.TryParse(inputOne.text, out GlobalVar.inputOne);
        float.TryParse(inputTwo.text, out GlobalVar.inputTwo);
        Instantiate<GameObject>((GameObject)Resources.Load("Rotation Choices"),transform);
    }
}
