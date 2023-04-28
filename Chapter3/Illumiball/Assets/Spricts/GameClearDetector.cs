using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearDetector : MonoBehaviour
{
    public Hole HoleRed;
    public Hole HoleBlue;
    public Hole HoleGreen;

    private void OnGUI()
    {
        //すべてのボールが入ったらラベルを表示
        if (HoleRed.IsHolding() && HoleBlue.IsHolding() && HoleGreen.IsHolding())
        {
            GUI.Label(new Rect(50, 50, 100, 30), "Game Clear!");
        }
    }
}
