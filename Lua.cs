//一、Lua 弱解释脚本语言语法

1.变量声明
#region
{
    *Lua语言结尾不需要分号(";"),多个连续变量声明不需要(",")
    输出方法：print("Hello！")
    a = 1  b = 2
    Lua语言中默认声明变量为全局变量，声明局部变量用local关键字如：
    local a = 3
}

#endregion

2.nil类型
#region
{ 
    nil类似于其他语言中的Null
    Lua中没用被赋值的变量的默认值是nil
    print(c) => 输出结果:nil
}
#endregion  

3.多重赋值
#region
{ 
    a,b = 3,4
    print(a,b)
    输出结果:3 4
}
#endregion

4.number数值型
#region
{ 
    在C语言中数字有很多类型如：int, long, float, double
    而Lua语言中只有一种类型，即: number 
    此外Lua语言中的赋值可以用 "十六进制" 和 "科学计数法" 如:
    a = 0x11  a = 2e10 
}
#endregion

5.算数运算符
#region
{ 
    a = 1 b = 2
    print(a + b)
    print(2^10)
    print(1 << 3) //支持版本:Lua 5.3
}
#endregion

6.string字符串
#region
{ 
    *Lua中字符串的表示方法可以用 "" 或者 '' 如:
    a = "dsdad\nasdasd"//其中的转义字符也能识别
    b = 'dsffdsfsdf'
    *想要格式化打印字符串用"[[ ]]" 如:
    a = [[dasdasdasdsdas
        dsdasdda
        dadadadsd]]
    输出之后将原封不动的打印[[]]中的内容
    *字符串连接符号".." 如：
       print(a..b)
    *string类型可以转换成number类型,number类型也可以转换成string类型
    c = tostring(10) 
    b = tonumber("10")
    当赋值失败时，变量会恢复默认值nil
    n = tonumber("abc") 
    *字符串前加"#"可以表示字符串的长度:
    a = "asdfgh"
    print(#a) => 输出结果: 6
    //string.char()函数可以把ASCCI码值变成相应的ASCII码的字符串，通常用16进制的码值
    s = string.char(0x30,0x00,0x31,0x34,0x34)  //C语言中0代表结束，而Lua语言中0可以存放
    print(s) => "0123"  //***十六进制码值转换成ASCCI码的字符串
    //string.byte()函数可以取出某个字符串的某一位
    //如果是ASCII码值则会将他转换成十进制码值的字符串在输出
    n = string.byte(s,3)
    print(n) => "49"   //***十六进制码值转换成十进制码值的字符串
    //print()函数默认输出十进制数据
}
#endregion

7.function函数
#region
{ 
    *函数的声明方法：//Lua函数中默认的返回值时nil
    function f(a,b)
        --body  //Lua语言的注释方法为"--",两个减号
    end         //function作为开头，end作为结尾必不可少
或者:
    f = function(a,b)
        --body
    end
   *函数可以有多个返回值,并且形参和实参可以不匹配
   function Main(a,b,c)
        return a,b
    end
    print(Main(1,2))
    输出结果: 1  2
    多个返回值可以配合多重赋值语句:
    local i,j = Main(1,2)

}
#endregion

8.table数字下标
#region
{ 
    //Lua中的table相当于其他语言中的数组
    //table分为数字小标和字符串下标两种
    //table中可以存放任意元素且下标从1开始
    a = {1,"dsadad",{},function() end}
    a[5] = "123"
    //可以在table任意位置插入任意元素
    table.insert(a,2,"X")
    //移除table中某一位置的元素，会将此元素作为返回值返回
    local c = table.move(a,1)
    print(c) => 输出: 1
}
#endregion

9.table字符串下标
#region
{ 
    a = { 
        a = 122,
        b = "568",
        c = function()
         --body
        end,
        d = 4568,
        [",:"] = "abc",
    }
    //打印第一个元素
    print(a["a"]) 或者 print(a.a)
    //打印不规则下标的元素
    print(a[",;"])
    //和数字下标的table一样，字符串下标的table
    //也可以在任意位置插入元素
    *如果输出元素的下标在table中不存在,则会输出其默认值nil
}
#endregion

10.全局表_G
#region
{ 
    //全局表默认是字符串下标的table
    *所有的全局变量都在全局表_G里面
    table.insert()
    print(_G["table"]["insert"])
}
#endregion

11.真和假
#region
{ 
    print(1 > 2)
    print(1 < 2)
    print(1 >= 2)
    print(1 <= 2)
    print(1 == 2)
    //Lua中不等于用"~="表示
    print(1 ~= 2)

    a = true b = false
    //逻辑且
    print(a and b)
    //逻辑与
    print(a or b)
    //逻辑非
    print(not a)
    *Lua语言中只有false和nil代表逻辑假，数字0代表逻辑真
    local c = 1
    //利用 and 和 or 实现短路求值，相当于C语言中的三目运算符
    print(c > 10 and "Yes" or "No")
}
#endregion

12.分支判断语句
#region
{ 
    //if 判断条件  then开头 end结尾
    if 1>10 then     //数字0代表真
        print("1>10")
    elseif 1<10      //else和if 必须连写中间不能有空格
        print("1<10")
    else 
        print("no")
    end
}
#endregion

13.循环(Loop)
#region
{ 
    //变量i默认为本地变量，10为循环终点，2为步长
    //步长默认是1，步长也可以是负数
    //for循环和分支不同是 do 开头，if则是 then 开头
    for i = 1,10,2 do
        print(i)
        i = 5 //初值在循环过程中不允许被修改，此处为新建本地变量季:local i = 5
        if i == 6 then break end
    end

    local n = 10
    while n > 1 do
        print(n)
        n = n - 1 //Lua 语言中没有 "n++" 或 "n += 1" 此类语法
        if n == 3 then break end
    end
}
#endregion












