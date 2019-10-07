using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, SceneController,SSActionManager
{

    private Role[] Priests;              
    private Role[] Devils;               

    private GameObject GroundFrom;       
    private GameObject GroundTo;         
    private GameObject Water;
    private GameObject Light;

    private Boat boat;             

    private int a;
    private int a_;
    private int b;
    private int b_;
    private int state;                      // 0--输，1--赢, 2--运行

    private UserGUI mygui;

    

    FirstController()
    {
        Priests = new Role[3];
        Devils = new Role[3];
    }

    // Use this for initialization
    void Start() {
        Director director = Director.GetInstance();        
        director.scene = this;
        director.manager = this;
        director.ccmove = this;
        director.ccsequen = this;
        this.load();
    }
    public void sequenaction(string name)
    {


    }
    public void load()
    {
        float p = 1.5f;
        state = 2;      
        a = a_ = 3;
        b = b_ = 0;
        mygui = new UserGUI();
        Vector3 groundFromPos = new Vector3(0, -5, 15);
        Vector3 groundToPos = new Vector3(0, -5, -15);
        Vector3 waterPos = new Vector3(0, -6.5f, 0);

        // 地面      
        GroundFrom = Object.Instantiate(Resources.Load("Ground", typeof(GameObject)), groundFromPos, Quaternion.identity) as GameObject;        
        GroundTo = Object.Instantiate(Resources.Load("Ground", typeof(GameObject)), groundToPos, Quaternion.identity) as GameObject;

        // 水
        Water = Object.Instantiate(Resources.Load("Water", typeof(GameObject)), waterPos, Quaternion.identity) as GameObject;
        

        // 船
        boat = new Boat();

        // 牧师和恶魔
        for (int i = 0;i < 3;i ++)
        {
            Role role_priest = new Role("Cube");
            Role role_devil = new Role("Sphere");
            float pos_priest = (float)(8 + i * p);
            float pos_devil = (float)(13 + i * p);
            role_priest.setName("Priest"+ i);
            role_devil.setName("Devil" + i);
            Priests[i] = role_priest;
            Devils[i] = role_devil;
            Priests[i].setFromPos(new Vector3(0, 0, pos_priest));
            Priests[i].setToPos(new Vector3(0, 0, -pos_priest));                   
            Devils[i].setFromPos(new Vector3(0, 0, pos_devil));
            Devils[i].setToPos(new Vector3(0, 0, -pos_devil));
        }

        //light
        //Light = Object.Instantiate(Resources.Load("Light", typeof(GameObject)), new Vector3(0, 3, 0), Quaternion.identity) as GameObject;

        GroundFrom.name = "groundfrom";
        GroundTo.name = "groundto";
        Water.name = "water";
        //Light.name = "Light";


    }


    public Role findRole(string name)
    {
        Role role_1 = null;
        for (int i = 0; i < 3; i++)
        {
            if (name == ("Priest" + i))
            {
                role_1 = Priests[i];
                break;
            }
            if (name == ("Devil" + i))
            {
                role_1 = Devils[i];
                break;
            }
        }
        return role_1;
    }


    public int getPos(string name)
    {
        if (name == "boat")
        {
            return boat.pos;
        }
        return findRole(name).pos;
    }

    public void moveTo(string name)
    {
        Role obj = findRole(name);
        if (name == "boat")
        {
            if(boat.pos == 0 && boat.Count > 0)//船在右且船上有人
            {
                boat.pos = 1;//设置船的位置
                boat.thisboat.transform.position = new Vector3(0, -4, -5);//船移动
                for(int i = 0;i < 3;i ++)
                {               
                    if(Priests[i].pos == 2)
                    {
                        a_--;
                        b_++;
                        if (Priests[i].boatPos == 0)
                        {
                            Priests[i].getBoat(4);
                        }
                        else
                        {
                            Priests[i].getBoat(3);
                        }
                    }
                    if(Devils[i].pos == 2)
                    {
                        a--;
                        b++;
                        if (Devils[i].boatPos == 0)
                        {
                            Devils[i].getBoat(4);
                        }
                        else
                        {
                            Devils[i].getBoat(3);
                        }
                    }
                }
            }
            // 船移动
            else if(boat.Count > 0)
            {
                boat.pos= 0;
                boat.thisboat.transform.position = new Vector3(0, -4, 5);
                for (int i = 0; i < 3; i++)
                {
                    if (Priests[i].pos == 2)
                    {
                        a_++;
                        b_--;
                        if (Priests[i].boatPos == 0)
                        {
                            Priests[i].getBoat(1);
                        }
                        else
                        {
                            Priests[i].getBoat(2);
                        }
                    }
                    if (Devils[i].pos == 2)
                    {
                        a++;
                        b--;
                        if (Devils[i].boatPos == 0)
                        {
                            Devils[i].getBoat(1);
                        }
                        else
                        {
                            Devils[i].getBoat(2);
                        }
                    }
                }
            }
        }
        // 上下船
        else
        {          
            if(obj.pos == 0 && 0 == boat.pos && boat.Count < 2)//对象在左边，船在左，有空位
            {
                for (int i = 0; i < 2; i++)
                {
                    if (boat.State[i] == 0)
                    {
                        obj.getBoat(1 + i);
                        boat.State[i] = 1;
                        break;
                    }
                }
                boat.Count++;
            }
            else if (obj.pos == 2)//对象在船上
            {
                if (boat.pos == 0)//船在左边
                {
                    boat.State[obj.boatPos] = 0;
                    obj.MoveToFromPos();
                }
                else//船在右边
                {
                    boat.State[obj.boatPos] = 0;
                    obj.MoveToToPos();               
                }
                boat.Count--;
            }
            else if(obj.pos == 1 && 1 == boat.pos && boat.Count < 2)//对象在右边，且船在右边，船上有空位
            {          
                for(int i = 0; i < 2; i++)
                {
                    if (boat.State[i] == 0)
                    {
                        obj.getBoat(4-i);
                        boat.State[i] = 1;
                        break;
                    }
                } 
                boat.Count++;
            }

            
        }
    }

    // Update is called once per frame
    void Update () {
        mygui.check(a, b, a_, b_);
    }
    
    public void reset()
    {
        for(int i = 0;i < 3;i ++)
        {
            Destroy(Priests[i]._object);
            Destroy(Devils[i]._object);           
        }
        Destroy(boat.thisboat);
        Destroy(GroundFrom);
        Destroy(GroundTo);
        Destroy(Water);
        load();
    }


    void OnGUI()
    {
        mygui.display();
    }


}
