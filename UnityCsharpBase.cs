
1.作为行为组件的脚本
#region
通过泛型方法GetComponent<T>()来获得gameObject的Component
在Update中通过静态方法Input.GetKeyDown(KeyCode.*)来更改组
件的属性.
public class ExampleBehaviourScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
#endregion

2.if语句
#region
通过Time.deltaTime来控制变化的速率

public class IfStatements : MonoBehaviour
{
    float coffeeTemperature = 85.0f;
    float hotLimitTemperature = 70.0f;
    float coldLimitTemperature = 40.0f;
    

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            TemperatureTest();
        
        coffeeTemperature -= Time.deltaTime * 5f;
    }
    
    
    void TemperatureTest ()
    {
        // 如果咖啡的温度高于最热的饮用温度...
        if(coffeeTemperature > hotLimitTemperature)
        {
            // ... 执行此操作。
            print("Coffee is too hot.");
        }
        // 如果不是，但咖啡的温度低于最冷的饮用温度...
        else if(coffeeTemperature < coldLimitTemperature)
        {
            // ... 执行此操作。
            print("Coffee is too cold.");
        }
        // 如果两者都不是，则...
        else
        {
            // ... 执行此操作。
            print("Coffee is just right.");
        }
    }
}
#endregion

3.Awake和Start
#region
当场景中存在挂载Awake函数的gameObject, 无论物体是否被启用Awake函数
任然显性,Start的函数只有当物体被启用时才会显性。

public class AwakeAndStart : MonoBehaviour
{
    void Awake ()
    {
        Debug.Log("Awake called.");
    }
    
    
    void Start ()
    {
        Debug.Log("Start called.");
    }

}
#endregion

4.Update和FixedUpdate
#region
Update函数在Unity中每一帧执行一次，执行的帧数取决于CPU的性能
而FixedUpdate则是每0.02秒执行一次，和物理相关的方法如果放在
Update当中，会更具不同配置表现出的不同性能展现出不统一的效果，
这通常不是我们想要的，因此和物理相关的方法放在FixedUpdate中
执行更佳，如果一定要放在Update中请乘以Time.deltaTime。


public class UpdateAndFixedUpdate : MonoBehaviour
{
    void FixedUpdate ()
    {
        Debug.Log("FixedUpdate time :" + Time.deltaTime);
    }
    
    
    void Update ()
    {
        Debug.Log("Update time :" + Time.deltaTime);
    }
}
#endregion

5.矢量数学
#region
点积 Dot Product
             Vector A(x,y,z) 
             Vector B(x,y,z)
(Ax*Bx) + (Ay*By) + (Az*Bz) = Dot Product
Vector3.Dot(VectorA,VectorB)

叉积 Cross Product
Vector3.Cross(VectorA,VectorB)  
#endregion

6.启用和禁用组件
#region
在Unity中每个物体自带gameObject和transform组件，当启用或禁用
gameObject时，直接调用 gameObject.SetActive(true/false)。
而启用或禁用gameObject的Component时，先声明对应Component的容器
再用泛型方法GetComponent<T>()获取物体的Component，然后对其进行
enabled的赋值操作



public class EnableComponents : MonoBehaviour
{
    private Light myLight;
    
    
    void Start ()
    {
        myLight = GetComponent<Light>();

        gameObject.SetActive(false);
    }
    
    
    void Update ()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            myLight.enabled = !myLight.enabled;
        }
    }
}
#endregion

7.Translate和Rotate
#region
new Vector3(0,0,1) 快捷写法 Vector3.forword

new Vector3(0,1,0) 快捷写法 Vector3.up


public class TransformFunctions : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    
    
    void Update ()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}
#endregion

8.Look At
#region
使用LookAt函数让gameObject的transform组件始终面向某个gameObject

public class CameraLookAt : MonoBehaviour
{
     public Transform target;

     void Update()
     {
           transform.LookAt(target);
     }
}
#endregion

9.线性插值
#region
{
    在制作游戏时，有时可以在两个值之间进行线性插值。这是通过 Lerp 函数来完成的。线性插值会
在两个给定值之间找到某个百分比的值。例如，我们可以在数字 3 和 5 之间按 50 % 进行线性插
值以得到数字 4。这是因为 4 是 3 和 5 之间距离的 50 %。在 Unity 中，有多个 Lerp 函数
可用于不同类型。对于我们刚才使用的示例，与之等效的将是 Mathf.Lerp 函数，如下所示：
// 在此示例中，result = 4
float result = Mathf.Lerp(3f, 5f, 0.5f);

    Mathf.Lerp 函数接受 3 个 float 参数：一个 float 参数表示要进行插值的起始值，另一个
float 参数表示要进行插值的结束值，最后一个 float 参数表示要进行插值的距离。在此示例中，
插值为 0.5，表示 50 %。如果为 0，则函数将返回“from”值；如果为 1，则函数将返回“to”值。
Lerp 函数的其他示例包括 Color.Lerp 和 Vector3.Lerp。这些函数的工作方式与 Mathf.Lerp
完全相同，但是“from”和“to”值分别为 Color 和 Vector3 类型。在每个示例中，第三个参数
仍然是一个 float 参数，表示要插值的大小。这些函数的结果是找到一种颜色（两种给定颜色的某
种混合）以及一个矢量（占两个给定矢量之间的百分比）。

让我们看看另一个示例：
    Vector3 from = new Vector3(1f, 2f, 3f);
    Vector3 to = new Vector3(5f, 6f, 7f);

    // 此处 result = (4, 5, 6)
    Vector3 result = Vector3.Lerp(from, to, 0.75f);

    在此示例中，结果为(4, 5, 6)，因为 4 位于 1 到 5 之间的 75 % 处，5 位于 2 到 6 之间
    的 75 % 处，而 6 位于 3 到 7 之间的 75 % 处。使用 Color.Lerp 时适用同样的原理。在 Color
结构中，颜色由代表红色、蓝色、绿色和 Alpha 的 4 个 float 参数表示。使用 Lerp 时，与
Mathf.Lerp 和 Vector3.Lerp 一样，这些 float 数值将进行插值。
在某些情况下，可使用 Lerp 函数使值随时间平滑。请考虑以下代码段：

    void Update()
    {
       light.intensity = Mathf.Lerp(light.intensity, 8f, 0.5f);
    }
    如果光的强度从 0 开始，则在第一次更新后，其值将设置为 4。下一帧会将其设置为 6，然后
    设置为 7，再然后设置为 7.5，依此类推。因此，经过几帧后，光强度将趋向于 8，但随着接近目标，
其变化速率将减慢。请注意，这是在若干个帧的过程中发生的。

如果我们不希望与帧率有关，则可以使用以下代码：
    void Update()
    {
        light.intensity = Mathf.Lerp(light.intensity, 8f, 0.5f * Time.deltaTime);
    }
    这意味着强度变化将按每秒而不是每帧发生。请注意，在对值进行平滑时，通常情况下最好使用
    SmoothDamp 函数。仅当您确定想要的效果时，才应使用 Lerp 进行平滑。
}
#endregion

10.Destroy
#region
public class DestroyBasic : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Destroy(gameObject);
            //通过后面增加参数让方法延迟执行
            Destroy(gameObject,2f);
        }
    }
}
#endregion

11.GetButton和GetKey
#region
public class ButtonInput : MonoBehaviour
{
    

    void Start()
    {
        graphic.texture = standard;
    }

    void Update()
    {
        //GetButton/KeyDown 只检测一次向下按的操作
        bool down = Input.GetButtonDown("Jump");
        //GetButton/Key 持续检测是否处于按住按钮的状态
        bool held = Input.GetButton("Jump");
        //GetButton/keyUp 只检测一次完整的按下按钮以及松开按钮的完整过程
        bool up = Input.GetButtonUp("Jump");

    }
}
#endregion

12.GetAxis
#region
public class AxisExample : MonoBehaviour
{
    public float range;
    public GUIText textOutput;


    void Update()
    {
        //Input.GetAxis("Horizontal")会根据按键的极性得到0至1或0至-1之间
        //的慢慢增长的数如（0.001，0.002，....，0.006，...，0.054，...）
        //而Input.GetAxisRaw("Horizontal")只会得到整数
        float h = Input.GetAxis("Horizontal");
        float x = Input.GetAxisRaw("Horizontal");
        float xPos = h * range;

        transform.position = new Vector3(xPos, 2f, 0);
        textOutput.text = "Value Returned: " + h.ToString("F2");
    }
}
#endregion

13.OnMouseDown
#region
OnMouseDown方法会直接监听鼠标的按键，当脚本挂载在物体上
且脚本包含OnmouseDown方法时，鼠标点击挂载OnMouseDown
方法的物体时会直接响应对应的函数操作。
public class MouseClick : MonoBehaviour
{
    void OnMouseDown()
    {
        rigidbody.AddForce(-transform.forward * 500f);
        rigidbody.useGravity = true;
    }
}
#endregion

14.GetComponent
#region

通过GetComponent<T>()泛型方法来获取当前物体或其他物体的组件并对其进行操作。

public class UsingOtherComponents : MonoBehaviour
{
    public GameObject otherGameObject;


    private AnotherScript anotherScript;
    private YetAnotherScript yetAnotherScript;
    private BoxCollider boxCol;


    void Awake()
    {
        anotherScript = GetComponent<AnotherScript>();
        yetAnotherScript = otherGameObject.GetComponent<YetAnotherScript>();
        boxCol = otherGameObject.GetComponent<BoxCollider>();
    }


    void Start()
    {
        boxCol.size = new Vector3(3, 3, 3);
        Debug.Log("The player's score is " + anotherScript.playerScore);
        Debug.Log("The player has died " + yetAnotherScript.numberOfPlayerDeaths + " times");
    }
}
#endregion

15.Delta Time
#region
Time.deltaTime通常用来使游戏数值平滑，从而达到画面平滑的效果
并且可以进行时间延迟
public class UsingDeltaTime : MonoBehaviour
{
    public float speed = 8f;
    public float countdown = 3.0f;


    void Update()
    {
        //简易倒计时器
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
            light.enabled = true;

        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }
}
#endregion

16.数据类型
#region
{ 
         ·Value       ·Referance

         ·int         ·Classes
         ·float         ·Transform
         ·double        ·GameObject
         ·bool
         ·char
         ·Structs
           ·Vector3
           ·Quaternion
}
#endregion

17.Instantiate
#region
Instantiate(要生成的物体，位置，角度)
public class UsingInstantiate : MonoBehaviour
{
    public Rigidbody rocketPrefab;
    public Transform barrelEnd;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody rocketInstance;
            //在指定位置生成指定的物体
            rocketInstance = Instantiate(rocketPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            rocketInstance.AddForce(barrelEnd.forward * 5000);
        }
    }
}
#endregion

18.数组
#region
数组的定义方式:
int[] Array = new int[5]
int[] Array = {12, 5, 3, 6, }

public class Arrays : MonoBehaviour
{
    public GameObject[] players;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        //数组常搭配循环使用
        for (int i = 0; i < players.Length; i++)
        {
            Debug.Log("Player Number " + i + " is named " + players[i].name);
        }
    }
}
#endregion

19.Invoke
#region
Invoke("函数名",延迟调用时间)
InvokeRepeating("函数名",延迟调用时间,要重复调用的次数)
CancelInvoke("函数名")

public class InvokeScript : MonoBehaviour
{
    public GameObject target;


    void Start()
    {
        Invoke("SpawnObject", 2);
        InvokeRepeating("SpawnObject", 2, 1);
        CancleInvoke("SpawnObject");
    }

    void SpawnObject()
    {
        Instantiate(target, new Vector3(0, 2, 0), Quaternion.identity);
    }
}
#endregion

20.枚举(enum)
#region
枚举通常与Switch语句搭配使用

public class EnumScript : MonoBehaviour
{
    enum Direction { North, East, South, West }

    void Start()
    {
        Direction myDirection;

        myDirection = Direction.North;
    }

    Direction ReverseDirection(Direction dir)
    {
        if (dir == Direction.North)
            dir = Direction.South;
        else if (dir == Direction.South)
            dir = Direction.North;
        else if (dir == Direction.East)
            dir = Direction.West;
        else if (dir == Direction.West)
            dir = Direction.East;

        return dir;
    }
}
#endregion

21.Switch语句
#region
可用于状态机的状态切换

public class ConversationScript : MonoBehaviour
{
    public int intelligence = 5;


    void Greet()
    {
        switch (intelligence)
        {
            case 5:
                print("Why hello there good sir! Let me teach you about Trigonometry!");
                break;
            case 4:
                print("Hello and good day!");
                break;
            case 3:
                print("Whadya want?");
                break;
            case 2:
                print("Grog SMASH!");
                break;
            case 1:
                print("Ulg, glib, Pblblblblb");
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }
}
#endregion

