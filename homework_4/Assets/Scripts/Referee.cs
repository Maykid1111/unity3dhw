using UnityEngine;
using System.Collections;

public interface Referee{
    void setLose();
    void setWin();
    void check(int a,int b,int a_,int b_);
}
