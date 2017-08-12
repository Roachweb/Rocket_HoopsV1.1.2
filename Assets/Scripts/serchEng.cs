using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class serchEng : MonoBehaviour {

    public InputField searchFeild;
    public struct info
    {
        public string playerName;
        public bool online;
        public int level;
        public float score;
    };

    public Text pName;
    public Text pStatus;
    public Text pLevel;
    public Text pScore;
    info inf;
    Hashtable openWith = new Hashtable();
    // Use this for initialization
    void start()
    {
        inf = new info();

        

        inf.playerName = "Rob";
        inf.online = true;
        inf.level = 50;
        inf.score = 5000;



        /*
        pinfo2.playerName = "Sue";
        pinfo2.online = true;
        pinfo2.level = 40;
        pinfo2.score = 5470;

        pinfo3.playerName = "Suzy";
        pinfo3.online = false;
        pinfo3.level = 60;
        pinfo3.score = 6000;
        */

        openWith.Add("Rob", inf);
    }

    void update()
    {

        
    } 


    public void hitEnter()
    {
        /*
        if (searchFeild.text == "Rob" || searchFeild.text == "Sue" || searchFeild.text == "Suzy")
        {
            if (searchFeild.text == "Rob")
            {
                inf.playerName = pName.text;

                if (inf.online == true)
                {
                    pStatus.text = "Online";
                }

                else if (inf.online == false)
                {
                    pStatus.text = "Offline";
                }

                pLevel.text = inf.level.ToString();

                pScore.text = inf.score.ToString();
            }

        }
        */

        Debug.LogWarning(inf.playerName);

    } 

}
