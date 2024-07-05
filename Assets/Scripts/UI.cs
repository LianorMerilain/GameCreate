using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Queue<Vector3> Cp = new();
    public float Speed;
    public Text ScoreText;
    public Scrollbar SpeedScrollbar;
    private void Start()
    {
        PlControl cop = GetComponent<PlControl>();
        Cp = cop.ChestPositionPoint;
        SpeedScrollbar.onValueChanged.AddListener(delegate { UpdateSpeed(); });
        UpdateSpeed();
    }
    private void Update()
    {
        ScoreText.text = "active click: " + Cp.Count;
    }
    public void UpdateSpeed()
    {
        Speed = SpeedScrollbar.value * 10;
    }
}