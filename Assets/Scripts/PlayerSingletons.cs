using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
public class PlayerSingletons : PersistentSingleton<PlayerSingletons>
{
    GameObject player;
    public GameObject Player { get { return player; } }

    public void RegisterPlayer(GameObject player)
    { this.player = player; }
}
