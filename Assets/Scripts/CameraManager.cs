using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraManager : MonoBehaviour {

    public enum Players
    {
        White,
        Black
    }

    // [System.SerializableAttribute]
    // public class CamPosition
    // {
    //     public Vector3 Position;
    //     public Vector3 Rotation;
    // }

    // public CamPosition WhiteCamPos = new CamPosition()
    // {
    //     Position = new Vector3(10, 25, -10),
    //     Rotation = new Vector3(55, 0, 0)
    // };
    // 
    // public CamPosition BlackCamPos = new CamPosition()
    // {
    //     Position = new Vector3(10, 25, 30),
    //     Rotation = new Vector3(55, 180, 0)
    // };

    public Players CurrentPlayer = Players.White;

	// Use this for initialization
	void Start () {	}

    public float RotationSpeed = 160;

    private float Rotation = 0;
    private float CurrentRotation = 0;

    // Update is called once per frame
    void Update () {
        
	    if (CurrentPlayer == Players.White)
        {
            Rotation = 0;
            // gameObject.transform.position = BlackCamPos.Position;
            // gameObject.transform.rotation = Quaternion.Euler(BlackCamPos.Rotation);
        } else
        {
            Rotation = 180;
            // gameObject.transform.position = WhiteCamPos.Position;
            // gameObject.transform.rotation = Quaternion.Euler(WhiteCamPos.Rotation);
        }
        // if (CurrentRotation != Rotation)
        // {
            float Delta = Rotation - CurrentRotation;
            float Step = RotationSpeed * round(Time.fixedDeltaTime);
            if (Delta > Step) Delta = Step;
            if (Delta < -Step) Delta = -Step;
            CurrentRotation += Delta;
        // }
        gameObject.transform.rotation = Quaternion.Euler(0, CurrentRotation, 0);
	}

    private static float round(float f)
    {
        return Mathf.Round(f * 1000) / 1000;
    }
}
