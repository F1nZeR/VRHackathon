using UnityEngine;
using System.Collections;

public class GuiBar : MonoBehaviour
{
    public GUIStyle progress_empty;
    public GUIStyle progress_full;

    //current progress
    public float barDisplay;

    Vector2 size = new Vector2(160, 70);
	Rect posOxygen = new Rect(0, Screen.height - 70, 160, 70);
	Rect posHealth = new Rect(Screen.width - 160, Screen.height - 70, 160, 70);

    public Texture2D emptyOxygenTex;
    public Texture2D fullOxygenTex;
    public Texture2D emptyHealthTex;
    public Texture2D fullHeathTex;

    void OnGUI()
    {
		DrawInPos(posOxygen, emptyOxygenTex, fullOxygenTex);
		DrawInPos(posHealth, emptyHealthTex, fullHeathTex);
    }

	private void DrawInPos(Rect pos, Texture2D emptyTex, Texture2D fullTex)
	{
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y), emptyTex, progress_empty);
        GUI.Box(new Rect(pos.x, pos.y, size.x, size.y), fullTex, progress_full);
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex, progress_full);
        GUI.EndGroup();
        GUI.EndGroup();
	}

    void Update()
    {

        //the player's health
        // barDisplay = 1f / 2f;
    }

}