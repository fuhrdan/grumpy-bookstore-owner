//*****************************************************************************
//**  1052. Grumpy Bookstore Owner leetcode                                  **
//**  I started going with a hashtable solution, but that did not work.  So  **
//**  I moved to a shifting window solution.  reading how others solved the  **
//**  problem really helped me figure out a better and faster solution.      **
//**  Apparently, not every leetcode problem is solved with a hashtable -Dan **
//*****************************************************************************

int maxSatisfied(int* customers, int customersSize, int* grumpy, int grumpySize, int minutes) {
    int sat = 0;
    int left = 0;
    int right = minutes;
    int temp = 0;
    for (int i = 0; i < grumpySize; i++)
    {
        if(grumpy[i] == 0)
        {
            sat = sat + customers[i];
        }
    }
    for (int i = 0; i < minutes; i++)
    {
        if(grumpy[i] == 1)
        {
            sat = sat + customers[i];
        }
    }
    temp = sat;
    while (right < customersSize)
    {
        if(grumpy[left] == 1)
        {
            temp = temp - customers[left];
        }
        if(grumpy[right] == 1)
        {
            temp = temp + customers[right];
        }
        left++;
        right++;
        sat = fmax(sat, temp);
    }
    return sat;
}