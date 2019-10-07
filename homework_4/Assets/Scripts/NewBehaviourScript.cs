using UnityEngine;
using System.Collections;

public class SSMoveToAction : SSAction
{
    public Vector3 target;
    public float speed;
    private SSMoveToAction() { }
    public static SSMoveToAction GetSSAction(Vector3 target, float speed)
    {
        SSMoveToAction action = ScriptableObject.CreateInstance<SSMoveToAction>();
        action.target = target;
        action.speed = speed;
        return action;
    }

    public void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        if (this.transform.position == target)
        {
            this.destory= true;
            this.callback.SSActionEvent(this);
        }
    }

    public void Start()
    {
        
    }
}
