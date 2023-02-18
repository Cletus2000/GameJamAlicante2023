using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{
    public Player player;
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.name == "Bola 1")
            player.bola1TocaSuelo(true);
        if (c.name == "Bola 2")
            player.bola2TocaSuelo(true);
    }
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.name == "Bola 1")
            player.bola1TocaSuelo(false);
        if (c.name == "Bola 2")
            player.bola2TocaSuelo(false);
    }
}
