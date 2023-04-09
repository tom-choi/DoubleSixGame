public class EffectCharacter
{
    private int strength;
    private int defense;
    private int speed;

    public EffectCharacter(string name, int health, int strength, int defense, int speed) : base(name, health)
    {
        this.strength = strength;
        this.defense = defense;
        this.speed = speed;
    }
} 