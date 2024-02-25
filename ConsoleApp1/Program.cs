using System.Reflection;

enum MobState
{
    Friendly,
    Netural,
    Aggressive
}
class Mob
{
    protected string name;
    private int HP { get; set; }
    private float mana;
    protected int damage;
    public MobState state;
    public double speed;

    public Mob(string name, int hp, float mana, int damage, double speed, MobState state)
    {
        this.name = name;
        this.HP = hp;
        this.mana = mana;
        this.damage = damage;
        this.speed = speed;
        this.state = state;
    }

    public void usePotion(double newSpeed)
    {
        speed = newSpeed;
        Console.WriteLine($"The mob used the potion of speed. Speed: {newSpeed}");
    }

    public void usePotion(int restoreHP)
    {
        HP += restoreHP;
        Console.WriteLine($"The mob used the potion of health. Health: {HP}");
    }

    public void DecreaseHP(int amount)
    {
        HP -= amount;
        Console.WriteLine($"Hit by {amount}. Hp is: {HP}");
    }
    public override string ToString()
    {
        return $"{name}\n\t-- Health: {HP} --\n";
    }
}
class Program
{

    static void Main()
    {
        Mob slime = new Mob("Slime", 50, 0, 5, 5, MobState.Aggressive);
        Mob ent = new Mob("Ent, Protector of the Forest", 200, 50, 60, 10, MobState.Netural);

        Type slimeType = slime.GetType();
        Console.WriteLine(slimeType);

        TypeInfo entTypeInfo = ent.GetType().GetTypeInfo();
        Console.WriteLine("\n"+entTypeInfo.Name);
        Console.WriteLine(entTypeInfo.IsClass);


        MemberInfo[] members = typeof(Mob).GetMembers();
        foreach (MemberInfo member in members)
        {
            Console.WriteLine(member.Name);
        }
        Console.WriteLine("\n");
        FieldInfo[] fields = typeof(Mob).GetFields();
        foreach (FieldInfo field in fields)
        {
            Console.WriteLine(field.Name);
        }


        MethodInfo decreaseMethodHPMethod = typeof(Mob).GetMethod("DecreaseHP");
        object[] parameters = { 10 };
        Console.WriteLine(ent);
        decreaseMethodHPMethod.Invoke(ent, parameters);

    }
}