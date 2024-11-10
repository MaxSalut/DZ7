using System;

namespace Decorator.Example
{
    class Program
    {
        static void Main()
        {
            // Create a basic Christmas tree
            ChristmasTree simpleTree = new BasicTree();

            // Add decorations (ornaments) and lights
            OrnamentDecorator ornamentDecorator = new OrnamentDecorator();
            LightDecorator lightDecorator = new LightDecorator();

            // Link decorators
            ornamentDecorator.SetTree(simpleTree);
            lightDecorator.SetTree(ornamentDecorator);

            // Perform the decorate operation to display the fully decorated tree
            lightDecorator.Decorate();

            Console.ReadLine();
        }
    }

    // Base class "ChristmasTree"
    abstract class ChristmasTree
    {
        public abstract void Decorate();
    }

    // Concrete implementation of a basic Christmas tree
    class BasicTree : ChristmasTree
    {
        public override void Decorate()
        {
            Console.WriteLine("Basic Christmas tree");
        }
    }

    // Abstract decorator for the Christmas tree
    abstract class TreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;

        public void SetTree(ChristmasTree tree)
        {
            this.tree = tree;
        }

        public override void Decorate()
        {
            if (tree != null)
            {
                tree.Decorate();
            }
        }
    }

    // Decorator for ornaments
    class OrnamentDecorator : TreeDecorator
    {
        public override void Decorate()
        {
            base.Decorate();
            AddOrnaments();
        }

        private void AddOrnaments()
        {
            Console.WriteLine("Added ornaments to the Christmas tree");
        }
    }

    // Decorator for lights
    class LightDecorator : TreeDecorator
    {
        public override void Decorate()
        {
            base.Decorate();
            AddLights();
        }

        private void AddLights()
        {
            Console.WriteLine("The Christmas tree is decorated with lights");
        }
    }
}
