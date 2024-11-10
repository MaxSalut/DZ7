using System;
using System.Collections;

namespace CompositeExample
{
    class MainApp
    {
        static void Main()
        {
            // Create a tree structure
            Component root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            // Create a composite structure
            Component comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));
            root.Add(comp);

            // Add additional leaves and composites
            root.Add(new Leaf("Leaf C"));

            // Create a group within the structure
            Component group = new Group("Group Y");
            group.Add(new Leaf("Leaf YA"));
            group.Add(new Leaf("Leaf YB"));
            comp.Add(group);

            // Add and remove a leaf
            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.Display(1);

            Console.ReadLine();
        }
    }

    // "Component" abstract class
    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    // "Composite" class
    class Composite : Component
    {
        private ArrayList children = new ArrayList();

        public Composite(string name) : base(name) { }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display child nodes
            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    // "Group" class that acts as a composite
    class Group : Component
    {
        private ArrayList members = new ArrayList();

        public Group(string name) : base(name) { }

        public override void Add(Component component)
        {
            members.Add(component);
        }

        public override void Remove(Component component)
        {
            members.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display group members
            foreach (Component member in members)
            {
                member.Display(depth + 2);
            }
        }
    }

    // "Leaf" class
    class Leaf : Component
    {
        public Leaf(string name) : base(name) { }

        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}
