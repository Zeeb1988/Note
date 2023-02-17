
1.作为行为组件的脚本
通过泛型方法GetComponent<T>()来获得gameObject的Component
在Update中通过静态方法Input.GetKeyDown(KeyCode.*)来更改组
件的属性。

using UnityEngine;
using System.Collections;

public class ExampleBehaviourScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Renderer> ().material.color = Color.red;
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

2.if语句
通过Time.deltaTime来控制变化的速率

using UnityEngine;
using System.Collections;

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

3.Awake和Start
当场景中存在挂载Awake函数的gameObject,无论物体是否被启用Awake函数
任然显性,Start的函数只有当物体被启用时才会显性。

using UnityEngine;
using System.Collections;

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

4.Update和FixedUpdate
Update函数在Unity中每一帧执行一次，执行的帧数取决于CPU的性能
而FixedUpdate则是每0.02秒执行一次，和物理相关的方法如果放在
Update当中，会更具不同配置表现出的不同性能展现出不统一的效果，
这通常不是我们想要的，因此和物理相关的方法放在FixedUpdate中
执行更佳，如果一定要放在Update中请乘以Time.deltaTime。

using UnityEngine;
using System.Collections;

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

5.矢量数学
点积 Dot Product
             Vector A(x,y,z) 
             Vector B(x,y,z)
(Ax*Bx) + (Ay*By) + (Az*Bz) = Dot Product
Vector3.Dot(VectorA,VectorB)

叉积 Cross Product
Vector3.Cross(VectorA,VectorB)    

6.启用和禁用组件
在Unity中每个物体自带gameObject和transform组件，当启用或禁用
gameObject时，直接调用 gameObject.SetActive(true/false)。
而启用或禁用gameObject的Component时，先声明对应Component的容器
再用泛型方法GetComponent<T>()获取物体的Component，然后对其进行
enabled的赋值操作。

using UnityEngine;
using System.Collections;

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

7.Translate和Rotate
Vector3(0,0,1) 快捷写法 Vector3.forword

Vector3(0,1,0) 快捷写法 Vector3.up

using UnityEngine;
using System.Collections;

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
