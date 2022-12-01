public class Dec01 {
    public void Run() {
        var lines = File.ReadAllLines("./01/input");
        
        var elfs_food = new Dictionary<int, IList<int>>();
        elfs_food.Add(1, new List<int>());

        foreach (var line in lines){
            if (!string.IsNullOrEmpty(line.Trim())) {
                elfs_food.Values.Last().Add(Convert.ToInt32(line));
            }
            else {
                elfs_food.Add(elfs_food.Keys.Last() + 1, new List<int>());
            }
        }

        var elfs_food_sum = elfs_food.ToDictionary(k => k.Key, k => k.Value.Sum());
        var top_three_elves = elfs_food_sum.OrderByDescending(k => k.Value).Take(3);

        foreach (var top_elve in top_three_elves) {
            Console.WriteLine($"Elf {top_elve.Key}: {top_elve.Value}");
        }

        Console.WriteLine($"Top three sum: {top_three_elves.Select(k => k.Value).Sum()}");
    }
}
