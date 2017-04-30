using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour {

    public Text Result;

    public void Start()
    {
        Show();
    }

    public void Show()
    {
        var header = Data.IsSurvive ? "Вы выжили" : "Вы умерли";
        var baby = Data.IsBabyTaken ? "Вы спасли ребенка." : "Вы НЕ спасли ребенка";
        var alarm = Data.IsAlarmPressed ? "Вы включили тревогу" : "Вы НЕ включили тревогу";

        Result.text = header + "\n\n" + baby + "\n" + alarm;
    }
}
