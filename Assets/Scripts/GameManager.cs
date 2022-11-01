using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<Tile> _bets;
    private void Awake()
    {
        _bets = GameObject.FindGameObjectsWithTag("Bet").ToList().Select(g => g.GetComponent<Tile>()).ToList();
        _bets.ForEach(b => b._onBetSet += OnBetSet);
    }

    void OnBetSet(int betType)
    {
        var bet = new BetTypes().GetNumbersForBetType(betType);
        Debug.Log(string.Join(',', bet));
    }
    private void OnDestroy()
    {
        _bets.ForEach(b => b._onBetSet -= OnBetSet);
    }

}
