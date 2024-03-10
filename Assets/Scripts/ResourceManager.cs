using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // public static ResourceManager instance; !!!

    [HideInInspector] public static int albedoCount = 0;
    [HideInInspector] public static int rubedoCount = 0;
    [HideInInspector] public static int nigredoCount = 0;
    [HideInInspector] public static int failedCount = 0;

    [HideInInspector] public static int currentDay = 1;

    public static string currentState = "normal";

    public static int mushrooms = 0;
    public static int olive = 0;
    public static int onix = 0;
    public static int flower = 0;
    public static int salt = 0;

    public static bool newGame = true;

    // [SerializeField] private Texture2D _cursorTexture;

    void Start()
    {
        // Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);

        newGame = true;

        currentDay = 1;

        albedoCount = 3;
        rubedoCount = 3;
        nigredoCount = 0;
        failedCount = 0;

        mushrooms = 6;
        olive = 6;
        onix = 0;
        flower = 5;
        salt = 6;
    }

    private void Update()
    {

    }
}
