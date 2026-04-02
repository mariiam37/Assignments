//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assignments
//{
//    public class ADV1
//    {
//    /*
//        Q1. generic class : class that works with different data types using a placeholder like T
//            we use generics to reuse code avoid duplication and get type safety instead of using object
//    */
//        //Q2.
//        public class Container<T>
//        {
//            private T item;

//            public void Add(T value)
//            {
//                item = value;
//            }

//            public T Get()
//            {
//                return item;
//            }
//        }

//    /*
//        Q3. multiple type parameters : a class can use more than one generic type
//    */
//        public class Pair<TKey, TValue>
//        {
//            public TKey Key { get; set; }
//            public TValue Value { get; set; }

//            public Pair(TKey key, TValue value)
//            {
//                Key = key;
//                Value = value;
//            }
//        }

//    /*
//        Q4. generic method works with any type without being tied to a class type
//    */
//        public static void Swap<T>(ref T a, ref T b)
//        {
//            T temp = a;
//            a = b;
//            b = temp;
//        }

//        //Q5.
//        public static T FindMax<T>(T a, T b) where T : IComparable<T>
//        {
//            if (a.CompareTo(b) > 0)
//                return a;
//            else
//                return b;
//        }

//        //Q6. 
//        public interface IRepository<T>
//        {
//            void Add(T item);
//            T Get(int id);
//            void Remove(int id);
//        }

//        //Q7. struct constraint :it means T must be a value type
//        public class ValueContainer<T> where T : struct
//        {
//            public T Value;
//        }

//        //Q8. class constraint : it means T must be a reference type

//        public class RefContainer<T> where T : class
//        {
//            public T Value;
//        }

//        //Q9. new() constraint : it means T must have a parameterless constructor
//        public class Creator<T> where T : new()
//        {
//            public T Create()
//            {
//                return new T();
//            }
//        }

//        //Q10. interface constraint : it means T must implement a specific interface
//        public class ComparableContainer<T> where T : IComparable<T>
//        {
//            public T Max(T a, T b)
//            {
//                return a.CompareTo(b) > 0 ? a : b;
//            }
//        }

//        //Q11. base class constraint : it means T must inherit from a specific class
//        public class Animal { }
//        public class Dog : Animal { }

//        public class AnimalContainer<T> where T : Animal
//        {
//            public T Pet;
//        }

//        //Q12. multiple constraints : you can combine more than one constraint
//        public class Complex<T> where T : class, IComparable<T>, new()
//        {
//            public T CreateAndCompare(T other)
//            {
//                T obj = new T();
//                return obj.CompareTo(other) > 0 ? obj : other;
//            }
//        }

//     /*
//          Q13. default returns the default value of a type
//               for int it is 0 for bool false for reference types null
//     */

//        //Q14.
//        public class SafeList<T>
//        {
//            private List<T> list = new List<T>();

//            public void Add(T item)
//            {
//                list.Add(item);
//            }

//            public T Get(int index)
//            {
//                if (index < 0 || index >= list.Count)
//                    return default(T);
//                return list[index];
//            }
//        }
//    /*
//        Q15. covariance allows using a more derived type 
//             out means the type is only used for output
//    */
//        public interface IProducer<out T>
//        {
//            T Get();
//        }

//    /*
//        Q16. contravariance allows using a less derived type
//             in means the type is only used for input
//    */
//        public interface IConsumer<in T>
//        {
//            void Set(T item);
//        }

//    /*    
//        Q17. covariance is for returning values out keyword
//             contravariance is for accepting values in keyword

//        Q18. each generic type has its own static members
//             Container<int> and Container<string> each have separate static values

//        Q19. you can inherit by specifying the type
//    */
//        public class IntContainer : Container<int>
//        {
//        }
//      //  or keep it generic
//        public class MyContainer<T> : Container<T>
//        {
//        }

//        //Q20.
//        public class Cache<TKey, TValue>
//        {
//            private Dictionary<TKey, (TValue value, DateTime expiry)> data 
//                = new Dictionary<TKey, (TValue, DateTime)>();

//            public void Add(TKey key, TValue value, int seconds)
//            {
//                data[key] = (value, DateTime.Now.AddSeconds(seconds));
//            }

//            public TValue Get(TKey key)
//            {
//                if (data.ContainsKey(key))
//                {
//                    var item = data[key];
//                    if (DateTime.Now <= item.expiry)
//                        return item.value;
//                    else
//                        data.Remove(key);
//                }
//                return default(TValue);
//            }
//            public void Remove(TKey key)
//            {
//                data.Remove(key);
//            }

//            public bool Contains(TKey key)
//            {
//                return data.ContainsKey(key);
//            }
//        }
//    }
//}
