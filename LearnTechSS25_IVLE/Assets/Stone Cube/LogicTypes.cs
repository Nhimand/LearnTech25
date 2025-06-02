using UnityEngine;

public enum LogicTypes
{
    ForAll,
    ThereEx,     
    Not,           
    And,          
    Or,            
    Implies,
    EqRelation,    
    ConstTrue,  
    ConstFalse  
}

public class LogicBlock : MonoBehaviour
{
    public LogicTypes type;
    public string value; 
}
