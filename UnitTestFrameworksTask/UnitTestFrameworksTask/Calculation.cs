namespace UnitTestFrameworksTask
{
    public sealed class Calculation
    {
        public string countInThatString { get; set; }

        public int CountMaximumDifferrentSymbols(string countThatString)
        {
            int count = 1; // count start with 1 because the string starts with any symbol
            int newCount = 0;

            for (int i = 1; i < countThatString.Length; i++)
            {
                //for whole string
                if (countThatString[i - 1] != countThatString[i])
                {
                    //If previous symbol differ from next 
                    count++;
                }
                else
                {
                    if (newCount < count)
                    {
                        // if next sequens of differ symbols more long than previous
                        newCount = count;
                        count = 1;
                    }
                    // else do nothing                    
                }
            }

            // return counted number
            if (newCount > count)
            {
                // if previous sequens of differ symbols more long than next
                return newCount;
            }
            else
            {
                return count;
            }
        }

        public int CountMaximumDifferentLetter(string countThatString)
        {
            int count = 0;
            int newCount = 0;

            if (char.IsLetter(countThatString[0]))
            {
                // if start symbol is letter increase count 
                count = 1;
            }

            for (int i = 1; i < countThatString.Length; i++) // (i-1) - index of checking symbol
            {
                if (char.IsLetter(countThatString[i - 1]) & char.IsLetter(countThatString[i])
                    & (countThatString[i - 1] != countThatString[i]))
                {
                    // if checking and next symbols are letter and differ between each other
                    count++;
                }
                else if (char.IsNumber(countThatString[i - 1]) & (char.IsNumber(countThatString[i])))
                {
                    // if checking and next symbol are numbers do nothing
                }
                else if (char.IsNumber(countThatString[i - 1]) & char.IsLetter(countThatString[i]))
                {
                    // if previous symbol is number and next symbol is letter start new count 
                    // save number of different letter sequence
                    if (count > newCount)
                    {
                        // if current sequence is longer than previuos
                        newCount = count;
                        count = 1;
                    }
                    else
                    {
                        count = 1;
                    }
                }
                else if (char.IsLetter(countThatString[i - 1]) & char.IsLetter(countThatString[i])
                    & (countThatString[i - 1] == countThatString[i]))
                {
                    // if checked and next symbols are letters and equal
                    if (count > newCount)
                    {
                        // if previuos sequence is longer than previous
                        newCount = count;
                        count = 1;
                    }
                    else
                    {
                        count = 1;
                    }
                }
            }

            // return counted number
            if (count > newCount)
            {
                return count;
            }
            else
            {
                return newCount;
            }
        }

        public int CountMaximumDifferentNumbers(string countThatString)
        {
            int count = 0;
            int newCount = 0;

            if (char.IsNumber(countThatString[0]))
            {
                // if start symbol is number increase count 
                count = 1;
            }

            for (int i = 1; i < countThatString.Length; i++)
            {
                if (char.IsNumber(countThatString[i - 1]) & char.IsNumber(countThatString[i])
                    & (countThatString[i - 1] != countThatString[i]))
                {
                    // If checking and next symbols are numbers and differ between each other
                    count++;
                }
                else if (char.IsLetter(countThatString[i - 1]) & char.IsLetter(countThatString[i]))
                {
                    // if checking and next symbol are numbers do nothing
                }
                else if (char.IsLetter(countThatString[i - 1]) & char.IsNumber(countThatString[i]))
                {
                    // if previous symbol is letter and next symbol is number start new count 
                    // save number of different number sequence
                    if (count > newCount)
                    {
                        // if current sequence is longer than previuos
                        newCount = count;
                        count = 1;
                    }
                    else
                    {
                        // start new count
                        count = 1;
                    }
                }
                else if (char.IsNumber(countThatString[i - 1]) & char.IsNumber(countThatString[i])
                    & (countThatString[i - 1] == countThatString[i]))
                {
                    // If checked and next symbols are numbers and equal
                    if (count > newCount)
                    {
                        // if previuos sequence is longer than previous
                        newCount = count;
                        count = 1;
                    }
                    else
                    {
                        // start new count
                        count = 1;
                    }
                }
            }

            // return counted number
            if (count > newCount)
            {
                return count;
            }
            else
            {
                return newCount;
            }
        }
    }
}
