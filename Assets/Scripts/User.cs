using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string password;
    public string email;
    public string country, state, city;
    public string about;


    public User(string _pass, string _email, string _country, string _state, string _city, string _about)
    {
        this.password = _pass;
        this.email = _email;
        this.country = _country;
        this.state = _state;
        this.city = _city;
        this.about = _about;
    }
}

