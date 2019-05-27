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

    [Header("References")]
    public GameObject MainCamera;

    [Header("Figures")]
    public GameObject King;
    public GameObject Queen;
    public GameObject Bishop;
    public GameObject Knight;
    public GameObject Rook;
    public GameObject Pawn;
    public GameObject Selection;
    public GameObject Highlight;

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
        public CameraManager.Players Player;
        public GameObject Figure;
        public Vector2 Position;
        public FigureTypes Type = FigureTypes.None;
        public bool isSelected = false;

        public FieldFigure(bool IsWhite, Vector2 Position, FigureTypes Type)
        {
            this.Player = (IsWhite) ? CameraManager.Players.White : CameraManager.Players.Black;
            this.Position = Position;
            this.Type = Type;
        }
    }

    private FieldFigure[,] Field = new FieldFigure[8, 8];

    private GameObject SelectionObj = null;

    [Header("Selection")]
    public Vector2 CurrentSelection = new Vector2(-1, -1);

    public FieldFigure SelectedFigure
    {
        get
        {
            if (CurrentSelection.x < 0) return null;
            if (CurrentSelection.x >= 8) return null;
            if (CurrentSelection.y < 0) return null;
            if (CurrentSelection.y >= 8) return null;
            return Field[(int)CurrentSelection.x, (int)CurrentSelection.y];
        }
    }

    public CameraManager.Players CurrentPlayer {
        get {
            if (MainCamera == null) return CameraManager.Players.White;
            if (MainCamera.GetComponent<CameraManager>() == null) return CameraManager.Players.White;
            return MainCamera.GetComponent<CameraManager>().CurrentPlayer;
        }
    }

    // Use this for initialization
    void Start () {
	    foreach (Placement p in Rook_Positions)
        {
            FieldFigure ff = new FieldFigure(p.white,new Vector2(p.x, p.z), FigureTypes.Rook);
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
            FieldFigure ff = new FieldFigure(p.white, new Vector2(p.x, p.z), FigureTypes.Knight);
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
            FieldFigure ff = new FieldFigure(p.white, new Vector2(p.x, p.z), FigureTypes.Bishop);
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
            FieldFigure ff = new FieldFigure(p.white, new Vector2(p.x, p.z), FigureTypes.Queen);
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
            FieldFigure ff = new FieldFigure(p.white, new Vector2(p.x, p.z), FigureTypes.King);
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
            FieldFigure ff = new FieldFigure(true, new Vector2(x, 1), FigureTypes.Pawn);
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
            FieldFigure ff = new FieldFigure(false, new Vector2(x, 6), FigureTypes.Pawn);
            ff.Figure = Instantiate(Pawn);
            ff.Figure.name = "Pawn_B_" + x + ",6";
            ff.Figure.GetComponent<Renderer>().material = Black;
            ff.Figure.transform.position = new Vector3(3 * x, 0, 6 * 3);
            ff.Figure.transform.Rotate(Vector3.forward, 270);
            ff.Figure.transform.SetParent(gameObject.transform);
            Field[x, 6] = ff;
        }

        Select(3, 0);
    }
    
    public void Select(Vector2 selection)
    {
        this.Select((int)selection.x, (int)selection.y);
    }
    public void Select(int x, int y)
    {
        if (x < 0) return;
        if (x >= 8) return;
        if (y < 0) return;
        if (y >= 8) return;
        if (SelectedFigure != null) {
            SelectedFigure.isSelected = false;
        }
        if(Field[x,y] != null)
        {
            if (SelectionObj == null) SelectionObj = Instantiate(Selection);
            SelectionObj.transform.position = new Vector3(x * 3, 1, y * 3);
            CurrentSelection = new Vector2(x, y);
            Field[x, y].isSelected = true;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        int? SelectionStep_X = null;
        int? SelectionStep_Y = null;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            SelectionStep_X = (CurrentPlayer == CameraManager.Players.White) ? -1 : 1;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            SelectionStep_X = (CurrentPlayer == CameraManager.Players.White) ? 1 : -1;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            SelectionStep_Y = (CurrentPlayer == CameraManager.Players.White) ? 1 : -1;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            SelectionStep_Y = (CurrentPlayer == CameraManager.Players.White) ? -1 : 1;

        if ((SelectionStep_X != null) || (SelectionStep_Y != null))
        {
            if (SelectionStep_X == null) SelectionStep_X = 0;
            if (SelectionStep_Y == null) SelectionStep_Y = 0;

            for (int x = (int)CurrentSelection.x + SelectionStep_X.Value; x < 8 && x >= 0; x += SelectionStep_X.Value)
            {
                for (int y = (int)CurrentSelection.y + SelectionStep_Y.Value; x < 8 && x >= 0; y += SelectionStep_Y.Value)
                {
                    if ((Field[x,y] != null) && (Field[x,y].Player == CurrentPlayer))
                    {
                        Select(x, y);

                        // Break Loops
                        x = -100;
                        y = -100;
                    }
                    if (SelectionStep_Y.Value == 0) break;
                }
                if (SelectionStep_X.Value == 0) break;
            }
        }
    }
}
