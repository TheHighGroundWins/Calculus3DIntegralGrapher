using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RotationChoices : MonoBehaviour
{
    [SerializeField]
    TMP_InputField x;
    [SerializeField]
    TMP_InputField y;
    [SerializeField]
    TMP_InputField z;
    [SerializeField]
    TMP_InputField xAxis;
    [SerializeField]
    TMP_InputField yAxis;
    [SerializeField]
    TMP_InputField zAxis;

    GameObject parent;

    void Start()
    {
        parent = GameObject.FindWithTag("MainCanvas");
    }

    public void SetPreferencesandGraph()
    {
        float.TryParse(x.text, out GlobalVar.x);
        float.TryParse(y.text, out GlobalVar.y);
        float.TryParse(z.text, out GlobalVar.z);
        float.TryParse(xAxis.text, out GlobalVar.xAxis);
        float.TryParse(yAxis.text, out GlobalVar.yAxis);
        float.TryParse(zAxis.text, out GlobalVar.zAxis);
        Instantiate<GameObject>((GameObject)Resources.Load("Graph"));
        Destroy(parent);
    }

    public void Back()
    {
        Destroy(gameObject);
    }
}
