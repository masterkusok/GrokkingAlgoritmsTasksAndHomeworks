namespace Breadth_First_Search
{
    class Program
    {

        private static bool IsMangoSeller(string name)
        {
            return name == "Johny" ? true : false;
        }

        private static bool BFSFindMangoSeller(Dictionary<string, object> friends)
        {
            Queue<KeyValuePair<string, object>> queue = new Queue<KeyValuePair<string, object>>();
            foreach(KeyValuePair<string, object> pair in friends)
            {
                queue.Enqueue(pair);
            }

            while(queue.Count > 0)
            {
                var person = queue.Dequeue();
                if (IsMangoSeller(person.Key))
                {
                    Console.WriteLine($"FOUND!!! - {person.Key} is actual mango seller!");
                    return true;
                }
                if(person.Value != null)
                {
                    foreach(KeyValuePair<string, object> pair in (Dictionary<string, object>)person.Value)
                    {
                        queue.Enqueue(pair);
                    }
                }
            }
            Console.WriteLine("I am so sorry, but you do not have any relationships with mango sellers :(");
            return false;
        }

        public static void Main()
        {

            Dictionary<string, object> friends = new Dictionary<string, object>();
            friends.Clear();
            // This is something like graph
            friends.Add("you", new Dictionary<string, object>()
            {
                {"Bob", new Dictionary<string, object>()
                    {
                        {"Anuj", null },
                        {"Peggy", null }
                    }
                },

                {"Alice", new Dictionary<string, object>()
                    {
                        {"GAYHORSE!", null }
                    }
                },

                {"Clare", new Dictionary<string, object>()
                    {
                        {"Tom", null },
                        {"Johny", null }
                    }
                }
            });

            BFSFindMangoSeller((Dictionary<string, object>)friends["you"] );
        }
    }
}