using System.Collections.Generic;
using UnityEngine;

public class LogicEval : MonoBehaviour
{
    public List<LogicBlock> logicBlocks;

    public bool? EvaluateFormula() //bool? for true, flase and null
    {
        Stack<bool> stack = new Stack<bool>(); //LogicStack

        foreach (var block in logicBlocks)
        {
            switch (block.type) //push the right logic type into the stack
            {
                case LogicTypes.ConstTrue:
                    stack.Push(true);
                    break;

                case LogicTypes.ConstFalse:
                    stack.Push(false);
                    break;

                case LogicTypes.Not:
                    if (stack.Count < 1) return null; //wrong inputs
                    stack.Push(!stack.Pop());
                    break;

                case LogicTypes.And:
                    if (stack.Count < 2) return null;
                    bool b1 = stack.Pop();
                    bool b2 = stack.Pop();
                    stack.Push(b1 && b2);
                    break;

                case LogicTypes.Or:
                    if (stack.Count < 2) return null;
                    b1 = stack.Pop();
                    b2 = stack.Pop();
                    stack.Push(b1 || b2);
                    break;

                case LogicTypes.Implies:
                    if (stack.Count < 2) return null;
                    b1 = stack.Pop(); 
                    b2 = stack.Pop(); 
                    stack.Push(!b1 || b2); // a implies b == not a or b
                    break;

                case LogicTypes.EqRelation:
                    if (stack.Count < 2) return null;
                    b1 = stack.Pop(); 
                    b2 = stack.Pop(); 
                    stack.Push(b1 == b2); // a implies b AND b implies a
                    break;
            }
        }

        return stack.Count == 1 ? (bool?)stack.Pop() : null;
    }
}
