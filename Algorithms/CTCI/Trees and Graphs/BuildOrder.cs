using System.Collections.Generic;

namespace Algorithms.CTCI.Trees_and_Graphs
{
    public static class BuildOrder
    {
        // solution #1
        public static Project[] FindBuildOrder(string[] projects, string[][] dependencies)
        {
            GraphBuild graph = BuildGraph(projects, dependencies);
            return OrderProjects(graph.GetNodes());
        }

        // build th egraph, adding the edge (a, b) if b is dependent on a.
        // assume a pair is listed on builder.
        private static GraphBuild BuildGraph(string[] projects, string[][] dependencies)
        {
            GraphBuild graph = new GraphBuild();
            foreach (var project in projects)
            {
                graph.GetOrCreateNode(project);
            }

            foreach (string[] dependency in dependencies)
            {
                string first = dependency[0];
                string second = dependency[1];
                graph.AddEdge(first, second);
            }

            return graph;
        }

        // return a list of the projects a correct build order
        private static Project[] OrderProjects(List<Project> projects)
        {
            Project[] order = new Project[projects.Count];

            // add "roots" to the build order first
            int endOfList = AddNonDependents(order, projects, 0);

            int toBeProcessed = 0;
            while (toBeProcessed < order.Length)
            {
                Project current = order[toBeProcessed];

                // we have a circular dependency
                if (current == null)
                {
                    return null;
                }

                // remove myself as dependency
                List<Project> children = current.GetChildren();
                foreach (var child in children)
                {
                    child.DecrementDependencies();
                }

                // add children that have no one depending on them
                endOfList = AddNonDependents(order, children, endOfList);
                toBeProcessed++;
            }

            return order;
        }

        private static int AddNonDependents(Project[] order, List<Project> projects, int offset)
        {
            foreach (var project in projects)
            {
                if (project.GetNumberDependencies() == 0)
                {
                    order[offset] = project;
                    offset++;
                }
            }

            return offset;
        }


        // solution #2 : build DPS
        public static Stack<ProjectDfs> FindBuildOrderDfs(string[] projects, string[][] dependencies)
        {
            GraphDfs graph = BuildGraphDfs(projects, dependencies);
            return OrderProjectsDfs(graph.GetNodes());
        }
        private static GraphDfs BuildGraphDfs(string[] projects, string[][] dependencies)
        {
            GraphDfs graph = new GraphDfs();
            foreach (var project in projects)
            {
                graph.GetOrCreateNode(project);
            }

            foreach (string[] dependency in dependencies)
            {
                string first = dependency[0];
                string second = dependency[1];
                graph.AddEdge(first, second);
            }

            return graph;
        }

        private static Stack<ProjectDfs> OrderProjectsDfs(List<ProjectDfs> projects)
        {
            Stack<ProjectDfs> stack = new Stack<ProjectDfs>();
            foreach (var project in projects)
            {
                if (project.GetState() == ProjectDfs.State.BLANK)
                {
                    if (!DoDfs(project, stack))
                    {
                        return null;
                    }
                }
            }

            return stack;
        }

        private static bool DoDfs(ProjectDfs project, Stack<ProjectDfs> stack)
        {
            if (project.GetState() == ProjectDfs.State.PARTIAL)
            {
                return false; // cycle
            }

            if (project.GetState() == ProjectDfs.State.BLANK)
            {
                project.SetState(ProjectDfs.State.PARTIAL);
                List<ProjectDfs> children = project.GetChildren();
                foreach (var child in children)
                {
                    if (!DoDfs(child, stack))
                    {
                        return false;
                    }
                }
                project.SetState(ProjectDfs.State.COMPLETE);
                stack.Push(project);
            }

            return true;
        }
    }

    public class GraphDfs
    {
        private List<ProjectDfs> nodes = new List<ProjectDfs>();
        private Dictionary<string, ProjectDfs> map = new Dictionary<string, ProjectDfs>();

        public ProjectDfs GetOrCreateNode(string name)
        {
            if (!map.ContainsKey(name))
            {
                ProjectDfs node = new ProjectDfs(name);
                nodes.Add(node);
                map.Add(name, node);
            }

            return map[name];
        }

        public void AddEdge(string startName, string endName)
        {
            ProjectDfs start = GetOrCreateNode(startName);
            ProjectDfs end = GetOrCreateNode(endName);
            start.AddNeighbor(end);
        }

        public List<ProjectDfs> GetNodes()
        {
            return nodes;
        }
    }

    public class GraphBuild
    {
        private List<Project> nodes = new List<Project>();
        private Dictionary<string, Project> map = new Dictionary<string, Project>();

        public Project GetOrCreateNode(string name)
        {
            if (!map.ContainsKey(name))
            {
                Project node = new Project(name);
                nodes.Add(node);
                map.Add(name, node);
            }

            return map[name];
        }

        public void AddEdge(string startName, string endName)
        {
            Project start = GetOrCreateNode(startName);
            Project end = GetOrCreateNode(endName);
            start.AddNeighbor(end);
        }

        public List<Project> GetNodes()
        {
            return nodes;
        }
    }

    public class Project
    {
        private List<Project> children = new List<Project>();
        private Dictionary<string, Project> map = new Dictionary<string, Project>();
        private readonly string name;
        private int dependencies = 0;

        public Project(string n)
        {
            name = n;
        }

        public void AddNeighbor(Project node)
        {
            if (!map.ContainsKey(node.GetName()))
            {
                children.Add(node);
                map.Add(node.GetName(), node);
                node.IncrementDependencies();
            }
        }

        public void IncrementDependencies()
        {
            dependencies++;
        }

        public void DecrementDependencies()
        {
            dependencies--;
        }

        public string GetName()
        {
            return name;
        }

        public List<Project> GetChildren()
        {
            return children;
        }

        public int GetNumberDependencies()
        {
            return dependencies;
        }
    }

    public class ProjectDfs
    {
        public enum State { COMPLETE, PARTIAL, BLANK }

        private State state = State.BLANK;
        private List<ProjectDfs> children = new List<ProjectDfs>();
        private Dictionary<string, ProjectDfs> map = new Dictionary<string, ProjectDfs>();
        private readonly string name;
        private int dependencies = 0;

        public ProjectDfs(string n)
        {
            name = n;
        }

        public void AddNeighbor(ProjectDfs node)
        {
            if (!map.ContainsKey(node.GetName()))
            {
                children.Add(node);
                map.Add(node.GetName(), node);
                node.IncrementDependencies();
            }
        }

        public State GetState()
        {
            return state;
        }

        public void SetState(State st)
        {
            state = st;
        }

        public void IncrementDependencies()
        {
            dependencies++;
        }

        public void DecrementDependencies()
        {
            dependencies--;
        }

        public string GetName()
        {
            return name;
        }

        public List<ProjectDfs> GetChildren()
        {
            return children;
        }

        public int GetNumberDependencies()
        {
            return dependencies;
        }
    }
}
