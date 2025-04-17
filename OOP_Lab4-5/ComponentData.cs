using System.Collections.Generic;

namespace OOP_Lab4_5
{
    public class ComponentData
    {
        public List<Component> CPUs { get; set; } = new();
        public List<Component> GPUs { get; set; } = new();
        public List<Component> RAMs { get; set; } = new();
        public List<Component> Motherboards { get; set; } = new();
        public List<Component> PSUs { get; set; } = new();
        public List<Component> Storages { get; set; } = new();
        public List<Component> Coolers { get; set; } = new();
        public List<Component> Cases { get; set; } = new();
    }

    public class Component
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public List<string> Specifications { get; set; } = new();
        public string Category { get; set; }

        public static implicit operator Component(string v)
        {
            throw new NotImplementedException();
        }
    }
}