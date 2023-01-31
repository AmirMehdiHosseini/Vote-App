using System;

public class Vote
{
    public static void Candidates(string[,] candidate_names, int x)
    {
        for (int i = 0; i < x; i++)
        {
            Console.WriteLine("Please enter your candidate name: ");
            candidate_names[i, 0] = Console.ReadLine();
        }
    }


    public static void vote(string[,] voters_names, int x, string[,] candidates_names, int y, int[] void_votes)
    {
        for (int i = 0; i < x; i++)
        {
            Console.WriteLine("Please enter your voter name: ");
            voters_names[i, 0] = Console.ReadLine();
            for (int j = 0; j < i; j++)
            {
                while (voters_names[i, 0] == voters_names[j, 0])
                {
                    Console.WriteLine($"you have entered the name {voters_names[i, 0]} twice. ");
                    voters_names[i, 0] = Console.ReadLine();
                }
            }
            Console.WriteLine($"{voters_names[i, 0]}, whom do you wanna vote? ");
            voters_names[i,1] = Console.ReadLine();
            bool check = false;
            for (int k = 0; k < y; k++)
            {
                if (voters_names[i,1] == candidates_names[k,0])
                {
                    candidates_names[k, 1] = Convert.ToString(Convert.ToInt32(candidates_names[k, 1]) + 1);
                    check = true;
                    break;
                }
                
            }
            if (!check)
            {
                void_votes[0]++;
                voters_names[i, 1] = "void vote";
            }
        }
    }

    public static void show_ary(string[,] ary, int x)
    {
        for (int i = 0; i < x;i++ )
        {
            Console.WriteLine(ary[i, 0] + '\t' + ary[i, 1]);
        }
    }

    public static void winner(string[,] candidates, int x)
    {
        string[,] win = new string[1,2];
        for (int i = 0; i < x; i++)
        {
            if (Convert.ToInt32(candidates[i,1]) > Convert.ToInt32(win[0,1]))
            {
                win[0, 1] = candidates[i, 1];
                win[0, 0] = candidates[i, 0];
            }
        }
        Console.WriteLine($"The winner: {win[0, 0]}, Number of votes: {win[0, 1]}");
    }


    public static void Main()
    {
        string[,] candidate_names = new string[5, 2];
        string[,] voters_names = new string[30, 2];
        int[] void_votes = {0};
        Console.WriteLine("Please enter how many candidates do you have: ");
        int number_of_candidates = Convert.ToInt32(Console.ReadLine());
        while (number_of_candidates > 5)
        {
            Console.WriteLine("Please enter a number lower than 6: ");
            number_of_candidates = Convert.ToInt32(Console.ReadLine());
        }
        Candidates(candidate_names, number_of_candidates);



        Console.WriteLine("Please enter how many voters do you have: ");
        int number_of_voters = Convert.ToInt32(Console.ReadLine());
        while (number_of_voters > 30)
        {
            Console.WriteLine("Please enter a number lower than 31: ");
            number_of_voters = Convert.ToInt32(Console.ReadLine());
        }
        vote(voters_names, number_of_voters, candidate_names, number_of_candidates, void_votes);
        show_ary(voters_names, number_of_voters);
        show_ary(candidate_names, number_of_candidates);
        Console.WriteLine("void votes\t" + void_votes[0]);
        winner(candidate_names, number_of_candidates);

    }
}