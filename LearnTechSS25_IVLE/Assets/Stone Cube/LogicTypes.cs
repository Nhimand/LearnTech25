using UnityEngine;

public enum LogicTypes
{  
    Not,           
    And,          
    Or,            
    Implies,
    EqRelation,    
    ConstTrue,  
    ConstFalse,
    KlammerAuf,
    KlammerZu,
    A,
    E,
    NotEqual,
    Equal
}

public class LogicBlock : MonoBehaviour
{
    public LogicTypes type;

    public Material Not;
    public Material And;
    public Material Or;
    public Material Implies;
    public Material EqRelation;
    public Material ConstTrue;
    public Material ConstFalse;
    public Material KlammerAuf;
    public Material KlammerZu;
    public Material E; 
    public Material A;
    public Material Equal;
    public Material NotEqual; 


    private LogicTypes lastType;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        lastType = type;
        UpdateMaterial();
    }

    private void Update()
    {
        if (type != lastType)
        {
            lastType = type;
            UpdateMaterial();
        }
    }

    private void UpdateMaterial()
    {
        switch (type)
        {
            case LogicTypes.Not:
            renderer.material = Not;
                break;
            case LogicTypes.And:
                renderer.material = And;
                break;
            case LogicTypes.Or:
                renderer.material = Or;
                break;
            case LogicTypes.Implies:
                renderer.material = Implies;
                break;
            case LogicTypes.EqRelation:
                renderer.material = EqRelation;
                break;
            case LogicTypes.ConstTrue:
                renderer.material = ConstTrue;
                break;
            case LogicTypes.ConstFalse:
                renderer.material = ConstFalse;
                break;
            case LogicTypes.Equal:
                renderer.material = Equal;
                break;        
            case LogicTypes.NotEqual:
                renderer.material = NotEqual;
                break;     
            case LogicTypes.KlammerAuf:
                renderer.material = KlammerAuf;
                break;            
            case LogicTypes.KlammerZu:
                renderer.material = KlammerZu;
                break;            
            case LogicTypes.E:
                renderer.material = E;
                break;            
            case LogicTypes.A:
                renderer.material = A;
                break;
        }
    }
}
