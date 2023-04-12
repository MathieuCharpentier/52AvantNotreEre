using UnityEngine;
using System;
using System.Data;
using System.Text;

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data;
using MySql.Data.MySqlClient;

public class MySQLData : MonoBehaviour
{
    public string host, database, user, password;
    public bool pooling = true;

    private string connectionString;
    private MySqlConnection con = null;
    private MySqlCommand cmd = null;
    private MySqlDataReader rdr = null;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        connectionString = "charset=utf8; persistsecurityinfo=True;sslmode=none; Server=" + host + ";Database=" + database + ";User=" + user + ";Password=" + password + ";Pooling=";
        if (pooling)
        {
            connectionString += "True";
        }
        else
        {
            connectionString += "False";
        }

        try
        {
            con = new MySqlConnection(connectionString);
            con.Open();
            Debug.Log("Mysql state: " + con.State);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public bool verifUser(string mail)
    {
        try
        {
            string sql = "SELECT Count(*) FROM laniste WHERE Mail LIKE " + mail;
            cmd = new MySqlCommand(sql, con);
            int userCount = (int) cmd.ExecuteScalar();

            if(userCount == 1)
            return true;
            else
            return false;
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return false;
        }
    }

    public String createUser(string lname, string fname, string mail)
    {
        if(!verifUser(mail))
        {
            try
            {
            string sql = "INSERT INTO laniste VALUES ('"+lname+"', '"+fname+"', '"+mail+"', 10)";
            cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            return "L'utilisateur a été crée avec succés";
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return "L'utilisateur n'a pas pu être crée";
            }
        }
        else 
        return "L'utilisateur n'a pas pu être crée (Adresse Mail déjà utilisé)";
    }

    public String createLudi(string name, string speciality)
    {
        try
        {
            string sql = "INSERT INTO ludi (Nom, Spécialité, Laniste) VALUES ('"+ name +"', '"+ speciality +"', '"+ PlayerStat.mail +"')";
            cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            return "La ludi a été crée avec succés";
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return "La ludi n'a pas pu être crée";
        }
    }

    public String createGladiator(string name, int avatar, int dexterity, int strength, int balance, int speed, int strategy, int ludi)
    {
        try
        {
            string sql = "INSERT INTO gladiateur (Nom, Avatar, Adresse, Force, Equilibre, Vitesse, Stratégie, Ludi)"+ 
            "VALUES"+
            "('"+ name +"', '"+ avatar +"', '"+ dexterity +"', '"+ strength +"', '"+ balance +"', '"+ speed +"', '"+ strategy +"', '"+ ludi +")";
            cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            return "Le Gladiateur a été crée avec succés";
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return "Le Gladiateur n'a pas pu être crée";
        }
    }

    public void modifUserMoney(string mail, int money)
    {
        try
        {
            string sql = "UPDATE laniste SET Bourse = '"+ money +"' WHERE Mail = " + mail;
            cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void modifGladiator(int id, int money)
    {
        try
        {
            string sql = "UPDATE gladiateur SET Bourse = '"+ money +"' WHERE ID = " + id;
            cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void getUser(string mail)
    {
        try
        {
            string sql = "SELECT * FROM laniste WHERE Mail LIKE "+ mail;
            cmd = new MySqlCommand(sql, con);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                PlayerStat.lname = (string) rdr[0];
                PlayerStat.fname = (string) rdr[1];
                PlayerStat.mail = (string) rdr[2];
                PlayerStat.money = (int) rdr[3];
            }
            rdr.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void getUserLudis()
    {
        try
        {
            PlayerStat.ludis.Clear();
            string sql = "SELECT * FROM ludi WHERE Laniste LIKE "+ PlayerStat.mail;
            cmd = new MySqlCommand(sql, con);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                PlayerStat.ludis.Add(new Ludi((int) rdr[0], (string) rdr[1], (string) rdr[2]));
            }
            rdr.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void getLudiGladiators(Ludi ludi)
    {
        try
        {
            ludi.gladiators.Clear();
            string sql = "SELECT * FROM ludi WHERE Laniste LIKE "+ PlayerStat.mail;
            cmd = new MySqlCommand(sql, con);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ludi.gladiators.Add(new Gladiator((int) rdr[0], (string) rdr[1], (int) rdr[2], (int) rdr[3], (int) rdr[4], (int) rdr[5], (int) rdr[6], (int) rdr[7]));
            }
            rdr.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    void onApplicationQuit()
    {
        if (con != null)
        {
            if (con.State.ToString() != "Closed")
            {
                con.Close();
                Debug.Log("Mysql connection closed");
            }
            con.Dispose();
        }
    }
}