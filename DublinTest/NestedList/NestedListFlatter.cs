using System.Collections.Generic;
using System.Text;

namespace DublinTest.NestedList
{
    class NestedListFlatter
    {
        public List<int> FlattenRecursive(List<object> list)
        {
            var result = new List<int>();
            foreach (var item in list)
            {
                if (!(item is int))
                    result.AddRange(FlattenRecursive((List<object>) item));
                else result.Add((int)item);
            }
            return result;
        }
        
        public List<int> FlattenIterative(List<object> list)
        {
            var objectStack = new Stack<object>();
            var result = new List<int>();

            list.Reverse();
            foreach (var o in list) objectStack.Push(o);

            while (objectStack.Count > 0)
            {
                var obj = objectStack.Pop();
                if (!(obj is int))
                {
                    var innerList = (List<object>) obj;
                    if (innerList.Count > 0)
                    {
                        innerList.Reverse();
                        foreach (var item in innerList)
                            objectStack.Push(item);
                    }
                }
                else result.Add((int)obj);
            }
            return result;
        }

        public string NestedListToString(List<object> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            foreach (var item in list)
            {
                if (!(item is int))
                {
                    sb.Append(NestedListToString((List<object>) item));
                }
                else
                {
                    int k = sb.Length;
                    if (k >= 1 && sb[k - 1] != ' ') sb.Append(" ");
                    sb.Append(item);
                }
            }
            sb.Append(" ]");
            return sb.ToString();
        }
    }
}
