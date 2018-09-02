using System.Collections.Generic;

namespace Algorithms.CTCI.Stacks_and_Queues
{
    public abstract class Animal
    {
        private int order;
        protected string name;

        protected Animal(string name)
        {
            this.name = name;
        }

        public void SetOrder(int order)
        {
            this.order = order;
        }

        public int GetOrder()
        {
            return order;
        }

        // compare orders of animal to return the older item
        public bool IsOlderThan(Animal a)
        {
            return this.order < a.GetOrder();
        }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }
    }

    public class AnimalShelter
    {
        LinkedList<Dog> dogs = new LinkedList<Dog>();
        LinkedList<Cat> cats = new LinkedList<Cat>();
        private int order = 0;

        public void Enqueue(Animal a)
        {
            // order is used as a sort of timestamp, so that we can compare the insertion order
            // of a dog or a cat
            a.SetOrder(order);
            order++;

            if (a is Dog) dogs.AddLast((Dog) a);
            else if (a is Cat) cats.AddLast((Cat) a);
        }

        public Animal DequeueAny()
        {
            // look at tops of dog and cat queues and pop the queue with the oldest value
            if (dogs.Count == 0)
            {
                return DequeueCats();
            }
            else if (cats.Count == 0)
            {
                return DequeueDogs();
            }

            Dog dog = dogs.First.Value;
            Cat cat = cats.First.Value;

            if (dog.IsOlderThan(cat))
            {
                return DequeueDogs();
            }
            else
            {
                return DequeueCats();
            }
        }

        public Dog DequeueDogs()
        {
            Dog first = dogs.First.Value;
            dogs.RemoveFirst();
            return first;
        }
        public Cat DequeueCats()
        {
            Cat first = cats.First.Value;
            cats.RemoveFirst();
            return first;
        }
    }
}
