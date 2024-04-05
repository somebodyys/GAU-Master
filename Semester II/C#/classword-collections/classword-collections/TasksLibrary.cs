namespace classword_collections;

public class TasksLibrary
{
    public static void TaskOne()
    {
        List<string> dynamicArray = new List<string>();
    
        dynamicArray.Add("Hello");
        dynamicArray.Add("World");

        Console.WriteLine("Length: " + dynamicArray.Count);
        Console.WriteLine("Array:");
        foreach (string str in dynamicArray)
        {
            Console.WriteLine(str);
        }
    }

    public static void TaskTwo()
    {
        List<string> dynamicList = new List<string>();
        
        for (int i = 0; i < 10; i++)
        {
            dynamicList.Add("String" + (i + 1));
        }

        dynamicList.RemoveAt(0);
        dynamicList.RemoveAt(3);
        dynamicList.RemoveAt(6);

        Console.WriteLine("Length: " + dynamicList.Count);
        Console.WriteLine("Array:");
        foreach (string str in dynamicList)
        {
            Console.WriteLine(str);
        }
    } 
    
    public static void TaskThree()
    {
        List<string> dynamicList = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            dynamicList.Add("String" + (i + 1));
        }

        dynamicList.Insert(2, "NewString1");
        dynamicList.Insert(3, "NewString2");

        Console.WriteLine("Length: " + dynamicList.Count);
        Console.WriteLine("Array:");
        foreach (string str in dynamicList)
        {
            Console.WriteLine(str);
        }
    } 
    
    public static void TaskFour()
    {
        List<string> dynamicList = new List<string>
        {
            "John",
            "Alice",
            "Bob",
            "Eva",
            "David",
            "Emily",
            "Chris",
            "Sophia",
            "Michael",
            "Sarah"
        };
        
        string searchName = "Bob";
        int foundIndex = dynamicList.IndexOf(searchName);
        
        if (foundIndex != -1)
        {
            Console.WriteLine($"Index of {searchName}: {foundIndex}");
        }
        else
        {
            Console.WriteLine($"{searchName} not found in the list.");
        }
        
        Console.WriteLine("Length: " + dynamicList.Count);
        Console.WriteLine("Array:");
        foreach (string str in dynamicList)
        {
            Console.WriteLine(str);
        }
    }
    
    public static void TaskFive()
    {
        Dictionary<int, string> hashMap = new Dictionary<int, string>();

        for (int i = 0; i < 10; i++)
        {
            hashMap.Add(i, "Value" + (i + 1));
        }

        hashMap.Add(10, "NewValue1");
        hashMap.Add(11, "NewValue2");
        
        Console.WriteLine("Length: " + hashMap.Count);
        Console.WriteLine("Key-Value pairs:");
        foreach (KeyValuePair<int, string> kvp in hashMap)
        {
            Console.WriteLine("Key: " + kvp.Key + ", Value: " + kvp.Value);
        }
    }
    
    public static void TaskSix()
    {
        Dictionary<int, string> hashMap = new Dictionary<int, string>();
        
        for (int i = 0; i < 10; i++)
        {
            hashMap.Add(i, "Value" + (i + 1));
        }

        hashMap.Remove(2);
        hashMap.Remove(5);

        Console.WriteLine("Length: " + hashMap.Count);
        Console.WriteLine("Key-Value pairs:");
        foreach (KeyValuePair<int, string> kvp in hashMap)
        {
            Console.WriteLine("Key: " + kvp.Key + ", Value: " + kvp.Value);
        }
    }
    
    public static void TaskSeven()
    {
        Dictionary<int, string> hashMap = new Dictionary<int, string>();

        for (int i = 0; i < 10; i++)
        {
            hashMap.Add(i, "Value" + (i + 1));
        }

        int searchKey = 3;
        string searchValue = "Value4";

        if (hashMap.ContainsKey(searchKey))
        {
            Console.WriteLine($"Found Key: {searchKey}, Value: {hashMap[searchKey]}");
        }
        else
        {
            Console.WriteLine($"Key {searchKey} not found.");
        }

        bool foundValue = false;
        foreach (KeyValuePair<int, string> kvp in hashMap)
        {
            if (kvp.Value == searchValue)
            {
                Console.WriteLine($"Found Key: {kvp.Key}, Value: {kvp.Value}");
                foundValue = true;
                break;
            }
        }
        if (!foundValue)
        {
            Console.WriteLine($"Value {searchValue} not found.");
        }

        Console.WriteLine("Length: " + hashMap.Count);
        Console.WriteLine("Key-Value pairs:");
        foreach (KeyValuePair<int, string> kvp in hashMap)
        {
            Console.WriteLine("Key: " + kvp.Key + ", Value: " + kvp.Value);
        }
    }
    
    public static void TaskEight()
    {
        Queue<string> queue = new Queue<string>();

        for (int i = 0; i < 10; i++)
        {
            queue.Enqueue("Element" + (i + 1));
        }

        string peekedElement = queue.Peek();
        Console.WriteLine("Peeked Element: " + peekedElement);
        Console.WriteLine("Length: " + queue.Count);
        Console.WriteLine("Queue elements:");
        foreach (string element in queue)
        {
            Console.WriteLine(element);
        }
        
        queue.Clear();
    }
    
    public static void TaskNine()
    {
        Stack<string> stack = new Stack<string>();
        
        for (int i = 0; i < 10; i++)
        {
            stack.Push("Element" + (i + 1));
        }
        
        string peekedElement = stack.Peek();
        Console.WriteLine("Peeked Element: " + peekedElement);
        
        Console.WriteLine("Length: " + stack.Count);
        
        Console.WriteLine("Stack elements:");
        foreach (string element in stack)
        {
            Console.WriteLine(element);
        }

        stack.Clear();
    }
    
}