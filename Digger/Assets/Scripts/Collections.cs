using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Collections : MonoBehaviour
{

    IEnumerable<Player> playerIEnumerable = new List<Player>
        {   new Player { ID = 1001, Name="Damon", JoinDate = new DateTime(2017,11,9)},
            new Player { ID = 1002, Name = "Darrenlloyd" , JoinDate = new DateTime(2017,12,9)},
            new Player { ID = 1003, Name = "Lachlan" , JoinDate = new DateTime(2017,11,9)},
            new Player { ID = 1004, Name = "Mary" , JoinDate = new DateTime(2017,12,9)},
            new Player { ID = 1005, Name = "Charlie" , JoinDate = new DateTime(2017,12,9)}
        };


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        //foreach (Player p in playerIEnumerable)
        //{
        //    print(p.ID + "  " + p.Name);
        //}

        //foreach (Player p in playerIEnumerable)
        //{
        //    if (p.Name.ToLower().Contains("da"))
        //    {
        //        print(p.ID + "  " + p.Name);
        //    }
        //}

        //IEnumerable<Player> DaPlayers = playerIEnumerable.Where(x => x.Name.ToLower().Contains("da") &&
        //    x.JoinDate > new DateTime(2017, 11, 15));
        //foreach (Player p in DaPlayers)
        //{
        //    print(p.ID + "  " + p.Name);
        //}

        //List<Player> playerIEnumerable2 = playerIEnumerable.OrderBy(x => x.JoinDate).ToList();
        //playerIEnumerable2.Reverse();
        //foreach (Player p in playerIEnumerable2)
        //{
        //    print(p.ID + "  " + p.Name);
        //}

        //List<Player> playerList = playerIEnumerable.ToList();
        //Player newplayer = new Player { ID = 1006, Name = "Ioannis" };
        //playerList.Add(newplayer);
        //foreach (Player p in playerList)
        //{
        //    print(p.ID + "  " + p.Name);
        //}
        //Player test = newplayer;
        //List<Player> playerList = playerIEnumerable.ToList();
        //playerList.RemoveAt(0);
        //Player testPlayer = playerList[1];
        //print(playerList.Remove(test));
        //foreach (Player p in playerList)
        //{
        //    print(p.ID + "  " + p.Name);
        //}


        Player newplayer = new Player { ID = 1006, Name = "Ioannis" };
        Player newplayer2 = new Player { ID = 1006, Name = "Ioannis" };
        print(newplayer == newplayer2);
    }
}
