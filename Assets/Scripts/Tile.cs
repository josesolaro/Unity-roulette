using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private int _betType;
    public event Action<int> _onBetSet;
    private void OnMouseUp()
    {
        _onBetSet?.Invoke(_betType);
    }
}
