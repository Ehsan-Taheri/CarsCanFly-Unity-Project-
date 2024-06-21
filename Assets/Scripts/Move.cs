using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public string Language;
    public Text coin, tprice, eprice, best;
    public Text
    tlevel,
    elevel,
    tap;
    public int wh_mass;
    public float breakvol;
    public float tierspeed, masss;
    public float maxspeed, maxway;
    public float speed, carpower;
    public float _s;
    public Slider shiftbar, turbobar;
    public float jetpackpower;
    bool shift, turbo, isgame;
    int shiftnum = 0;
    public Button btn, turbobtn;
    public GameObject egzoz1, egziz2;
    WheelCollider l, r, fl, fr, mr;
    float _max, _power;
    float first, last;
    public Text record;
    public GameObject wheel, sako;
    Rigidbody rb;
    public GameObject panel;
    public Text newrec;
    public Button turboUP, earnigbut, engineUP, cars, hs;
    public AudioSource ac, ac2;
    // Update is called once per frame
    [HideInInspector]
    public ShakeCamera sc;
    public int point;
    public Transform hsLine;
    [Header("Audio clip")]
    public AudioClip tormoz;
    public AudioClip NOS, gaz, crash, dande, Wind;
    public WheelFrictionCurve frictionCurve;
    [SerializeField]
    public Text shiftmode1, shiftmode2, shiftmode3;
    public GameObject bp;
    public GameObject Tutorial_panel;
    Image shiftPin;
    // Use this for initialization
    float fbreak;



    float tirespeed = 20f;
    bool firstgameover;
    bool start;
    public GameObject particle_fx;
    bool end;
    public Text endscore;
    bool isover;

    public float Shetab = 3f;

    public GameObject RateUsPanel;
    private float breakPlaceSize=9f;

    void Awake()
    {

        PlayerPrefs.SetInt("coin", 40000);

        if (PlayerPrefs.GetInt("elevel") == 0)
            PlayerPrefs.SetInt("elevel", 1);
        if (PlayerPrefs.GetInt("tlevel") == 0)
            PlayerPrefs.SetInt("tlevel", 1);
        if (PlayerPrefs.GetInt("eprice") == 0)
            PlayerPrefs.SetInt("eprice", 500);
        if (PlayerPrefs.GetInt("tprice") == 0)
            PlayerPrefs.SetInt("tprice", 500);
        if (PlayerPrefs.GetInt("earningp") == 0)
            PlayerPrefs.SetInt("earningp", 500);
        if (PlayerPrefs.GetInt("earning") == 0)
            PlayerPrefs.SetInt("earning", 400);
        if (PlayerPrefs.GetInt("turbo") == 0)
            PlayerPrefs.SetInt("turbo", 40);
        if (PlayerPrefs.GetFloat("maxway") == 0)
            PlayerPrefs.SetFloat("maxway", 10);
        try
        {
            shiftPin = shiftbar.gameObject.transform.Find("Handle Slide Area").Find("Handle").GetComponent<Image>();
            shiftPin.color = Color.red;
        }
        catch
        {

        }
    }
    void Start()
    {

        if (PlayerPrefs.GetInt("firstplay") == 0)
        {
            Tutorial_panel.SetActive(true);
            PlayerPrefs.SetInt("coin", 400);


        }
        sc = GameObject.Find("Main Camera").GetComponent<ShakeCamera>();
        l = GameObject.Find("WheelR.L").GetComponent<WheelCollider>();
        r = GameObject.Find("WheelR.R").GetComponent<WheelCollider>();
        fl = GameObject.Find("WheelF.L").GetComponent<WheelCollider>();
        fr = GameObject.Find("WheelF.R").GetComponent<WheelCollider>();
        try
        {
            mr = GameObject.Find("Wheelm").GetComponent<WheelCollider>();
        }
        catch { }
        best.text = PlayerPrefs.GetInt("rec",0).ToString();

        coin.text = PlayerPrefs.GetInt("coin").ToString();
        tprice.text = PlayerPrefs.GetInt("tprice",500).ToString();
        eprice.text = PlayerPrefs.GetInt("eprice",500).ToString();
        tlevel.text = PlayerPrefs.GetInt("tlevel",1).ToString();
        elevel.text = PlayerPrefs.GetInt("elevel",1).ToString();
        earnigbut.transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("earningp",500).ToString();
        earnigbut.transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetInt("earning",200).ToString()+" $";
        checkcoin();


        maxway = PlayerPrefs.GetFloat("maxway",10);
        turbobar.maxValue = PlayerPrefs.GetInt("turbo",40);
        turbobar.value = turbobar.maxValue;
        ac = GetComponent<AudioSource>();
        ac.clip = gaz;
        ac.Stop();
        first = transform.position.z;
        _max = maxway;
        _power = carpower;
        isgame = true;
        rb = GetComponent<Rigidbody>();




        rb.mass = masss;
        if (PlayerPrefs.GetInt("rec") > 0)
            hsLine.position = new Vector3(0, 0, PlayerPrefs.GetInt("rec") * 4f);

    }


    void LateUpdate()
    {

        if (start)
        {
            //shetab avalie

            point = (int)(transform.position.z / 4f);
            record.text = (point).ToString();
            speed = rb.velocity.magnitude;
            if (speed > 15)
            {
                _s = 1;
                Shetab = 0;
            }
            if (tirespeed < 20)
                tirespeed += 0.4f;
            else
                tirespeed -= 0.4f;
            if (!isgame)
                tirespeed = 0f;
            l.transform.Rotate(speed * tirespeed * Time.deltaTime * tierspeed, 0, 0);
            r.transform.Rotate(speed * tirespeed * Time.deltaTime * tierspeed, 0, 0);
            fr.transform.Rotate(speed * tirespeed * Time.deltaTime * tierspeed, 0, 0);
            if (mr)
                mr.transform.Rotate(speed * tirespeed * Time.deltaTime * tierspeed, 0, 0);
            turbojet();
            if (speed < 15 && !isgame)
            {
                scope.isScope = true;

            }
            if (transform.position.y > 12f)
                if (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.x, 360f)) > 3f)
                {

                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.004f);
                }

            if (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.x, 360f)) == 0 && !isgame)
            {

                rb.freezeRotation = true;

            }

            if (speed < 2 && !isgame)
            {
                if (!isover)
                    GAMEOVER();
                Camera_follow.norot = true;
                rb.freezeRotation = false;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 45, 0), 0.1f);
                fr.transform.localEulerAngles = new Vector3(0f, 45f, 0f);
                rb.velocity = new Vector3(0, 0, 0);
                if (!end)
                    Invoke("GO", 3f);
            }


            if (!isgame)
            {


                if (!firstgameover)
                {

                    rb.mass = 8000 + speed;
                }
                else
                {
                    rb.velocity -= rb.velocity / 50;
                }
                rb.drag = 0.1f + (speed / 1500f);
                r.motorTorque = 0;
                l.motorTorque = 0;

                if (r.transform.position.z >= fbreak + breakPlaceSize && r.transform.position.y<2)                {

                    fbreak = r.transform.position.z;
                    float diff = r.transform.position.y /2;
                    Instantiate(bp, new Vector3(r.transform.position.x, diff, r.transform.position.z), Quaternion.identity);
                    Instantiate(bp, new Vector3(l.transform.position.x, diff, l.transform.position.z), Quaternion.identity);

                }
                if (!ac.isPlaying && transform.position.y < 1.5f && rb.velocity.magnitude > 0.01f)
                {
                    ac.pitch = 1f;
                    r.brakeTorque = breakvol;
                    l.brakeTorque = breakvol;
                    fr.brakeTorque = breakvol;
                    fl.brakeTorque = breakvol;

                    ac.clip = tormoz;

                    ac.loop = false;
                    ac.Play();



                }
                else if (rb.velocity.magnitude < 1)
                    ac.Stop();
            }
            else if (isgame)
            {
                if (speed >= maxspeed)
                {
                    r.brakeTorque = 15000;
                    l.brakeTorque = 15000;

                    r.motorTorque = 0;
                    l.motorTorque = 0;
                    if (!ac.isPlaying && isgame && transform.position.y < 1)
                    {
                        if (ac.pitch < 2)
                            ac.pitch += 0.009f;
                        //..	ac.clip = gaz;

                        //ac.Play ();
                    }
                }
                else
                {
                    if (!ac.isPlaying && isgame)
                    {
                        if (ac.pitch < 2)
                            ac.pitch += 0.009f;

                    }
                    r.brakeTorque = 0;
                    l.brakeTorque = 0;
                    fr.brakeTorque = 0;
                    fl.brakeTorque = 0;
                    rb.velocity += Vector3.forward * Shetab;
                    r.motorTorque = _s * carpower;
                    l.motorTorque = _s * carpower;
                    fr.motorTorque = _s * carpower;
                    fl.motorTorque = _s * carpower;
                }
            }




            if (point < maxway + 2 && point > maxway - 2)
                if (shiftnum < 3)
                {
                    canceltxt();
                    shiftbar.gameObject.SetActive(true);
                    if (PlayerPrefs.GetInt("firstplay") == 0)
                    {
                        if (gameManager.index == 1)
                        {
                           // ac.Pause();
                            Time.timeScale = 0.001f;
                            Tutorial_panel.transform.GetChild(0).GetChild(1).GetComponent<Text>().text= "This is the gear indicator, when it turns green, press it to change the gear"; ;// " این نشانگر دنده ماشینه وقتی رنگ گیره دنده سبز شد ضربه بزن تا دنده رو عوض کنی";
                            Tutorial_panel.SetActive(true);
                            Tutorial_panel.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                        }
                        else if (gameManager.index == 3)

                        {
                            Time.timeScale = 0.001f;
                            Tutorial_panel.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "You must change gear twice, if you don't change gear in the right place, your speed will slow down";//"شما دوبار باید دنده عوض کنید اگه دنده رو تو جای درست عوض نکنی سرعتت کم میشه";
                            Tutorial_panel.SetActive(true);

                        }
                    }
                    shift = true;
                    btn.gameObject.SetActive(true);
                }

                else if (shiftnum >= 3)
                {
                    Invoke("canceltxt", 1f);
                    turbobar.gameObject.SetActive(true);
                    if (PlayerPrefs.GetInt("firstplay") == 0)
                    {
                        if (gameManager.index <= 5)
                        {
                            Time.timeScale = 0.001f;
                            Tutorial_panel.transform.GetChild(0).GetChild(1).GetComponent<Text>().text ="Tap and hold to use the jetpack and jump. Be careful, you can jump further if you use the jetpack correctly";
                               // "ضربه بزنید و نگه دارید تا از جت پک استفاده کنید و بپرید. دقت کن با استفاده درست از جت پک بیشتر میتونی بپری ";
                            Tutorial_panel.SetActive(true);
                        }
                    }
                    turbobtn.gameObject.SetActive(true);
                    if (!sako.activeSelf)
                    {
                        sako.gameObject.SetActive(true);

                        sako.transform.position = new Vector3(0, 0.9f, transform.position.z + 75f);

                    }
                }

            if (shift)
            {
                shiftbar.value += Time.deltaTime;
                if (shiftbar.value >= shiftbar.maxValue)
                {
                    isgame = false;

                    shiftbar.gameObject.SetActive(false);
                    ac.Stop();
                    ac.clip = tormoz;

                    ac.loop = false;
                    ac.Play();
                    shift = false;
                    rb.drag = 0.6f;
                    firstgameover = true;
                    GAMEOVER();

                }
            }
            else
                shiftbar.value = 0f;
        }
        if (shiftbar.value / shiftbar.maxValue >= 0.5f && shiftbar.value / shiftbar.maxValue < 0.7f)
            shiftPin.color = Color.yellow;
        else if (shiftbar.value / shiftbar.maxValue >= 0.8f)
        {
            shiftPin.color = Color.green;
            if (PlayerPrefs.GetInt("firstplay") == 0)
            {
                Time.timeScale = 0.001f;
                Tutorial_panel.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Right here, be careful if you change the gear too late, your car engine will blow up";// "دقیقا همین جا دقت کن اگه دنده رو دیر عوض کنی موتور ماشینت میسوزه";
                Tutorial_panel.SetActive(true);
            }
        }
    }

    void shifting()
    {
        ac2.clip = dande;
        ac2.volume = 0.6f;
        ac2.Play();
        ac.pitch += 0.05f;
        shiftnum++;
        rb.AddForce(Vector3.forward * 10000f);

        shift = false;

        btn.gameObject.SetActive(false);
        shiftbar.gameObject.SetActive(false);
        float v = shiftbar.value / shiftbar.maxValue;
        if (v < 0.5f)
        {

            shiftmode3.gameObject.SetActive(true);
            maxway = (transform.position.z / 4f) + _max * 0.4f;

        }
        else if (v >= 0.5f && v < 0.8f)
        {
            shiftmode2.gameObject.SetActive(true);
            maxway = (transform.position.z / 4f) + _max * 0.7f;

        }
        else
        {
            shiftmode1.gameObject.SetActive(true);

            maxway = (transform.position.z / 4f) + _max;

        }

        shiftbar.value = 0f;

        shiftPin.color = Color.red;
        //	Invoke ("canceltxt", 1.5f);
        //InvokeRepeating ("txt_effect", 0.1f, 0.1f);

    }
    void canceltxt()
    {
        shiftmode3.gameObject.SetActive(false);
        shiftmode2.gameObject.SetActive(false);
        shiftmode1.gameObject.SetActive(false);



    }




    void turbojet()
    {
        if (turbo && turbobar.value > 0 && isgame)
        {
            //transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, 0), 0.2f);
            ac2.clip = NOS;
            if (!ac2.isPlaying)
                ac2.Play();
            egzoz1.SetActive(true);
            egziz2.SetActive(true);
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * jetpackpower);
            rb.AddForce(transform.up * jetpackpower/5 );
            turbobar.value -= 1f;
        }
        else
        {
            if (ac2.clip == NOS)
                ac2.Stop();
            egzoz1.SetActive(false);
            egziz2.SetActive(false);

        }
    }

    public void Button_clck()
    {
        if (shiftnum < 3 && shiftnum > 0 && isgame)
            shifting();
        else if (shiftnum == 0)
        {
            btn.gameObject.SetActive(false);
            start = true;
            shiftnum++;
            engineUP.gameObject.SetActive(false);
            turboUP.gameObject.SetActive(false);
            ac.clip = gaz;
            ac.loop = true;
            ac.Play();
            tap.gameObject.SetActive(false);

        }

    }
    public void checkcoin()
    {
        try
        {
            int x = int.Parse(engineUP.transform.GetChild(0).GetComponent<Text>().text);
            if (x > PlayerPrefs.GetInt("coin") && PlayerPrefs.GetInt("elevel") < 100)
                engineUP.interactable = false;
            x = int.Parse(turboUP.transform.GetChild(0).GetComponent<Text>().text);
            if (x > PlayerPrefs.GetInt("coin"))
                turboUP.interactable = false;
            x = int.Parse(earnigbut.transform.GetChild(0).GetComponent<Text>().text);
            if (x > PlayerPrefs.GetInt("coin"))
                earnigbut.interactable = false;
        }
        catch
        {
        }
    }
    public void engine_up(bool free)
    {

        if (!free)
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - PlayerPrefs.GetInt("eprice"));
        PlayerPrefs.SetInt("elevel", PlayerPrefs.GetInt("elevel") + 1);
        PlayerPrefs.SetInt("eprice", PlayerPrefs.GetInt("eprice") + 40);
        PlayerPrefs.SetFloat("maxway", PlayerPrefs.GetFloat("maxway") + 1f);
        maxway = PlayerPrefs.GetFloat("maxway");
        engineUP.transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("eprice").ToString();
        engineUP.transform.GetChild(1).GetComponent<Text>().text = (PlayerPrefs.GetInt("elevel")).ToString();
        coin.text = PlayerPrefs.GetInt("coin").ToString();
        _max = maxway;
        checkcoin();

    }
    public void turbo_up(bool free)
    {
        if (!free)
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - PlayerPrefs.GetInt("tprice"));
        PlayerPrefs.SetInt("tlevel", PlayerPrefs.GetInt("tlevel") + 1);
        PlayerPrefs.SetInt("tprice", PlayerPrefs.GetInt("tprice") + 40);
        PlayerPrefs.SetInt("turbo", PlayerPrefs.GetInt("turbo") + 6);
        turbobar.maxValue = PlayerPrefs.GetInt("turbo");
        turboUP.transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("tprice").ToString();
        turboUP.transform.GetChild(1).GetComponent<Text>().text = (PlayerPrefs.GetInt("tlevel")).ToString();
        coin.text = PlayerPrefs.GetInt("coin").ToString();
        turbobar.value = turbobar.maxValue;
        checkcoin();

    }
    public void earning()
    {
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - PlayerPrefs.GetInt("earningp"));
        PlayerPrefs.SetInt("earning", PlayerPrefs.GetInt("earning") + 10);
        PlayerPrefs.SetInt("earningp", PlayerPrefs.GetInt("earningp") + 40);


        earnigbut.transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("earningp").ToString();
        earnigbut.transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetInt("earning").ToString();
        coin.text = PlayerPrefs.GetInt("coin").ToString();

        checkcoin();

    }


    public void turbtn()
    {
        turbo = true;


    }
    public void upbtn()
    {
        if (ac2.isPlaying)
        {
            ac2.clip = NOS;
            ac2.Pause();
        }
        turbo = false;
    }


    void OnTriggerEnter(Collider c)
    {

        if (c.transform.tag == "Ground" && shiftnum > 1)
        {
            fbreak = r.transform.position.z + 50f;
            ac2.clip = NOS;
            ac2.Stop();
            ac2.clip = crash;
            ac2.Play();
            ac.Stop();
            particle_fx.transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z + 10);
            r.mass = wh_mass;
            l.mass = wh_mass;
            fl.mass = wh_mass;
            fr.mass = wh_mass;
            particle_fx.SetActive(true);
            sc.DoShake();



            //rb.AddForce (0,100000f,100000f );
            isgame = false;
            turbo = false;
        }
        if (c.tag == "Gold")
        {

            ac.Stop();
            ac.clip = Wind;
            ac.Play();
            Camera_follow.rot = true;
            rb.AddForce(Vector3.up * 100000);
        }


    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "hs")
        {
            c.gameObject.SetActive(false);

        }

    }

    void GO()
    {
        if (end) { return; }

        panel.SetActive(true);
        endscore.text = point.ToString();
        if (Random.Range(0, 4) == 0)
            panel.transform.GetChild(3).gameObject.SetActive(true);
        CancelInvoke("GO");
        end = true;
    }


    void GAMEOVER()
    {
        

        if (int.Parse(record.text) > PlayerPrefs.GetInt("rec"))
        {
            if (PlayerPrefs.GetInt("firstplay") != 0 && PlayerPrefs.GetInt("rate") == 0)
            {
                if (Random.Range(0, 7) == 0)
                    RateUsPanel.SetActive(true);
            }

            newrec.gameObject.SetActive(true);
            PlayerPrefs.SetInt("rec", int.Parse(record.text));

        }
        else
            newrec.gameObject.SetActive(false);
        isover = true;


    }

    public void Restart()
    {
        ac.Stop();
        scope.isScope = false;
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + int.Parse(record.text));
        CancelInvoke(nameof(GO));
        panel.SetActive(false);
        shiftnum = 0;
        _s = 0;
        sako.SetActive(false);
        turbobtn.gameObject.SetActive(false);
        btn.gameObject.SetActive(false);
        turbo = false;
        shift = false;

        isgame = true;
        transform.position = new Vector3(0, 1, 0);
        maxway = _max;
        carpower = _power;
        turbobar.value = turbobar.maxValue;
        turbobar.gameObject.SetActive(false);
        r.brakeTorque = 0;
        l.brakeTorque = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 1f);
        wheel.transform.rotation = Quaternion.Euler(0, 0, 0);
        wheel.GetComponent<WheelCollider>().steerAngle = 0;
        Camera_follow.rot = false;

        PlayerPrefs.SetInt("firstplay", 1);
        SceneManager.LoadScene("Main");

    }
}
