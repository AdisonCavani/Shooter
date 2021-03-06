using UnityEngine;

[ExecuteInEditMode]
public class Crosshair : MonoBehaviour
{
    public Texture2D crosshairTex { get; private set; } // Crosshair texture

    [Range(0f, 50f)] public uint size = 14; // Crosshair size
    [Range(0f, 10f)] public uint thickness = 2; // Crosshair thickness
    [Range(0f, 25f)] public uint gap = 6; // Crosshair gap

    public Color32 crosshairColor; // Crosshair color
    public uint customColor;
    public byte redColorValue;
    public byte greenColorValue;
    public byte blueColorValue;
    public byte alphaColorValue;

    public bool dot = false; // Crosshair dot
    public bool refresh = false;

    private void Start()
    {
        Refresh();
    }

    private void Update()
    {
        //if (refresh)
        //{
        //    Refresh();
        //    refresh = false;
        //}

        Refresh();
    }

    private void CheckThickness()
    {
        if (thickness % 2 == 0 && gap % 2 == 1) // Thickness even, gap odd
        {
            gap--;
        }

        else if (thickness % 2 == 1 && gap % 2 == 0) // Thickness odd, gap even
        {
            gap++;
        }

        if (thickness > gap) // Fix crashing when pixels are overwriting
        {
            gap = thickness;
        }
    }

    private void CheckColor()
    {
        if (customColor == 0)
        {
            crosshairColor = Color.red;
        }
        else if (customColor == 1)
        {
            crosshairColor = Color.green;
        }
        else if (customColor == 2)
        {
            crosshairColor = Color.yellow;
        }
        else if (customColor == 3)
        {
            crosshairColor = Color.blue;
        }
        else if (customColor == 4)
        {
            crosshairColor = Color.cyan;
        }
        else if (customColor == 5)
        {
            crosshairColor = new Color32(redColorValue, greenColorValue, blueColorValue, alphaColorValue);
        }
    }

    private void Refresh()
    {
        // Fix thickness and gap diff
        CheckThickness();
        CheckColor();

        uint s, g, t;

        s = size;
        g = gap;
        t = thickness;

        string crosshair = "";
        g += t;
        float se = (2 * s + g) / 2f;
        uint sC = 2 * s + (g - t);

        crosshairTex = new Texture2D((int)sC, (int)sC, TextureFormat.RGBA32, false);

        for (int k = 0; k < s; k++)
        {
            for (int i = 0; i < se - t; i++)
                crosshair += "0";

            for (int i = 0; i < t; i++)
                crosshair += "Y";

            crosshair += "\n";
        }

        for (int i = 0; i < (g - 2 * t) / 2; i++)
            crosshair += "\n";

        for (int k = 0; k < t; k++)
        {
            for (int i = 0; i < s; i++)
                crosshair += "X";

            for (int i = 0; i < g - t; i++)
                crosshair += "0";

            for (int i = 0; i < s; i++)
                crosshair += "X";

            crosshair += "\n";
        }

        for (int i = 0; i < (g - 2 * t) / 2; i++)
            crosshair += "\n";

        for (int k = 0; k < s; k++)
        {
            for (int i = 0; i < se - t; i++)
                crosshair += "0";

            for (int i = 0; i < t; i++)
                crosshair += "Y";

            if (k != s - 1)
                crosshair += "\n";
        }

        for (int ys = 0; ys < crosshairTex.height; ys++)
            for (int xs = 0; xs < crosshairTex.width; xs++)
                crosshairTex.SetPixel(xs, ys, new Color(0, 0, 0, 0));

        int x = 0; int y = 0;
        var crosshairARR = crosshair.Split(new char[] { '\n' }, System.StringSplitOptions.None);
        foreach (string cStr in crosshairARR)
        {
            foreach (char cChar in cStr)
            {
                if (cChar == 'Y' || cChar == 'X')
                    crosshairTex.SetPixel(x, y, crosshairColor);
                else
                    crosshairTex.SetPixel(x, y, new Color(0, 0, 0, 0));
                x++;
            }
            x = 0;
            y++;
        }

        if (dot == true)
        {
            for (int yk = 0; yk < thickness; yk++)
                for (int xk = 0; xk < thickness; xk++)
                {
                    crosshairTex.SetPixel((int)(crosshairTex.width / 2 - (thickness / 2) + xk), (int)(crosshairTex.width / 2 - (thickness / 2) + yk), crosshairColor);
                }
        }

        crosshairTex.Apply();
    }

    void OnGUI()
    {
        // Crosshair
        GUI.DrawTexture(new Rect(Screen.width / 2f - crosshairTex.width / 2f, Screen.height / 2f - crosshairTex.height / 2f, crosshairTex.width, crosshairTex.height), crosshairTex);
    }
}