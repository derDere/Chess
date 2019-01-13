using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class BordManager : MonoBehaviour {

    public struct Placement
    {
        public int x;
        public int z;
        public bool white;
    }

    private static Placement[] Rook_Positions = new Placement[] {
        new Placement() {x = 0, z = 0, white = true },
        new Placement() {x = 7, z = 0, white = true },
        new Placement() {x = 0, z = 7, white = false },
        new Placement() {x = 7, z = 7, white = false }
    };
    private static Placement[] Knight_Positions = new Placement[]{
        new Placement() {x = 1, z = 0, white = true },
        new Placement() {x = 6, z = 0, white = true },
        new Placement() {x = 1, z = 7, white = false },
        new Placement() {x = 6, z = 7, white = false }
    };
    private static Placement[] Bishop_Positions = new Placement[] {
        new Placement() {x = 2, z = 0, white = true },
        new Placement() {x = 5, z = 0, white = true },
        new Placement() {x = 2, z = 7, white = false },
        new Placement() {x = 5, z = 7, white = false }
    };
    private static Placement[] Queen_Positions = new Placement[] {
        new Placement() {x = 3, z = 0, white = true },
        new Placement() {x = 3, z = 7, white = false }
    };
    private static Placement[] King_Positions = new Placement[] {
        new Placement() {x = 4, z = 0, white = true },
        new Placement() {x = 4, z = 7, white = false }
    };

    [Header("Figures")]
    public GameObject King;
    public GameObject Queen;
    public GameObject Bishop;
    public GameObject Knight;
    public GameObject Rook;
    public GameObject Pawn;

    [Header("Colors")]
    public Material White;
    public Material Black;

    public enum FigureTypes
    {
        King,
        Queen,
        Bishop,
        Knight,
        Rook,
        Pawn,
        None
    }

    public class FieldFigure
    {
        public GameObject Figure;
        public Vector2 Position;
        public FigureTypes Type = FigureTypes.None;
    }

    private FieldFigure[,] Field = new FieldFigure[8, 8];

    // Use this for initialization
	void Start () {
	    foreach (Placement p in Rook_Positions)
        {
            FieldFigure ff = new FieldFigure();
            ff.Type = FigureTypes.Rook;
            ff.Figure = Instantiate(Rook);
            ff.Figure.name = "Rook_" + ((p.white) ? "W" : "B") + "_" + p.x + "," + p.z;
            ff.Figure.GetComponent<Renderer>().material = (p.white) ? White : Black;
            ff.Figure.transform.position = new Vector3(3 * p.x, 0, 3 * p.z);
            if (p.white) ff.Figure.transform.Rotate(Vector3.forward, 180);
            ff.Figure.transform.SetParent(gameObject.transform);
            Field[p.x, p.z] = ff;
        }
        foreach (Placement p in Knight_Positions)
        {
            FieldFigure ff = new FieldFigure();
            ff.Type = FigureTypes.Knight;
            ff.Figure = Instantiate(Knight);
            ff.Figure.name = "Knight_" + ((p.white) ? "W" : "B") + "_" + p.x + "," + p.z;
            ff.Figure.GetComponent<Renderer>().material = (p.white) ? White : Black;
            ff.Figure.transform.position = new Vector3(3 * p.x, 0, 3 * p.z);
            ff.Figure.transform.Rotate(Vector3.forward, (p.white) ? 90 : 270);
            ff.Figure.transform.SetParent(gameObject.transform);
            Field[p.x, p.z] = ff;
        }
        foreach (Placement p in Bishop_Positions)
        {
            FieldFigure ff = new FieldFigure();
            ff.Type = FigureTypes.Bishop;
            ff.Figure = Instantiate(Bishop);
            ff.Figure.name = "Bishop_" + ((p.white) ? "W" : "B") + "_" + p.x + "," + p.z;
            ff.Figure.GetComponent<Renderer>().material = (p.white) ? White : Black;
            ff.Figure.transform.position = new Vector3(3 * p.x, 0, 3 * p.z);
            ff.Figure.transform.Rotate(Vector3.forward, (p.white) ? 90 : 270);
            ff.Figure.transform.SetParent(gameObject.transform);
            Field[p.x, p.z] = ff;
        }
        foreach (Placement p in Queen_Positions)
        {
            FieldFigure ff = new FieldFigure();
            ff.Type = FigureTypes.Queen;
            ff.Figure = Instantiate(Queen);
            ff.Figure.name = "Queen_" + ((p.white) ? "W" : "B") + "_" + p.x + "," + p.z;
            ff.Figure.GetComponent<Renderer>().material = (p.white) ? White : Black;
            ff.Figure.transform.position = new Vector3(3 * p.x, 0, 3 * p.z);
            ff.Figure.transform.Rotate(Vector3.forward, (p.white) ? 90 : 270);
            ff.Figure.transform.SetParent(gameObject.transform);
            Field[p.x, p.z] = ff;
        }
        foreach (Placement p in King_Positions)
        {
            FieldFigure ff = new FieldFigure();
            ff.Type = FigureTypes.King;
            ff.Figure = Instantiate(King);
            ff.Figure.name = "King_" + ((p.white) ? "W" : "B") + "_" + p.x + "," + p.z;
            ff.Figure.GetComponent<Renderer>().material = (p.white) ? White : Black;
            ff.Figure.transform.position = new Vector3(3 * p.x, 0, 3 * p.z);
            ff.Figure.transform.Rotate(Vector3.forward, (p.white) ? 90 : 270);
            ff.Figure.transform.SetParent(gameObject.transform);
            Field[p.x, p.z] = ff;
        }
        for (int x = 0; x < 8; x++)
        {
            FieldFigure ff = new FieldFigure();
            ff.Type = FigureTypes.Pawn;
            ff.Figure = Instantiate(Pawn);
            ff.Figure.name = "Pawn_W_" + x + ",0";
            ff.Figure.GetComponent<Renderer>().material = White;
            ff.Figure.transform.position = new Vector3(3 * x, 0, 3);
            ff.Figure.transform.Rotate(Vector3.forward, 90);
            ff.Figure.transform.SetParent(gameObject.transform);
            Field[x, 1] = ff;
        }
        for (int x = 0; x < 8; x++)
        {
            FieldFigure ff = new FieldFigure();
            ff.Type = FigureTypes.Pawn;
            ff.Figure = Instantiate(Pawn);
            ff.Figure.name = "Pawn_B_" + x + ",0";
            ff.Figure.GetComponent<Renderer>().material = Black;
            ff.Figure.transform.position = new Vector3(3 * x, 0, 6 * 3);
            ff.Figure.transform.Rotate(Vector3.forward, 270);
            ff.Figure.transform.SetParent(gameObject.transform);
            Field[x, 6] = ff;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
