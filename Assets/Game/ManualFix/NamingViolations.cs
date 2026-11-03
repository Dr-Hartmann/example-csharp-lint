namespace RoslynRulesTest.Assets.Game.ManualFix;

// IDE1006: dotnet format не переименовывает символы по naming rules.
public interface drawable
{
    void draw_item();
}

public enum state
{
    idle,
    running,
}

public class player_data : drawable
{
    public int Health;
    protected int Score;
    private int health;
    internal int score;

    public string player_name { get; set; } = "guest";
    public event EventHandler? changed;

    public void update_player(int player_id)
    {
        this.health = player_id;
        this.player_name = "player";
    }

    private void reset_player()
    {
        health = 0;
    }

    private static void calculate_score()
    {
    }

    public void draw_item()
    {
    }
}
