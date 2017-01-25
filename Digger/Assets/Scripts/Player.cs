using System;
using System.Collections;
using System.Collections.Generic;

public class Player: IEquatable<Player>
{
    private int _ID;
    private string _Name;
    private DateTime _date;

    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public DateTime JoinDate
    {
        get { return _date; }
        set { _date = value; }
    }

    public Player()
    {

    }

    public Player(int id, string name, DateTime date)
    {
        ID = id;
        Name = name;
        JoinDate = date;
    }

    public bool Equals(Player p)
    {
        if (Name == p.Name
            && ID == p.ID)
            return true;
        else
            return false;
    }

    public static bool operator ==(Player person1, Player person2)
    {
        if (((object)person1) == null || ((object)person2) == null)
            return Object.Equals(person1, person2);

        return person1.Equals(person2);
    }

    public static bool operator !=(Player person1, Player person2)
    {
        if (((object)person1) == null || ((object)person2) == null)
            return !Object.Equals(person1, person2);

        return !(person1.Equals(person2));
    }
}