using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour

{

    public static List<int> Sıfırlar = new List<int> { 5, 6, 7, 9, 10, 13, 16, 17, 19, 20 };

    public static List<int> Otuzlar = new List<int> { 8 , 11 , 12 , 13 , 14 , 22 , 24 };

    public static List<int> On_Ikiler = new List<int> { 5 , 6 , 7 , 9 , 13 , 16 , 20 , 21 , };

    public static List<int> Kirk_Ikiler = new List<int> { 9 , 10 , 13 , 14 , 18 , 21, 22, 23, };

    public static List<int> On_Yediler = new List<int> { 7 , 8 , 12 , 13 , 14 , 17 , 21 , 22 , 24 };

    public static List<int> Kirk_Yediler = new List<int> { 5 , 6 , 9 , 10 , 11 , 15 , 18 , 19 , 23 };

    public static List<string> isimler = new List<string> {"Pooka","Lard Orc","Orc Archer","Troll Berserker","Baron","Death Knight","Crimson Wing","Cardinal","Tyon","Ash Knight","Haunga","Deruvish","Lamia","Uruk Hai","Harpy",
            "DTS","UrukBlade","Wraith","Apostle","Garuna","Lamiros","Deruvish","Blood Seeker","Orc Sniper","Stone Golem","Haunga","BugBear","Raven Harpy","Sheriff","DTK","Lamentation","Dark Stone","Lich"
            ,"Hob Goblin","Uruk Tron","Scolar","Manticore","Burning Skeleton","Lamia","Fallen Angel","Grell","Mastadon","Centaur","Goblin Bounce","Harpy","Tyon","Stone Golem","Beast","GiantGolem","HaungaWarrior","TrollWarrior","Reaper"};

    public static List<int> Son = new List<int> ();

    public AudioClip Hazır;
    public AudioSource Sayman;

    public AudioClip sayar;
    public AudioSource hazman;


    public Text sayac;
    public Text mob_isim;
    public static float sayac_sure = 280;
    public static int mob_sira = 0;
    public static int sayac_anlık = 0;

    public int speed = 1;
    public bool playing = false;

    public InputField Sifir, İki, Yedi, anliksüre  ;



    public int Sifirlar_Gecikme, İkiler_Gecikme, Yediler_Gecikme;

    // Start is called before the first frame update
    void Start()
    {
        mob_isim.text = isimler[mob_sira];

      
    }

    // Update is called once per frame
    void Update()
    {
        sayac.text = sayac_sure.ToString();

        if (playing == true)
        {
            sayac_sure += Time.deltaTime * speed;

            sayac_anlık = Convert.ToInt32(sayac_sure);

            if(sayac_anlık == Son[mob_sira] - 2 )
            {
                mob_sira += 1;
                mob_isim.text = isimler[mob_sira];
                Debug.Log(Son[mob_sira]);

                Sayman.Play();
            }else if (sayac_anlık == Son[mob_sira] - 5)
            {
                hazman.Play();
            }

            
            string minutes = Mathf.Floor((sayac_sure % 3600) / 60).ToString("00");
            string seconds = (sayac_sure % 60).ToString("00");
            sayac.text ="Süre:" + minutes + ":" + seconds;
        }

        


        
    }

    public void click()
    {
        playing = true;
        
    }


    public void getsüre()
    {
        Sifirlar_Gecikme = int.Parse(Sifir.text);
        İkiler_Gecikme = int.Parse(İki.text);
        Yediler_Gecikme = int.Parse(Yedi.text);

        setsüre();

        
    }

    public void setanlik()
    {
        sayac_sure = int.Parse(anliksüre.text);
    }

    public void setsüre()
    {
        int x = 0;
        Son.Clear();

        foreach (int item in Sıfırlar)
        {
            x = (item * 60) + Sifirlar_Gecikme;
            Son.Add(x);

        }

        foreach (int item in Otuzlar)
        {
            x = (item * 60) + Sifirlar_Gecikme + 30 ;
            Son.Add(x);

        }

        foreach (int item in On_Ikiler)
        {
            x = (item * 60) + İkiler_Gecikme ;
            Son.Add(x);

        }

        foreach (int item in Kirk_Ikiler)
        {
            x = (item * 60) + İkiler_Gecikme + 30;
            Son.Add(x);

        }

        foreach (int item in On_Yediler)
        {
            x = (item * 60) + Yediler_Gecikme;
            Son.Add(x);

        }

        foreach (int item in Kirk_Yediler)
        {
            x = (item * 60) + Yediler_Gecikme + 30;
            Son.Add(x);

        }

        Son.Sort();

        
        
    }
}
