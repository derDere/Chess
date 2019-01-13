using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class FieldGenerator : MonoBehaviour
{
    [Header("Model")]
    public GameObject FieldModel;

    [Header("Colors")]
    public Material White;
    public Material Black;

    // Use this for initialization
    void Start () {
        for (int x = 0; x < 8; x++)
        {
            for (int z = 0; z < 8; z++)
            {
                GameObject field = Instantiate(FieldModel);
                field.GetComponent<Renderer>().material = (((x + z) % 2) == 0) ? White : Black;
                field.transform.Translate(x * 3, -z * 3, 0);
                field.transform.parent = gameObject.transform;
                field.name = "Field_" + x + "," + z;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
