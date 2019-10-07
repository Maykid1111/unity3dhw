
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class UserGUI : MonoBehaviour, IUserAction ,Referee  {

    private int state;
    private int record=0;
    public UserGUI()
    {
        state = -1;
    }
    public void check(int a, int b, int a_, int b_)
    {
        if (b + b_ == 6 && a+a_==6)
        {
            state = 1;
            setWin();
            return;
        }
        if ((a_ != 0 && a > a_) || (b_ != 0 && b > b_))
        {
            state = 0;
            setLose();
        }
    }
    public void setWin()
    {
        state = 1;

    }

    public void setLose()
    {
        state = 0;
       
    }

    public void display()
    {
        OnGUI();
    }

    void f1()
    {
        
            for (int i = 0; i < 3; i++)
            {
                if (Director.GetInstance().manager.getPos("Devil" + i) == 0)
                {
                    Director.GetInstance().ccmove.moveTo("Devil" + i);
                    break;
                }
            }
        
    }
    void f2()
    {
        
            for (int i = 0; i < 3; i++)
            {
                if (Director.GetInstance().manager.getPos("Priest" + i) == 0)
                {
                    Director.GetInstance().ccmove.moveTo("Priest" + i);
                    break;
                }
            }
        
    }
    void f3()
    {
        
        
            for (int i = 0; i < 3; i++)
            {
                if (Director.GetInstance().manager.getPos("Priest" + i) == 1)
                {
                    Director.GetInstance().ccmove.moveTo("Priest" + i);
                    break;
                }
            }

        
    }
    void f4()
    {
        
        
            for (int i = 0; i < 3; i++)
            {
                if (Director.GetInstance().manager.getPos("Devil" + i) == 1)
                {
                    Director.GetInstance().ccmove.moveTo("Devil" + i);
                    break;
                }
            }
        
    }
    void fgo()
    {
        
        
            int x = 0;
            for (int i = 0; i < 3; i++)
            {
                if (Director.GetInstance().manager.getPos("Priest" + i) == 2)
                {
                    x++;
                }
                if (Director.GetInstance().manager.getPos("Devil" + i) == 2)
                {
                    x++;
                }
            }
            if (x != 0)
            {
                Director.GetInstance().ccmove.moveTo("boat");
            }
        
    }
    void foff()
    {
        
        
            for (int i = 0; i < 3; i++)
            {
                if (Director.GetInstance().manager.getPos("Priest" + i) == 2)
                {
                    Director.GetInstance().ccmove.moveTo("Priest" + i);
                    break;
                }
                if (Director.GetInstance().manager.getPos("Devil" + i) == 2)
                {
                    Director.GetInstance().ccmove.moveTo("Devil" + i);
                    break;
                }
            }
        
    }
    void q1()
    {
        f1();
        f2();
        fgo();
        foff();
        foff();
        
    }
    void q2()
    {
        f1();
        f1();
        fgo();
        foff();
        foff();
    }
    void q3()
    {
        f2();
        f2();
        fgo();
        foff();
        foff();
    }
    void q4()
    {
        f3();
        f4();
        fgo();
        foff();
        foff();
    }
    void q5()
    {
        f4();
        f4();
        fgo();
        foff();
        foff();
    }
    void q6()
    {
        f3();
        f3();
        fgo();
        foff();
        foff();
    }
    void back()
    {
        if (record == 1||record==2||record==3||record==4)
            foff();
        if (record == 5)
            fgo();
        /*if (record == 6)
            foff();*/
        if (record == 7)
            q4();
        if (record == 8)
            q5();
        if (record == 9)
            q6();
        if (record == 4)
            q1();
        if (record == 5)
            q2();
        if (record == 6)
            q3();
    }
    void OnGUI()
    {      
        if (GUI.Button(new Rect(50, 10, 100, 50), "Reset"))
        {
            Director.GetInstance().manager.reset();
        }
        if (state == 0)
        {
            GUI.Label(new Rect(300, 30, 100, 50), "You Lose!");
        }
        if (state == 1)
        {
            GUI.Label(new Rect(300, 30, 100, 50), "You Win!");
        }
        //左一按钮
        if (GUI.Button(new Rect(50, 100, 30, 30), "On"))
        {
            f1();
            record = 1;
        }
            
        //左二按钮
        if (GUI.Button(new Rect(100, 100, 30, 30), "On"))
        {
            f2();
            record = 2;
        }
            
        //右一
        if (GUI.Button(new Rect(500, 100, 30, 30), "On"))
        {
            f3();
            record = 3;
        }
            
        //右二
        if (GUI.Button(new Rect(550, 100, 30, 30), "On"))
        {
            f4();
            record = 4;
        }
            
        //Go
        if (GUI.Button(new Rect(300, 60, 30, 30), "Go"))
        {
            fgo();
            record = 5;
        }
            
        //off
        if (GUI.Button(new Rect(300, 150, 30, 30), "Off"))
        {
            foff();
            record = 6;
        }
            

        //sequenceaction
        if (GUI.Button(new Rect(150, 30, 40, 30), "d+p"))
        {
            
            q1();
            record = 7;
        }
        if (GUI.Button(new Rect(190, 30, 40, 30), "d+d"))
        {
           
            q2();
            record = 8;
        }
        if (GUI.Button(new Rect(150, 60, 40, 30), "p+p"))
        {
            
            q3();
            record = 9;
        }
        if (GUI.Button(new Rect(190, 60, 40, 30), "back"))
        {
            
            back();
        }

        if (GUI.Button(new Rect(400, 30, 40, 30), "d+p"))
        {
            
            q4();
            record = 10;
        }
        if (GUI.Button(new Rect(440, 30, 40, 30), "d+d"))
        {
            
            q5();
            record = 11;
        }
        if (GUI.Button(new Rect(400, 60, 40, 30), "p+p"))
        {
            
            q6();
            record = 12;
        }
        if (GUI.Button(new Rect(440, 60, 40, 30), "back"))
        {
            
            back();
            record = 13;
        }
    }

}
