//һ��Lua �����ͽű������﷨

1.��������
#region
{
    *Lua���Խ�β����Ҫ�ֺ�(";"),�������������������Ҫ(",")
    ���������print("Hello��")
    a = 1  b = 2
    Lua������Ĭ����������Ϊȫ�ֱ����������ֲ�������local�ؼ����磺
    local a = 3
}

#endregion

2.nil����
#region
{ 
    nil���������������е�Null
    Lua��û�ñ���ֵ�ı�����Ĭ��ֵ��nil
    print(c) => ������:nil
}
#endregion  

3.���ظ�ֵ
#region
{ 
    a,b = 3,4
    print(a,b)
    ������:3 4
}
#endregion

4.number��ֵ��
#region
{ 
    ��C�����������кܶ������磺int, long, float, double
    ��Lua������ֻ��һ�����ͣ���: number 
    ����Lua�����еĸ�ֵ������ "ʮ������" �� "��ѧ������" ��:
    a = 0x11  a = 2e10 
}
#endregion

5.���������
#region
{ 
    a = 1 b = 2
    print(a + b)
    print(2^10)
    print(1 << 3) //֧�ְ汾:Lua 5.3
}
#endregion

6.string�ַ���
#region
{ 
    *Lua���ַ����ı�ʾ���������� "" ���� '' ��:
    a = "dsdad\nasdasd"//���е�ת���ַ�Ҳ��ʶ��
    b = 'dsffdsfsdf'
    *��Ҫ��ʽ����ӡ�ַ�����"[[ ]]" ��:
    a = [[dasdasdasdsdas
        dsdasdda
        dadadadsd]]
    ���֮��ԭ�ⲻ���Ĵ�ӡ[[]]�е�����
    *�ַ������ӷ���".." �磺
       print(a..b)
    *string���Ϳ���ת����number����,number����Ҳ����ת����string����
    c = tostring(10) 
    b = tonumber("10")
    ����ֵʧ��ʱ��������ָ�Ĭ��ֵnil
    n = tonumber("abc") 
    *�ַ���ǰ��"#"���Ա�ʾ�ַ����ĳ���:
    a = "asdfgh"
    print(#a) => ������: 6
    //string.char()�������԰�ASCCI��ֵ�����Ӧ��ASCII����ַ�����ͨ����16���Ƶ���ֵ
    s = string.char(0x30,0x00,0x31,0x34,0x34)  //C������0�����������Lua������0���Դ��
    print(s) => "0123"  //***ʮ��������ֵת����ASCCI����ַ���
    //string.byte()��������ȡ��ĳ���ַ�����ĳһλ
    //�����ASCII��ֵ��Ὣ��ת����ʮ������ֵ���ַ��������
    n = string.byte(s,3)
    print(n) => "49"   //***ʮ��������ֵת����ʮ������ֵ���ַ���
    //print()����Ĭ�����ʮ��������
}
#endregion

7.function����
#region
{ 
    *����������������//Lua������Ĭ�ϵķ���ֵʱnil
    function f(a,b)
        --body  //Lua���Ե�ע�ͷ���Ϊ"--",��������
    end         //function��Ϊ��ͷ��end��Ϊ��β�ز�����
����:
    f = function(a,b)
        --body
    end
   *���������ж������ֵ,�����βκ�ʵ�ο��Բ�ƥ��
   function Main(a,b,c)
        return a,b
    end
    print(Main(1,2))
    ������: 1  2
    �������ֵ������϶��ظ�ֵ���:
    local i,j = Main(1,2)

}
#endregion

8.table�����±�
#region
{ 
    //Lua�е�table�൱�����������е�����
    //table��Ϊ����С����ַ����±�����
    //table�п��Դ������Ԫ�����±��1��ʼ
    a = {1,"dsadad",{},function() end}
    a[5] = "123"
    //������table����λ�ò�������Ԫ��
    table.insert(a,2,"X")
    //�Ƴ�table��ĳһλ�õ�Ԫ�أ��Ὣ��Ԫ����Ϊ����ֵ����
    local c = table.move(a,1)
    print(c) => ���: 1
}
#endregion

9.table�ַ����±�
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
    //��ӡ��һ��Ԫ��
    print(a["a"]) ���� print(a.a)
    //��ӡ�������±��Ԫ��
    print(a[",;"])
    //�������±��tableһ�����ַ����±��table
    //Ҳ����������λ�ò���Ԫ��
    *������Ԫ�ص��±���table�в�����,��������Ĭ��ֵnil
}
#endregion

10.ȫ�ֱ�_G
#region
{ 
    //ȫ�ֱ�Ĭ�����ַ����±��table
    *���е�ȫ�ֱ�������ȫ�ֱ�_G����
    table.insert()
    print(_G["table"]["insert"])
}
#endregion

11.��ͼ�
#region
{ 
    print(1 > 2)
    print(1 < 2)
    print(1 >= 2)
    print(1 <= 2)
    print(1 == 2)
    //Lua�в�������"~="��ʾ
    print(1 ~= 2)

    a = true b = false
    //�߼���
    print(a and b)
    //�߼���
    print(a or b)
    //�߼���
    print(not a)
    *Lua������ֻ��false��nil�����߼��٣�����0�����߼���
    local c = 1
    //���� and �� or ʵ�ֶ�·��ֵ���൱��C�����е���Ŀ�����
    print(c > 10 and "Yes" or "No")
}
#endregion

12.��֧�ж����
#region
{ 
    //if �ж�����  then��ͷ end��β
    if 1>10 then     //����0������
        print("1>10")
    elseif 1<10      //else��if ������д�м䲻���пո�
        print("1<10")
    else 
        print("no")
    end
}
#endregion

13.ѭ��(Loop)
#region
{ 
    //����iĬ��Ϊ���ر�����10Ϊѭ���յ㣬2Ϊ����
    //����Ĭ����1������Ҳ�����Ǹ���
    //forѭ���ͷ�֧��ͬ�� do ��ͷ��if���� then ��ͷ
    for i = 1,10,2 do
        print(i)
        i = 5 //��ֵ��ѭ�������в������޸ģ��˴�Ϊ�½����ر�����:local i = 5
        if i == 6 then break end
    end

    local n = 10
    while n > 1 do
        print(n)
        n = n - 1 //Lua ������û�� "n++" �� "n += 1" �����﷨
        if n == 3 then break end
    end
}
#endregion












