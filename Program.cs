using System.Text;

static int[] BubbleSort(int[] array)
{
    int tempValue;
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j < array.Length - 1; j++)
        {
            if (array[j] > array[j + 1])
            {
                tempValue = array[j];
                array[j] = array[j + 1];
                array[j + 1] = tempValue;
            }
        }
    }
    return array;
}

static int[] MergeSort(int[] array)
{
    if (array.Length <= 1)
    {
        return array;
    }

    int middle = array.Length / 2;
    int[] left = new int[middle];
    int[] right = new int[array.Length - middle];

    for (int i = 0; i < middle; i++)
    {
        left[i] = array[i];
    }

    for (int i = middle; i < array.Length; i++)
    {
        right[i - middle] = array[i];
    }

    left = MergeSort(left);
    right = MergeSort(right);

    return Merge(left, right);
}

static int[] Merge(int[] left, int[] right)
{
    int[] result = new int[left.Length + right.Length];
    int leftIndex = 0;
    int rightIndex = 0;
    int resultIndex = 0;

    while (leftIndex < left.Length || rightIndex < right.Length)
    {
        if (leftIndex < left.Length && rightIndex < right.Length)
        {
            if (left[leftIndex] <= right[rightIndex])
            {
                result[resultIndex] = left[leftIndex];
                resultIndex++;
                leftIndex++;
            }
            else
            {
                result[resultIndex] = right[rightIndex];
                resultIndex++;
                rightIndex++;
            }
        }
        else if (leftIndex < left.Length)
        {
            result[resultIndex] = left[leftIndex];
            resultIndex++;
            leftIndex++;
        }
        else if (rightIndex < right.Length)
        {
            result[resultIndex] = right[rightIndex];
            resultIndex++;
            rightIndex++;
        }
    }
    return result;
}

string filePath;
StreamReader sr;
List<int> list = new List<int>();

if (args.Length == 0)
{
    Console.Write("Enter your file path: ");
    filePath = Console.ReadLine();
    sr = new StreamReader(filePath);
}
else { sr = new StreamReader(args[0]); }

while (!sr.EndOfStream)
{
    int[] splitValues = sr.ReadLine().Split(',').Select(int.Parse).ToArray();
    foreach (int value in splitValues)
    {
        list.Add(value);
    }
}
int[] array = list.ToArray();


int[] mergeSortedArray = MergeSort(array);

int[] bubbleSortedArray = BubbleSort(array);


// This is used to see if the sort methods work not used when profiling performance.
/*    StringBuilder sb = new StringBuilder();
    foreach (int value in mergeSortedArray)
    {
        sb.Append(value + ",");
    }
    System.Console.WriteLine(sb.ToString().TrimEnd(','));*/
