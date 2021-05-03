using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager instance;
    public Texture2D defaultCursor, clickCursor, inputCursor;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Default();
    }

    public void Default()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void Click()
    {
        Cursor.SetCursor(clickCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void Edit()
    {
        Cursor.SetCursor(inputCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
