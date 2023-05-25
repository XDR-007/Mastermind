using System;
using System.Text;

class Mastermind
{
    static public void Main(String[] args)
    {
        char play_again = 'y';
        do
        {

            int contains = 0;
            int pluses = 0;
            int minuses = 0;
            int sum = 0;


            int[] random_num_array = new int[4];

            Random rnd = new Random();

            bool test = false; //set to false for productioon


            int d1 = rnd.Next(1, 7);   // creates a number between 1 and 6
            int d2 = rnd.Next(1, 7);
            int d3 = rnd.Next(1, 7);
            int d4 = rnd.Next(1, 7);

            random_num_array[0] = d1;
            random_num_array[1] = d2;
            random_num_array[2] = d3;
            random_num_array[3] = d4;

            int[] test_array = new int[4];

            if (test)
            {

                test_array[0] = 1;
                test_array[1] = 2;
                test_array[2] = 3;
                test_array[3] = 1;

            }

            //for testing only

            bool debug = false; //set too fals for production

            string str_code = string.Join("", random_num_array); //change to random_num_array for final product

            if (debug)
            {
                str_code = string.Join("", test_array); //change to random_num_array for final product
            }

            // str_code = "3232"; //delete for final product

            int i = 0;

            Char[] letters = {};

            int sum_input = 0;
            
            int digit = 0;
            StringBuilder score_SB = new StringBuilder("");
            while (i < 12) //change to 12
            {
                string input;
                Console.WriteLine("\nEnter four digit integer: ");
                input = Console.ReadLine();

                char valid_input = 'n';

                while (valid_input == 'n')
                {

                    if (input.Length == 4 && int.TryParse(input, out int res))
                    {
                        letters = input.ToCharArray();
                        sum_input = 0;
                        for(int q = 0; q < 4; q++){
                            digit = int.Parse(letters[q].ToString());
                            
                                
                            
                            if ((1 <= digit) && (digit <= 6)){
                               sum_input++;

                            }
                        }
                        if(sum_input == 4){
                            Console.Write("Input valid. Assessing... \n");
                               valid_input = 'y';
                        }else {
                           Console.Write("Input invalid. Please try again. \n");
                        valid_input = 'n';
                        Console.WriteLine("\nEnter four digit integer: ");
                        input = Console.ReadLine();
                        }
                    }
                    else
                    {

                        Console.Write("Input invalid. Please try again. \n");
                        valid_input = 'n';
                        Console.WriteLine("\nEnter four digit integer: ");
                        input = Console.ReadLine();

                    }

                }

                contains = 0;
                pluses = 0;
                minuses = 0;
                sum = 0;

                for (int k = 0; k < 4; k++)
                {

                    String input_char = input[k].ToString();
                    //int rnd_num = random_num_array[k];
                    //String rnd_num_as_int = (rnd_num.ToString());
                    String str_code_ch = (str_code[k].ToString());

                    score_SB.Clear();

                    if (input_char.Equals(str_code_ch))
                    {

                        pluses++;
                        if (debug)
                            Console.Write("\n pluses: " + pluses + "\n");
                        //score_SB.Append("+");

                    }
                    else if (random_num_array.Contains(int.Parse(input_char))) // change to this condition for final product random_num_array.Contains(int.Parse(input_char))
                    {

                        // Console.Write(int.Parse(input_char));
                        //score_SB.Append("-");

                        contains++;
                        if (debug)
                            Console.Write("\n contains: " + contains + "\n");

                    }

                    if (pluses <= contains)
                    {
                        sum += pluses;
                    }
                    else if (contains < pluses)
                    {
                        sum += contains;
                    }

                }

                minuses = sum - pluses;


                //Console.Write(pluses + " " + minuses);

                for (int z = 0; z < pluses; z++)
                {
                    score_SB.Append("+");

                }

                for (int v = 0; v < minuses; v++)
                {
                    score_SB.Append("-");
                }


                // Console.Write(anser);

                Console.Write("Your score: " + score_SB);
                if (debug)
                {
                    Console.Write(pluses);
                    Console.Write(minuses);
                    Console.Write(contains);

                }


                if (str_code.Equals(input))
                { //change back to 3

                    Console.Write("\nYou solved it!");
                    Console.Write(" The answer was: " + str_code);
                    i = 100;
                }
                else if ((i == 11) && !str_code.Equals(input))
                { //change back to 3
                    Console.Write("\nYou lose :(");
                    Console.Write(" The answer was: " + str_code);
                }

                i++;

            }

            Console.Write("\n Thanks for playing! Play again? (y/n)");
            string play_again_string = "";
            play_again_string = Console.ReadLine();
            play_again = char.Parse(play_again_string);
        } while (play_again == 'y');
    }

}
